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
    public partial class RenameForm : Telerik.WinControls.UI.RadForm
    {
        MainForm mainForm;
        string path = Application.StartupPath;
        public RenameForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void RenameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void RenameForm_Shown(object sender, EventArgs e)
        {
            radTextBox1.Text = mainForm.radTreeView1.SelectedNode.Text;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "")
            {
                string old_file = path + "\\GeogebraFiles\\" + mainForm.radTreeView1.SelectedNode.Text + ".html";
                string new_file = path + "\\GeogebraFiles\\" + radTextBox1.Text + ".html";
                File.Move(old_file, new_file);
                FileInfo file = new FileInfo(old_file);
                if (file.Exists)
                {
                    file.Delete();
                }
                mainForm.radTreeView1.SelectedNode.Text = radTextBox1.Text;
                FileStream writer = new FileStream(Application.StartupPath + "\\tree.lst", FileMode.Create, FileAccess.Write);
                mainForm.radTreeView1.SaveXML(writer);
                writer.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Некоректное имя узла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (radTextBox1.Text != "")
                {
                    string old_file = path + "\\GeogebraFiles\\" + mainForm.radTreeView1.SelectedNode.Text + ".html";
                    string new_file = path + "\\GeogebraFiles\\" + radTextBox1.Text + ".html";
                    File.Move(old_file, new_file);
                    FileInfo file = new FileInfo(old_file);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    mainForm.radTreeView1.SelectedNode.Text = radTextBox1.Text;
                    FileStream writer = new FileStream(Application.StartupPath + "\\tree.lst", FileMode.Create, FileAccess.Write);
                    mainForm.radTreeView1.SaveXML(writer);
                    writer.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Некоректное имя узла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
