using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TextBook_Geogebra
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        AvtorizationForm avtorizationForm;
        AboutForm aboutForm;
        ResetPassForm resetPassForm;
        SettingsForm settingsForm;
        internal bool singIn = false;
        string path = Application.StartupPath;
        string pathApplicationEXE = "";
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

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            if (!singIn)
            {
                if (avtorizationForm == null)
                {
                    avtorizationForm = new AvtorizationForm(this);
                    avtorizationForm.Show();
                }
                else if (avtorizationForm.IsDisposed)
                {
                    avtorizationForm = new AvtorizationForm(this);
                    avtorizationForm.Show();
                }
            }
            else
            {
                singIn = false;
                radMenuItem9.Text = "Войти";
                radMenuItem4.Enabled = false;
            }

        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
                aboutForm.Show();
            } else if (aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm();
                aboutForm.Show();
            }
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if (resetPassForm == null)
            {
                resetPassForm = new ResetPassForm();
                resetPassForm.Show();
            } else if (resetPassForm.IsDisposed)
            {
                resetPassForm = new ResetPassForm();
                resetPassForm.Show();
            }
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm();
                settingsForm.Show();
            } else if (settingsForm.IsDisposed)
            {
                settingsForm = new SettingsForm();
                settingsForm.Show();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FileStream file = new FileStream(path + "\\config.cfg", FileMode.CreateNew, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine("path: null");
                writer.Close();
                file.Close();
            }
            catch (Exception)
            {
              
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {

            //TODO open application on settings
            //FileStream file = new FileStream(path + "\\config.cfg", FileMode.OpenOrCreate, FileAccess.Read);
            //StreamReader reader = new StreamReader(file);
            //pathApplicationEXE = reader.ReadLine().Substring(6);
            //reader.Close();
            //file.Close();
            //Process.Start(pathApplicationEXE);
        }
    }
}
