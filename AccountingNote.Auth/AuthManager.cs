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
            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();
            return model;
        }

        /// <summary>清除登入 (登出)</summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }
    }
}
