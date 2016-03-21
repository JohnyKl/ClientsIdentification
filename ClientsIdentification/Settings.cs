using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientsIdentification
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            DBManager.ReloadUsersAuthData();

            tbAddress.Text = DBManager.AUTH_DATA[0];
            tbLogin.Text = DBManager.AUTH_DATA[1];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"ClientsIdentification.stg";
            string data = "";

            if(tbAddress.Text.Trim().Length > 0)
            {
                if (tbLogin.Text.Trim().Length > 0)
                {
                    if (tbPassword.Text.Trim().Length > 0)
                    {
                        data += "DB:" + tbAddress.Text.Trim() + ";\nlogin:" + tbLogin.Text.Trim() + ";\npassword:" + tbPassword.Text.Trim() + ";";
                    }
                    else
                    {
                        MessageBoxEx.Show(this,"Введите пароль!", "Ошибка ввода");
                    }
                }
                else
                {
                    MessageBoxEx.Show(this, "Введите логин!", "Ошибка ввода");
                }
            }
            else
            {
                MessageBoxEx.Show(this, "Введите ссылку на базу даных!", "Ошибка ввода");
            }
            if (data.Length > 0)
            {
                File.WriteAllText(path, Cryptor.Encrypt(data, true));

                if (!DBManager.ReloadUsersAuthData())
                {
                    MessageBoxEx.Show(this, "Ошибка при сохранении даных - перезапустите программу.", "Ошибка программы");
                }
                Close();
            }
        }
    }
}
