using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class ExecuteNonQuery

    {
        static void Main(string[] args)
        {

            string connectionstring = "data source=.; database=Projectsample; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("insert into Department values (7, 'Botany')", connection);
                connection.Open();

             int rowafftected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Inserted Row = {rowafftected} ");

                cmd.CommandText = "update Department set DeptName='BioBotany' where DeptID=7";
                rowafftected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Updated Row = {rowafftected} ");

                cmd.CommandText = "Delete from Department where DeptID=7";
               // cmd.Connection = connection;
                  rowafftected = cmd.ExecuteNonQuery();
                 Console.WriteLine($"Deleted Row = {rowafftected} ");

            }
            Console.ReadKey();
        }
    }
}
