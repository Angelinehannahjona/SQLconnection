using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class SPsimple

    {
        static void Main(string[] args)


        {
            using (SqlConnection connection = new SqlConnection("data source =.; database=Projectsample; integrated security = SSPI"))

            {
                SqlCommand cmd = new SqlCommand("GetnamebyDeptID", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptid", 1);
                cmd.Parameters.AddWithValue("@Deptname", "Physics");

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["DeptID"] + " , " + reader["DeptName"]);
                }
            }
            Console.ReadKey();
        }


    }
}
