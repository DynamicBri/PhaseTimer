using System;
using System.Windows.Forms;

namespace PhaseTimer.Forms
{
    public partial class VolumeSettingsDialog : Form
    {
        private VolumeSettings volSettings;

        public VolumeSettings VolumeSettings
        {
            get => volSettings;
            set
            {
                if (volSettings != value)
                {
                    volSettings = value;

                    if (volSettings != null)
                    {
                        trackBarAlarmVolume.Value = volSettings.AlarmVolume;
                        trackBarAmbienceVolume.Value = volSettings.AmbienceVolume;
                        trackBarAlarmBalance.Value = (int)(volSettings.AlarmBalance * 100 + 0.5);
                        trackBarAmbienceBalance.Value = (int)(volSettings.AmbienceBalance * 100 + 0.5);
                    }
                    else
                    {
                        trackBarAlarmVolume.Value = 100;
                        trackBarAmbienceVolume.Value = 100;
                        trackBarAlarmBalance.Value = 0;
                        trackBarAmbienceBalance.Value = 0;
                    }
                }
            }
        }

        public VolumeSettingsDialog()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            trackBarAlarmVolume.Value = 100;
            trackBarAmbienceVolume.Value = 100;
            trackBarAlarmBalance.Value = 0;
            trackBarAmbienceBalance.Value = 0;
            labelNumberInfo.Text = string.Empty;
        }

        private void trackBarAlarmVolumeUpdateHandler(object sender, EventArgs e)
        {
            if (volSettings == null)
                return;

            volSettings.AlarmVolume = trackBarAlarmVolume.Value;
            labelNumberInfo.Text = trackBarAlarmVolume.Value + "%";
        }

        private void trackBarAmbienceVolumeUpdateHandler(object sender, EventArgs e)
        {
            if (volSettings == null)
                return;

            volSettings.AmbienceVolume = trackBarAmbienceVolume.Value;
            labelNumberInfo.Text = trackBarAmbienceVolume.Value + "%";
        }

        private void trackBarAlarmBalanceUpdateHandler(object sender, EventArgs e)
        {
            if (volSettings == null)
                return;

            volSettings.AlarmBalance = (double)Math.Round((decimal)(trackBarAlarmBalance.Value / 100.0), 2);
            labelNumberInfo.Text = Math.Round((decimal)trackBarAlarmBalance.Value, 2).ToString();
        }

        private void trackBarAmbienceBalanceUpdateHandler(object sender, EventArgs e)
        {
            if (volSettings == null)
                return;

            volSettings.AmbienceBalance = (double)Math.Round((decimal)(trackBarAmbienceBalance.Value / 100.0), 2);
            labelNumberInfo.Text = Math.Round((decimal)trackBarAmbienceBalance.Value, 2).ToString();
        }

        private void AnyTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            labelNumberInfo.Text = string.Empty;
        }
    }
}
