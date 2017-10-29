using System;
using System.Windows.Forms;

namespace PhaseTimer.Forms
{
    /// <summary>
    /// A dialog for picking a name.
    /// </summary>
    public partial class NamePickerDialog : Form
    {
        /// <summary>
        /// Gets or sets the currently inputted name.
        /// </summary>
        public string EnteredName
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        public NamePickerDialog()
        {
            InitializeComponent();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = !String.IsNullOrWhiteSpace(textBoxName.Text);
        }
    }
}
