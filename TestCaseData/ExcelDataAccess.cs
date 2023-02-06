using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Dapper;
/*
1)OLE DB supports accessing data stored in any format (databases, spreadsheets, text files, and so on)
2) add reference of Dapper , System.Data.oleDb package
*/
namespace SeleniumwithDotNetCore.TestCaseData
{
    public class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            /*
             Data Provider: The first parameter or one of the parameters of a connection is the database provider. To specify the provider.  Microsoft.Jet.OLEDB.4.0 Or Microsoft.ACE.OLEDB.12.
             */
            var fileName = ConfigurationManager.AppSettings["path"]; // path: excel file path 
            var conn = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return conn;
        }

        public static string GetTestData()
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open(); // dataset is sheetname of excel file , key name = testcasename
                var query = string.Format("select * from [DataSet$]");
                var value = connection.Query<string>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}

