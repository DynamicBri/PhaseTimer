# PhaseTimer
## Requirements
-.NET Framework 4.5.2

## Introduction
The phase timer is a timer with a highly customizable alarm. The idea is to set off an alarm strategically all throughout the night to help the physical body bring consciousness into a dream, or enter a borderland state for an OBE.
When the application is first started, it installs a directory called “Phase Timer” in your My Documents. In that directory should reside preset audio assets and some preset timer programs. Some timer programs will be locked so that they cannot be removed and have their intervals edited. However, they can still be deleted with Windows Explorer.

## Timer Programs
Timer programs are self-contained projects that hold information about timer behaviour. You can create programs to suit your specific needs, or use the provided timer programs. Timer programs are saved under “…My Documents\Phase Timer\Timer Programs” under their own directory. Audio files picked from within the application will be copied to this project directory. The phase timer project file (.ptp) will be found in this directory. This is a plain text file holding audio file paths, volume settings, timer intervals, etc.
Click the + button to add a timer program. A dialog should appear prompting for a name. Make sure to give the timer program a path-safe name as the timer program will create both a file and folder with this name.
When changes have been made to the timer program, an asterisk will show up in the window caption. Press Ctrl + S to save changes.
 
## Intervals
The intervals are the time in between alarms. In the program, they are entered in minutes as whole numbers or fractions.
1.5 = 1 minute and 30 seconds.
Intervals are entered into the interval textbox as space separated values. This textbox will turn red if the input is invalid. If “8 16 16” is entered, the first alarm will sound in 8 minutes, 16 after that, then another one in another 16. The last alarm would sound after 40 minutes has elapsed.
The timeline below the interval textbox, depicting the intervals and alarm duration, will update as the intervals are changed. The intervals are depicted in blue and the current track position is indicated as a red bar.
 
## Timer End Actions
There are 3 timer end actions which affect the continuity of the timer.
Iteration: A single cycle through all of the explicitly defined intervals.
### Stop
The timer is stopped when the timer completes an iteration. The last interval will not have an alarm sound at the end of it. The tail end of the iteration is silence.
### Loop All
After the last interval elapses, the timer loops back to the first again and begins cycling through the intervals like it did previously. The alarm will sound at the end of every iteration (in other words, at the end of the last interval).
### Repeat Last Interval
After the last interval elapses, the timer loops back to the start of the last interval. If the last interval is 2 minutes and the timer is repeating in this mode, a full cycle of the timer would be 2 minutes and the alarm would sound at this frequency.
 
## Importing Audio
Audio is “imported” by using the import buttons or by drag dropping files onto the file path textboxes. Upon import, the audio is immediately copied into the timer program directory — effectively making it an embedded resource. This new copy is what is referenced by the timer henceforth. Over time, audio files may accumulate in the timer program folder, in which case, it may be desirable to use the “Clean Timer Program Folder” tool. This tool will remove unreferenced audio files in the active timer program’s folder.
Other important points:

•	MP3s, WAVs, and FLACs are the supported file types.

•	The path and validity of audio files are not checked until “Play” is clicked.
 
## Volume Controls
The volume control dialog allows one to adjust the amplification and balance of the alarm and ambience playback. The volume controls work as one would expect. The balance controls adjust the left/right balance of the audio playback.

•	-100 is the minimum and will cause playback to come through the left speaker only.

•	0 is center balance (default) and will cause playback to come through both speakers normally.

•	100 is the maximum and will cause playback to come through the right speaker only.
The volume settings may be adjusted while the timer is active.
 
## Tips
•	Before running a timer program on Windows 10, turn on “Quiet Hours” to disable sound notifications. Right click or press and hold on the “Action Center icon” in the taskbar notification area. Click “Turn on quiet hours”.

•	There is no need to disable the screensaver on Windows 10, the screensaver will not interfere with the timer program (testing need for other versions of Windows).
