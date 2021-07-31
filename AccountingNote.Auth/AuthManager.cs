using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using AccountingNote.DBsourse;

namespace AccountingNote.Auth
{
    public class AuthManager
    {
        //專門檢查有無登入
        public static bool Islogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 取得已登入使用者 (沒登入回復null)
        /// </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
            {
                return null;
            }

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
            {
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();

            return model;
        }
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            //check empty
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
            {
                errorMsg = "Account / PWD is required. ";
                return false;
            }

            var dr = UserInfoManager.GetUserInfoByAccount(account);

            //check null
            if (dr == null)
            {
                errorMsg = $"Account : {account} doesn't exists";
                return false;
            }
            //check Account / Pwd
            //Compare 比對大小寫 , true = 大小寫不干擾 false = 大小寫字串需一致
            if (string.Compare(dr["Account"].ToString(), account, true) == 0 && string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                //進入使用者畫面
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();

                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "Login Fail ! Please check your Account / Password";
                return false;
            }
        }
    }
}
