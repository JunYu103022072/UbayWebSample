using AccountingNote.DBsourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userList = UserInfoManager.GetUserList_ORM();
            this.gvUserInfo.DataSource = userList.ToList();
            this.gvUserInfo.DataBind();
        }
    }
}