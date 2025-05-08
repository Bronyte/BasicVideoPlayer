# Video Player App

##  Overview
The **Video Player App** is a simple Windows Forms application built with C#. It allows users to load and play video files from a selected folder using the Windows Media Player ActiveX control. The app automatically builds a playlist and displays video duration and filename information.

---

##  Purpose
This project helps students and beginner developers:
- Learn how to use the Windows Forms Designer.
- Integrate ActiveX controls like Windows Media Player.
- Handle events and UI updates in C#.
- Use file system operations and collections.

---

##  Features
- Load videos from a selected folder.
- Supports common formats: `.mp4`, `.avi`, `.mkv`, `.wmv`, `.webm`.
- Displays video file name and duration.
- Automatically plays the next video in the playlist.
- Includes a basic menu with "Load Folder" and "About" options.

---

## Key Components & Methods

### Controls
- `AxWindowsMediaPlayer VideoPlayer`: Plays video files.
- `ListBox PlayList`: Displays all loaded video files.
- `Label fileName`: Shows currently playing video name.
- `Label lblDuration`: Displays video duration or status.
- `Timer timer1`: Controls delayed video playback.

### Important Methods
- `LoadFolderEvent`: Opens folder dialog and loads supported video files.
- `LoadPlayList`: Populates playlist and sets up video playback.
- `PlayListChanged`: Handles video switching when user selects a different item.
- `TimerEvent`: Starts video playback after a brief delay.
- `ShowAboutEvent`: Displays app information.
- `MediaPlayerStateChangeEvent`: Manages UI updates and auto-play for the next video.
- `PlayFile(string url)`: Sets the video to play.
- `ShowFileName(Label name)`: Updates the label with the currently playing file name.

---

## How to Run

1. Clone or download the project from the [GitHub repository](https://github.com/your-username/your-repo-name).
2. Open the solution (`.sln` file) in **Visual Studio**.
3. Build the project (`Ctrl + Shift + B`).
4. Run the app (`F5`).
5. In the application, click **File → Load Folder** and select a folder containing video files.

---

## Notes
- Requires Windows Media Player installed and enabled in Windows Features.
- Supported formats depend on system-installed codecs.
- Ensure `AxInterop.WMPLib.dll` and `Interop.WMPLib.dll` are present in references.

---
