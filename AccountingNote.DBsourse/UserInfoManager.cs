using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;                      //利用Data資料庫欄位設定
using System.Data.SqlClient;            //取得連線
using System.Configuration;
using AccountingNote.ORM.DBModel;

namespace AccountingNote.DBsourse
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID], [Account], [PWD], [Name], [Email],[UserLevel],[Datetime]
                    FROM UserInfo 
                    WHERE [Account] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));
            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                //Web環境無法Console 所以用Logger替
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static UserInfo GetUserInfoByAccount_ORM(string account)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.UserInfoes
                         where item.Account == account
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

        public static DataTable GetUserList()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [Account], [PWD], [Name], [Email],[UserLevel],[Datetime]
                    FROM UserInfo 
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.AddRange(list);
            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                //Web環境無法Console 所以用Logger替
                Logger.WriteLog(ex);
                return null;
            }
        }
        /// <summary> 取得用戶列表 </summary>
        /// <returns></returns>
        public static List<UserInfo> GetUserList_ORM()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = context.UserInfoes;
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
        public static UserInfo GetUser(Guid ID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.UserInfoes
                         where item.ID == ID
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
        public static bool UpdateUserInfo(UserInfo userInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbuser = context.UserInfoes.Where(user => user.ID == userInfo.ID).FirstOrDefault();

                    if (dbuser != null)
                    {
                        dbuser.Name = userInfo.Name;
                        dbuser.Email = userInfo.Email;

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
        public static bool UpdateUserPassword(UserInfo userInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbuser = context.UserInfoes.Where(user => user.ID == userInfo.ID).FirstOrDefault();

                    if (dbuser != null)
                    {
                        dbuser.PWD = userInfo.PWD;

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
        public static void CreateUser(UserInfo userinfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    userinfo.Datetime = DateTime.Now;
                    context.UserInfoes.Add(userinfo);
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
