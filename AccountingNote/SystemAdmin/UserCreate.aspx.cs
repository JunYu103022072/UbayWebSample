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
    public partial class UserCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            UserInfor userInfo = new UserInfor()
            {
                Account = this.txtAccount.Text,
                PWD = this.txtPassword.Text,
                Name = this.txtName.Text,
                Email = this.txtEmail.Text,
                MobilePhone = this.txtPhone.Text,
                UserLevel = 1
            };
            UserInfoManager.CreateUser(userInfo);
            Response.Redirect("/SystemAdmin/UserList.aspx");
        }
    }
}