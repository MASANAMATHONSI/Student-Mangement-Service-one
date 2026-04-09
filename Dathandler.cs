using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
    }
}
