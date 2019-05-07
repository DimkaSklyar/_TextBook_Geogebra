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
        string style = "zoom: 100%;";
        string path = Application.StartupPath;
        string pathApplicationEXE = "";
        string selectNode = "";
        
        
        public MainForm()
        {
            InitializeComponent();
            addMenuItem.Click += AddMenuItem_Click;
            editMenuItem.Click += EditMenuItem_Click;
            renameMenuItem.Click += RenameMenuItem_Click;
            removeMenuItem.Click += RemoveMenuItem_Click;
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить страницу учебника: " + radTreeView1.SelectedNode.Text + "?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                try
                {
                    Directory.Delete(path + "\\GeogebraFiles\\" + radTreeView1.SelectedNode.Text + ".files", true);
                }
                catch (Exception)
                {

                }
                FileInfo file = new FileInfo(Application.StartupPath + "\\GeogebraFiles\\" + radTreeView1.SelectedNode.Text + ".html");
                if (file.Exists)
                {
                    file.Delete();
                }
                radTreeView1.SelectedNode.Remove();
                FileStream writer = new FileStream(Application.StartupPath + "\\tree.lst", FileMode.Create, FileAccess.Write);
                radTreeView1.SaveXML(writer);
                writer.Close();

            }
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
                radMenuItem15.Text = "Войти";
                radMenuItem16.Enabled = false;
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


        }

        private void radTreeView1_ContextMenuOpening(object sender, Telerik.WinControls.UI.TreeViewContextMenuOpeningEventArgs e)
        {
            radContextMenu1.Show();
        }

        private void radTreeView1_Click(object sender, EventArgs e)
        {
            
        }
        private void radTreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.radTreeView1.GetNodeAt(e.X, e.Y) == null)
            {
                this.radTreeView1.SelectedNode = null;
            }
            if (e.Button == MouseButtons.Right && singIn)
            {
                if (radTreeView1.SelectedNode == null)
                {
                    removeMenuItem.Enabled = false;
                    renameMenuItem.Enabled = false;
                    editMenuItem.Enabled = false;
                    Point point = new Point(e.X, e.Y);
                    radContextMenu1.Show(radTreeView1, point);
                }
                else
                {
                    removeMenuItem.Enabled = true;
                    renameMenuItem.Enabled = true;
                    editMenuItem.Enabled = true;
                    Point point = new Point(e.X, e.Y);
                    radContextMenu1.Show(radTreeView1, point);
                }
                
            }
        }

 

        private void radTreeView1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void radTreeView1_NodeMouseClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            //selectNode = e.Node.Text;
            radTreeView1.SelectedNode = e.Node;
        }

        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            try
            {

                Uri uri = new Uri(path + "\\GeogebraFiles\\" + e.Node.Text + ".html");
                webBrowser1.Url = uri;
                radButton1.Visible = false;
                if (radTreeView1.SelectedNode.Parent.Text.ToUpper() == "Практические задания".ToUpper())
                {
                    radButton1.Visible = true;
                }
                else
                {
                    radButton1.Visible = false;
                }
            }
            catch (Exception)
            {

            }


        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom: 100%;";
            style = "zoom: 100%;";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Body.Style = style;
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom: 125%;";

            style = "zoom: 125%;";

        }

        private void radMenuItem12_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom: 150%;";

            style = "zoom: 150%;";

        }

        private void radMenuItem13_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom: 200%;";

            style = "zoom: 200%;";

        }


        private void radTreeView1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //TODO open application on settings
            FileStream file = new FileStream(path + "\\config.cfg", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            pathApplicationEXE = reader.ReadLine().Substring(6);
            reader.Close();
            file.Close();
            try
            {
                Process.Start(pathApplicationEXE);
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка запуска GeoGebra. Убедитесь, что путь Настройках программы, указан правильно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }






    }
}
