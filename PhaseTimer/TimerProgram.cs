using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PhaseTimer.Properties;

namespace PhaseTimer
{
    public class TimerProgram
    {
        /// <summary>
        /// Gets the extension (. included) to use for timer program files.
        /// </summary>
        public const string FileExtension = ".ptp";

        #region Properties
        /// <summary>
        /// Gets the total runtime of this timer program in milliseconds.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                if (!HasIntervals)
                    return TimeSpan.Zero;

                double dur = 0;

                foreach (var inter in intervals)
                {
                    dur += inter;
                }

                return TimeSpan.FromMinutes(dur);
            }
        }

        /// <summary>
        /// Gets the directory that houses all of the timer program directories.
        /// </summary>
        public static string MasterDirectory =>
            Path.Combine(Settings.Default.PhaseTimerDir, "Timer Programs");

        /// <summary>
        /// Gets the name of this timer program. The name is the file name without the extension.
        /// </summary>
        public string Name => Path.GetFileNameWithoutExtension(ProgramFilePath);

        private string description;
        /// <summary>
        /// Gets or sets the description of this timer program.
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    Modified = true;
                }
            }
        }

        /// <summary>
        /// Gets the program's parent directory (usually has the same name as the .ptp file).
        /// </summary>
        public string ProgramDirectory => Path.GetDirectoryName(ProgramFilePath);

        /// <summary>
        /// Gets the path of the timer program file.
        /// </summary>
        public string ProgramFilePath { get; }

        private double[] intervals;
        /// <summary>
        /// Gets a list of intervals for this program.
        /// </summary>
        public double[] Intervals
        {
            get => intervals;
            set
            {
                if (!CompareArrays(value, intervals))
                {
                    intervals = value;
                    Modified = true;
                }
            }
        }

        public bool HasIntervals => intervals != null && intervals.Length > 0;

        /// <summary>
        /// Gets the amplification and balance settings to use for playback.
        /// </summary>
        public VolumeSettings VolumeSettings { get; }

        private TimerEndAction timerEndAction;
        /// <summary>
        /// Gets or sets the action to perform when a timer iteration ends.
        /// </summary>
        public TimerEndAction TimerEndAction
        {
            get => timerEndAction;
            set
            {
                if (value != timerEndAction)
                {
                    timerEndAction = value;
                    Modified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether this program is locked. When a program is locked,
        /// it cannot be edited or removed.
        /// </summary>
        public bool Locked { get; }

        private string alarmPath;
        /// <summary>
        /// Gets or sets the path to the alarm audio file.
        /// </summary>
        public string AlarmPath
        {
            get => alarmPath;
            set
            {
                if (alarmPath != value)
                {
                    alarmPath = value;
                    Modified = true;
                }
            }
        }

        private string ambiencePath;
        /// <summary>
        /// Gets or sets the path to the ambience audio file.
        /// </summary>
        public string AmbiencePath
        {
            get => ambiencePath;
            set
            {
                if (ambiencePath != value)
                {
                    ambiencePath = value;
                    Modified = true;
                }
            }
        }

        private bool modified;
        /// <summary>
        /// Gets or sets whether the program was changed. This property will be set to false
        /// when 
        /// </summary>
        public bool Modified
        {
            get => modified;
            set
            {
                if (value != modified)
                {
                    modified = value;
                    ModifiedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        /// <summary>
        /// Occurs when the value of the <see cref="Modified"/> property has changed.
        /// </summary>
        public event EventHandler ModifiedChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerProgram"/> class with the specified arguments.
        /// </summary>
        /// <param name="filePath">The path of the program file.</param>
        /// <param name="intervals">The intervals in minutes.</param>
        /// <param name="alarmPath">The path of the alarm audio file.</param>
        /// <param name="ambiencePath">The path of the ambience audio file.</param>
        /// <param name="volumeInfo">The amplification and balance settings to use for playback.</param>
        /// <param name="timerEndAction">The action to perform when a timer iteration expires.</param>
        /// <param name="description">The summary of the program.</param>
        /// <param name="locked">Whether the program can be edited and removed from within the app.</param>
        public TimerProgram(string filePath, double[] intervals, string alarmPath,
            string ambiencePath, VolumeSettings volumeInfo, TimerEndAction timerEndAction, string description, bool locked)
        {
            ProgramFilePath = filePath;
            this.intervals = intervals;
            this.alarmPath = alarmPath;
            this.ambiencePath = ambiencePath;
            this.timerEndAction = timerEndAction;
            this.description = description;
            Locked = locked;

            VolumeSettings = volumeInfo;
            VolumeSettings.Modified += delegate
            {
                if (!Locked)
                    Modified = true;
            };
        }

        private static bool CompareArrays<T>(T[] array1, T[] array2)
        {
            if (array1 == null && array2 == null)
                return true;

            return !(array1 == null && array2 != null ||
                     array1 != null && array2 == null ||
                     !array1.SequenceEqual(array2));
        }

        public override string ToString()
        {
            return ProgramFilePath == null ? string.Empty : Name;
        }

        /// <summary>
        /// Copies the specified file to the program's directory
        /// (the file name and extension are retained).
        /// </summary>
        /// <returns>The new file path.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public string EmbedFile(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                return filePath;

            string fileParentDir = Path.GetDirectoryName(filePath);
            string safeFileName = Path.GetFileName(filePath);
            string dest = Path.Combine(ProgramDirectory, safeFileName);
            // If file is not already embedded.
            // We may want to check for changes in the file here as well.
            if (!fileParentDir.Equals(ProgramDirectory))
            {
                File.Copy(filePath, Path.Combine(ProgramDirectory, safeFileName), true);
            }

            return dest;
        }

        public string[] GetUnreferencedFiles()
        {
            var files = Directory.GetFiles(ProgramDirectory);
            var unreffedFiles = new List<string>();

            foreach (var file in files)
            {
                if (!CompareFilePaths(file, ProgramFilePath) &&
                    !CompareFilePaths(file, AlarmPath) &&
                    !CompareFilePaths(file, AmbiencePath))
                {
                    unreffedFiles.Add(file);
                }
            }

            return unreffedFiles.ToArray();
        }

        /// <summary>
        /// Gets whether the two specified paths are the same.
        /// </summary>
        private static bool CompareFilePaths(string path1, string path2)
        {
            return path1.Trim(' ', '\\').Equals(
                path2.Trim(' ', '\\'), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Saves this program to file (.ptp) and sets <see cref="Modified"/> to false.
        /// </summary>
        public void Save()
        {
            // Create and save timer program file.
            StringBuilder SB = new StringBuilder();
            if (!String.IsNullOrWhiteSpace(description))
                SB.AppendLine($"{nameof(Description)}: " + description.Replace("\r", string.Empty).Replace('\n', ' '));
            if (HasIntervals)
                SB.AppendLine($"{nameof(Intervals)}: " + IntervalConversion.ToString(intervals));
            SB.AppendLine($"{nameof(TimerEndAction)}: " + timerEndAction);
            SB.AppendLine($"{nameof(VolumeSettings.AlarmVolume)}: " + VolumeSettings.AlarmVolume);
            SB.AppendLine($"{nameof(VolumeSettings.AmbienceVolume)}: " + VolumeSettings.AmbienceVolume);
            SB.AppendLine($"{nameof(VolumeSettings.AlarmBalance)}: " + VolumeSettings.AlarmBalance);
            SB.AppendLine($"{nameof(VolumeSettings.AmbienceBalance)}: " + VolumeSettings.AmbienceBalance);
            if (!String.IsNullOrWhiteSpace(AmbiencePath))
                SB.AppendLine($"{nameof(AmbiencePath)}: " + Path.GetFileName(ambiencePath));
            if (!String.IsNullOrWhiteSpace(AlarmPath))
                SB.AppendLine($"{nameof(AlarmPath)}: " + Path.GetFileName(alarmPath));
            if (Locked)
                SB.AppendLine($"{nameof(Locked)}: " + Locked);

            if (!Directory.Exists(ProgramDirectory))
                Directory.CreateDirectory(ProgramDirectory);

            File.WriteAllText(ProgramFilePath, SB.ToString());
            Modified = false;
        }

        /// <summary>
        /// Extracts program properties from the provided string.
        /// </summary>
        public static void ExtractProgramProperties(string content, out double[] intervals, out TimerEndAction timerAction,
            out VolumeSettings volumeSettings, out string alarmPath, out string ambiencePath,
            out string description, out bool locked)
        {
            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string intervalStr = GetValueByKey(nameof(Intervals), lines);
            // Do nothing with format errors, intervals will be an empty array.
            intervals = IntervalConversion.FromString(intervalStr, out var formatErrors);

            string timerEndActionStr = GetValueByKey(nameof(TimerEndAction), lines);
            timerAction = TimerEndAction.Stop;
            if (timerEndActionStr.Length > 0)
                timerAction = (TimerEndAction)Enum.Parse(typeof(TimerEndAction), timerEndActionStr);

            string ambienceVolumeStr = GetValueByKey(nameof(volumeSettings.AmbienceVolume), lines);
            int ambienceVolume = 100;
            if (ambienceVolumeStr.Length > 0)
                ambienceVolume = int.Parse(ambienceVolumeStr);

            string alarmVolumeStr = GetValueByKey(nameof(volumeSettings.AlarmVolume), lines);
            int alarmVolume = 100;
            if (alarmVolumeStr.Length > 0)
                alarmVolume = int.Parse(alarmVolumeStr);

            string alarmBalanceStr = GetValueByKey(nameof(volumeSettings.AlarmBalance), lines);
            double alarmBalance = 0;
            if (alarmBalanceStr.Length > 0)
                alarmBalance = double.Parse(alarmBalanceStr);

            string ambienceBalanceStr = GetValueByKey(nameof(volumeSettings.AmbienceBalance), lines);
            double ambienceBalance = 0;
            if (ambienceBalanceStr.Length > 0)
                ambienceBalance = double.Parse(ambienceBalanceStr);

            volumeSettings = new VolumeSettings(alarmVolume, ambienceVolume, alarmBalance, ambienceBalance);

            alarmPath = GetValueByKey(nameof(AlarmPath), lines);
            ambiencePath = GetValueByKey(nameof(AmbiencePath), lines);
            description = GetValueByKey(nameof(Description), lines);

            string lockedStr = GetValueByKey(nameof(Locked), lines);
            locked = false;
            if (!string.IsNullOrWhiteSpace(lockedStr))
                locked = bool.Parse(lockedStr);
        }

        /// <summary>
        /// Loads a <see cref="TimerProgram"/> from the specified file path.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public static TimerProgram LoadFromFile(string filePath)
        {
            string content = File.ReadAllText(filePath);

            ExtractProgramProperties(content, out var intervals, out var timerEndAction,
                out VolumeSettings volumeInfo, out var alarmName, out var ambienceName,
                out var description, out bool locked);

            string programDir = Path.GetDirectoryName(filePath);
            string alarmPath = ResolveFileNameIfNeeded(alarmName, programDir);
            string ambiencePath = ResolveFileNameIfNeeded(ambienceName, programDir);

            return new TimerProgram(filePath, intervals, alarmPath, ambiencePath,
                volumeInfo, timerEndAction, description, locked);
        }

        /// <summary>
        /// Creates a new timer program with the specified name. The program will be marked as
        /// modified as it has yet to be saved to file.
        /// </summary>
        /// <param name="name">The name of the program (ex. "New Program 1").</param>
        public static TimerProgram CreateNew(string name)
        {
            var programDir = $@"{MasterDirectory}\{name}";

            if (!Directory.Exists(programDir))
            {
                Directory.CreateDirectory(programDir);
            }

            var filePath = $@"{programDir}\{name}{FileExtension}";
            // Set modified to true because it hasn't been saved to file yet.
            return new TimerProgram(filePath, new[] { 1.0 }, null, null, new VolumeSettings(), TimerEndAction.Stop, null, false)
            { Modified = true };
        }

        /// <summary>
        /// Resolves the specified filename to a valid path. This is needed because
        /// the .ptp files hold paths without directory information to make the timer program
        /// more portable.
        /// </summary>
        /// <param name="fileName">The name of the file (extension included).</param>
        /// <param name="timerProgramDir">The timer program's directory.</param>
        private static string ResolveFileNameIfNeeded(string fileName, string timerProgramDir)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                return fileName;
            string dir = Path.GetDirectoryName(fileName);
            return dir == string.Empty ? Path.Combine(timerProgramDir, fileName) : fileName;
        }

        /// <summary>
        /// Gets all of the timer programs found in the user's PhaseTimer directory.
        /// </summary>
        /// <returns>An empty array, if none found.</returns>
        public static TimerProgram[] GetAllPrograms()
        {
            string[] files = Directory.GetFiles(Settings.Default.PhaseTimerDir, "*" + FileExtension, SearchOption.AllDirectories);
            var programList = new List<TimerProgram>();

            foreach (var file in files)
            {
                programList.Add(LoadFromFile(file));
            }

            return programList.ToArray();
        }

        /// <summary>
        /// Finds and returns a value using the specified key.
        /// </summary>
        /// <param name="key">The property identifier.</param>
        /// <param name="lines">An array of strings containing key/value pairs to search through.</param>
        /// <returns><see cref="string.Empty"/> if nothing found.</returns>
        private static string GetValueByKey(string key, string[] lines)
        {
            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                    continue;

                string[] splitted = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 0)
                    throw new Exception("Timer program key-value pair missing semi-colon.");

                if (splitted.Length > 2)
                    throw new Exception("Timer program key-value pair has too many semi-colons.");

                if (key == splitted.First() && splitted.Length == 2)
                    return splitted.Last().Trim();
            }

            return string.Empty;
        }

        #region Equality Members
        protected bool Equals(TimerProgram other)
        {
            return string.Equals(ProgramFilePath, other.ProgramFilePath, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TimerProgram)obj);
        }

        public override int GetHashCode()
        {
            return (ProgramFilePath != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(ProgramFilePath) : 0);
        }

        public static bool operator ==(TimerProgram left, TimerProgram right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimerProgram left, TimerProgram right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
