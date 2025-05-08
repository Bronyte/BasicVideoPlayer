using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TestVideoPlayer
{
    public partial class Form1 : Form
    {

        int nextIndex = 0;
        bool playNextWithDelay = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Filter for video files
                    string[] supportedExtensions = { ".mp4", ".avi", ".mkv", ".wmv", ".mpg", ".mpeg", ".m4v", ".mov", ".3gp", ".3g2", ".asf" };
                    string[] videoFiles = Directory.GetFiles(folderDialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
                                                   .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                                                   .ToArray();

                    PlayList.Items.Clear();
                    foreach (string file in videoFiles)
                    {
                        PlayList.Items.Add(file);
                    }

                    if (PlayList.Items.Count > 0)
                    {
                        PlayList.SelectedIndex = 0; // Start with first video
                    }
                }
            }

        }

        private void PlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select the video file from the list
            if (PlayList.SelectedItem != null)
            {
                string selectedFile = PlayList.SelectedItem.ToString();
                VideoPlayer.URL = selectedFile;

                fileName.Text = Path.GetFileName(selectedFile);
            }
        }



        private void VideoPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // 0 = Undefined (Ready to load)
            if (e.newState == 0)
            {
                lblDuration.Text = "Media Player is Ready to be loaded";
            }
            // 1 = Stopped
            else if (e.newState == 1)
            {
                lblDuration.Text = "Media Player stopped";
            }
            // 3 = Playing
            else if (e.newState == 3)
            {
                lblDuration.Text = "Duration: " + VideoPlayer.currentMedia.durationString;
            }
            // 8 = Media Ended
            else if (e.newState == 8)
            {
                nextIndex = PlayList.SelectedIndex + 1;
                if (nextIndex >= PlayList.Items.Count)
                    nextIndex = 0;

                playNextWithDelay = true;
                timer1.Interval = 5000; // 5 seconds
                timer1.Start();
            }
            // 9 = Transitioning (loading)
            else if (e.newState == 9)
            {
                lblDuration.Text = "Loading new video";
                //VideoPlayer.Ctlcontrols.play();
            }
            // 10 = Ready (after buffering)
            else if (e.newState == 10)
            {
                lblDuration.Text = "Ready to play";

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TestVideoPlayerApp\nCreated for .NET Major Test 3\n© 2025 ITC-Lingua", "About");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Stop the timer to prevent it from running repeatedly
            timer1.Stop();

            if (playNextWithDelay)
            {
                playNextWithDelay = false;

                //Select the next video in playlist
                PlayList.SelectedIndex = nextIndex;

                string nextFile = PlayList.Items[nextIndex].ToString();
                VideoPlayer.URL = nextFile;
                //Force the video to start playing immediately.
                VideoPlayer.Ctlcontrols.play();
                fileName.Text = Path.GetFileName(nextFile);
            }
        }
    }
}
