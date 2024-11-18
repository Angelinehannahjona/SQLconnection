using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class Datareader
    {
        static void Main(string[] args)
        {

            try
            {
                string connectionstring = "data source =LAPTOP-UECHVFJR; database=Projectsample; integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {

                    SqlCommand command = new SqlCommand("Select * from department", connection);
                    connection.Open();
                    Console.WriteLine("Connection Established Successfully");

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        /* int id = reader.GetInt32(0);
                         string name = reader.GetString(1);
                         decimal salary = reader.GetDecimal(2);  
                         int departmentId = reader.GetInt32(3);      */

                        Console.WriteLine(reader["DeptId"]  +" ," +reader["Deptname"]);
                    }
                }
            }
            
            catch (Exception e)
            
            {
                Console.WriteLine($"Something went wrong {e}");
            }
            Console.ReadKey();
        }
    }
}
