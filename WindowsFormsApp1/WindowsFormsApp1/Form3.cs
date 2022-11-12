using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace WindowsFormsApp1
{



    public partial class Form3 : Form
    {
        private SQLiteConnection OoO;
        private DataTable DT;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DT = new DataTable();
            OoO = new SQLiteConnection();
            string path = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\OoO.db");
            OoO = new SQLiteConnection("Data Source=" + path + "; Version=3;");
            OoO.Open();
            string SQLi = "SELECT *FROM История";
           

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLi, OoO);
            adapter.Fill(DT);
            ShowTable(SQLi);
        }



        public void ShowTable(string SQLQuery)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            //char j;
            for (int colum = 0; colum < DT.Columns.Count; colum++)
            {
                string ColumName = DT.Columns[colum].ColumnName;
                dataGridView1.Columns.Add(ColumName, ColumName);
                dataGridView1.Columns[colum].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            }
            

            for (int row = 0; row < DT.Rows.Count; row++)
            {
                dataGridView1.Rows.Add();
                
                dataGridView1.Rows[row].Cells[0].Value = Convert.ToString(DT.Rows[row][0]);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand("DELETE FROM История WHERE Пароли = @pId", OoO);
            command.Parameters.Add(new SQLiteParameter("@pId", this.dataGridView1.CurrentRow.Cells["Пароли"].Value));
            command.ExecuteNonQuery();

            ShowTable(DT, dataGridView1);
            this.Close();
            Form3 form = new Form3();
            form.Show();



            

            //string s = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //SQLiteCommand command = new SQLiteCommand($"DELETE FROM История WHERE Пароли = {s}", OoO);
            //command.ExecuteNonQuery();
            //ShowTable(SQL_AllTable());
        }
        private void ShowTable(DataTable DTable, DataGridView Table)//заполнение таблицы
        {
            Table.Columns.Clear();
            Table.Rows.Clear();
            for (int colum = 0; colum < DTable.Columns.Count; colum++)
            {
                string ColumName = DTable.Columns[colum].ColumnName;
                Table.Columns.Add(ColumName, ColumName);
                Table.Columns[colum].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int row = 0; row < DTable.Rows.Count; row++)
            {
                Table.Rows.Add(DTable.Rows[row].ItemArray);
            }
            foreach (DataGridViewColumn column in Table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
