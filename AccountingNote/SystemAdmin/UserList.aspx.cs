using AccountingNote.DBsourse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AccountingNote.Auth.AuthManager.Islogined())
            {
                return;
            }
            //取得使用者
            var currentUser = AccountingNote.Auth.AuthManager.GetCurrentUser();
            //帳號不存在轉登入頁
            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            var userList = UserInfoManager.GetUserList_ORM();
            this.gvUserList.DataSource = userList.ToList();
            this.gvUserList.DataBind();
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;        // = 每一列樣板實體化的內容

            if (row.RowType == DataControlRowType.DataRow)
            {
                string account = this.Request.Form["Account"];
                var dr = row.DataItem as DataRowView;
                Label lbl = row.FindControl("UserLevel") as Label;
                var rowData = row.DataItem as UserInfo;
                int level = dr.Row.Field<int>("UserLevel");
                if (level == 2)
                {
                    account = "管理員";
                }
                else
                {
                    lbl.Text = "一般會員";
                }
 
            }
        }
    }
}