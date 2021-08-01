using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountingNote.DBsourse
{
    public class AccountingManager
    {
        public static DataTable GetAccountingList(string userID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT
                        ID,
                        Caption,
                        Amount,
                        ActType,
                        CreateDate
                    FROM Accounting
                    WHERE UserID = @userID
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            //要把錯誤露出來
            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>查詢流水帳清單</summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// 一次查詢兩個值比較不容易讓人窺探資料
        public static DataRow GetAccounting(int id, string userID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT
                        ID,
                        Caption,
                        Amount,
                        ActType,
                        CreateDate,
                        Body
                    FROM Accounting
                    WHERE ID = @id AND UserID = @userID
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));
            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>更改流水帳</summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            //  check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount  must  between  0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1");

            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [Accounting]
                    SET
                        UserID      = @userID
                        ,Caption    = @caption
                        ,Amount     = @amount
                        ,ActType    = @actType
                        ,CreateDate = @createDate
                        ,Body        =@body
                    WHERE
                        ID = @id
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@userID", userID));
            paramlist.Add(new SqlParameter("@caption", caption));
            paramlist.Add(new SqlParameter("@amount", amount));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@createDate", DateTime.Now));
            paramlist.Add(new SqlParameter("@body", body));
            paramlist.Add(new SqlParameter("@id", ID));

            try
            {
                int effectRows = DBHelper.ModifyData(connectionString, dbCommand, paramlist);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        /// <summary>刪除流水帳</summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting(int ID)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE  [Accounting]
                    WHERE ID = @id ";

            try
            {
                DBHelper.ModifyData(paramlist, connectionString, dbCommand);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }



        /// <summary>建立流水帳</summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            //  check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount  must  between  0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1");

            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO [dbo].[Accounting]
                    (
                        UserID     
                        ,Caption    
                        ,Amount     
                        ,ActType    
                        ,CreateDate 
                        ,Body       
                    )
                    VALUES
                    (
                        @userid    
                        ,@caption    
                        ,@amount     
                        ,@actType    
                        ,@createDate 
                        ,@body       
                    ) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommand, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@caption", caption);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@actType", actType);
                    command.Parameters.AddWithValue("@createDate", DateTime.Now);
                    command.Parameters.AddWithValue("@body", body);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }
                }
            }
        }
    }
}
