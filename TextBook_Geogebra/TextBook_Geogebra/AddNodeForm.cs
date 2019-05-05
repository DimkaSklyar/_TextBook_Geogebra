using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace TextBook_Geogebra
{
    public partial class AddNodeForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        MainForm mainForm;
        public AddNodeForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        void addNode()
        {
            if (radTextBox1.Text != "")
            {
                var selectNode = mainForm.radTreeView1.SelectedNode;
                try
                {
                    FileStream file = new FileStream(path + "\\GeogebraFiles\\" + radTextBox1.Text + ".html", FileMode.CreateNew, FileAccess.ReadWrite);
                    if (selectNode == null)
                    {
                        mainForm.radTreeView1.Nodes.Add(radTextBox1.Text);
                    }
                    else
                    {
                        mainForm.radTreeView1.SelectedNode.Nodes.Add(radTextBox1.Text);
                    }
                    mainForm.radTreeView1.SaveXML(path + "\\tree.lst");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Раздел с таким именем уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Имя раздела не может быть пустым", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {

            addNode();
        }

        private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                addNode();
            }
        }
    }
}
