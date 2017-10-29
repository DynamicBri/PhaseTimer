using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using PhaseTimer.Properties;

namespace PhaseTimer.Forms
{
    public partial class MainForm : Form
    {
        private readonly TimerProgramManager timerProgManager = new TimerProgramManager();
        private readonly MultiIntervalTimer multiTimer = new MultiIntervalTimer();
        private readonly JukeBox jukeBoxAmbience = new JukeBox();
        private readonly JukeBox jukeBoxAlarm = new JukeBox();
        private const double INTERVAL_INCR = 0.25;

        /// <summary>
        /// Gets whether a timer program has been selected in the <see cref="comboTimerPrograms"/> control.
        /// </summary>
        private bool HasSelectedProgram => comboTimerPrograms.SelectedIndex != -1;

        /// <summary>
        /// Gets the timer program that has been selected through the UI.
        /// </summary>
        private TimerProgram SelectedTimerProgram => (TimerProgram)comboTimerPrograms.SelectedItem;

        private TimerEndAction SelectedEndAction
        {
            get
            {
                if (radioButtonLoop.Checked)
                    return TimerEndAction.LoopAll;
                else if (radioButtonRepeatFinal.Checked)
                    return TimerEndAction.RepeatLastInterval;
                else
                    return TimerEndAction.Stop;
            }
            set
            {
                switch (value)
                {
                    case TimerEndAction.LoopAll:
                        radioButtonLoop.Checked = true;
                        break;
                    case TimerEndAction.Stop:
                        radioButtonStop.Checked = true;
                        break;
                    case TimerEndAction.RepeatLastInterval:
                        radioButtonRepeatFinal.Checked = true;
                        break;
                }
            }
        }

        #region MainForm And Misc.
        public MainForm()
        {
            UnpackPresets();

            // Set open file dialog init dir to preset paths.
            if (String.IsNullOrEmpty(Settings.Default.LastPickAlarmDir))
            {
                Settings.Default.LastPickAlarmDir = PresetCreation.PresetAlarmsDirectory;
            }

            if (String.IsNullOrEmpty(Settings.Default.LastPickAmbienceDir))
            {
                Settings.Default.LastPickAmbienceDir = PresetCreation.PresetAmbienceDirectory;
            }

            InitializeComponent();
            timerProgManager.All.AddRange(TimerProgram.GetAllPrograms());
            comboTimerPrograms.DataSource = timerProgManager.All;
            menuItemAlwaysMinimize.Checked = Settings.Default.AlwaysMinToTray;
            HookMultiTimerEvents();
            UpdateHasTimerProgramControlState();
            RestoreTimerProgramSelection();
            UpdatePathTextBoxes();
        }

        private void HookMultiTimerEvents()
        {
            multiTimer.PlayStateChanged += delegate
            {
                switch (multiTimer.PlayState)
                {
                    case PlayState.Paused:
                        jukeBoxAmbience.Pause();
                        jukeBoxAlarm.Pause();
                        timerUpdateTimeLine.Stop();
                        break;

                    case PlayState.Playing:
                        timerUpdateTimeLine.Start();
                        break;

                    case PlayState.Stopped:
                        timerUpdateTimeLine.Stop();
                        StopAudio();
                        break;
                }

                SetUiPlayState(multiTimer.PlayState);
                UpdateTimeLabel();
            };

            multiTimer.SecondElapsed += delegate
            {
                if (IsHandleCreated)
                    UpdateTimeLabel();
            };

            multiTimer.MarkerReached += delegate { jukeBoxAlarm.Play(); };

            multiTimer.LoopingAllChanged += delegate
            {
                timeLineStrip.IntervalAtStart = multiTimer.LoopingAll;
            };
        }

        /// <summary>
        /// Restores the last selected timer program. If no last selection, the first unlocked
        /// item will be selected.
        /// </summary>
        private void RestoreTimerProgramSelection()
        {
            if (timerProgManager.All.Any())
            {
                if (Settings.Default.LastSelectedProgIndex == -1)
                {
                    var s = timerProgManager.All.FirstOrDefault(p => !p.Locked);

                    if (s != null)
                        comboTimerPrograms.SelectedItem = s;
                }
                else if (Settings.Default.LastSelectedProgIndex < comboTimerPrograms.Items.Count)
                {
                    comboTimerPrograms.SelectedIndex = Settings.Default.LastSelectedProgIndex;
                }
            }
        }

