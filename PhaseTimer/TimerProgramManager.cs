using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace PhaseTimer
{
    /// <summary>
    /// Manages all of the timer programs present in the users timer program directory.
    /// All timer programs found in the timer program directory are kept loaded into the program.
    /// </summary>
    internal class TimerProgramManager
    {
        public BindingList<TimerProgram> All { get; } = new BindingList<TimerProgram>();

        /// <summary>
        /// Gets all timer programs that have not had their changes saved.
        /// </summary>
        public IEnumerable<TimerProgram> Unsaved => All.Where(p => p.Modified);

        /// <summary>
        /// Gets all timer programs that have their changes saved or have not been changed
        /// since they have been loaded.
        /// </summary>
        public IEnumerable<TimerProgram> Saved => All.Where(p => !p.Modified);

        /// <summary>
        /// Hooks the <see cref="TimerProgram.ModifiedChanged"/> event of the specified
        /// timer program to the specified handler. The specified handler is unsubscribed from every
        /// other <see cref="TimerProgram.ModifiedChanged"/> event.
        /// </summary>
        public void IsolateModifiedChangedEvent(TimerProgram programToSub, EventHandler handler)
        {
            foreach (var prog in All)
            {
                prog.ModifiedChanged -= handler;
            }

            programToSub.ModifiedChanged += handler;
        }

        /// <summary>
        /// Hooks the <see cref="VolumeSettings.Modified"/> event of the specified
        /// timer program to the specified handler. The specified handler is unsubscribed from every
        /// other <see cref="VolumeSettings.Modified"/> event.
        /// </summary>
        public void IsolateVolumeModifiedEvent(TimerProgram programToSub, EventHandler handler)
        {
            foreach (var prog in All)
            {
                prog.VolumeSettings.Modified -= handler;
            }

            programToSub.VolumeSettings.Modified += handler;
        }

        /// <summary>
        /// Gets whether one of the loaded timer programs is already using the specified name.
        /// </summary>
        public bool NameAlreadyExists(string name)
        {
           return All.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Removes the timer program at the specified index.
        /// </summary>
        public void RemoveProgramAt(int index)
        {
            RemoveProgram(All[index]);
        }

        public void RemoveProgram(TimerProgram program)
        {
            Pathing.DeleteDirectory(program.ProgramDirectory);
            //Directory.Delete(program.ProgramDirectory, true);
            All.Remove(program);
        }
    }
}
