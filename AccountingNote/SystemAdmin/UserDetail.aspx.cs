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
    public partial class UserChangeInfo : AdminPageBass
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
            if (!this.IsPostBack)
            {
                string idText = this.Request.QueryString["ID"];
                Guid id;
                if (Guid.TryParse(idText, out id))
                {
                    var user = UserInfoManager.GetUser(id);

                    if (user == null)
                    {
                        this.Response.Write("User null");
                    }
                    else
                    {
                        this.ltlAccount.Text = user.Account;
                        this.txtName.Text = user.Name;
                        this.txtEmail.Text = user.Email;

                        int userLevel = user.UserLevel;
                        if (userLevel == 2)
                        {
                            this.ltlUserLevel.Text = "管理員";
                        }
                        else
                        {
                            this.ltlUserLevel.Text = "一般會員";
                        }
                        this.ltlDateTime.Text = currentUser.DateTime.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            string email = this.txtEmail.Text;
            string account = this.Session["UserLoginInfo"] as string;
            var userInfo = UserInfoManager.GetUserInfoByAccount_ORM(account);
            if (userInfo == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            //string userID = drUserInfo["ID"].ToString();

            ORM.DBModel.UserInfo user = new ORM.DBModel.UserInfo()
            {
                Name = name,
                Email = email
            };

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                Response.Write("名稱不得空白");
            }
            else
            {
                string idText = this.Request.QueryString["ID"];
                Guid id;
                if (Guid.TryParse(idText, out id))
                {
                    var userEdit = UserInfoManager.GetUser(id);
                    user.ID = userEdit.ID;
                    UserInfoManager.UpdateUserInfo(user);
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();            // 清除登入資訊
            Response.Redirect("/Login.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}