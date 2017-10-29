using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhaseTimer
{
    /// <summary>
    /// Specifies what format, if any, occurred when an interval string was parsed.
    /// </summary>
    [Flags]
    public enum IntervalFormatErrors
    {
        /// <summary>
        /// No errors occurred.
        /// </summary>
        None = 0,
        /// <summary>
        /// 1 or more of the intervals was less than 0.01.
        /// </summary>
        HasInvalidNumbers = 1,
        /// <summary>
        /// A <see cref="FormatException"/> occurred while parsing.
        /// </summary>
        NotParsable = 2
    }

    static class IntervalConversion
    {
        /// <summary>
        /// Gets the string representation of the intervals specified.
        /// </summary>
        public static string ToString(double[] intervals)
        {
            StringBuilder SB = new StringBuilder();

            for (int i = 0; i < intervals.Length; i++)
            {
                SB.Append(intervals[i]);

                if (i != intervals.Length - 1)
                {
                    // Add two spaces for readability.
                    SB.Append("  ");
                }
            }

            return SB.ToString();
        }

        /// <summary>
        /// Extracts intervals from the specified comma-separated values.
        /// </summary>
        /// <returns>An empty array, if provided string is empty.</returns>
        public static double[] FromString(string text, out IntervalFormatErrors formatResult)
        {
            double[] numbers = { };
            formatResult = IntervalFormatErrors.None;

            if (String.IsNullOrWhiteSpace(text))
                return numbers;

            string[] splitted = text.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            try
            {
                numbers = splitted.Select(double.Parse).ToArray();
            }
            catch (FormatException)
            {
                formatResult |= IntervalFormatErrors.NotParsable;
            }

            if (numbers.Any(n => n < 0.01))
            {
                formatResult |= IntervalFormatErrors.HasInvalidNumbers;

            }

            return numbers;
        }

        /// <summary>
        /// Gets whether the specified intervals are in a valid string formate.
        /// </summary>
        /// <param name="text">The comma-separated intervals.</param>
        /// <returns>True, if valid format, otherwise false.</returns>
        public static IntervalFormatErrors ValidateIntervalString(string text)
        {
            FromString(text, out var errors);
            return errors;
        }

        /// <summary>
        /// Converts minute intervals to time markers (measured in MS).
        /// </summary>
        /// <param name="minIntervals">Intervals in minutes.</param>
        public static int[] ToTimeMarkers(IEnumerable<double> minIntervals)
        {
            var timeMarkerList = new List<int>();
            int[] msIntervals = minIntervals.Select(i => (int)(i * 60 * 1000 + 0.5)).ToArray();

            for (int i = 0; i < msIntervals.Length; i++)
            {
                int endTime = 0;

                for (int i2 = 0; i2 <= i; i2++)
                {
                    endTime += msIntervals[i2];
                }

                timeMarkerList.Add(endTime);
            }

            return timeMarkerList.ToArray();
        }
    }
}
