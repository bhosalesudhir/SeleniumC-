
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumwithDotNetCore.DataBase
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Dev"].ConnectionString);

            connection.Open();

            return connection;
        }
    }
}
