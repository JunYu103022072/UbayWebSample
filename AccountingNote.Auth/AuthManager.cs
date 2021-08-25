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
        /// <summary> 檢查是否登入</summary>
        /// <returns></returns>
        public static bool Islogined()
        {
            //check logined
            if (HttpContext.Current.Session["UserLoginInfo"] == null) //沒登入狀況
                return false;
            else
                return true;
        }
        /// <summary>取得已登入使用者資訊（沒登入就回傳null)</summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;
            if (account == null)
            return null;

            //有值的狀況下存使用者資訊回傳
            //DataRow dr = UserInfoManager.GetUserInfoByAccount(account);
            var userInfo = UserInfoManager.GetUserInfoByAccount_ORM(account);
            if (userInfo == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.ID = userInfo.ID;
            model.Account = userInfo.Account;
            model.Password = userInfo.PWD;
            model.Name = userInfo.Name;
            model.Email = userInfo.Email;
            model.MobilePhone = userInfo.MobilePhone;
            model.UserLevel = userInfo.UserLevel;
            model.DateTime = userInfo.Datetime;
            //model.UserLevel = dr["UserLevel"].ToString();
            //model.DateTime = dr["Datetime"].ToString();
            return model;
        }

        /// <summary>清除登入 (登出)</summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }
        /// <summary>嘗試登入</summary>
        /// <param name="account"></param>
        /// <param name="PWD"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string PWD, out string errorMsg)
        {
            //check empty
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(PWD))
            {
                errorMsg = "Required the Account / PWD";
                return false;
            }
            var userInfo = UserInfoManager.GetUserInfoByAccount_ORM(account);
            //check null
            if (userInfo == null)
            {
                errorMsg = $"This Account : {account} doesn't exists";
                return false;
            }
            //check Account / Pwd
            //Compare 比對大小寫 , true = 大小寫不干擾 false = 大小寫字串需一致
            if (string.Compare(userInfo.Account.ToString(), account, true) == 0 && string.Compare(userInfo.PWD.ToString(), PWD, false) == 0)
            {
                //進入使用者畫面
                HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account.ToString();

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
