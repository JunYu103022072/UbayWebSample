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
            var cUser = AccountingNote.Auth.AuthManager.GetCurrentUser();

            this.gvUserList.DataSource = AccountingNote.DBsourse.UserInfoManager.GetUserList();
            this.gvUserList.DataBind();
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;        // = 每一列樣板實體化的內容

            if (row.RowType == DataControlRowType.DataRow)
            {
                var dr = row.DataItem as DataRowView;
                Label label = new Label();
                label.ID = "lblLevel";

                int level = dr.Row.Field<int>("UserLevel");
                string userL = level.ToString();
                if (level == 1)
                {
                    userL = "高級會員";
                }
                else
                {

                    userL = "一般會員";
                }
 
            }
        }
    }
}