using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.Session["UserLoginedInfo"] = null;
        }
    }
}