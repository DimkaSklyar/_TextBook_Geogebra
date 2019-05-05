using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace TextBook_Geogebra
{
    public partial class PreloadForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        public PreloadForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            timer1.Enabled = false;
            this.Hide();
        }

        private void PreloadForm_Shown(object sender, EventArgs e)
        {


        }
    }
}
