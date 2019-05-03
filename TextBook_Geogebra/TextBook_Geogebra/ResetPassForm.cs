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
    public partial class ResetPassForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        string[] autorization = new string[2];

        public ResetPassForm()
        {
            InitializeComponent();
        }

        void ResetPassword()
        {
            if (radTextBox1.Text != "" && radTextBox2.Text != "")
            {
                FileStream file = new FileStream(path + "\\settings.ini", FileMode.Open, FileAccess.ReadWrite);
                StreamReader streamReader = new StreamReader(file);
                autorization[0] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key");
                autorization[1] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key");
                streamReader.Close();
                file.Close();
                if (autorization[1] == radTextBox1.Text)
                {
                    FileStream filestream = new FileStream(path + "\\settings.ini", FileMode.Truncate, FileAccess.ReadWrite);
                    StreamWriter streamWriter = new StreamWriter(filestream);
                    var new_login = Crypto.EncryptStringAES("admin", "key");
                    var new_password = Crypto.EncryptStringAES(radTextBox2.Text, "key");
                    streamWriter.WriteLine(new_login);
                    streamWriter.WriteLine(new_password);
                    streamWriter.Close();
                    filestream.Close();
                    DialogResult res = MessageBox.Show("Пароль успешно изменён!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }
            else
            {
                MessageBox.Show("Поля не должны быть пусты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ResetPassword();
        }

        private void radTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ResetPassword();
            }
        }
    }
}
