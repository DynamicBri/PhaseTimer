using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhaseTimer
{
    static class ExtensionMethods
    {
        /// <summary>
        /// Adds a range of items to the <see cref="BindingList{T}"/>.
        /// </summary>
        public static void AddRange<T>(this BindingList<T> list, T[] range)
        {
            foreach (var item in range)
                list.Add(item);
        }

        /// <summary>
        /// Gets the first filename found within this data object.
        /// </summary>
        public static string GetFirstFileName(this IDataObject obj)
        {
            return ((string[])obj.GetData(DataFormats.FileDrop)).FirstOrDefault();
        }
    }
}
