using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class SPinputoutput
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection("data source=.; database= Projectsample; integrated security=SSPI"))

            {



                SqlCommand cmd = new SqlCommand("InsertDepartment9", connection)
                {
                    CommandType = CommandType.StoredProcedure


                };

                SqlParameter param1 = new SqlParameter

                {

                    ParameterName = "deptid",
                    SqlDbType = SqlDbType.Int,
                    Value = 11,
                    Direction = ParameterDirection.Input

                };
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter

                {

                    ParameterName = "Deptname",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "Geo",
                    Direction = ParameterDirection.Input

                };
                cmd.Parameters.Add(param2);

                SqlParameter outputparam = new SqlParameter

                {

                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                   Direction = ParameterDirection.Output

                };
                cmd.Parameters.Add(outputparam);
                connection.Open();


                cmd.ExecuteNonQuery();

                int lastInsertedId = (int)outputparam.Value;

               
                Console.WriteLine($"Last inserted DeptID: {lastInsertedId}");
            
          

            }

            Console.ReadKey();

        }

    }
}
