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
    public partial class SettingsForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            radTextBox1.Text = openFileDialog1.FileName;
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (radTextBox1.Text == "")
            {
                radButton2.Enabled = false;
            }
            else
            {
                radButton2.Enabled = true;
            }
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
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
                FileStream file = new FileStream(path + "\\config.cfg", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                radTextBox1.Text = reader.ReadLine().Substring(6);
                reader.Close();
                file.Close();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(path + "\\config.cfg", FileMode.Truncate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("path: " + radTextBox1.Text);
            writer.Close();
            file.Close();
            MessageBox.Show("Путь успешно сохранён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
