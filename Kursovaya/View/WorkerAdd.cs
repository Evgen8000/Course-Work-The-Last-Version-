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
    public partial class WorkerAdd : Form
    {
        //Индекс, если передается в форму
        private int Index;
        //Внешний список
        private WorkerCollection List;
        //флаг редактирования
        private bool edit;

        //конструктор добавления
        public WorkerAdd(WorkerCollection list)
        {
            InitializeComponent();
            edit = false;
            List = list;

        }

        //конструктор редактирования
        public WorkerAdd(WorkerCollection list, int index)
        {
            InitializeComponent();
            Index = index;
            edit = true;
            List = list;
            FirstName.Text = list[index].FirstName;
            SecondName.Text = list[index].SecondName;
            Position.Text = list[index].Position;
            Day.Text = list[index].DateOfStart.Day.ToString();
            Month.Text = list[index].DateOfStart.Month.ToString();
            Year.Text = list[index].DateOfStart.Year.ToString();
        }

        //отработка кнопки добавления
        private void Add_button_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(Day.Text);
            int month = Convert.ToInt32(Month.Text);
            int year = Convert.ToInt32(Year.Text);
            if (day > 31 || day < 1 || month > 12 || month < 1 || FirstName.Text == "" || SecondName.Text == "" || Position.Text == "")
            {
                MessageBox.Show("Проверьте правильность ввода");
                return;
            }
            if (edit)
            {
                List[Index] = new Worker(FirstName.Text, SecondName.Text, Position.Text,
                    new Date(day, month, year));
            }
            else
            {
                List.Add(new Worker(FirstName.Text, SecondName.Text, Position.Text,
                    new Date(day, month, year)));
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
