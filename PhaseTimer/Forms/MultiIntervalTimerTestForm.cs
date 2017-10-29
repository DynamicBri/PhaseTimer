using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PhaseTimer.Forms
{
    public partial class MultiIntervalTimerTestForm : Form
    {
        private MultiIntervalTimer timer = new MultiIntervalTimer();

        public MultiIntervalTimerTestForm()
        {
            InitializeComponent();
            SetUiState(PlayState.Stopped);
            timer.PlayStateChanged += Timer_PlayStateChanged;
            timer.SecondElapsed += Timer_SecondElapsed;
            timer.MarkerReached += (s, e) => SubmitLog($"Marker reached (Marker index: {e})");
        }

        private void Timer_SecondElapsed(object sender, EventArgs e)
        {
            //SubmitLog("Second elapsed");
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            timer.BeginTimeAccess();
            var span = timer.TotalRunTime;
            labelRunTime.Text = $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            span = timer.RemainingRuntime;

            if (span == TimeSpan.MaxValue)
            {
                labelRemainingRunTime.Text = "Infinity";
            }
            else
            {
                labelRemainingRunTime.Text = $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            }

            span = timer.TimeSinceLastMarker;

            if (span == TimeSpan.MinValue)
            {
                labelTimeSinceLastMarker.Text = "N/A";
            }
            else
            {
                labelTimeSinceLastMarker.Text = $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            }

            span = timer.TimeUntilNextMarker;
            labelTimeUntilNextMarker.Text = $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            span = timer.IterationRunTime;
            labelIterationRuntime.Text = $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            labelLoopCount.Text = timer.LoopCount.ToString();
            labelLastMarkerIndex.Text = timer.LastTimeMarkerIndex.ToString();
            timer.EndTimeAccess();
        }

        private void Timer_PlayStateChanged(object sender, EventArgs e)
        {
            SetUiState(timer.PlayState);
            Timer_SecondElapsed(null, EventArgs.Empty);
            SubmitLog("PlayState changed to " + timer.PlayState);
            UpdateLabels();
        }

        private void SubmitLog(string line)
        {
            richTextBoxLog.AppendText($"-{line}\n");
        }

        private void SetUiState(PlayState playState)
        {
            labelPlayState.Text = playState.ToString();

            switch (playState)
            {
                case PlayState.Paused:
                    buttonStart.Enabled = true;
                    buttonPause.Enabled = false;
                    break;

                case PlayState.Stopped:
                    buttonPause.Enabled = false;
                    buttonStop.Enabled = false;
                    buttonStart.Enabled = true;
                    break;

                case PlayState.Playing:
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                    buttonPause.Enabled = true;
                    break;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Only load markers if timer stopped.
            if (timer.PlayState == PlayState.Stopped)
            {
                double[] numbers = textBoxIntervals.Text.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).Select(num => double.Parse(num)).ToArray();

                timer.LoadTimeMarkersFromMinIntervals(numbers);
            }

            labelLastMarkerDuration.Text = timer.LastIntevalDuration.ToString();
            timer.Start();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            timer.Pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void radioLoop_CheckedChanged(object sender, EventArgs e)
        {
            timer.TimerEndAction = TimerEndAction.LoopAll;
        }

        private void radioRepeatFinal_CheckedChanged(object sender, EventArgs e)
        {
            timer.TimerEndAction = TimerEndAction.RepeatLastInterval;
        }

        private void radioStop_CheckedChanged(object sender, EventArgs e)
        {
            timer.TimerEndAction = TimerEndAction.Stop;
        }
    }
}
