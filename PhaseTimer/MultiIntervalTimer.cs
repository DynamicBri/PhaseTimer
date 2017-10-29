using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PhaseTimer
{
    public enum PlayState
    {
        Stopped,
        Playing,
        Paused
    }

    public enum TimerEndAction
    {
        Stop,
        LoopAll,
        RepeatLastInterval
    }

    /// <summary>
    /// A timer that iterates through multiple consumer-provided intervals.
    /// </summary>
    public class MultiIntervalTimer : IDisposable
    {
        private long precalcIterElapsedTime;
        private bool precalcActive;
        private int lastSecond;
        /// <summary>
        /// Tracks the time for a single iteration.
        /// </summary>
        private readonly Stopwatch iterationStopwatch = new Stopwatch();
        /// <summary>
        /// Tracks the time for all iterations (persists through loops).
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly Timer timerPoller = new Timer();

        #region Properties
        private bool loopingAll;
        /// <summary>
        /// Gets whether all intervals are being looped. This is true if <see cref="TimerEndAction"/> is set
        /// to <see cref="PhaseTimer.TimerEndAction.LoopAll"/> and one iteration has been completed.
        /// </summary>
        public bool LoopingAll
        {
            get => loopingAll;
            private set
            {
                if (loopingAll != value)
                {
                    loopingAll = value;
                    LoopingAllChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the total duration of one timer iteration.
        /// </summary>
        public TimeSpan TotalDuration => 
            HasTimeMarkers ? TimeSpan.FromMilliseconds(TimeMarkers.Last()) : TimeSpan.Zero;

        /// <summary>
        /// Gets the position along the current iteration. This is the same as <see cref="IterationRunTime"/>
        /// unless looping the last interval.
        /// </summary>
        public TimeSpan CurrentIterationPosition
        {
            get
            {
                if (!HasTimeMarkers)
                    return TimeSpan.Zero;

                if (LoopingLastInterval)
                {
                    int interRunTimeMS = (int)(IterationRunTime.TotalMilliseconds + 0.5);

                    if (TimeMarkers.Length == 1)
                    {
                        return IterationRunTime;
                    }
                    else
                    {
                        return TimeSpan.FromMilliseconds(interRunTimeMS + TimeMarkers[TimeMarkers.Length - 2]);
                    }
                }
                else
                {
                    return IterationRunTime;
                }
            }
        }

        /// <summary>
        /// Gets the last interval time in milliseconds. This is the interval that is looped
        /// when <see cref="TimerEndAction"/> is set to <see cref="PhaseTimer.TimerEndAction.RepeatLastInterval"/>.
        /// </summary>
        public TimeSpan LastIntevalDuration { get; private set; }

        /// <summary>
        /// Gets or sets whether the last interval is being looped.
        /// </summary>
        public bool LoopingLastInterval { get; private set; }

        /// <summary>
        /// Gets or sets the poll rate in milliseconds. This class polls for changes
        /// in elapsed seconds and time markers being reached.
        /// </summary>
        public int PollRate
        {
            get => timerPoller.Interval;
            set => timerPoller.Interval = value;
        }

        /// <summary>
        /// Gets the index of the last time marker surpassed/reached.
        /// </summary>
        public int TimeMarkerIndex { get; private set; }

        private PlayState playState = PlayState.Stopped;
        public PlayState PlayState
        {
            get => playState;
            set
            {
                if (playState != value)
                {
                    playState = value;
                    OnPlayStateChanged();
                }
            }
        }

        public bool HasTimeMarkers => TimeMarkers != null && TimeMarkers.Length > 0;

        /// <summary>
        /// Gets the time markings that specify when the <see cref="MarkerReached"/> event
        /// will fire. This array is sorted by time length ascending.
        /// </summary>
        public int[] TimeMarkers { get; private set; }

        /// <summary>
        /// Gets how many times the timer intervals have been looped through.
        /// If <see cref="TimerEndAction"/> is set to <see cref="TimerEndAction.RepeatLastInterval"/>,
        /// the loop count will increment every time the last interval is iterated through.
        /// </summary>
        public int LoopCount { get; private set; }

        /// <summary>
        /// Gets or sets the action to perform when a timer iteration is completed
        /// (when all provided intervals are iterated through once).
        /// </summary>
        public TimerEndAction TimerEndAction { get; set; }

        /// <summary>
        /// Gets how many milliseconds have elapsed since a loop iteration <see cref="MultiIntervalTimer"/> has started.
        /// </summary>
        public TimeSpan IterationRunTime =>
            TimeSpan.FromMilliseconds(precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds);

        /// <summary>
        /// Gets how many milliseconds have elapsed since the timer has been started.
        /// </summary>
        public TimeSpan TotalRunTime => stopwatch.Elapsed;

        /// <summary>
        /// Gets the remaining time, in milliseconds, the watch will run until
        /// it stops or loops. Returns <see cref="TimeSpan.MaxValue"/> if looping last
        /// interval.
        /// </summary>
        public TimeSpan RemainingRuntime
        {
            get
            {
                if (playState == PlayState.Stopped)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    if (LoopingLastInterval)
                        return TimeSpan.MaxValue;

                    long currentTime = precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds;
                    long remainingMS = TimeMarkers.Last() - currentTime;
                    return TimeSpan.FromMilliseconds(remainingMS);
                }
            }
        }

        /// <summary>
        /// Gets the time, in milliseconds, it will take to reach the next time marker.
        /// </summary>
        public TimeSpan TimeUntilNextMarker
        {
            get
            {
                if (playState == PlayState.Stopped)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    long currentTime = precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds;

                    if (LoopingLastInterval)
                    {
                        return TimeSpan.FromMilliseconds(LastIntevalDuration.TotalMilliseconds - currentTime);
                    }

                    for (int i = 0; i < TimeMarkers.Length; i++)
                    {
                        if (TimeMarkers[i] > currentTime)
                        {
                            return TimeSpan.FromMilliseconds(TimeMarkers[i] - currentTime);
                        }
                    }

                    return TimeSpan.Zero;
                }
            }
        }

        /// <summary>
        /// Gets the time, in milliseconds, elapsed since the last interval.
        /// If no interval has been reached, this will be <see cref="TimeSpan.MinValue"/>.
        /// </summary>
        public TimeSpan TimeSinceLastMarker
        {
            get
            {
                if (playState == PlayState.Stopped)
                    return TimeSpan.MinValue;

                if (LoopingLastInterval)
                    return iterationStopwatch.Elapsed;

                int lastTimeMarkerIndex = LastTimeMarkerIndex;

                if (lastTimeMarkerIndex == -1)
                    return TimeSpan.MinValue;

                long currentTime = precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds;

                if (TimerEndAction == TimerEndAction.LoopAll && lastTimeMarkerIndex == TimeMarkers.Length - 1)
                {
                    return TimeSpan.FromMilliseconds(currentTime);
                }

                if (lastTimeMarkerIndex != -1)
                {
                    return TimeSpan.FromMilliseconds(currentTime - TimeMarkers[lastTimeMarkerIndex]);
                }

                return TimeSpan.MinValue;
            }
        }

        /// <summary>
        /// Gets the index of the last interval reached. If IntervalElapsed is true, this will be
        /// an interval that has been reached within the last 20ms. If the value is -1, then no
        /// interval has been reached yet.
        /// </summary>
        public int LastTimeMarkerIndex
        {
            get
            {
                if (LoopingLastInterval || playState == PlayState.Stopped)
                    return TimeMarkers.Length - 1;

                long currentTime = precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds;

                for (int i = TimeMarkers.Length - 1; i >= 0; i--)
                {
                    if (TimeMarkers[i] < currentTime)
                        return i;
                }

                if (TimerEndAction == TimerEndAction.LoopAll)
                {
                    return TimeMarkers.Length - 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Gets the index of the upcoming interval. If this is -1, then the loop is about to end.
        /// </summary>
        public int NextTimeMarkerIndex
        {
            get
            {
                long currentTime = precalcActive ? precalcIterElapsedTime : iterationStopwatch.ElapsedMilliseconds;

                for (int i = 0; i < TimeMarkers.Length; i++)
                {
                    if (TimeMarkers[i] > currentTime)
                    {
                        return TimeMarkers[i];
                    }
                }

                return -1;
            }
        }
        #endregion

        /// <summary>
        /// Occurs when the value of the <see cref="LoopingAll"/> property has changed.
        /// </summary>
        public event EventHandler LoopingAllChanged;

        public MultiIntervalTimer()
        {
            timerPoller.Tick += TimerPoller_Tick;
            timerPoller.Interval = 50;
        }

        private void TimerPoller_Tick(object sender, EventArgs e)
        {
            long elapsedMS = iterationStopwatch.ElapsedMilliseconds;
            int elapsedSec = (int)(stopwatch.ElapsedMilliseconds / 1000.0 + 0.5);

            if (elapsedSec > lastSecond)
            {
                lastSecond = elapsedSec;
                OnSecondElapsed();
            }

            if (LoopingLastInterval)
            {
                if (elapsedMS >= LastIntevalDuration.TotalMilliseconds)
                {
                    iterationStopwatch.Restart();
                    LoopCount++;
                    OnMarkerReached();
                }
            }
            else if (elapsedMS > TimeMarkers[TimeMarkerIndex])
            {
                OnMarkerReached();

                // If time marker is the last one.
                if (TimeMarkerIndex == TimeMarkers.Length - 1)
                {
                    switch (TimerEndAction)
                    {
                        case TimerEndAction.LoopAll:
                            timerPoller.Stop();
                            iterationStopwatch.Restart();
                            timerPoller.Start();
                            LoopCount++;
                            TimeMarkerIndex = 0;
                            lastSecond = 0;
                            LoopingAll = true;
                            break;

                        case TimerEndAction.Stop:
                            Stop();
                            break;

                        case TimerEndAction.RepeatLastInterval:
                            LoopingLastInterval = true;
                            iterationStopwatch.Restart();
                            LoopCount++;
                            break;
                    }
                }
                else
                {
                    TimeMarkerIndex++;
                }
            }
        }

        #region Events
        /// <summary>
        /// Occurs when the value of the <see cref="PlayState"/> property has changed.
        /// </summary>
        public event EventHandler PlayStateChanged;
        /// <summary>
        /// Raises the <see cref="PlayStateChanged"/> event.
        /// </summary>
        protected virtual void OnPlayStateChanged()
        {
            PlayStateChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when a time marker has been reached. The provided number is the
        /// time marker index reached.
        /// </summary>
        public event EventHandler<int> MarkerReached;
        /// <summary>
        /// Raises the <see cref="MarkerReached"/> event.
        /// </summary>
        private void OnMarkerReached()
        {
            MarkerReached?.Invoke(this, TimeMarkerIndex);
        }

        /// <summary>
        /// Occurs when one second has elapsed.
        /// </summary>
        public event EventHandler SecondElapsed;
        /// <summary>
        /// Raises the <see cref="SecondElapsed"/> event.
        /// </summary>
        protected virtual void OnSecondElapsed()
        {
            SecondElapsed?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        /// <summary>
        /// Indicates that many of the statistical properties are
        /// going to be accessed and precalculated data should be used.
        /// Always use this method in tandem with <see cref="EndTimeAccess"/>.
        /// </summary>
        public void BeginTimeAccess()
        {
            precalcIterElapsedTime = iterationStopwatch.ElapsedMilliseconds;
            precalcActive = true;
        }

        /// <summary>
        /// Indicates that precalculated data is no longer needed.
        /// Always use this method in tandem with <see cref="BeginTimeAccess"/>.
        /// </summary>
        public void EndTimeAccess()
        {
            precalcActive = false;
        }

        /// <summary>
        /// Sets the time markers for the timer from minute intervals.
        /// </summary>
        /// <param name="minuteIntervals">Intervals in minutes.</param>
        public void LoadTimeMarkersFromMinIntervals(IEnumerable<double> minuteIntervals)
        {
            if (minuteIntervals == null || !minuteIntervals.Any())
                throw new InvalidOperationException("Provide at least one interval.");

            if (PlayState != PlayState.Stopped)
                throw new InvalidOperationException("Timer must be stopped before loading new time markers.");

            LastIntevalDuration = TimeSpan.FromMilliseconds((int)(minuteIntervals.Last() * 60 * 1000));
            TimeMarkers = IntervalConversion.ToTimeMarkers(minuteIntervals);
        }

        /// <exception cref="InvalidOperationException">At least one time marker needs to be loaded.</exception>
        public void Start()
        {
            if (!HasTimeMarkers)
                throw new InvalidOperationException("At least one time marker needs to be loaded.");

            if (PlayState != PlayState.Playing)
            {
                iterationStopwatch.Start();
                stopwatch.Start();
                timerPoller.Start();
                PlayState = PlayState.Playing;
            }
        }

        public void Stop()
        {
            if (PlayState != PlayState.Stopped)
            {
                iterationStopwatch.Stop();
                stopwatch.Stop();
                timerPoller.Stop();
                iterationStopwatch.Reset();
                stopwatch.Reset();
                TimeMarkerIndex = 0;
                lastSecond = 0;
                LoopCount = 0;
                LoopingLastInterval = false;
                LoopingAll = false;
                PlayState = PlayState.Stopped;
            }
        }

        public void Pause()
        {
            if (PlayState != PlayState.Paused)
            {
                iterationStopwatch.Stop();
                stopwatch.Stop();
                timerPoller.Stop();
                PlayState = PlayState.Paused;
            }
        }

        /// <summary>
        /// Stops then starts the timer.
        /// </summary>
        public void Restart()
        {
            Stop();
            Start();
        }

        public void Dispose()
        {
            timerPoller.Dispose();
        }
    }
}