        /// <summary>
        /// Unpacks preset resources and timer programs to the PhaseTimer directory.
        /// If such directory does not exist, then it is created.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        private static void UnpackPresets()
        {
            PresetCreation.AutoSetTimerProgramDirectory();

            if (!Directory.Exists(Settings.Default.PhaseTimerDir))
            {
                try
                {
                    PresetCreation.UnpackPresetResources();
                }
                catch (UnauthorizedAccessException)
                {
                    // Try to get the user to restart with admin privileges. If we cannot save presets
                    // it is very unlikely that we will be able to save their phase timer programs or embed audio resources.
                    Program.ShowError("Default assets could not be installed because of insufficient privileges." +
                                      "Please close the application, then start it with administrative rights.");
                }
                catch (IOException ex)
                {
                    Program.ShowError("Could not write presets to file.\n\n" + ex.Message);
                }

                try
                {
                    PresetCreation.SavePresetProgramsToFile();
                }
                catch (UnauthorizedAccessException)
                {
                    Program.ShowError("Preset timer programs could not be installed because of insufficient privileges." +
                                      "Please close the application, then start it with administrative rights.");
                }
                catch (IOException ex)
                {
                    Program.ShowError("Could not write presets to file.\n\n" + ex.Message);
                }
            }
        }

        private void ImportAudioFile(string filePath, bool alarm)
        {
            string embedPath = SelectedTimerProgram.EmbedFile(filePath);

            if (embedPath != string.Empty)
            {
                if (alarm)
                {
                    SelectedTimerProgram.AlarmPath = embedPath;
                    UpdateAlarmLength();
                }
                else
                {
                    SelectedTimerProgram.AmbiencePath = embedPath;
                }
            }

            UpdatePathTextBoxes();
        }

