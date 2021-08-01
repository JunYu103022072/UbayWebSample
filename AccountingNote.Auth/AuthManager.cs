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
    }
}
