using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursovaya.View;

namespace Kursovaya
{
    public partial class AdminLoginForm : Form
    {
        //список аккаунтов
        public AccountList Basic;
        //конструктор формы, аргументом которого является редактируемый список
        public AdminLoginForm(AccountList RC)
        {
            InitializeComponent();
            Basic = RC;
            table.Columns.Add("ID");
            table.Columns.Add("Логин");
            table.Columns.Add("Пароль");
            table.Columns.Add("Права админа");
            DisplayList();
        }
        //таблица
        DataTable table = new DataTable();
        private void AdminLoginForm_Load(object sender, EventArgs e)
        {
        }

        //метод отображения списка
        private void DisplayList()
        {
            table.Rows.Clear();
            int index = 0;


            foreach (Account account in Basic)
            {
                DisplayAccount(account, index);
                index++;
            }
            AccView.DataSource = table;
            AccView.Columns[0].Visible = false;
        }

        //метод отображения аккаунта из коллекции
        private void DisplayAccount(Account account, int index)
        {
            DataRow row = table.NewRow();
            row["ID"] = index;
            row["Логин"] = account.Login;
            row["Пароль"] = account.Password;
            row["Права админа"] = account.IsAdmin;
            table.Rows.Add(row);
        }

        //метод удаления аккаунта из списка
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(AccView.SelectedCells[0].OwningRow.Cells[0].Value);
            Basic.RemoveAt(index);
            DisplayList();
        }

        //сохранение в файл и закрытие формы
        private void AdminLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Basic.SaveToFile();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //кнопка добавления
        private void AddButton_Click(object sender, EventArgs e)
        {
            AdminEdit edit = new AdminEdit(Basic);
            edit.ShowDialog(this);
            DisplayList();
        }

        //кнопка редактирования
        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(AccView.SelectedCells[0].OwningRow.Cells[0].Value);
            AdminEdit edit = new AdminEdit(Basic, index);
            edit.ShowDialog(this);
            DisplayList();
        }
    }
}
