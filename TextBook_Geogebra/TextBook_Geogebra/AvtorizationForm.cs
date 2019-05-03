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
    public partial class AvtorizationForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        string[] autorization = new string[] { "admin", "admin" };
        internal bool signIn = false;
        MainForm mainForm;

        void SingIn()
        {
            FileStream file = new FileStream(path + "\\settings.ini", FileMode.Open, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(file);
            autorization[0] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key");
            autorization[1] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key");
            if (autorization[0] == radTextBox1.Text && autorization[1] == radTextBox2.Text)
            {
                signIn = true;
                mainForm.radMenuItem4.Enabled = true;
                mainForm.radMenuItem9.Text = "Выйти";
                mainForm.singIn = signIn;
                streamReader.Close();
                Close();
            }
            else
            {
                signIn = false;
                MessageBox.Show("Неверное имя пользователя или пароль!");
                file.Close();
                streamReader.Close();

            }
        }

        public AvtorizationForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void AvtorizationForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FileStream file = new FileStream(path + "\\settings.ini", FileMode.CreateNew, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(file);
                var login = Crypto.EncryptStringAES(autorization[0], "key");
                var password = Crypto.EncryptStringAES(autorization[1], "key");

                streamWriter.WriteLine(login);
                streamWriter.WriteLine(password);
                streamWriter.Close();
                MessageBox.Show("Файл настроек был удалён! Если идёт первоначальная настройка программы, игнорируйте это сообщение!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {


            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            SingIn();
        }

        private void radTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SingIn();
            }
        }
    }
}
