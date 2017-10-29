using System;
using System.Reflection;
using System.Windows.Forms;

namespace PhaseTimer.Forms
{
    partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            // Might as well use the product name here instead of the assembly name.
            this.Text = "About " + Application.ProductName;
            this.labelProductName.Text = Application.ProductName;
            this.labelVersion.Text = Application.ProductVersion;
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = Application.CompanyName;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors
        public string AssemblyDescription => 
            GetAssemblyAttribute<AssemblyDescriptionAttribute>()?.Description;

        public string AssemblyCopyright =>
            GetAssemblyAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        #endregion

        /// <summary>
        /// Gets an the first occurrence of an attribute, with the specified type, from the executing assembly.
        /// </summary>
        private static T GetAssemblyAttribute<T>() where T : Attribute
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<T>();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
