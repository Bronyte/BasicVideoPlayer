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
- `Menustrip menustrip1`: Provides menu options.

---

## How to Run

1. Clone or download the project.
2. Open the solution (`.sln` file) in **Visual Studio**.
3. Build the project (`Ctrl + Shift + B`).
4. Run the app (`F5`).
5. In the application, click **File → Open Folder** and select a folder containing video files.

---

## Notes
- Requires Windows Media Player installed and enabled in Windows Features.
- Supported formats depend on system-installed codecs.
- Ensure `AxInterop.WMPLib.dll` and `Interop.WMPLib.dll` are present in references.

---