        /// <summary>
        /// Gets whether the specified path has a valid audio file extension.
        /// </summary>
        private static bool IsValidAudioFile(string filePath)
        {
            string[] validExts = { ".mp3", ".flac", ".wav" };
            string ext = Path.GetExtension(filePath);

            foreach (var validExt in validExts)
            {
                if (validExt.Equals(ext, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyData)
            {
                case Keys.Pause:
                    if (buttonPause.Visible)
                        buttonPause_Click(buttonPause, EventArgs.Empty);
                    break;

                case Keys.Play:
                    if (buttonPlay.Visible)
                        buttonPlay_Click(buttonPlay, EventArgs.Empty);
                    break;

                // Toggle play/pause key shortcut support.
                case Keys.Control | Keys.F6:
                case Keys.MediaPlayPause:
                    if (multiTimer.PlayState != PlayState.Playing)
                    {
                        buttonPlay_Click(buttonPlay, EventArgs.Empty);
                    }
                    else if (buttonPause.Visible)
                    {
                        buttonPause_Click(buttonPause, EventArgs.Empty);
                    }
                    break;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            foreach (var program in timerProgManager.Unsaved)
            {
                var result = MessageBox.Show($@"Save changes to ""{program.Name}""?", Application.ProductName,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes: program.Save(); break;
                    case DialogResult.No: continue;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }

                if (e.Cancel)
                    break;
            }

            Settings.Default.LastSelectedProgIndex = comboTimerPrograms.SelectedIndex;
            Settings.Default.AlwaysMinToTray = menuItemAlwaysMinimize.Checked;
            Settings.Default.Save();
            base.OnClosing(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (WindowState == FormWindowState.Minimized && menuItemAlwaysMinimize.Checked)
            {
                WindowState = FormWindowState.Normal;
                menuItemMinToTray_Click(null, null);
            }
        }

        private void SelectedProgram_ModifiedChanged(object sender, EventArgs e)
        {
            UpdateWindowCaption();
        }

        private void SelectedProgramVolumeModified(object sender, EventArgs e)
        {
            UpdateJukeBoxVolumeSettings();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                // Sometimes the window is not brought forth and BringToFront does help.
                NativeMethods.SetForegroundWindow(Handle);
                notifyIcon.Visible = false;
            }
        }
        #endregion

        #region Timer Programs Control Group
        private void comboTimerPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selTimerProgram = SelectedTimerProgram;

            if (HasSelectedProgram)
            {
                UpdateSelectedProgramhandlers();
                SelectedEndAction = selTimerProgram.TimerEndAction;
                textBoxIntervals.Text = IntervalConversion.ToString(SelectedTimerProgram.Intervals);
            }
            else
            {
                textBoxIntervals.Clear();
                textBoxAlarmPath.Clear();
                textBoxAmbiencePath.Clear();
            }

            UpdatePathTextBoxes();
            UpdateAlarmLength();
            UpdateHasTimerProgramControlState();
            UpdateWindowCaption();
            UpdateJukeBoxVolumeSettings();
            UpdateTimeLabel();
        }

        private void buttonAddTimerProgram_Click(object sender, EventArgs e)
        {
            using (var dialog = new NamePickerDialog())
            {
                dialog.Text = "Pick a name for your timer program...";

                dialog.Closing += (o, args) =>
                {
                    // Do not close dialog if user submits a name that already exists or has invalid path chars.
                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        bool alreadyExist = timerProgManager.NameAlreadyExists(dialog.EnteredName);

                        if (alreadyExist)
                        {
                            Program.ShowError("Name already exists.");
                            args.Cancel = true;
                            return;
                        }

                        var invalidChars = Path.GetInvalidFileNameChars();
                        bool hasInvalidChars = dialog.EnteredName.Any(c => invalidChars.Any(c2 => c2 == c));

                        if (hasInvalidChars)
                        {
                            Program.ShowError("Name contains invalid path characters.");
                            args.Cancel = true;
                        }
                    }
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var newProgram = TimerProgram.CreateNew(dialog.EnteredName);
                    timerProgManager.All.Add(newProgram);
                    comboTimerPrograms.SelectedItem = newProgram;
                    UpdateHasTimerProgramControlState();
                    UpdateWindowCaption();
                    UpdateSelectedProgramhandlers();
                }
            }
        }

        private void buttonRemoveProgram_Click(object sender, EventArgs e)
        {
            string message = $@"Are you sure you want to delete ""{comboTimerPrograms.SelectedItem}""?";
            var dialogResult = MessageBox.Show(message, "Delete Saved Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                timerProgManager.RemoveProgramAt(comboTimerPrograms.SelectedIndex);
            }
        }
        #endregion

        #region Alarm Control Group
        private void buttonImportAlarm_Click(object sender, EventArgs e)
        {
            contextMenuImportAlarm.Show(buttonImportAlarm, new Point(0, buttonImportAlarm.Height));
        }

        private void menuItemImportAlarm_Click(object sender, EventArgs e)
        {
            ImportAlarmAudioFromDialog(Settings.Default.LastPickAlarmDir, true);
        }

        private void menuItemImportAlarmPresets_Click(object sender, EventArgs e)
        {
            ImportAlarmAudioFromDialog(PresetCreation.PresetAlarmsDirectory, false);
        }

        private void menuItemImportFromWinSounds_Click(object sender, EventArgs e)
        {
            string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            ImportAlarmAudioFromDialog($@"{winDir}\Media", false);
        }

        private void textBoxAlarmPath_DragDrop(object sender, DragEventArgs e)
        {
            ImportAudioFile(e.Data.GetFirstFileName(), true);
        }

        /// <summary>
        /// Imports an alarm audio file from an <see cref="OpenFileDialog"/>.
        /// </summary>
        /// <param name="initDir">The initial directory to show in the dialog.</param>
        /// <param name="saveDir">When true, persists the selected directory.</param>
        private void ImportAlarmAudioFromDialog(string initDir, bool saveDir)
        {
            using (var dialogOpenFile = new OpenFileDialog())
            {
                dialogOpenFile.InitialDirectory = initDir;
                dialogOpenFile.Filter = Resources.AudioDialogFilter;

                if (dialogOpenFile.ShowDialog() == DialogResult.OK)
                {
                    ImportAudioFile(dialogOpenFile.FileName, true);

                    if (saveDir)
                        Settings.Default.LastPickAlarmDir = Path.GetDirectoryName(dialogOpenFile.FileName);
                }
            }
        }

        private void AudioPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            string firstFileName = e.Data.GetFirstFileName();

            if (IsValidAudioFile(firstFileName))
                e.Effect = DragDropEffects.Link;
        }

