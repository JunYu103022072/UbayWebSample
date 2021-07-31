using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountingNote.DBsourse
{
    public class DBHelper
    {
        public static string GetConnectionString()
        {
            //Configuration 使用特定資源或應用程式 且不能繼承 ex : Application
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }
        public static DataRow ReadDataRow(string connect,string command,List<SqlParameter> list)
        {

            return null;
        }
        public static int MotifyData(string ConnStr,string dbCommand, List<SqlParameter> paramList)
        {
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                using (SqlCommand command = new SqlCommand(dbCommand, connection))
                {
                    command.Parameters.AddRange(paramList.ToArray());
                    connection.Open();
                    int effetcRowsCount = command.ExecuteNonQuery();
                    return effetcRowsCount;
                }
            }
        }
    }
}
