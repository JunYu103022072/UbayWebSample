using AccountingNote.DBsourse;
using AccountingNote.ORM.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : AdminPageBass
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

            //認證授權
            var list = UserInfoManager.GetUserList_ORM();
            this.gvList.DataSource = list;
            this.gvList.DataBind();
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;        // = 每一列樣板實體化的內容

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lblUserLevel") as Label;
                var rowData = row.DataItem as ORM.DBModel.UserInfo;
                int userLevel = rowData.UserLevel;
                if( userLevel == 2)
                {
                    lbl.Text = "管理者";
                }
                else
                {
                    lbl.Text = "一般會員";
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserCreate.aspx");
        }
    }
}