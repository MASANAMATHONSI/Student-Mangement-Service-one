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
            if (int.TryParse(textBox1.Text, out int studentID))
            {
                // 1. Get the existing data from the database
                DataTable currentData = handler.Search(studentID.ToString());

                if (currentData.Rows.Count > 0)
                {
                    DataRow row = currentData.Rows[0];

                    // 2. Use the new text if provided, otherwise keep the old database value
                    string name = string.IsNullOrWhiteSpace(textBox3.Text) ? row["Name"].ToString() : textBox3.Text;
                    string surname = string.IsNullOrWhiteSpace(textBox4.Text) ? row["Surname"].ToString() : textBox4.Text;

                    // For numbers, check if the box is empty before parsing
                    int year = string.IsNullOrWhiteSpace(textBox5.Text) ? int.Parse(row["Year"].ToString()) : int.Parse(textBox5.Text);
                    decimal grade = string.IsNullOrWhiteSpace(textBox6.Text) ? decimal.Parse(row["Grade"].ToString()) : decimal.Parse(textBox6.Text);

                    // 3. Send the merged data to the update method
                    handler.Updata(studentID, name, surname, year, grade);

                    // Refresh the grid
                    dataGridView1.DataSource = handler.ViewAll().Tables[0];
                    MessageBox.Show("Update processed successfully!");
                }
                else
                {
                    MessageBox.Show("Student ID not found in database.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Student ID to perform an update.");
            }
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            handler.Delete(textBox1.Text);
            MessageBox.Show("Sucessful");
        }
    }
    
}
