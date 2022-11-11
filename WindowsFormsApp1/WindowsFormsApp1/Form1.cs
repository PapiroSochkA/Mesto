using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private SQLiteConnection OoO;
        public Form1()
        {
            InitializeComponent();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            richTextBox1.Clear();
            label4.Text = "";
            int dlina = (int)numericUpDown1.Value;
            bool symbols = checkBox1.Checked;
            bool tyan = checkBox2.Checked;
            bool op = checkBox3.Checked;
            
            Random rand = new Random();
            Random type = new Random();
            for (int i = 0; i < dlina; i++)
            {
                if (op == true)
                {
                    int type_num = type.Next(0, 2);

                    if (type_num == 0)
                    {
                        char value = (char)rand.Next(65, 91);
                        richTextBox1.Text += value.ToString();
                        continue;
                    }
                    else
                    {
                        char value = (char)rand.Next(97, 123);
                        richTextBox1.Text += value.ToString();
                        continue;
                    }
                }

                else
                {
                    if (tyan == true)
                    {
                        char value = (char)rand.Next(40, 122);
                        if (value == '\\' || value == '/')
                        {
                            value = (char)rand.Next(65, 91);
                            richTextBox1.Text += value.ToString();
                        }
                        else
                        {
                            richTextBox1.Text += value.ToString();
                        }
                        continue;
                    }
                }


                    if (symbols == true)
                    {
                        int value = rand.Next(0, 9);
                        richTextBox1.Text += value.ToString();
                        continue;
                    }
                


                //int type_num = type.Next(0, 2);
                //if (type_num == 0)
                //{
                //    int value = rand.Next(0, 9);
                //    richTextBox1.Text += value.ToString();
                //    continue;
                //}
                //if (symbols == true)
                //{

                //        char value = (char)rand.Next(65, 67);
                //        if (value == '\\' || value == '/')
                //        {
                //            value = (char)rand.Next(33, 91);
                //            richTextBox1.Text += value.ToString();
                //        }
                //        else
                //        {
                //            richTextBox1.Text += value.ToString();
                //        }
                //    continue;

                //}
                //else
                //{
                //    int value = rand.Next(0, 9);
                //    richTextBox1.Text += value.ToString();
                //    continue;
                //}
            }
            
            

        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    richTextBox1.Clear();
        //}

        private void button2_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Вы не можете скопировать пароль, который ещё не сгенерировали", "Ахтунг!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            Clipboard.SetText(richTextBox1.Text);
            label4.Text = "Скопированно!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.CheckState == CheckState.Checked)
            checkBox2.CheckState = CheckState.Unchecked;
            checkBox1.CheckState = CheckState.Unchecked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                checkBox2.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //OoO = new SQLiteConnection();
            //OoO = new SQLiteConnection("Data Source=C:\\Users\\chist\\Desktop\\OoO\\OoO.db; Pooling=true;FailIfMissing=false; Version=3;");
            //OoO.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OoO = new SQLiteConnection("Data Source=C:\\Users\\chist\\Desktop\\OoO\\OoO.db; Pooling=true;FailIfMissing=false; Version=3;");
            OoO.Open();
            string SQL = "INSERT INTO История (Пароли)"+" VALUES(' " + richTextBox1.Text.ToString() + "')";
            SQLiteCommand cmd = new SQLiteCommand(SQL);
            cmd.Connection = OoO;
            cmd.CommandText = SQL;
            cmd.ExecuteNonQuery();




            label5.Text = "Сохранено!";

        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
