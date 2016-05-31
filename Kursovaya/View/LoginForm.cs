using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class LoginForm : Form
    {
        //список аккаунтов
        public AccountList RC;
        public LoginForm()
        {
            InitializeComponent();
        }

        //Проверка полей и открытие главной формы
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(RC.ContainsByText(LoginBox.Text, PasswordBox.Text))
                OpenMainForm();
            else
            {
                MessageBox.Show("Такого пользователя не существует, либо пароль не верен");
            }
        }

        //чтение из файла с аккаунтами
        private void LoginForm_Load(object sender, EventArgs e)
        {
            RC = AccountList.ReadFromFile();
        }

        //метод открытие главной формы
        public void OpenMainForm()
        {
            searchForm Main = new searchForm();
            Hide();
            Main.ShowDialog();     
            Close();           
        }

        //открытие формы редактирования списка аккаунтов
        private void ToAdminControl_Click(object sender, EventArgs e)
        {
            if (RC.ContainsByText(LoginBox.Text, PasswordBox.Text, true))
            {
                AdminLoginForm admin = new AdminLoginForm(RC);
                Hide();
                admin.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("У пользователя нет прав администратора или пользователя не существует");
            }
        }
    }
}
