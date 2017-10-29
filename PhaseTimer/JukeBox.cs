using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhaseTimer
{
    /// <summary>
    /// An audio file player that has a loop mode.
    /// </summary>
    class JukeBox : IDisposable
    {
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private bool loop;
        private string fileName;

        /// <summary>
        /// Gets or sets the scrub position of the audio in milliseconds.
        /// </summary>
        public int Position
        {
            get => (int)(mediaPlayer.Position.TotalMilliseconds + 05);
            set => mediaPlayer.Position = TimeSpan.FromMilliseconds(value);
        }

        public PlayState PlayState { get; private set; }

        /// <summary>
        /// Occurs when the media is opened.
        /// </summary>
        public event EventHandler MediaOpened
        {
            add => mediaPlayer.MediaOpened += value;
            remove => mediaPlayer.MediaOpened -= value;
        }

        /// <summary>
        /// Closes the currently loaded file and opens the specified audio.
        /// </summary>
        /// <param name="filePath">If null or empty, closes the underlying media player.</param>
        public void Open(string filePath)
        {
            double balance = mediaPlayer.Balance;
            double vol = mediaPlayer.Volume;
            mediaPlayer.Close();
            fileName = filePath;
            // Volume information gets reset when Close() is called
            // so restore here.
            mediaPlayer.Balance = balance;
            mediaPlayer.Volume = vol;

            if (!String.IsNullOrEmpty(filePath))
            {
                mediaPlayer.Open(new Uri(fileName));
            }
        }

        /// <summary>
        /// Gets whether the jukebox has any media loaded.
        /// </summary>
        public bool HasMedia => !String.IsNullOrEmpty(fileName);

        /// <summary>
        /// Gets or sets the volume of the media playback. A valid range is 0-1
        /// but 0.5 is 100% amplification.
        /// </summary>
        public double Volume
        {
            get => mediaPlayer.Volume;
            set => mediaPlayer.Volume = value;
        }

        /// <summary>
        /// Gets or sets the left-right volume balance. -1 is left, 0 center, and 1 right.
        /// </summary>
        public double Balance
        {
            get => mediaPlayer.Balance;
            set => mediaPlayer.Balance = value;
        }

        public JukeBox()
        {
            mediaPlayer.MediaEnded += delegate
            {
                if (loop)
                {
                    // Magic to restart the track from the beginning (track keeps playing for some reason).
                    mediaPlayer.Position = TimeSpan.Zero;
                }
                else
                {
                    // Resets the position to 0 without starting playback.
                    mediaPlayer.Stop();
                    PlayState = PlayState.Stopped;
                }
            };
        }

        /// <summary>
        /// Gets the duration of the specified audio file in milliseconds.
        /// </summary>
        /// <returns>0, if the file could not be opened or if the file does not exist.</returns>
        public static Task<int> GetAudioLengthAsync(string filePath)
        {
            return Task.Run(() =>
            {
                if (!File.Exists(filePath))
                    return 0;

                var p = new MediaPlayer();

                try
                {
                    p.Open(new Uri(filePath));
                }
                catch (UriFormatException)
                {
                    return 0;
                }

                // Max run time is 1 second.
                for (int i = 0; i < 20; i++)
                {
                    if (p.NaturalDuration.HasTimeSpan)
                    {
                        // Duration available.
                        int len = (int)(p.NaturalDuration.TimeSpan.TotalMilliseconds + 0.5);
                        p.Close();
                        return len;
                    }

                    System.Threading.Thread.Sleep(50);
                }

                // Method max run time has elapsed.
                p.Close();
                return 0;
            });
        }

        public void Stop()
        {
            mediaPlayer.Stop();
            PlayState = PlayState.Stopped;
            mediaPlayer.Close();
        }

        public void Play(bool loop = false)
        {
            this.loop = loop;
            PlayState = PlayState.Playing;
            mediaPlayer.Play();
        }

        public void Pause()
        {
            PlayState = PlayState.Paused;
            mediaPlayer.Pause();
        }

        public void Dispose()
        {
            mediaPlayer.Close();
        }
    }
}
