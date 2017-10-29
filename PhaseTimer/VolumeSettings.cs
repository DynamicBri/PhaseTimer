using System;

namespace PhaseTimer
{
    /// <summary>
    /// Represents amplification and balance settings for the audio of a timer program.
    /// </summary>
    public class VolumeSettings
    {
        private int alarmVolume = 100;
        /// <summary>
        /// Gets or sets the volume setting to use for alarm playback (0-100).
        /// </summary>
        public int AlarmVolume
        {
            get => alarmVolume;
            set
            {
                if (value != alarmVolume)
                {
                    alarmVolume = value;
                    OnModified();
                }
            }
        }

        private int ambienceVolume = 100;
        /// <summary>
        /// Gets or sets the volume setting to use for ambience playback (0-100).
        /// </summary>
        public int AmbienceVolume
        {
            get => ambienceVolume;
            set
            {
                if (value != ambienceVolume)
                {
                    ambienceVolume = value;
                    OnModified();
                }
            }
        }

        private double alarmBalance;
        /// <summary>
        /// Gets or sets the left-right balance for the alarm. -1 is left, 0 center, and 1 right.
        /// </summary>
        public double AlarmBalance
        {
            get => alarmBalance;
            set
            {
                if (value != alarmBalance)
                {
                    alarmBalance = value;
                    OnModified();
                }
            }
        }

        private double ambienceBalance;
        /// <summary>
        /// Gets or sets the left-right balance for the ambience. -1 is left, 0 center, and 1 right.
        /// </summary>
        public double AmbienceBalance
        {
            get => ambienceBalance;
            set
            {
                if (value != ambienceBalance)
                {
                    ambienceBalance = value;
                    OnModified();
                }
            }
        }

        public VolumeSettings(int alarmVolume, int ambienceVolume, double alarmBalance, double ambienceBalance)
        {
            this.alarmVolume = alarmVolume;
            this.ambienceVolume = ambienceVolume;
            this.alarmBalance = alarmBalance;
            this.ambienceBalance = ambienceBalance;
        }

        public VolumeSettings() { }

        public event EventHandler Modified;

        protected virtual void OnModified()
        {
            Modified?.Invoke(this, EventArgs.Empty);
        }

        public void ResetToDefaults()
        {
            AlarmVolume = 100;
            AmbienceVolume = 100;
            AlarmBalance = 0;
            AmbienceBalance = 0;
        }
    }
}
