using System;
using System.Data.SqlClient;


namespace SQLconnection
{
    internal class ConnectionSQL
    {
        static void Main(string[] args)
        {
            string connectionstring = "data source =.; database=Projectsample; integrated security = SSPI";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                Console.WriteLine("Connection Established Successfully");

            }
            Console.ReadKey();

        }
    }
}
