using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace SQLconnection
{

    public class ConnectedArchitecture
    {
        public void Insertmethod(string pName, string pDesc)
        {

            using (SqlConnection connection = new SqlConnection("data source =.; database=Product; integrated security=SSPI"))

            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.CommandText = "Insert into Products values ('"+ pName + "','" + pDesc + "')";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

            }
        }

        public void Selectmethod(string ProductNm)
        {

            using (SqlConnection connection = new SqlConnection("data source =.; database=Product; integrated security=SSPI"))

            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.CommandText = "Select * from Products where ProductName = @pName";
                cmd.Connection = connection;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = ProductNm;
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    Console.WriteLine("ProductID:{0}, ProductName:{1}, ProductDesc:{2}", reader["ProductID"], reader["ProductName"], reader["ProductDesc"]);
                }
            }

        }

        public void StoreProcedureMethod(string ProductNm, string ProductDesc)
        {

            using (SqlConnection connection = new SqlConnection("data source =.; database=Product; integrated security=SSPI"))

            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPProducts";
                cmd.Connection = connection;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = ProductNm;
                cmd.Parameters.Add("@pDesc", SqlDbType.VarChar).Value = ProductDesc;
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    Console.WriteLine("ProductID:{0}, ProductName:{1}, ProductDesc:{2}", reader["ProductID"], reader["ProductName"], reader["ProductDesc"]);
                }
            }

        }
    }
        class Program
        {
              static void Main(string[] args)

              {
                        ConnectedArchitecture objCA = new ConnectedArchitecture();

                        Console.WriteLine("Inserting the products to the DB");
                        objCA.Insertmethod("Smart Watch", "Apple Smart Watch Series");


                
                        Console.WriteLine("Fetching the products from DB");
                        objCA.Selectmethod("Smart Watch");

                        Console.WriteLine("Executing Store procedure");
                        objCA.StoreProcedureMethod("Smart TV", "Oneplus Smart TV Series");

                        Console.ReadLine();
                }

        }

}



    