        private void menuItemClearAlarmPath_Click(object sender, EventArgs e)
        {
            textBoxAlarmPath.Clear();
            SelectedTimerProgram.AlarmPath = null;
        }

        private void textBoxAlarmPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && menuItemClearAlarmPath.Enabled)
                menuItemClearAlarmPath_Click(this, EventArgs.Empty);
        }
        #endregion

        #region Ambience Control Groups
        private void buttonImportAmbience_Click(object sender, EventArgs e)
        {
            contextMenuAmbience.Show(buttonImportAmbience, new Point(0, buttonImportAmbience.Height));
        }

        private void menuItemImportAmbience_Click(object sender, EventArgs e)
        {
            ImportAmbienceFromDialog(Settings.Default.LastPickAmbienceDir, true);
        }

        private void menuItemImportAmbiencePresets_Click(object sender, EventArgs e)
        {
            ImportAmbienceFromDialog(PresetCreation.PresetAmbienceDirectory, false);
        }

        private void menuItemImportFromMusic_Click(object sender, EventArgs e)
        {
            string musicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            ImportAmbienceFromDialog(musicDir, false);
        }

        /// <summary>
        /// Imports an ambience file from an <see cref="OpenFileDialog"/>.
        /// </summary>
        /// <param name="initDir">The initial directory to show in the dialog.</param>
        /// <param name="saveDir">When true, persists the selected directory.</param>
        private void ImportAmbienceFromDialog(string initDir, bool saveDir)
        {
            Button button = new Button();
            button.Text = "Hello";

            using (var dialogOpenFile = new OpenFileDialog())
            {
                dialogOpenFile.InitialDirectory = initDir;
                dialogOpenFile.Filter = Resources.AudioDialogFilter;

                if (dialogOpenFile.ShowDialog() == DialogResult.OK)
                {
                    ImportAudioFile(dialogOpenFile.FileName, false);

                    if (saveDir)
                        Settings.Default.LastPickAmbienceDir = Path.GetDirectoryName(dialogOpenFile.FileName);
                }
            }

            button.Dispose();
        }

        private void textBoxAmbiencePath_DragDrop(object sender, DragEventArgs e)
        {
            ImportAudioFile(e.Data.GetFirstFileName(), false);
        }

        private void menuItemClearAmbiencePath_Click(object sender, EventArgs e)
        {
            textBoxAmbiencePath.Clear();
            SelectedTimerProgram.AmbiencePath = null;
        }

        private void textBoxAmbiencePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && menuItemClearAmbiencePath.Enabled)
                menuItemClearAmbiencePath_Click(this, EventArgs.Empty);
        }
        #endregion

        #region Intervals Control Group
        private void textBoxIntervals_TextChanged(object sender, EventArgs e)
        {
            if (!HasSelectedProgram)
            {
                textBoxIntervals.BackColor = SystemColors.Window;
                UpdateTimeLineStrip();
                return;
            }

            SelectedTimerProgram.Intervals = IntervalConversion.FromString(textBoxIntervals.Text, out var errors);
            bool hasFormatErrors = errors != IntervalFormatErrors.None;
            buttonIncrementAll.Enabled = buttonDecrementAll.Enabled = !(textBoxIntervals.TextLength == 0 || hasFormatErrors);

            if (hasFormatErrors)
            {
                SelectedTimerProgram.Intervals = null;
                textBoxIntervals.BackColor = Color.LightCoral;
                return;
            }

            textBoxIntervals.BackColor = SystemColors.Window;
            UpdateTimeLineStrip();
            UpdateTimeLabel();
        }

        private void buttonIncrementAll_Click(object sender, EventArgs e)
        {
            var intervals = IntervalConversion.FromString(textBoxIntervals.Text, out var errors);

            if (errors == IntervalFormatErrors.None)
            {
                for (var i = 0; i < intervals.Length; i++)
                {
                    intervals[i] += INTERVAL_INCR;
                }

                textBoxIntervals.Text = IntervalConversion.ToString(intervals);
            }
        }

        private void buttonDecrementAll_Click(object sender, EventArgs e)
        {
            var intervals = IntervalConversion.FromString(textBoxIntervals.Text, out var errors);

            if (errors == IntervalFormatErrors.None)
            {
                for (var i = 0; i < intervals.Length; i++)
                {
                    if (intervals[i] >= 0.5)
                    {
                        intervals[i] -= INTERVAL_INCR;
                    }
                }

                textBoxIntervals.Text = IntervalConversion.ToString(intervals);
            }
        }
        #endregion

        #region Timer End Option Control Group
        private void TimerEndOptionRadios_CheckedChanged(object sender, EventArgs e)
        {
            SelectedTimerProgram.TimerEndAction = SelectedEndAction;
        }
        #endregion

        #region Playback Control Group
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!SelectedTimerProgram.HasIntervals)
            {
                Program.ShowError("At least one interval needs to be set.");
                textBoxIntervals.Focus();
                return;
            }

            if (String.IsNullOrEmpty(SelectedTimerProgram.AlarmPath))
            {
                Program.ShowError("No alarm selected.");
                return;
            }

            if (!File.Exists(SelectedTimerProgram.AlarmPath))
            {
                Program.ShowError("Alarm audio file not found.");
                return;
            }

            if (!String.IsNullOrWhiteSpace(SelectedTimerProgram.AmbiencePath) && !File.Exists(SelectedTimerProgram.AmbiencePath))
            {
                Program.ShowError("Background audio file not found.");
                return;
            }

            if (multiTimer.PlayState != PlayState.Paused)
            {
                jukeBoxAmbience.Open(SelectedTimerProgram.AmbiencePath);
                // Alarm file is mandatory, no null check needed.
                jukeBoxAlarm.Open(SelectedTimerProgram.AlarmPath);
                multiTimer.TimerEndAction = SelectedEndAction;
                multiTimer.LoadTimeMarkersFromMinIntervals(SelectedTimerProgram.Intervals);
                timeLineStrip.LoadTimeMarkersFromMinIntervals(SelectedTimerProgram.Intervals);
            }

            if (jukeBoxAlarm.PlayState == PlayState.Paused)
            {
                jukeBoxAlarm.Play();
            }

            if (jukeBoxAmbience.HasMedia)
            {
                jukeBoxAmbience.Play(true);
            }

            multiTimer.Start();
            UpdateTimeLineStrip();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            multiTimer.Pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopAudio();
        }

        private void buttonVolumeControls_Click(object sender, EventArgs e)
        {
            using (var dialogVolumeInfo = new VolumeSettingsDialog())
            {
                dialogVolumeInfo.VolumeSettings = SelectedTimerProgram.VolumeSettings;
                dialogVolumeInfo.ShowDialog();
            }
        }

        private void StopAudio()
        {
            multiTimer.Stop();
            jukeBoxAmbience.Stop();
            jukeBoxAlarm.Stop();
            UpdateTimeLineStrip();
        }
        #endregion

        #region Update Methods
        /// <summary>
        /// Hooks to the events of the currently selected timer program and unsubscribes from
        /// all other timer programs.
        /// </summary>
        private void UpdateSelectedProgramhandlers()
        {
            if (HasSelectedProgram)
            {
                timerProgManager.IsolateModifiedChangedEvent(SelectedTimerProgram, SelectedProgram_ModifiedChanged);
                timerProgManager.IsolateVolumeModifiedEvent(SelectedTimerProgram, SelectedProgramVolumeModified);
            }
        }

        /// <summary>
        /// Updates the alarm length asynchronously and quietly.
        /// </summary>
        /// <remarks>This needs to be done so that the timelinestrip can properly depict the alarms.
        /// We cannot load the alarms in the media player until the play button is pressed because we
        /// do not want selecting timer programs with the combobox to be unresponsive.</remarks>
        private async void UpdateAlarmLength()
        {
            if (HasSelectedProgram)
            {
                int alarmLengthLocal = await JukeBox.GetAudioLengthAsync(SelectedTimerProgram.AlarmPath);

                if (IsHandleCreated)
                {
                    timeLineStrip.AlarmLength = alarmLengthLocal;
                }
            }
        }

        private void UpdateTimeLinePosition()
        {
            if (HasSelectedProgram)
                timeLineStrip.PlaybackPosition = multiTimer.CurrentIterationPosition.TotalMilliseconds;
        }

        private void UpdateJukeBoxVolumeSettings()
        {
            if (HasSelectedProgram)
            {
                jukeBoxAlarm.Volume = (SelectedTimerProgram.VolumeSettings.AlarmVolume / 100.0) / 2.0;
                jukeBoxAmbience.Volume = (SelectedTimerProgram.VolumeSettings.AmbienceVolume / 100.0) / 2.0;
                jukeBoxAmbience.Balance = SelectedTimerProgram.VolumeSettings.AmbienceBalance;
                jukeBoxAlarm.Balance = SelectedTimerProgram.VolumeSettings.AlarmBalance;
            }
        }

        private void UpdatePathTextBoxes()
        {
            if (HasSelectedProgram)
            {
                textBoxAlarmPath.Text = String.IsNullOrWhiteSpace(SelectedTimerProgram.AlarmPath) ?
                    Resources.DragImportPrompt : Path.GetFileName(SelectedTimerProgram.AlarmPath);

                textBoxAmbiencePath.Text = String.IsNullOrWhiteSpace(SelectedTimerProgram.AmbiencePath) ?
                    Resources.DragImportPrompt : Path.GetFileName(SelectedTimerProgram.AmbiencePath);
            }
            else
            {
                textBoxAlarmPath.Text = Resources.DragImportPrompt;
                textBoxAmbiencePath.Text = Resources.DragImportPrompt;
            }
        }

        /// <summary>
        /// Updates controls to reflect whether the app has a timer program selected.
        /// </summary>
        private void UpdateHasTimerProgramControlState()
        {
            var hasProgram = HasSelectedProgram;
            bool projLocked = hasProgram && SelectedTimerProgram.Locked;
            menuItemSave.Enabled = hasProgram;
            menuItemOpenActiveProgDir.Enabled = hasProgram;
            buttonRemoveProgram.Enabled = hasProgram && !projLocked;
            groupBoxIntervals.Enabled = hasProgram && !projLocked;
            buttonCleanTimerProgFolder.Enabled = hasProgram;
            comboTimerPrograms.Enabled = hasProgram;
            groupBoxAlarmAudio.Enabled = hasProgram;
            groupBoxAmbience.Enabled = hasProgram;
            groupBoxCompleteAction.Enabled = hasProgram;
            panelPlayback.Enabled = hasProgram;
            buttonVolumeControls.Enabled = hasProgram;
            labelTime.Enabled = hasProgram;
        }

        /// <summary>
        /// Adjusts the UI to reflect the specified program playback state.
        /// </summary>
        private void SetUiPlayState(PlayState playSate)
        {
            switch (playSate)
            {
                case PlayState.Paused:
                    groupBoxIntervals.Enabled = false;
                    buttonPause.Visible = false;
                    menuItemPause.Enabled = false;
                    buttonPlay.Visible = true;
                    menuItemPlay.Enabled = true;
                    buttonStop.Enabled = true;
                    menuItemStop.Enabled = true;
                    break;

                case PlayState.Stopped:
                    groupBoxCompleteAction.Enabled = true;
                    buttonCleanTimerProgFolder.Enabled = true;
                    groupBoxIntervals.Enabled = HasSelectedProgram && !SelectedTimerProgram.Locked;
                    buttonImportAlarm.Enabled = true;
                    menuItemClearAlarmPath.Enabled = true;
                    buttonImportAmbience.Enabled = true;
                    menuItemClearAmbiencePath.Enabled = true;
                    groupBoxTimerPrograms.Enabled = true;
                    buttonPause.Visible = false;
                    menuItemPause.Enabled = false;
                    buttonPlay.Visible = true;
                    menuItemPlay.Enabled = true;
                    buttonStop.Enabled = false;
                    menuItemStop.Enabled = false;
                    break;

                case PlayState.Playing:
                    groupBoxCompleteAction.Enabled = false;
                    buttonCleanTimerProgFolder.Enabled = false;
                    groupBoxIntervals.Enabled = false;
                    buttonImportAlarm.Enabled = false;
                    menuItemClearAlarmPath.Enabled = false;
                    buttonImportAmbience.Enabled = false;
                    menuItemClearAmbiencePath.Enabled = false;
                    groupBoxTimerPrograms.Enabled = false;
                    buttonPause.Visible = true;
                    menuItemPause.Enabled = true;
                    buttonPlay.Visible = false;
                    menuItemPlay.Enabled = false;
                    buttonStop.Enabled = true;
                    menuItemStop.Enabled = true;
                    break;
            }
        }

        private void timerUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateTimeLinePosition();
        }

        private void UpdateTimeLabel()
        {
            if (HasSelectedProgram)
            {
                labelTime.Text =
                    $@"{multiTimer.CurrentIterationPosition:mm\:ss} /" 
                    + $@" {SelectedTimerProgram.Duration:mm\:ss}";
            }
            else
            {
                labelTime.Text = @"00:00 / 00:00";
            }
        }

        private void UpdateWindowCaption()
        {
            if (!HasSelectedProgram)
            {
                Text = Application.ProductName;
            }
            else
            {
                string timerProgramName = SelectedTimerProgram.Name;

                if (SelectedTimerProgram.Modified)
                    timerProgramName += "*";

                Text = $"{timerProgramName} - {Application.ProductName}";
            }
        }

        private void UpdateTimeLineStrip()
        {
            if (!HasSelectedProgram)
            {
                timeLineStrip.Clear();
            }
            else
            {
                timeLineStrip.LoadTimeMarkersFromMinIntervals(SelectedTimerProgram.Intervals);
                UpdateTimeLinePosition();
            }
        }
        #endregion

        #region MenuItem Event Handlers
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (HasSelectedProgram)
                SelectedTimerProgram.Save();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            // Environment.Exit keeps form.Closing from being raised and causes
            // Tray icon to stay in tray after app is closed.
            Application.Exit();
        }

        private void menuItemMinToTray_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.Visible = true;
        }

        private void menuItemOpenTimerProgDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(TimerProgram.MasterDirectory);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex.Message);
            }
        }

        private void menuItemOpenActiveProgDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(SelectedTimerProgram.ProgramDirectory);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex.Message);
            }
        }

        private void buttonCleanTimerProgFolder_Click(object sender, EventArgs e)
        {
            string[] unrefedFiles = SelectedTimerProgram.GetUnreferencedFiles();

            if (!unrefedFiles.Any())
            {
                MessageBox.Show("This timer program has no unreferenced files.", "Everything looks good",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var SB = new StringBuilder();
            SB.AppendLine("Would you like to remove the following unreferenced files?");
            SB.AppendLine();

            foreach (var file in unrefedFiles)
            {
                SB.AppendLine("•" + Path.GetFileName(file));
            }

            var result = MessageBox.Show(SB.ToString(), Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (var file in unrefedFiles)
                    {
                        File.Delete(file);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Program.ShowError(ex.Message);
                }
            }

            UpdateTimeLabel();
        }

        private void menuItemDeleteMainFolder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all timer programs and preset assets?",
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Directory.Exists(Settings.Default.PhaseTimerDir))
                {
                    try
                    {
                        Directory.Delete(Settings.Default.PhaseTimerDir, true);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Program.ShowError(ex.Message);
                    }
                }

                timerProgManager.All.Clear();
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            using (var dialogAbout = new AboutDialog())
                dialogAbout.ShowDialog();
        }

        private void menuItemOpenUserManual_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("User Manual.pdf");
            }
            catch (Exception ex)
            {
                Program.ShowError(ex.Message);
            }
        }
        #endregion
    }
}
