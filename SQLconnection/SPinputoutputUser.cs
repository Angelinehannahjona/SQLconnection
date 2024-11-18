using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SQLconnection
{
    internal class SPinputoutputUser
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection("data source=.; database= Projectsample; integrated security=SSPI"))

            {

                try
                {

                    Console.WriteLine("Enter the department id to insert");
                    int DepartmentID = Convert.ToInt32(Console.ReadLine());


                    Console.WriteLine("Enter the department Name to insert");
                    string DepartmentName = Console.ReadLine();


                    SqlCommand cmd = new SqlCommand("InsertDepartment9", connection)
                    {
                        CommandType = CommandType.StoredProcedure


                    };

                    SqlParameter param1 = new SqlParameter

                    {

                        ParameterName = "deptid",
                        SqlDbType = SqlDbType.Int,
                        Value = DepartmentID,
                        Direction = ParameterDirection.Input

                    };
                    cmd.Parameters.Add(param1);

                    SqlParameter param2 = new SqlParameter

                    {

                        ParameterName = "Deptname",
                        SqlDbType = SqlDbType.VarChar,
                        Value = "DepartmentName",
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

                  //  int lastInsertedId = (int)cmd.Parameters["@id"].Value;
                  int lastInsertedId = (int)outputparam.Value;

                    Console.WriteLine($"Last inserted DeptID: {lastInsertedId}");




                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error message :" +ex.Message);
                }

                Console.ReadKey();

            }

        }



    }
}