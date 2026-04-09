using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Student_Mangement_Service_one
{
    public partial class Form1 : Form
    {
        Dathandler handler = new Dathandler();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string studentid = textBox1.Text;
            DataTable result = handler.Search(studentid);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Not found");
            }
            dataGridView1.DataSource = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.ViewAll().Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handler.AddData(textBox1.Text, textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), decimal.Parse(textBox6.Text));

            MessageBox.Show("Sucessful");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int studentID = int.Parse(textBox1.Text);
            string name = textBox3.Text;
            string surname = textBox4.Text;
            int year = int.Parse(textBox5.Text);
            decimal grade = decimal.Parse(textBox6.Text);

            handler.Updata(studentID, name, surname, year, grade);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
    
}
