using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class Scalar
    {
        static void Main(string[] args)
        {
            string connectionstring = "data source =.; database=Projectsample; integrated security = SSPI";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {

                SqlCommand command = new SqlCommand("Select count(DeptId) from department", connection);
                connection.Open();

                int TotalRows=(int)command.ExecuteScalar();
                Console.WriteLine($"TotalRows in Department table : {TotalRows}");

            }
            Console.ReadKey();

        }
    }
}
