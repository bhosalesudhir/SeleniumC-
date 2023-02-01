
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumwithDotNetCore.DataBase
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Dev"].ConnectionString);

            connection.Open();

            return connection;
        }

        public static int Execute(string query, int timeout)
        {
            var connnection= DBConnection.GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = timeout;
                cmd.Connection = connnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                return cmd.ExecuteNonQuery(); // return no of rows affected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            finally{
                connnection.Close(); 
            }
        }
    }

    
}
