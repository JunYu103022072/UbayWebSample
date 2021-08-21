using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLogInfo"] != null)
            {
                this.plclogin.Visible = false;
            }
            else
            {
                this.plclogin.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //從資料庫取出的
            //string db_Account = "Admin";
            //string db_Password = "12345";
            //inp = 輸入值
            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtPassword.Text;
            string errorMsg;

            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out errorMsg))
            {
                this.ltlMessage.Text = errorMsg;
                return;
            }

            Response.Redirect("/SystemAdmin/UserInfo.aspx");

        }
    }
}