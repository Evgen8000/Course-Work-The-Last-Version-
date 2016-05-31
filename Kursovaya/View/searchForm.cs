using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kursovaya
{
    public partial class searchForm : Form
    {
        public searchForm()
        {
            InitializeComponent();
            table.Columns.Add("№");
            table.Columns.Add("Имя");
            table.Columns.Add("Фамилия");
            table.Columns.Add("Камера");
            table.Columns.Add("Статья");
            table.Columns.Add("Дата заключения");
            table.Columns.Add("Место в тюремной иерархии");
            table.Columns.Add("Родственики");
            table.Columns.Add("Характер");
            DisplayList();
        }
        DataTable table = new DataTable();
        Prison jailed = new Prison();

        private void Search_Load(object sender, EventArgs e) { }

        private void DisplayList()
        {

            table.Rows.Clear();
            int index = 0;


            foreach (Prisoner prisoner in jailed)
            {
                DisplayPrisoner(prisoner, index);
                index++;
            }
            tablePrison.DataSource = table;
            tablePrison.Columns[0].Visible = false;
        }

        private void DisplayPrisoner(Prisoner prisoner, int index)
        {
            DataRow row = table.NewRow();
            row["№"] = index;
            row["Имя"] = prisoner.First_Name;
            row["Фамилия"] = prisoner.Second_Name;
            row["Камера"] = prisoner.Room;
            row["Статья"] = prisoner.Criminality;
            row["Дата заключения"] = prisoner.DateOfJailed.Day + "/" + prisoner.DateOfJailed.Month + "/" + prisoner.DateOfJailed.Year;
            row["Место в тюремной иерархии"] = prisoner.PITPH;
            if (prisoner.Relatives == "")
            {
                row["Родственики"] = "-";
            }
            else
            {
                row["Родственики"] = prisoner.Relatives;
            }
            row["Характер"] = prisoner.Temper;
            table.Rows.Add(row);

        }
        private void Search()
        {
            string query = searchTextBox.Text;
            if (query == "")
            {
                DisplayList();
            }
            else
            {
                table.Rows.Clear();
                int index = 0;
                foreach (Prisoner prisoner in jailed)
                {
                    if (prisoner.First_Name.ToUpper().IndexOf(query.ToUpper()) != -1 || prisoner.Second_Name.ToUpper().IndexOf(query.ToUpper()) != -1 || Convert.ToString(prisoner.Room).IndexOf(query) == 0 || prisoner.Criminality.ToUpper().IndexOf(query.ToUpper()) == 0 ||/* prisoner.DateOfJailed.Day == 0 || prisoner.DateOfJailed.Month == 0 || prisoner.DateOfJailed.Month == 0 */  prisoner.PITPH.ToUpper().IndexOf(query.ToUpper()) != -1 || prisoner.Relatives.ToUpper().IndexOf(query.ToUpper()) != -1 || prisoner.Temper.ToUpper().IndexOf(query.ToUpper()) != -1)
                    {
                        DisplayPrisoner(prisoner, index);
                    }
                    index++;
                }

            }
        }
        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(tablePrison.SelectedCells[0].OwningRow.Cells[0].Value);
            jailed.RemoveAt(index);
            DisplayList();
        }
        private void cellContextMenu_Opening(object sender, CancelEventArgs e) // меню ячейки
        {
            Point selected = new Point(cellContextMenu.Left, cellContextMenu.Top);
            selected = tablePrison.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo selectedCell = tablePrison.HitTest(selected.X, selected.Y);
            if (selectedCell.Type == DataGridViewHitTestType.Cell)
            {
                tablePrison.ClearSelection();
                tablePrison[selectedCell.ColumnIndex, selectedCell.RowIndex].Selected = true;

            }
            else
            {
                e.Cancel = true;
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            Add_Form add = new Add_Form(jailed);
            add.Show();
        }

        private void editMenuItem_Click(object sender, EventArgs e)  //редактирование
        {
            int index = Convert.ToInt32(tablePrison.SelectedCells[0].OwningRow.Cells[0].Value);
            Form editionForm = new Add_Form(index, jailed);
            editionForm.ShowDialog();
        }

        private void searchForm_Activated(object sender, EventArgs e)
        {
            DisplayList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Отчет о формировании состава.txt", false, Encoding.Default))
            {
                for (int i = 0; i < tablePrison.RowCount; i++)
                {
                    writer.WriteLine("Имя : " + tablePrison[1, i].Value.ToString());
                    writer.WriteLine("Фамилия : " + tablePrison[2, i].Value.ToString());
                    writer.WriteLine("Камера : " + tablePrison[3, i].Value.ToString());
                    writer.WriteLine("Статья : " + tablePrison[4, i].Value.ToString());
                    writer.WriteLine("Дата заключения под стражу : " + tablePrison[5, i].Value.ToString());
                    writer.WriteLine("Место в тюремной иерархии : " + tablePrison[6, i].Value.ToString());
                    writer.WriteLine("Родственики : " + tablePrison[7, i].Value.ToString());
                    writer.WriteLine("Характер : " + tablePrison[8, i].Value.ToString());

                    writer.WriteLine();
                }
                writer.WriteLine("Количество заключеных : " + tablePrison.RowCount);
                writer.Close();
            }
            MessageBox.Show("Выполнено");
            Process.Start("Отчет о формировании состава.txt");
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFormatter loader = new BinaryFormatter();
            OpenFileDialog dialog = new OpenFileDialog()
            {
                FileName = "DB.bin",
                Filter = "База данных (*.bin)|*.bin|Все файлы (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                jailed = (Prison)loader.Deserialize(stream);
                stream.Close();
                Search();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFormatter saver = new BinaryFormatter();
            SaveFileDialog dialog = new SaveFileDialog()
            {
                FileName = "DB.bin",
                Filter = "База данных (*.bin)|*.bin|Все файлы (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                saver.Serialize(stream, jailed);
                stream.Close();
            }
        }

        private void WorkersButton_Click(object sender, EventArgs e)
        {
            WorkersForm son = new WorkersForm(jailed.Workers);
            if (son.ShowDialog() == DialogResult.OK)
            {
                jailed.Workers = son.toSave;
            }
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Stats.txt", false, Encoding.Default))
            {
                Dictionary<int,int> dict = new Dictionary<int, int>();
                foreach (Prisoner prisoner in jailed)
                {
                    if (!dict.ContainsKey(prisoner.Room)) dict.Add(prisoner.Room, 1);
                    else dict[prisoner.Room]++;
                }
                writer.WriteLine("Отчет по камерам");
                foreach (KeyValuePair<int,int> key in dict)
                {
                    writer.WriteLine("Камера №" + key.Key + ": " + key.Value);
                }
                writer.WriteLine("Количество заключеных : " + jailed.Count);
                Dictionary<string, int> dict2 = new Dictionary<string, int>();
                writer.WriteLine("Отчет по должностям рабочих:");
                foreach (Worker wrkr in jailed.Workers)
                {
                    if (!dict2.ContainsKey(wrkr.Position)) dict2.Add(wrkr.Position, 1);
                    else dict2[wrkr.Position]++;
                }
                foreach (KeyValuePair<string, int> key in dict2)
                {
                    writer.WriteLine(key.Key + ": " + key.Value);
                }
                writer.Close();
            }
            MessageBox.Show("Выполнено");
            Process.Start("Stats.txt");
        }
    }
}


