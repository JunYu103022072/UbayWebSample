using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using AccountingNote.DBsourse;
using AccountingNote.Auth;

namespace AccountingNote.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)                           //可能是按鈕跳回本頁 , 所以要判斷PostBack
            {
                //還沒登入的話 導回登入頁
                if (!AuthManager.Islogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrentUser();
                //帳號不存在轉登入頁
                if (currentUser == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                this.ltlAccount.Text = currentUser.Account;
                this.ltlName.Text = currentUser.Name;
                this.ltlEmail.Text = currentUser.Email;
                this.ltlUserLevel.Text = currentUser.UserLevel;
                this.ltlDateTime.Text = currentUser.DateTime;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();            // 清除登入資訊
            Response.Redirect("/Login.aspx");
        }
    }
}