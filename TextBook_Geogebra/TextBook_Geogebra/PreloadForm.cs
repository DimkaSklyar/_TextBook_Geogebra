using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TextBook_Geogebra
{
    public partial class PreloadForm : Telerik.WinControls.UI.RadForm
    {
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
    }
}
