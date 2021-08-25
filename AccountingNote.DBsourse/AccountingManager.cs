using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using AccountingNote.ORM.DBModel;

namespace AccountingNote.DBsourse
{
    public class AccountingManager
    {
        /// <summary>
        /// 查詢流水帳清單
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
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

        public static List<Accounting> GetAccountingList(Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.UserID == userID
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

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
        /// <summary>查詢流水帳</summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// 一次查詢兩個值比較不容易讓人窺探資料
        public static Accounting GetAccounting(int id, Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.ID == id && item.UserID == userID
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 取得第一筆和最後一筆使用者
        /// </summary>
        /// <returns></returns>
        public static DataRow GetFirstAndLastAccount()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                     MAX(CreateDate) AS LAST
                    ,MIN(CreateDate) AS FIRST
                    FROM Accounting
                ";

            List<SqlParameter> list = new List<SqlParameter>();
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

        public static DataRow GetTotal()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        COUNT(Accounting.ID) AS TotalAccount,
                        (
                        SELECT COUNT(ID) 
                        FROM UserInfo 
                        )TotalUser
                        FROM Accounting
                ";

            List<SqlParameter> list = new List<SqlParameter>();
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
                int effectRows = DBHelper.ModifyData(paramlist, connectionString, dbCommand);

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
        /// <summary>更改流水帳</summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static bool UpdateAccounting(Accounting accounting)
        {
            //  check input
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount  must  between  0 and 1,000,000.");
            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("ActType must be 0 or 1");
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Accountings.Where(obj => obj.ID == accounting.ID).FirstOrDefault();
                    if (dbObject != null)
                    {
                        dbObject.ActType = accounting.ActType;
                        dbObject.Amount = accounting.Amount;
                        dbObject.Caption = accounting.Caption;
                        dbObject.Body = accounting.Body;

                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

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
        /// <summary>刪除流水帳</summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting_ORM(int ID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbRemove = context.Accountings.Where(obj => obj.ID == ID).FirstOrDefault();
                    context.Accountings.Remove(dbRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            //  check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount  must  between  0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1");

            string bodyColumnSQL = "";
            string bodyValueSQL = "";
            if (!string.IsNullOrWhiteSpace(body))
            {
                bodyColumnSQL = ",Body";
                bodyValueSQL = ",@body";
            }
            string connectionString = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO [dbo].[Accounting]
                    (
                        UserID     
                        ,Caption    
                        ,Amount     
                        ,ActType    
                        ,CreateDate 
                        {bodyColumnSQL}
                    )
                    VALUES
                    (
                        @userid    
                        ,@caption    
                        ,@amount     
                        ,@actType    
                        ,@createDate 
                        {bodyValueSQL}   
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
        /// <summary>建立流水帳</summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(Accounting accounting)
        {
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount  must  between  0 and 1,000,000.");
            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("ActType must be 0 or 1");

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    accounting.CreateDate = DateTime.Now;
                    context.Accountings.Add(accounting);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
    }
}
