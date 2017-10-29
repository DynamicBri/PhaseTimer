namespace PhaseTimer.Forms
{
    partial class MultiIntervalTimerTestForm
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
            timer.Dispose();
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label4;
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRunTime = new System.Windows.Forms.Label();
            this.labelTimeSinceLastMarker = new System.Windows.Forms.Label();
            this.labelTimeUntilNextMarker = new System.Windows.Forms.Label();
            this.labelIterationRuntime = new System.Windows.Forms.Label();
            this.labelLoopCount = new System.Windows.Forms.Label();
            this.labelPlayState = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIntervals = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioStop = new System.Windows.Forms.RadioButton();
            this.radioRepeatFinal = new System.Windows.Forms.RadioButton();
            this.radioLoop = new System.Windows.Forms.RadioButton();
            this.labelLastMarkerDuration = new System.Windows.Forms.Label();
            this.labelRemainingRunTime = new System.Windows.Forms.Label();
            this.labelLastMarkerIndex = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 4);
            label5.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(80, 13);
            label5.TabIndex = 21;
            label5.Text = "Total Run Time";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 67);
            label6.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(119, 13);
            label6.TabIndex = 22;
            label6.Text = "Time Since Last Marker";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 88);
            label7.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(115, 13);
            label7.TabIndex = 23;
            label7.Text = "Time Until Next Marker";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 130);
            label3.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 13);
            label3.TabIndex = 24;
            label3.Text = "PlayState";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(3, 109);
            label8.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 13);
            label8.TabIndex = 26;
            label8.Text = "Loop Count";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 46);
            label9.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(94, 13);
            label9.TabIndex = 28;
            label9.Text = "Iteration Run Time";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(350, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(81, 33);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(437, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(81, 33);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPause.Location = new System.Drawing.Point(263, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(81, 33);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelRemainingRunTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRunTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelIterationRuntime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeSinceLastMarker, 1, 3);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeUntilNextMarker, 1, 4);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelLoopCount, 1, 5);
            this.tableLayoutPanel1.Controls.Add(label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPlayState, 1, 6);
            this.tableLayoutPanel1.Controls.Add(label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelLastMarkerDuration, 1, 7);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelLastMarkerIndex, 1, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 208);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // labelRunTime
            // 
            this.labelRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(134, 4);
            this.labelRunTime.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(106, 13);
            this.labelRunTime.TabIndex = 16;
            this.labelRunTime.Text = "00:00:00";
            // 
            // labelTimeSinceLastMarker
            // 
            this.labelTimeSinceLastMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeSinceLastMarker.AutoSize = true;
            this.labelTimeSinceLastMarker.Location = new System.Drawing.Point(134, 67);
            this.labelTimeSinceLastMarker.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelTimeSinceLastMarker.Name = "labelTimeSinceLastMarker";
            this.labelTimeSinceLastMarker.Size = new System.Drawing.Size(106, 13);
            this.labelTimeSinceLastMarker.TabIndex = 19;
            this.labelTimeSinceLastMarker.Text = "00:00:00";
            // 
            // labelTimeUntilNextMarker
            // 
            this.labelTimeUntilNextMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeUntilNextMarker.AutoSize = true;
            this.labelTimeUntilNextMarker.Location = new System.Drawing.Point(134, 88);
            this.labelTimeUntilNextMarker.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelTimeUntilNextMarker.Name = "labelTimeUntilNextMarker";
            this.labelTimeUntilNextMarker.Size = new System.Drawing.Size(106, 13);
            this.labelTimeUntilNextMarker.TabIndex = 18;
            this.labelTimeUntilNextMarker.Text = "00:00:00";
            // 
            // labelIterationRuntime
            // 
            this.labelIterationRuntime.AutoSize = true;
            this.labelIterationRuntime.Location = new System.Drawing.Point(134, 46);
            this.labelIterationRuntime.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelIterationRuntime.Name = "labelIterationRuntime";
            this.labelIterationRuntime.Size = new System.Drawing.Size(49, 13);
            this.labelIterationRuntime.TabIndex = 29;
            this.labelIterationRuntime.Text = "00:00:00";
            // 
            // labelLoopCount
            // 
            this.labelLoopCount.AutoSize = true;
            this.labelLoopCount.Location = new System.Drawing.Point(137, 109);
            this.labelLoopCount.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.labelLoopCount.Name = "labelLoopCount";
            this.labelLoopCount.Size = new System.Drawing.Size(13, 13);
            this.labelLoopCount.TabIndex = 27;
            this.labelLoopCount.Text = "0";
            // 
            // labelPlayState
            // 
            this.labelPlayState.AutoSize = true;
            this.labelPlayState.Location = new System.Drawing.Point(137, 130);
            this.labelPlayState.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.labelPlayState.Name = "labelPlayState";
            this.labelPlayState.Size = new System.Drawing.Size(47, 13);
            this.labelPlayState.TabIndex = 25;
            this.labelPlayState.Text = "Stopped";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 239);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(506, 142);
            this.richTextBoxLog.TabIndex = 22;
            this.richTextBoxLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Intervals";
            // 
            // textBoxIntervals
            // 
            this.textBoxIntervals.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIntervals.Location = new System.Drawing.Point(331, 58);
            this.textBoxIntervals.Name = "textBoxIntervals";
            this.textBoxIntervals.Size = new System.Drawing.Size(187, 27);
            this.textBoxIntervals.TabIndex = 24;
            this.textBoxIntervals.Text = "0.1   0.1   0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Log:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioStop);
            this.groupBox1.Controls.Add(this.radioRepeatFinal);
            this.groupBox1.Controls.Add(this.radioLoop);
            this.groupBox1.Location = new System.Drawing.Point(274, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 90);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer End Action";
            // 
            // radioStop
            // 
            this.radioStop.AutoSize = true;
            this.radioStop.Checked = true;
            this.radioStop.Location = new System.Drawing.Point(5, 18);
            this.radioStop.Margin = new System.Windows.Forms.Padding(2);
            this.radioStop.Name = "radioStop";
            this.radioStop.Size = new System.Drawing.Size(47, 17);
            this.radioStop.TabIndex = 14;
            this.radioStop.TabStop = true;
            this.radioStop.Text = "Stop";
            this.radioStop.UseVisualStyleBackColor = true;
            this.radioStop.CheckedChanged += new System.EventHandler(this.radioStop_CheckedChanged);
            // 
            // radioRepeatFinal
            // 
            this.radioRepeatFinal.AutoSize = true;
            this.radioRepeatFinal.Location = new System.Drawing.Point(5, 57);
            this.radioRepeatFinal.Margin = new System.Windows.Forms.Padding(2);
            this.radioRepeatFinal.Name = "radioRepeatFinal";
            this.radioRepeatFinal.Size = new System.Drawing.Size(123, 17);
            this.radioRepeatFinal.TabIndex = 15;
            this.radioRepeatFinal.Text = "Repeat Final Interval";
            this.radioRepeatFinal.UseVisualStyleBackColor = true;
            this.radioRepeatFinal.CheckedChanged += new System.EventHandler(this.radioRepeatFinal_CheckedChanged);
            // 
            // radioLoop
            // 
            this.radioLoop.AutoSize = true;
            this.radioLoop.Location = new System.Drawing.Point(5, 38);
            this.radioLoop.Margin = new System.Windows.Forms.Padding(2);
            this.radioLoop.Name = "radioLoop";
            this.radioLoop.Size = new System.Drawing.Size(63, 17);
            this.radioLoop.TabIndex = 16;
            this.radioLoop.Text = "Loop All";
            this.radioLoop.UseVisualStyleBackColor = true;
            this.radioLoop.CheckedChanged += new System.EventHandler(this.radioLoop_CheckedChanged);
            // 
            // labelLastMarkerDuration
            // 
            this.labelLastMarkerDuration.AutoSize = true;
            this.labelLastMarkerDuration.Location = new System.Drawing.Point(137, 151);
            this.labelLastMarkerDuration.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.labelLastMarkerDuration.Name = "labelLastMarkerDuration";
            this.labelLastMarkerDuration.Size = new System.Drawing.Size(27, 13);
            this.labelLastMarkerDuration.TabIndex = 30;
            this.labelLastMarkerDuration.Text = "N/A";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 151);
            label11.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(131, 13);
            label11.TabIndex = 31;
            label11.Text = "Last Marker Duration (MS)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 25);
            label10.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(106, 13);
            label10.TabIndex = 28;
            label10.Text = "Remaining Run Time";
            // 
            // labelRemainingRunTime
            // 
            this.labelRemainingRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRemainingRunTime.AutoSize = true;
            this.labelRemainingRunTime.Location = new System.Drawing.Point(134, 25);
            this.labelRemainingRunTime.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelRemainingRunTime.Name = "labelRemainingRunTime";
            this.labelRemainingRunTime.Size = new System.Drawing.Size(106, 13);
            this.labelRemainingRunTime.TabIndex = 32;
            this.labelRemainingRunTime.Text = "00:00:00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 172);
            label4.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(92, 13);
            label4.TabIndex = 33;
            label4.Text = "Last Marker Index";
            // 
            // labelLastMarkerIndex
            // 
            this.labelLastMarkerIndex.AutoSize = true;
            this.labelLastMarkerIndex.Location = new System.Drawing.Point(137, 172);
            this.labelLastMarkerIndex.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.labelLastMarkerIndex.Name = "labelLastMarkerIndex";
            this.labelLastMarkerIndex.Size = new System.Drawing.Size(27, 13);
            this.labelLastMarkerIndex.TabIndex = 34;
            this.labelLastMarkerIndex.Text = "N/A";
            // 
            // MultiIntervalTimerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 393);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIntervals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "MultiIntervalTimerTestForm";
            this.Text = "MultiIntervalTimerTestForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.Label labelTimeSinceLastMarker;
        private System.Windows.Forms.Label labelTimeUntilNextMarker;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIntervals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPlayState;
        private System.Windows.Forms.Label labelLoopCount;
        private System.Windows.Forms.Label labelIterationRuntime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioStop;
        private System.Windows.Forms.RadioButton radioRepeatFinal;
        private System.Windows.Forms.RadioButton radioLoop;
        private System.Windows.Forms.Label labelLastMarkerDuration;
        private System.Windows.Forms.Label labelRemainingRunTime;
        private System.Windows.Forms.Label labelLastMarkerIndex;
    }
}