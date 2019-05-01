using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextBook_Geogebra
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
