using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.View
{
    public partial class AdminEdit : Form
    {
        //флаг редактирования\добавления
        private bool edit;
        //индекс редактируемого элемента
        private int Index;
        //список в который добавляется\редактируется элемент
        private AccountList List;

        //Конструктор формы с заменой аккаунта (редактирование)
        public AdminEdit(AccountList list,int index)
        {
            InitializeComponent();
            LoginBox.Text = list[index].Login;
            PasswordBox.Text = list[index].Password;
            if (list[index].IsAdmin) AdminCheckBox.Checked = true;
            else AdminCheckBox.Checked = false;
            Index = index;
            List = list;
            edit = true;
        }

        //конструктор формы добавления аккаунта
        public AdminEdit(AccountList list)
        {
            InitializeComponent();
            List = list;
            edit = false;
        }

        //принятие изменений (сохранение в основной список)
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show("Проверьте заполненность полей");
                return;
            }
            if (edit)
            {
                List[Index] = new Account(LoginBox.Text, PasswordBox.Text, AdminCheckBox.Checked);
            }
            else
            {
                List.Add(new Account(LoginBox.Text, PasswordBox.Text, AdminCheckBox.Checked));
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
