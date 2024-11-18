using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLconnection
{
    internal class Sqlcmdparam
    {
        static void Main(string[] args)
        {

            //string connectionstring = " data source=.; database=Department; integrated security = SSPI";


            using (SqlConnection connection = new SqlConnection(" data source=LAPTOP-UECHVFJR; database=projectsample; integrated security = SSPI"))
            {

                SqlCommand cmd = new SqlCommand("select * from department where DeptID=@deptid", connection);
                //cmd.Parameters.AddWithValue("@deptid", 8);

                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@deptid",
                    SqlDbType = SqlDbType.Int,
                    Value = 8
                };

                cmd.Parameters.Add(param);

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
