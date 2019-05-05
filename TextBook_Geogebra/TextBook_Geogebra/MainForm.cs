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
using Word = Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;

namespace TextBook_Geogebra
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        AvtorizationForm avtorizationForm;
        AboutForm aboutForm;
        ResetPassForm resetPassForm;
        SettingsForm settingsForm;
        AddNodeForm addNodeForm;
        RenameForm renameForm;
        internal bool singIn = false;
        string path = Application.StartupPath;
        string pathApplicationEXE = "";
        
        
        public MainForm()
        {
            InitializeComponent();
            addMenuItem.Click += AddMenuItem_Click;
            editMenuItem.Click += EditMenuItem_Click;
            renameMenuItem.Click += RenameMenuItem_Click;
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            if (renameForm == null)
            {
                renameForm = new RenameForm(this);
                renameForm.Show();
            }
            else if (renameForm.IsDisposed)
            {
                renameForm = new RenameForm(this);
                renameForm.Show();
            }
            this.Enabled = false;
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            var selectNode = radTreeView1.SelectedNode;
            if (selectNode != null)
            {
                try
                {

                    Word.Application word = new Word.Application();
                    word.Visible = true;
                    word.Documents.Open(path + "\\GeogebraFiles\\" + selectNode.Text + ".html");
                    //word.Documents.OpenNoRepairDialog(path + "\\GeogebraFiles\\" + selectNode.Text + ".html");
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Не выбран не один узел для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            if (addNodeForm == null)
            {
                addNodeForm = new AddNodeForm(this);
                addNodeForm.Show();
            } else if (addNodeForm.IsDisposed)
            {
                addNodeForm = new AddNodeForm(this);
                addNodeForm.Show();
            }
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
            Directory.CreateDirectory(path + "\\GeogebraFiles");

            FileStream reader = new FileStream(path + "\\tree.lst", FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                radTreeView1.LoadXML(reader);
            }
            catch (Exception)
            {
                MessageBox.Show("Структура учебника повреждена или не существует! Если происходит создание нового учебника, проигнорируйте это сообщение.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radTreeView1.Nodes.Clear();
            }

            reader.Close();
            try
            {
                radTreeView1.SelectedNode = radTreeView1.Nodes[0];
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

        private void radTreeView1_ContextMenuOpening(object sender, Telerik.WinControls.UI.TreeViewContextMenuOpeningEventArgs e)
        {
            radContextMenu1.Show();
        }

        private void radTreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(e.X, e.Y);
                radContextMenu1.Show(radTreeView1, point);
            }
        }

        private void radTreeView1_Click(object sender, EventArgs e)
        {
            //radTreeView1.SelectedNode = null;
        }

        private void radTreeView1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void radTreeView1_NodeMouseClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            radTreeView1.SelectedNode = e.Node;
        }

        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            Uri uri = new Uri(path + "\\GeogebraFiles\\" + e.Node.Text + ".html");
            webBrowser1.Url = uri;
        }
    }
}
