using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class ExecuteNonQuery

    {
        static void Main(string[] args)
        {

            string connectionstring = "data source=.; database=Projectsample; integrated security=SSPI; "

            using(SqlConnection connection = new SqlConnection(connectionstring))
            {

                Sqlcommand cmd = new Sqlcommand("insert into Department values (7, 'Botany')", connection);

                connection.Open();

                int rowafftected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Inserted Row = {rowafftected} ");

                cmd.CommandText = "update Department set DeptName=BioBotany where DeptID=7";
                int rowafftected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Updated Row = {rowafftected} ");

               /* cmd.CommandText = "Delete from Department DeptID=7";
                int rowafftected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Deleted Row = {rowafftected} ");*/

            }
            Console.ReadKey();
        }
    }
}
