namespace PhaseTimer.Forms
{
    partial class VolumeSettingsDialog
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
            this.labelAmbienceVolume = new System.Windows.Forms.Label();
            this.trackBarAmbienceVolume = new System.Windows.Forms.TrackBar();
            this.labelAlarmVolume = new System.Windows.Forms.Label();
            this.trackBarAlarmVolume = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAlarmBalance = new System.Windows.Forms.Label();
            this.trackBarAlarmBalance = new System.Windows.Forms.TrackBar();
            this.labelAmbienceBalance = new System.Windows.Forms.Label();
            this.trackBarAmbienceBalance = new System.Windows.Forms.TrackBar();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelNumberInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmbienceVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlarmVolume)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlarmBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmbienceBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAmbienceVolume
            // 
            this.labelAmbienceVolume.AutoSize = true;
            this.labelAmbienceVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAmbienceVolume.Location = new System.Drawing.Point(3, 64);
            this.labelAmbienceVolume.Name = "labelAmbienceVolume";
            this.labelAmbienceVolume.Size = new System.Drawing.Size(179, 13);
            this.labelAmbienceVolume.TabIndex = 17;
            this.labelAmbienceVolume.Text = "Ambience Volume";
            this.labelAmbienceVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarAmbienceVolume
            // 
            this.trackBarAmbienceVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarAmbienceVolume.LargeChange = 10;
            this.trackBarAmbienceVolume.Location = new System.Drawing.Point(3, 80);
            this.trackBarAmbienceVolume.Maximum = 100;
            this.trackBarAmbienceVolume.Name = "trackBarAmbienceVolume";
            this.trackBarAmbienceVolume.Size = new System.Drawing.Size(179, 45);
            this.trackBarAmbienceVolume.SmallChange = 5;
            this.trackBarAmbienceVolume.TabIndex = 16;
            this.trackBarAmbienceVolume.TickFrequency = 25;
            this.trackBarAmbienceVolume.Value = 100;
            this.trackBarAmbienceVolume.ValueChanged += new System.EventHandler(this.trackBarAmbienceVolumeUpdateHandler);
            this.trackBarAmbienceVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAmbienceVolumeUpdateHandler);
            this.trackBarAmbienceVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyTrackBar_MouseUp);
            // 
            // labelAlarmVolume
            // 
            this.labelAlarmVolume.AutoSize = true;
            this.labelAlarmVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlarmVolume.Location = new System.Drawing.Point(3, 0);
            this.labelAlarmVolume.Name = "labelAlarmVolume";
            this.labelAlarmVolume.Size = new System.Drawing.Size(179, 13);
            this.labelAlarmVolume.TabIndex = 19;
            this.labelAlarmVolume.Text = "Alarm Volume";
            this.labelAlarmVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarAlarmVolume
            // 
            this.trackBarAlarmVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarAlarmVolume.LargeChange = 10;
            this.trackBarAlarmVolume.Location = new System.Drawing.Point(3, 16);
            this.trackBarAlarmVolume.Maximum = 100;
            this.trackBarAlarmVolume.Name = "trackBarAlarmVolume";
            this.trackBarAlarmVolume.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlarmVolume.SmallChange = 5;
            this.trackBarAlarmVolume.TabIndex = 18;
            this.trackBarAlarmVolume.TickFrequency = 25;
            this.trackBarAlarmVolume.Value = 100;
            this.trackBarAlarmVolume.ValueChanged += new System.EventHandler(this.trackBarAlarmVolumeUpdateHandler);
            this.trackBarAlarmVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAlarmVolumeUpdateHandler);
            this.trackBarAlarmVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyTrackBar_MouseUp);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.labelAlarmVolume, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAlarmVolume, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelAmbienceVolume, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAmbienceVolume, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelAlarmBalance, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAlarmBalance, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelAmbienceBalance, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAmbienceBalance, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonReset, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.labelNumberInfo, 0, 9);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(370, 165);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // labelAlarmBalance
            // 
            this.labelAlarmBalance.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelAlarmBalance, 2);
            this.labelAlarmBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlarmBalance.Location = new System.Drawing.Point(188, 0);
            this.labelAlarmBalance.Name = "labelAlarmBalance";
            this.labelAlarmBalance.Size = new System.Drawing.Size(179, 13);
            this.labelAlarmBalance.TabIndex = 21;
            this.labelAlarmBalance.Text = "Alarm Balance";
            this.labelAlarmBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarAlarmBalance
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.trackBarAlarmBalance, 2);
            this.trackBarAlarmBalance.LargeChange = 10;
            this.trackBarAlarmBalance.Location = new System.Drawing.Point(188, 16);
            this.trackBarAlarmBalance.Maximum = 100;
            this.trackBarAlarmBalance.Minimum = -100;
            this.trackBarAlarmBalance.Name = "trackBarAlarmBalance";
            this.trackBarAlarmBalance.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlarmBalance.SmallChange = 5;
            this.trackBarAlarmBalance.TabIndex = 20;
            this.trackBarAlarmBalance.TickFrequency = 100;
            this.trackBarAlarmBalance.ValueChanged += new System.EventHandler(this.trackBarAlarmBalanceUpdateHandler);
            this.trackBarAlarmBalance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAlarmBalanceUpdateHandler);
            this.trackBarAlarmBalance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyTrackBar_MouseUp);
            // 
            // labelAmbienceBalance
            // 
            this.labelAmbienceBalance.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelAmbienceBalance, 2);
            this.labelAmbienceBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAmbienceBalance.Location = new System.Drawing.Point(188, 64);
            this.labelAmbienceBalance.Name = "labelAmbienceBalance";
            this.labelAmbienceBalance.Size = new System.Drawing.Size(179, 13);
            this.labelAmbienceBalance.TabIndex = 22;
            this.labelAmbienceBalance.Text = "Ambience Balance";
            this.labelAmbienceBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarAmbienceBalance
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.trackBarAmbienceBalance, 2);
            this.trackBarAmbienceBalance.LargeChange = 10;
            this.trackBarAmbienceBalance.Location = new System.Drawing.Point(188, 80);
            this.trackBarAmbienceBalance.Maximum = 100;
            this.trackBarAmbienceBalance.Minimum = -100;
            this.trackBarAmbienceBalance.Name = "trackBarAmbienceBalance";
            this.trackBarAmbienceBalance.Size = new System.Drawing.Size(179, 45);
            this.trackBarAmbienceBalance.SmallChange = 5;
            this.trackBarAmbienceBalance.TabIndex = 23;
            this.trackBarAmbienceBalance.TickFrequency = 100;
            this.trackBarAmbienceBalance.ValueChanged += new System.EventHandler(this.trackBarAmbienceBalanceUpdateHandler);
            this.trackBarAmbienceBalance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAmbienceBalanceUpdateHandler);
            this.trackBarAmbienceBalance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnyTrackBar_MouseUp);
            // 
            // buttonReset
            // 
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Location = new System.Drawing.Point(299, 139);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(68, 23);
            this.buttonReset.TabIndex = 24;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelNumberInfo
            // 
            this.labelNumberInfo.AutoSize = true;
            this.labelNumberInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberInfo.Location = new System.Drawing.Point(3, 136);
            this.labelNumberInfo.Name = "labelNumberInfo";
            this.labelNumberInfo.Size = new System.Drawing.Size(46, 21);
            this.labelNumberInfo.TabIndex = 25;
            this.labelNumberInfo.Text = "         ";
            // 
            // VolumeSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(394, 189);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeSettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volume Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmbienceVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlarmVolume)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlarmBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmbienceBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAmbienceVolume;
        private System.Windows.Forms.TrackBar trackBarAmbienceVolume;
        private System.Windows.Forms.TrackBar trackBarAlarmVolume;
        private System.Windows.Forms.Label labelAlarmVolume;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelAlarmBalance;
        private System.Windows.Forms.TrackBar trackBarAlarmBalance;
        private System.Windows.Forms.Label labelAmbienceBalance;
        private System.Windows.Forms.TrackBar trackBarAmbienceBalance;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelNumberInfo;
    }
}