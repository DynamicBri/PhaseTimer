
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PhaseTimer.Properties;

namespace PhaseTimer
{
    /// <summary>
    /// Provides functionality for creating and working with preset timer programs
    /// and resources.
    /// </summary>
    public static class PresetCreation
    {
        /// <summary>
        /// Gets the directory of the preset audio unpacked from the application.
        /// </summary>
        public static string PresetAudioDirectory =>
            Path.Combine(Settings.Default.PhaseTimerDir, "Preset Audio Resources");

        /// <summary>
        /// Gets the directory of the preset alarm audio unpacked from the application.
        /// </summary>
        public static string PresetAlarmsDirectory =>
            Path.Combine(PresetAudioDirectory, "Alarms");

        /// <summary>
        /// Gets the directory of the preset ambience audio unpacked from the application.
        /// </summary>
        public static string PresetAmbienceDirectory =>
            Path.Combine(PresetAudioDirectory, "Ambience");

        /// <summary>
        /// Unpacks the preset resources to the path in <see cref="PresetAudioDirectory"/>.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        public static void UnpackPresetResources()
        {
            const string AMBIENCE_PREFIX = "Ambience_";
            const string ALARMS_PREFIX = "Alarms_";

            // Export embedded resources to file using reflections and File.WriteAllBytes.
            var properties = typeof(Resources).GetProperties(BindingFlags.Static | BindingFlags.NonPublic).
                Where(p => p.PropertyType == typeof(byte[]));

            string alarmsDir = Path.Combine(PresetAudioDirectory, "Alarms");
            string ambienceDir = Path.Combine(PresetAudioDirectory, "Ambience");

            if (!Directory.Exists(alarmsDir))
                Directory.CreateDirectory(alarmsDir);

            if (!Directory.Exists(ambienceDir))
                Directory.CreateDirectory(ambienceDir);

            foreach (var property in properties)
            {
                if (property.Name.StartsWith(AMBIENCE_PREFIX))
                {
                    string safeFileName = property.Name.Remove(0, AMBIENCE_PREFIX.Length).Replace('_', ' ');
                    string outputPath = Path.Combine(ambienceDir, safeFileName) + ".mp3";
                    File.WriteAllBytes(outputPath, (byte[])property.GetValue(null));
                }
                else if (property.Name.StartsWith(ALARMS_PREFIX))
                {
                    string safeFileName = property.Name.Remove(0, ALARMS_PREFIX.Length).Replace('_', ' ');
                    string outputPath = Path.Combine(alarmsDir, safeFileName) + ".mp3";
                    File.WriteAllBytes(outputPath, (byte[])property.GetValue(null));
                }
            }
        }

        /// <summary>
        /// Automatically sets the Phase Timer directory.
        /// </summary>
        public static void AutoSetTimerProgramDirectory()
        {
            if (String.IsNullOrEmpty(Settings.Default.PhaseTimerDir))
            {
                string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Settings.Default.PhaseTimerDir = Path.Combine(myDocs, Application.ProductName);
            }
        }

        /// <summary>
        /// Outputs the preset timer programs from the <see cref="Resources.PresetTimerPrograms"/> files.
        /// </summary>
        public static void SavePresetProgramsToFile()
        {
            var matches = Regex.Matches(Resources.PresetTimerPrograms, @"\[(?<Name>[^\]]+)\].+?(?=\[[^\]]+\]|$)",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                TimerProgram.ExtractProgramProperties(match.Value, out var intervals, out var timerEndAction,
                    out VolumeSettings volumeInfo, out var alarmName, out var ambienceName,
                    out var description, out bool locked);

                string name = match.Groups["Name"].Value;
                // TODO: Use property path.
                string exportDir = $@"{Settings.Default.PhaseTimerDir}\\Timer Programs\\{name}\\";
                string fileName = Path.Combine(exportDir, $"{name}{TimerProgram.FileExtension}");

                if (!Directory.Exists(exportDir))
                    Directory.CreateDirectory(exportDir);

                var timerProgram = new TimerProgram(fileName, intervals, alarmName, ambienceName,
                    volumeInfo, timerEndAction, description, locked);

                string alarmPath = GetPresetAudioPath(alarmName);
                string ambiencePath = GetPresetAudioPath(ambienceName);
                timerProgram.EmbedFile(alarmPath);
                timerProgram.EmbedFile(ambiencePath);
                timerProgram.Save();
            }
        }

        /// <summary>
        /// Resolves the path of a preset audio resource.
        /// </summary>
        /// <param name="safeFileName">The name of the file (extension included).</param>
        private static string GetPresetAudioPath(string safeFileName)
        {
            if (safeFileName == null) return null;
            var files = Directory.GetFiles(PresetAudioDirectory, safeFileName, SearchOption.AllDirectories);
            return files.Length == 0 ? string.Empty : files.First();
        }
    }
}
