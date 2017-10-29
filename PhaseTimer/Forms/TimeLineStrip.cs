using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;

namespace PhaseTimer.Forms
{
    class TimeLineStrip : Control
    {
        private readonly Pen intervalPen = new Pen(Color.DodgerBlue);
        private readonly Pen playbackPositionPen = new Pen(Color.Red, 2);
        private int[] timeMarkers;

        private double playbackPosition;
        /// <summary>
        /// Gets or sets the playback position of the phase timer in milliseconds.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        public double PlaybackPosition
        {
            get => playbackPosition;
            set
            {
                if (value != playbackPosition)
                {
                    playbackPosition = value;
                    Invalidate();
                }
            }
        }

        private int alarmLength;
        /// <summary>
        /// Gets or sets the length of the alarm sound in milliseconds.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int AlarmLength
        {
            get { return alarmLength; }
            set
            {
                if (value != alarmLength)
                {
                    alarmLength = value;
                    Invalidate();
                }
            }
        }

        private bool intervalAtStart;
        /// <summary>
        /// Gets or sets whether an interval should be depicted at the very start of the timeline.
        /// This is for when the multi-timer is set to "loop all".
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IntervalAtStart
        {
            get => intervalAtStart;
            set
            {
                if (value != intervalAtStart)
                {
                    intervalAtStart = value;
                    Invalidate();
                }
            }
        }

        public TimeLineStrip()
        {
            base.DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void Clear()
        {
            alarmLength = 0;
            playbackPosition = 0;
            timeMarkers = null;
            Invalidate();
        }

        public void LoadTimeMarkersFromMinIntervals(IEnumerable<double> minIntervals)
        {
            timeMarkers = IntervalConversion.ToTimeMarkers(minIntervals);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (timeMarkers != null && timeMarkers.Length > 0)
            {
                // Compensator for border. Always use these values for calculations.
                int width = Width - 2;
                int height = Height - 1;
                float totalDuration = timeMarkers.Last();

                if (alarmLength == 0)
                {
                    intervalPen.Width = 2;
                }
                else
                {
                    float widthPercent = alarmLength / totalDuration;
                    intervalPen.Width = width * widthPercent;
                }

                if (intervalAtStart)
                {
                    e.Graphics.DrawLine(intervalPen, 1, 1, 1, height);
                }

                // Draw interval blocks.
                for (var i = 0; i < timeMarkers.Length; i++)
                {
                    // No need to draw the last one.
                    if (i == timeMarkers.Length - 1)
                        break;

                    var marker = timeMarkers[i];
                    float xPercent =  marker / totalDuration;
                    float x = width * xPercent + intervalPen.Width / 2;
                    e.Graphics.DrawLine(intervalPen, x, 1, x, height);
                }

                // Draw playback position indicator.
                if (playbackPosition != 0)
                {
                    float xPercent2 = (float)playbackPosition / totalDuration;
                    float x2 = width * xPercent2 + playbackPositionPen.Width / 2;
                    e.Graphics.DrawLine(playbackPositionPen, x2, 1, x2, height);
                }
            }

            base.OnPaint(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            intervalPen.Dispose();
            playbackPositionPen.Dispose();
        }
    }
}
