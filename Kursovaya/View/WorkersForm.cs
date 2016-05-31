using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursovaya.View;

namespace Kursovaya
{
    public partial class WorkersForm : Form
    {
        //таблица данных
        public DataTable table = new DataTable();
        public WorkerCollection toSave;
        //конструктор формы с аргументом - отображаемой коллекции
        public WorkersForm(WorkerCollection col)
        {
            InitializeComponent();
            toSave = new WorkerCollection();
            table.Columns.Add("№");
            table.Columns.Add("Имя");
            table.Columns.Add("Фамилия");
            table.Columns.Add("Дата наема");
            table.Columns.Add("Должность");
            toSave = col;
            DisplayList();

        }

        private void WorkersForm_Load(object sender, EventArgs e)
        {
            //WorkerView.DataMember = new Worker();
        }

        //метод отображения списка
        private void DisplayList()
        {

            table.Rows.Clear();
            int index = 0;

            foreach (Worker worker in toSave)
            {
                DisplayWorker(worker, index);
                index++;
            }
            WorkerView.DataSource = table;
            WorkerView.Columns[0].Visible = false;
        }

        //метод отображения строки
        private void DisplayWorker(Worker worker, int index)
        {
            DataRow row = table.NewRow();
            row["№"] = index;
            row["Имя"] = worker.FirstName;
            row["Фамилия"] = worker.SecondName;
            row["Дата наема"] = worker.DateOfStart.Day + "/" + worker.DateOfStart.Month + "/" + worker.DateOfStart.Year;
            row["Должность"] = worker.Position;
            table.Rows.Add(row);
        }

        private void WorkerView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //метод открытия формы добавления
        private void AddButton_Click(object sender, EventArgs e)
        {
            WorkerAdd form = new WorkerAdd(toSave);
            form.ShowDialog();
            DisplayList();
        }

        //метод открытия формы редактирования
        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(WorkerView.SelectedCells[0].OwningRow.Cells[0].Value);
            WorkerAdd form = new WorkerAdd(toSave,index);
            form.ShowDialog();
            DisplayList();
        }

        //метод удаления выбраного элемента
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(WorkerView.SelectedCells[0].OwningRow.Cells[0].Value);
            toSave.RemoveAt(index);
            DisplayList();
        }

        //метод поиска в списке
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string query = SearchTextBox.Text;
            if (query == "")
            {
                DisplayList();
            }
            else
            {
                table.Rows.Clear();
                int index = 0;
                foreach (Worker wrkr in toSave)
                {
                    if (wrkr.FirstName.ToLower().IndexOf(query.ToLower()) != -1 || wrkr.SecondName.ToLower().IndexOf(query.ToLower()) != -1 || wrkr.Position.ToLower().IndexOf(query.ToLower()) != -1)
                    {
                        DisplayWorker(wrkr, index);
                    }
                    index++;
                }

            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Отчет о рабочих.txt", false, Encoding.Default))
            {
                for (int i = 0; i < WorkerView.RowCount; i++)
                {
                    writer.WriteLine("Имя : " + WorkerView[1, i].Value.ToString());
                    writer.WriteLine("Фамилия : " + WorkerView[2, i].Value.ToString());
                    writer.WriteLine("Дата наема : " + WorkerView[3, i].Value.ToString());
                    writer.WriteLine("Должноть : " + WorkerView[4, i].Value.ToString());

                    writer.WriteLine();
                }
                writer.WriteLine("Количество рабочих : " + WorkerView.RowCount);
                writer.Close();
            }
            MessageBox.Show("Выполнено");
            Process.Start("Отчет о рабочих.txt");
        }
    }
}
