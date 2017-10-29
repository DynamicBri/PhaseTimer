namespace PhaseTimer.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            multiTimer.Dispose();
            jukeBoxAmbience.Dispose();
            jukeBoxAlarm.Dispose();
     
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMinToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAlwaysMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOpenTimerProgDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenActiveProgDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenUserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCleanTimerProgFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteMainFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonStop = new System.Windows.Forms.RadioButton();
            this.radioButtonRepeatFinal = new System.Windows.Forms.RadioButton();
            this.radioButtonLoop = new System.Windows.Forms.RadioButton();
            this.groupBoxAlarmAudio = new System.Windows.Forms.GroupBox();
            this.textBoxAlarmPath = new System.Windows.Forms.TextBox();
            this.contextMenuAlarmTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemClearAlarmPath = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonImportAlarm = new System.Windows.Forms.Button();
            this.groupBoxCompleteAction = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.comboTimerPrograms = new System.Windows.Forms.ComboBox();
            this.groupBoxTimerPrograms = new System.Windows.Forms.GroupBox();
            this.buttonRemoveProgram = new System.Windows.Forms.Button();
            this.buttonAddTimerProgram = new System.Windows.Forms.Button();
            this.groupBoxAmbience = new System.Windows.Forms.GroupBox();
            this.textBoxAmbiencePath = new System.Windows.Forms.TextBox();
            this.contextMenuAmbienceTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemClearAmbiencePath = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonImportAmbience = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPause = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.panelPlayback = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDecrementAll = new System.Windows.Forms.Button();
            this.buttonIncrementAll = new System.Windows.Forms.Button();
            this.contextMenuImportAlarm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemImportAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportAlarmPresets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportFromWinSounds = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAmbience = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemImportAmbience = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportAmbiencePresets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImportFromMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxIntervals = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBoxIntervals = new System.Windows.Forms.GroupBox();
            this.timeLineStrip = new PhaseTimer.Forms.TimeLineStrip();
            this.buttonVolumeControls = new System.Windows.Forms.Button();
            this.timerUpdateTimeLine = new System.Windows.Forms.Timer(this.components);
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAlarmAudio.SuspendLayout();
            this.contextMenuAlarmTextBox.SuspendLayout();
            this.groupBoxCompleteAction.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBoxTimerPrograms.SuspendLayout();
            this.groupBoxAmbience.SuspendLayout();
            this.contextMenuAmbienceTextBox.SuspendLayout();
            this.contextMenuSysTray.SuspendLayout();
            this.panelPlayback.SuspendLayout();
            this.contextMenuImportAlarm.SuspendLayout();
            this.contextMenuAmbience.SuspendLayout();
            this.groupBoxIntervals.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSave,
            this.toolStripSeparator1,
            this.menuItemExit});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            fileToolStripMenuItem.Text = "&File";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(152, 22);
            this.menuItemSave.Text = "Save";
            this.menuItemSave.ToolTipText = "Save to file.";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeyDisplayString = "Alt+F4";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMinToTray,
            this.menuItemAlwaysMinimize,
            this.toolStripSeparator4,
            this.menuItemOpenTimerProgDir,
            this.menuItemOpenActiveProgDir});
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            viewToolStripMenuItem.Text = "&View";
            // 
            // menuItemMinToTray
            // 
            this.menuItemMinToTray.Name = "menuItemMinToTray";
            this.menuItemMinToTray.Size = new System.Drawing.Size(237, 22);
            this.menuItemMinToTray.Text = "&Minimize To Tray";
            this.menuItemMinToTray.Click += new System.EventHandler(this.menuItemMinToTray_Click);
            // 
            // menuItemAlwaysMinimize
            // 
            this.menuItemAlwaysMinimize.CheckOnClick = true;
            this.menuItemAlwaysMinimize.Name = "menuItemAlwaysMinimize";
            this.menuItemAlwaysMinimize.Size = new System.Drawing.Size(237, 22);
            this.menuItemAlwaysMinimize.Text = "&Always Minimize To Tray";
            this.menuItemAlwaysMinimize.ToolTipText = "Always minimize this application to tray\r\nwhen the main window is minimized.";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // menuItemOpenTimerProgDir
            // 
            this.menuItemOpenTimerProgDir.Name = "menuItemOpenTimerProgDir";
            this.menuItemOpenTimerProgDir.Size = new System.Drawing.Size(237, 22);
            this.menuItemOpenTimerProgDir.Text = "Open \"&Timer Programs\" Folder";
            this.menuItemOpenTimerProgDir.ToolTipText = "Open the folder that contains all timer programs.";
            this.menuItemOpenTimerProgDir.Click += new System.EventHandler(this.menuItemOpenTimerProgDir_Click);
            // 
            // menuItemOpenActiveProgDir
            // 
            this.menuItemOpenActiveProgDir.Name = "menuItemOpenActiveProgDir";
            this.menuItemOpenActiveProgDir.Size = new System.Drawing.Size(237, 22);
            this.menuItemOpenActiveProgDir.Text = "Open &Active Program Folder";
            this.menuItemOpenActiveProgDir.ToolTipText = "Open the currently active timer program folder.";
            this.menuItemOpenActiveProgDir.Click += new System.EventHandler(this.menuItemOpenActiveProgDir_Click);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout,
            this.menuItemOpenUserManual});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(191, 22);
            this.menuItemAbout.Text = "&About...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItemOpenUserManual
            // 
            this.menuItemOpenUserManual.Name = "menuItemOpenUserManual";
            this.menuItemOpenUserManual.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemOpenUserManual.Size = new System.Drawing.Size(191, 22);
            this.menuItemOpenUserManual.Text = "Open User Manual";
            this.menuItemOpenUserManual.Click += new System.EventHandler(this.menuItemOpenUserManual_Click);
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCleanTimerProgFolder,
            this.menuItemDeleteMainFolder});
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            toolToolStripMenuItem.Text = "&Tools";
            // 
            // buttonCleanTimerProgFolder
            // 
            this.buttonCleanTimerProgFolder.Name = "buttonCleanTimerProgFolder";
            this.buttonCleanTimerProgFolder.Size = new System.Drawing.Size(223, 22);
            this.buttonCleanTimerProgFolder.Text = "&Clean Timer Program Folder";
            this.buttonCleanTimerProgFolder.ToolTipText = "Removes unreferenced files from the active timer program\'s folder.";
            this.buttonCleanTimerProgFolder.Click += new System.EventHandler(this.buttonCleanTimerProgFolder_Click);
            // 
            // menuItemDeleteMainFolder
            // 
            this.menuItemDeleteMainFolder.Name = "menuItemDeleteMainFolder";
            this.menuItemDeleteMainFolder.Size = new System.Drawing.Size(223, 22);
            this.menuItemDeleteMainFolder.Text = "&Delete \"Phase Timer\" Folder";
            this.menuItemDeleteMainFolder.ToolTipText = "Deletes all preset assets, and timer programs.";
            this.menuItemDeleteMainFolder.Click += new System.EventHandler(this.menuItemDeleteMainFolder_Click);
            // 
            // radioButtonStop
            // 
            this.radioButtonStop.AutoSize = true;
            this.radioButtonStop.Checked = true;
            this.radioButtonStop.Location = new System.Drawing.Point(4, 17);
            this.radioButtonStop.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonStop.Name = "radioButtonStop";
            this.radioButtonStop.Size = new System.Drawing.Size(47, 17);
            this.radioButtonStop.TabIndex = 11;
            this.radioButtonStop.TabStop = true;
            this.radioButtonStop.Text = "Stop";
            this.toolTip.SetToolTip(this.radioButtonStop, "The timer will stop after all intervals are iterated through.");
            this.radioButtonStop.UseVisualStyleBackColor = true;
            this.radioButtonStop.CheckedChanged += new System.EventHandler(this.TimerEndOptionRadios_CheckedChanged);
            // 
            // radioButtonRepeatFinal
            // 
            this.radioButtonRepeatFinal.AutoSize = true;
            this.radioButtonRepeatFinal.Location = new System.Drawing.Point(4, 59);
            this.radioButtonRepeatFinal.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRepeatFinal.Name = "radioButtonRepeatFinal";
            this.radioButtonRepeatFinal.Size = new System.Drawing.Size(123, 17);
            this.radioButtonRepeatFinal.TabIndex = 12;
            this.radioButtonRepeatFinal.Text = "Repeat Final Interval";
            this.toolTip.SetToolTip(this.radioButtonRepeatFinal, "When the last interval is reached, it is looped indefinitely.");
            this.radioButtonRepeatFinal.UseVisualStyleBackColor = true;
            this.radioButtonRepeatFinal.CheckedChanged += new System.EventHandler(this.TimerEndOptionRadios_CheckedChanged);
            // 
            // radioButtonLoop
            // 
            this.radioButtonLoop.AutoSize = true;
            this.radioButtonLoop.Location = new System.Drawing.Point(4, 38);
            this.radioButtonLoop.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonLoop.Name = "radioButtonLoop";
            this.radioButtonLoop.Size = new System.Drawing.Size(63, 17);
            this.radioButtonLoop.TabIndex = 13;
            this.radioButtonLoop.Text = "Loop All";
            this.toolTip.SetToolTip(this.radioButtonLoop, "When the last interval elapses, the timer starts at the first interval again.");
            this.radioButtonLoop.UseVisualStyleBackColor = true;
            this.radioButtonLoop.CheckedChanged += new System.EventHandler(this.TimerEndOptionRadios_CheckedChanged);
            // 
            // groupBoxAlarmAudio
            // 
            this.groupBoxAlarmAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAlarmAudio.Controls.Add(this.textBoxAlarmPath);
            this.groupBoxAlarmAudio.Controls.Add(this.buttonImportAlarm);
            this.groupBoxAlarmAudio.Location = new System.Drawing.Point(12, 83);
            this.groupBoxAlarmAudio.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAlarmAudio.Name = "groupBoxAlarmAudio";
            this.groupBoxAlarmAudio.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAlarmAudio.Size = new System.Drawing.Size(376, 54);
            this.groupBoxAlarmAudio.TabIndex = 19;
            this.groupBoxAlarmAudio.TabStop = false;
            this.groupBoxAlarmAudio.Text = "Alarm Audio";
            // 
            // textBoxAlarmPath
            // 
            this.textBoxAlarmPath.AllowDrop = true;
            this.textBoxAlarmPath.ContextMenuStrip = this.contextMenuAlarmTextBox;
            this.textBoxAlarmPath.Location = new System.Drawing.Point(5, 23);
            this.textBoxAlarmPath.Name = "textBoxAlarmPath";
            this.textBoxAlarmPath.ReadOnly = true;
            this.textBoxAlarmPath.Size = new System.Drawing.Size(286, 20);
            this.textBoxAlarmPath.TabIndex = 26;
            this.textBoxAlarmPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAlarmPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxAlarmPath_DragDrop);
            this.textBoxAlarmPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.AudioPathTextBox_DragEnter);
            this.textBoxAlarmPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAlarmPath_KeyDown);
            // 
            // contextMenuAlarmTextBox
            // 
            this.contextMenuAlarmTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClearAlarmPath});
            this.contextMenuAlarmTextBox.Name = "contextMenuAlarmAudio";
            this.contextMenuAlarmTextBox.Size = new System.Drawing.Size(102, 26);
            // 
            // menuItemClearAlarmPath
            // 
            this.menuItemClearAlarmPath.Name = "menuItemClearAlarmPath";
            this.menuItemClearAlarmPath.Size = new System.Drawing.Size(101, 22);
            this.menuItemClearAlarmPath.Text = "Clear";
            this.menuItemClearAlarmPath.Click += new System.EventHandler(this.menuItemClearAlarmPath_Click);
            // 
            // buttonImportAlarm
            // 
            this.buttonImportAlarm.Location = new System.Drawing.Point(289, 22);
            this.buttonImportAlarm.Name = "buttonImportAlarm";
            this.buttonImportAlarm.Size = new System.Drawing.Size(75, 22);
            this.buttonImportAlarm.TabIndex = 27;
            this.buttonImportAlarm.Text = "Import";
            this.buttonImportAlarm.UseVisualStyleBackColor = true;
            this.buttonImportAlarm.Click += new System.EventHandler(this.buttonImportAlarm_Click);
            // 
            // groupBoxCompleteAction
            // 
            this.groupBoxCompleteAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCompleteAction.Controls.Add(this.radioButtonStop);
            this.groupBoxCompleteAction.Controls.Add(this.radioButtonRepeatFinal);
            this.groupBoxCompleteAction.Controls.Add(this.radioButtonLoop);
            this.groupBoxCompleteAction.Location = new System.Drawing.Point(11, 315);
            this.groupBoxCompleteAction.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCompleteAction.Name = "groupBoxCompleteAction";
            this.groupBoxCompleteAction.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCompleteAction.Size = new System.Drawing.Size(159, 83);
            this.groupBoxCompleteAction.TabIndex = 20;
            this.groupBoxCompleteAction.TabStop = false;
            this.groupBoxCompleteAction.Text = "Action on Complete";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            viewToolStripMenuItem,
            toolToolStripMenuItem,
            helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(399, 24);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // comboTimerPrograms
            // 
            this.comboTimerPrograms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTimerPrograms.FormattingEnabled = true;
            this.comboTimerPrograms.Location = new System.Drawing.Point(4, 17);
            this.comboTimerPrograms.Margin = new System.Windows.Forms.Padding(2);
            this.comboTimerPrograms.Name = "comboTimerPrograms";
            this.comboTimerPrograms.Size = new System.Drawing.Size(296, 21);
            this.comboTimerPrograms.TabIndex = 24;
            this.comboTimerPrograms.SelectedIndexChanged += new System.EventHandler(this.comboTimerPrograms_SelectedIndexChanged);
            // 
            // groupBoxTimerPrograms
            // 
            this.groupBoxTimerPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimerPrograms.Controls.Add(this.comboTimerPrograms);
            this.groupBoxTimerPrograms.Controls.Add(this.buttonRemoveProgram);
            this.groupBoxTimerPrograms.Controls.Add(this.buttonAddTimerProgram);
            this.groupBoxTimerPrograms.Location = new System.Drawing.Point(12, 27);
            this.groupBoxTimerPrograms.Name = "groupBoxTimerPrograms";
            this.groupBoxTimerPrograms.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxTimerPrograms.Size = new System.Drawing.Size(375, 51);
            this.groupBoxTimerPrograms.TabIndex = 25;
            this.groupBoxTimerPrograms.TabStop = false;
            this.groupBoxTimerPrograms.Text = "Timer Programs";
            // 
            // buttonRemoveProgram
            // 
            this.buttonRemoveProgram.AutoSize = true;
            this.buttonRemoveProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRemoveProgram.FlatAppearance.BorderSize = 0;
            this.buttonRemoveProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveProgram.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveProgram.Image")));
            this.buttonRemoveProgram.Location = new System.Drawing.Point(336, 11);
            this.buttonRemoveProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveProgram.Name = "buttonRemoveProgram";
            this.buttonRemoveProgram.Size = new System.Drawing.Size(30, 30);
            this.buttonRemoveProgram.TabIndex = 27;
            this.toolTip.SetToolTip(this.buttonRemoveProgram, "Remove active phase timer program.");
            this.buttonRemoveProgram.UseVisualStyleBackColor = true;
            this.buttonRemoveProgram.Click += new System.EventHandler(this.buttonRemoveProgram_Click);
            // 
            // buttonAddTimerProgram
            // 
            this.buttonAddTimerProgram.AutoSize = true;
            this.buttonAddTimerProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddTimerProgram.FlatAppearance.BorderSize = 0;
            this.buttonAddTimerProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddTimerProgram.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddTimerProgram.Image")));
            this.buttonAddTimerProgram.Location = new System.Drawing.Point(304, 11);
            this.buttonAddTimerProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddTimerProgram.Name = "buttonAddTimerProgram";
            this.buttonAddTimerProgram.Size = new System.Drawing.Size(30, 30);
            this.buttonAddTimerProgram.TabIndex = 26;
            this.toolTip.SetToolTip(this.buttonAddTimerProgram, "Create a new phase timer program.");
            this.buttonAddTimerProgram.UseVisualStyleBackColor = true;
            this.buttonAddTimerProgram.Click += new System.EventHandler(this.buttonAddTimerProgram_Click);
            // 
            // groupBoxAmbience
            // 
            this.groupBoxAmbience.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAmbience.Controls.Add(this.textBoxAmbiencePath);
            this.groupBoxAmbience.Controls.Add(this.buttonImportAmbience);
            this.groupBoxAmbience.Location = new System.Drawing.Point(12, 141);
            this.groupBoxAmbience.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAmbience.Name = "groupBoxAmbience";
            this.groupBoxAmbience.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAmbience.Size = new System.Drawing.Size(376, 54);
            this.groupBoxAmbience.TabIndex = 20;
            this.groupBoxAmbience.TabStop = false;
            this.groupBoxAmbience.Text = "Background Audio";
            // 
            // textBoxAmbiencePath
            // 
            this.textBoxAmbiencePath.AllowDrop = true;
            this.textBoxAmbiencePath.ContextMenuStrip = this.contextMenuAmbienceTextBox;
            this.textBoxAmbiencePath.Location = new System.Drawing.Point(5, 22);
            this.textBoxAmbiencePath.Name = "textBoxAmbiencePath";
            this.textBoxAmbiencePath.ReadOnly = true;
            this.textBoxAmbiencePath.Size = new System.Drawing.Size(286, 20);
            this.textBoxAmbiencePath.TabIndex = 28;
            this.textBoxAmbiencePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAmbiencePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxAmbiencePath_DragDrop);
            this.textBoxAmbiencePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.AudioPathTextBox_DragEnter);
            this.textBoxAmbiencePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAmbiencePath_KeyDown);
            // 
            // contextMenuAmbienceTextBox
            // 
            this.contextMenuAmbienceTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClearAmbiencePath});
            this.contextMenuAmbienceTextBox.Name = "contextMenuAlarmAudio";
            this.contextMenuAmbienceTextBox.Size = new System.Drawing.Size(102, 26);
            // 
            // menuItemClearAmbiencePath
            // 
            this.menuItemClearAmbiencePath.Name = "menuItemClearAmbiencePath";
            this.menuItemClearAmbiencePath.Size = new System.Drawing.Size(101, 22);
            this.menuItemClearAmbiencePath.Text = "Clear";
            this.menuItemClearAmbiencePath.Click += new System.EventHandler(this.menuItemClearAmbiencePath_Click);
            // 
            // buttonImportAmbience
            // 
            this.buttonImportAmbience.Location = new System.Drawing.Point(289, 21);
            this.buttonImportAmbience.Name = "buttonImportAmbience";
            this.buttonImportAmbience.Size = new System.Drawing.Size(75, 22);
            this.buttonImportAmbience.TabIndex = 29;
            this.buttonImportAmbience.Text = "Import";
            this.buttonImportAmbience.UseVisualStyleBackColor = true;
            this.buttonImportAmbience.Click += new System.EventHandler(this.buttonImportAmbience_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuSysTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Phase Timer";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuSysTray
            // 
            this.contextMenuSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStop,
            this.menuItemPause,
            this.menuItemPlay,
            this.toolStripSeparator2,
            this.contextItemExit});
            this.contextMenuSysTray.Name = "contextMenuSysTray";
            this.contextMenuSysTray.Size = new System.Drawing.Size(106, 98);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Enabled = false;
            this.menuItemStop.Name = "menuItemStop";
            this.menuItemStop.Size = new System.Drawing.Size(105, 22);
            this.menuItemStop.Text = "Stop";
            this.menuItemStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // menuItemPause
            // 
            this.menuItemPause.Enabled = false;
            this.menuItemPause.Name = "menuItemPause";
            this.menuItemPause.Size = new System.Drawing.Size(105, 22);
            this.menuItemPause.Text = "Pause";
            this.menuItemPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // menuItemPlay
            // 
            this.menuItemPlay.Name = "menuItemPlay";
            this.menuItemPlay.Size = new System.Drawing.Size(105, 22);
            this.menuItemPlay.Text = "Play";
            this.menuItemPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(102, 6);
            // 
            // contextItemExit
            // 
            this.contextItemExit.Name = "contextItemExit";
            this.contextItemExit.Size = new System.Drawing.Size(105, 22);
            this.contextItemExit.Text = "Exit";
            this.contextItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(48, 2);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(45, 44);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(2, 2);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(45, 44);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPause.Image")));
            this.buttonPause.Location = new System.Drawing.Point(2, 2);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(45, 44);
            this.buttonPause.TabIndex = 10;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Visible = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // panelPlayback
            // 
            this.panelPlayback.Controls.Add(this.buttonPlay);
            this.panelPlayback.Controls.Add(this.buttonPause);
            this.panelPlayback.Controls.Add(this.buttonStop);
            this.panelPlayback.Location = new System.Drawing.Point(295, 353);
            this.panelPlayback.Name = "panelPlayback";
            this.panelPlayback.Size = new System.Drawing.Size(96, 47);
            this.panelPlayback.TabIndex = 26;
            // 
            // buttonDecrementAll
            // 
            this.buttonDecrementAll.Enabled = false;
            this.buttonDecrementAll.Location = new System.Drawing.Point(273, 75);
            this.buttonDecrementAll.Name = "buttonDecrementAll";
            this.buttonDecrementAll.Size = new System.Drawing.Size(96, 23);
            this.buttonDecrementAll.TabIndex = 30;
            this.buttonDecrementAll.Text = "Decrement All";
            this.toolTip.SetToolTip(this.buttonDecrementAll, "Decreases all intervals by 0.25 minutes.");
            this.buttonDecrementAll.UseVisualStyleBackColor = true;
            this.buttonDecrementAll.Click += new System.EventHandler(this.buttonDecrementAll_Click);
            // 
            // buttonIncrementAll
            // 
            this.buttonIncrementAll.Enabled = false;
            this.buttonIncrementAll.Location = new System.Drawing.Point(171, 75);
            this.buttonIncrementAll.Name = "buttonIncrementAll";
            this.buttonIncrementAll.Size = new System.Drawing.Size(96, 23);
            this.buttonIncrementAll.TabIndex = 31;
            this.buttonIncrementAll.Text = "Increment All";
            this.toolTip.SetToolTip(this.buttonIncrementAll, "Increases all intervals by 0.25 minutes.");
            this.buttonIncrementAll.UseVisualStyleBackColor = true;
            this.buttonIncrementAll.Click += new System.EventHandler(this.buttonIncrementAll_Click);
            // 
            // contextMenuImportAlarm
            // 
            this.contextMenuImportAlarm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImportAlarm,
            this.menuItemImportAlarmPresets,
            this.menuItemImportFromWinSounds});
            this.contextMenuImportAlarm.Name = "contextMenuImportAlarm";
            this.contextMenuImportAlarm.Size = new System.Drawing.Size(201, 70);
            // 
            // menuItemImportAlarm
            // 
            this.menuItemImportAlarm.Name = "menuItemImportAlarm";
            this.menuItemImportAlarm.Size = new System.Drawing.Size(200, 22);
            this.menuItemImportAlarm.Text = "...";
            this.menuItemImportAlarm.ToolTipText = "Import alarm audio file.\r\nThis copies the picked file to the timer program\'s fold" +
    "er.";
            this.menuItemImportAlarm.Click += new System.EventHandler(this.menuItemImportAlarm_Click);
            // 
            // menuItemImportAlarmPresets
            // 
            this.menuItemImportAlarmPresets.Name = "menuItemImportAlarmPresets";
            this.menuItemImportAlarmPresets.Size = new System.Drawing.Size(200, 22);
            this.menuItemImportAlarmPresets.Text = "From Presets...";
            this.menuItemImportAlarmPresets.ToolTipText = "Import alarm audio file from the application\'s default assets.\r\nThis copies the p" +
    "icked file to the timer program\'s folder.";
            this.menuItemImportAlarmPresets.Click += new System.EventHandler(this.menuItemImportAlarmPresets_Click);
            // 
            // menuItemImportFromWinSounds
            // 
            this.menuItemImportFromWinSounds.Name = "menuItemImportFromWinSounds";
            this.menuItemImportFromWinSounds.Size = new System.Drawing.Size(200, 22);
            this.menuItemImportFromWinSounds.Text = "From Window Sounds...";
            this.menuItemImportFromWinSounds.ToolTipText = "Import alarm audio file from the Windows sound folder.\r\nThis copies the picked fi" +
    "le to the timer program\'s folder.";
            this.menuItemImportFromWinSounds.Click += new System.EventHandler(this.menuItemImportFromWinSounds_Click);
            // 
            // contextMenuAmbience
            // 
            this.contextMenuAmbience.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImportAmbience,
            this.menuItemImportAmbiencePresets,
            this.menuItemImportFromMusic});
            this.contextMenuAmbience.Name = "contextMenuAmbience";
            this.contextMenuAmbience.Size = new System.Drawing.Size(167, 70);
            // 
            // menuItemImportAmbience
            // 
            this.menuItemImportAmbience.Name = "menuItemImportAmbience";
            this.menuItemImportAmbience.Size = new System.Drawing.Size(166, 22);
            this.menuItemImportAmbience.Text = "...";
            this.menuItemImportAmbience.ToolTipText = "Import background audio file.\r\nThis copies the picked file to the timer program\'s" +
    " folder.";
            this.menuItemImportAmbience.Click += new System.EventHandler(this.menuItemImportAmbience_Click);
            // 
            // menuItemImportAmbiencePresets
            // 
            this.menuItemImportAmbiencePresets.Name = "menuItemImportAmbiencePresets";
            this.menuItemImportAmbiencePresets.Size = new System.Drawing.Size(166, 22);
            this.menuItemImportAmbiencePresets.Text = "From Presets...";
            this.menuItemImportAmbiencePresets.Click += new System.EventHandler(this.menuItemImportAmbiencePresets_Click);
            // 
            // menuItemImportFromMusic
            // 
            this.menuItemImportFromMusic.Name = "menuItemImportFromMusic";
            this.menuItemImportFromMusic.Size = new System.Drawing.Size(166, 22);
            this.menuItemImportFromMusic.Text = "From My Music...";
            this.menuItemImportFromMusic.ToolTipText = "Import background audio file from your Music folder.\r\nThis copies the picked file" +
    " to the timer program\'s folder.";
            this.menuItemImportFromMusic.Click += new System.EventHandler(this.menuItemImportFromMusic_Click);
            // 
            // textBoxIntervals
            // 
            this.textBoxIntervals.Location = new System.Drawing.Point(6, 19);
            this.textBoxIntervals.Name = "textBoxIntervals";
            this.textBoxIntervals.Size = new System.Drawing.Size(363, 20);
            this.textBoxIntervals.TabIndex = 28;
            this.textBoxIntervals.TextChanged += new System.EventHandler(this.textBoxIntervals_TextChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelTime.Location = new System.Drawing.Point(292, 320);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(95, 20);
            this.labelTime.TabIndex = 30;
            this.labelTime.Text = "00:00 / 00:00";
            // 
            // groupBoxIntervals
            // 
            this.groupBoxIntervals.Controls.Add(this.buttonIncrementAll);
            this.groupBoxIntervals.Controls.Add(this.buttonDecrementAll);
            this.groupBoxIntervals.Controls.Add(this.textBoxIntervals);
            this.groupBoxIntervals.Controls.Add(this.timeLineStrip);
            this.groupBoxIntervals.Location = new System.Drawing.Point(12, 200);
            this.groupBoxIntervals.Name = "groupBoxIntervals";
            this.groupBoxIntervals.Size = new System.Drawing.Size(375, 110);
            this.groupBoxIntervals.TabIndex = 31;
            this.groupBoxIntervals.TabStop = false;
            this.groupBoxIntervals.Text = "Intervals (space separated minutes)";
            // 
            // timeLineStrip
            // 
            this.timeLineStrip.Location = new System.Drawing.Point(6, 45);
            this.timeLineStrip.Name = "timeLineStrip";
            this.timeLineStrip.Size = new System.Drawing.Size(363, 24);
            this.timeLineStrip.TabIndex = 27;
            this.timeLineStrip.Text = "timeLineStrip1";
            // 
            // buttonVolumeControls
            // 
            this.buttonVolumeControls.AutoSize = true;
            this.buttonVolumeControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonVolumeControls.FlatAppearance.BorderSize = 0;
            this.buttonVolumeControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolumeControls.Image = global::PhaseTimer.Properties.Resources.VolControls;
            this.buttonVolumeControls.Location = new System.Drawing.Point(262, 360);
            this.buttonVolumeControls.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVolumeControls.Name = "buttonVolumeControls";
            this.buttonVolumeControls.Size = new System.Drawing.Size(31, 31);
            this.buttonVolumeControls.TabIndex = 12;
            this.buttonVolumeControls.UseVisualStyleBackColor = true;
            this.buttonVolumeControls.Click += new System.EventHandler(this.buttonVolumeControls_Click);
            // 
            // timerUpdateTimeLine
            // 
            this.timerUpdateTimeLine.Interval = 50;
            this.timerUpdateTimeLine.Tick += new System.EventHandler(this.timerUpdateUI_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 408);
            this.Controls.Add(this.buttonVolumeControls);
            this.Controls.Add(this.groupBoxIntervals);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.panelPlayback);
            this.Controls.Add(this.groupBoxAmbience);
            this.Controls.Add(this.groupBoxTimerPrograms);
            this.Controls.Add(this.groupBoxCompleteAction);
            this.Controls.Add(this.groupBoxAlarmAudio);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Phase Timer";
            this.groupBoxAlarmAudio.ResumeLayout(false);
            this.groupBoxAlarmAudio.PerformLayout();
            this.contextMenuAlarmTextBox.ResumeLayout(false);
            this.groupBoxCompleteAction.ResumeLayout(false);
            this.groupBoxCompleteAction.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxTimerPrograms.ResumeLayout(false);
            this.groupBoxTimerPrograms.PerformLayout();
            this.groupBoxAmbience.ResumeLayout(false);
            this.groupBoxAmbience.PerformLayout();
            this.contextMenuAmbienceTextBox.ResumeLayout(false);
            this.contextMenuSysTray.ResumeLayout(false);
            this.panelPlayback.ResumeLayout(false);
            this.contextMenuImportAlarm.ResumeLayout(false);
            this.contextMenuAmbience.ResumeLayout(false);
            this.groupBoxIntervals.ResumeLayout(false);
            this.groupBoxIntervals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonStop;
        private System.Windows.Forms.RadioButton radioButtonRepeatFinal;
        private System.Windows.Forms.RadioButton radioButtonLoop;
        private System.Windows.Forms.GroupBox groupBoxAlarmAudio;
        private System.Windows.Forms.GroupBox groupBoxCompleteAction;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ComboBox comboTimerPrograms;
        private System.Windows.Forms.GroupBox groupBoxTimerPrograms;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.GroupBox groupBoxAmbience;
        private System.Windows.Forms.ToolStripMenuItem menuItemMinToTray;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAlwaysMinimize;
        private System.Windows.Forms.ContextMenuStrip contextMenuSysTray;
        private System.Windows.Forms.ToolStripMenuItem menuItemStop;
        private System.Windows.Forms.ToolStripMenuItem menuItemPause;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contextItemExit;
        private System.Windows.Forms.TextBox textBoxAlarmPath;
        private System.Windows.Forms.TextBox textBoxAmbiencePath;
        private System.Windows.Forms.Button buttonAddTimerProgram;
        private System.Windows.Forms.Button buttonRemoveProgram;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenTimerProgDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenActiveProgDir;
        private System.Windows.Forms.Button buttonImportAlarm;
        private System.Windows.Forms.Button buttonImportAmbience;
        private System.Windows.Forms.Panel panelPlayback;
        private System.Windows.Forms.ToolStripMenuItem buttonCleanTimerProgFolder;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuImportAlarm;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportAlarm;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportAlarmPresets;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportFromWinSounds;
        private System.Windows.Forms.ContextMenuStrip contextMenuAmbience;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportAmbience;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportFromMusic;
        private TimeLineStrip timeLineStrip;
        private System.Windows.Forms.TextBox textBoxIntervals;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ToolStripMenuItem menuItemImportAmbiencePresets;
        private System.Windows.Forms.GroupBox groupBoxIntervals;
        private System.Windows.Forms.Button buttonIncrementAll;
        private System.Windows.Forms.Button buttonDecrementAll;
        private System.Windows.Forms.Button buttonVolumeControls;
        private System.Windows.Forms.ContextMenuStrip contextMenuAlarmTextBox;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearAlarmPath;
        private System.Windows.Forms.ContextMenuStrip contextMenuAmbienceTextBox;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearAmbiencePath;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteMainFolder;
        private System.Windows.Forms.Timer timerUpdateTimeLine;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenUserManual;
    }
}

