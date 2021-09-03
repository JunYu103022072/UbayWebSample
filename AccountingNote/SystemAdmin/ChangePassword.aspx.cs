using AccountingNote.Auth;
using AccountingNote.DBsourse;
using AccountingNote.ORM.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //還沒登入的話 導回登入頁
            if (!AuthManager.Islogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            var currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            this.ltlAccount.Text = currentUser.Account;
            this.txtPWD.Text = currentUser.Password;
        }

        protected void btnPwdChange_Click(object sender, EventArgs e)
        {
            string inp_PWD = this.txtNewPWD.Text;
            string inp_PWD2 = this.txtNewPWD2.Text;
            string account = this.Session["UserLoginInfo"] as string;
            var userInfo = UserInfoManager.GetUserInfoByAccount_ORM(account);
            ORM.DBModel.UserInfor user = new ORM.DBModel.UserInfor()
            {
                PWD = inp_PWD
            };
            if (userInfo == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            Guid userGuid = userInfo.ID;
            if (inp_PWD != inp_PWD2)
            {
                this.ltlMsg.Text = "輸入密碼不一致,請重新輸入";
            }
            else if(string.IsNullOrWhiteSpace(inp_PWD) || string.IsNullOrWhiteSpace(inp_PWD2))
            {
                this.ltlMsg.Text = "密碼不得為空值";
            }
            else
            {
                user.ID = userGuid;
                UserInfoManager.UpdateUserPassword(user);
                this.ltlMsg.Text = "密碼更換成功";
            }
        }
    }
}