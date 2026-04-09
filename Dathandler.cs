using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Mangement_Service_one
{
  public class Dathandler
    {
        string conn = ("Server=.;Initial Catalog=BCDatabase1;User ID=sa;Password=sa2025@1");

        public DataSet ViewAll()
        {
            string query = "SELECT * FROM Student";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable Search(string studentID)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM Student WHERE StudentID=@StudentID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;

            }
        }

        public void AddData(string studentID, string name, string surname, int year, decimal grade)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                try
                {
                    connection.Open();
                    string query = "INSERT INTO Student (StudentID,Name,Surname,Year,Grade)" +
                        "VALUES (@StudentID,@Name,@Surname,@Year,@Grade)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Grade", grade);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Updata(int studentID, string name, string surname, int year, decimal grade) // Already int
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Student SET Name=@Name, Surname=@Surname, Year=@Year, Grade=@Grade WHERE StudentID=@StudentID";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Grade", grade);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("Update failed: ID not found.");
                    }
                    else
                    {
                        MessageBox.Show("Update successful!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public void Delete(string studentID)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Student WHERE StudentID=@StudentID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("No student found");
                    }
                    else
                    {
                        MessageBox.Show("Student found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
