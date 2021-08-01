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

        public static DataTable ReadDataTable(string connectionString, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommand, connection))
                {
                    command.Parameters.AddRange(list.ToArray());

                    connection.Open();
                    var reader = command.ExecuteReader();

                    DataTable dt = new DataTable();         //放到DataTable
                    dt.Load(reader);

                    return dt;
                }
            }
        }
        public static DataRow ReadDataRow(string connectionString, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommand, connection))
                {
                    command.Parameters.AddRange(list.ToArray());

                    connection.Open();
                    var reader = command.ExecuteReader();

                    DataTable dt = new DataTable();         //放到DataTable
                    dt.Load(reader);

                    if (dt.Rows.Count == 0)
                        return null;

                    return dt.Rows[0];

                }
            }
        }
        public static int ModifyData(List<SqlParameter> paramlist, string connectionString, string dbCommand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommand, connection))
                {
                    command.Parameters.AddRange(paramlist.ToArray());
                    connection.Open();
                    int effectRowCount = command.ExecuteNonQuery();
                    return effectRowCount;
                }
            }
        }

        internal static int ModifyData(string connectionString, string dbCommand, List<SqlParameter> paramlist)
        {
            throw new NotImplementedException();
        }
    }
}
