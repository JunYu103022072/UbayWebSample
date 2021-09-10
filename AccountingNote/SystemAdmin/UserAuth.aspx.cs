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
    public partial class UserAuth : AdminPageBass
    {
        public override UserLevelEnum RequiredLevel { get; set; } = UserLevelEnum.Admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser.Level != UserLevelEnum.Admin)
            {
                Response.Redirect("UserInfo.aspx");
                return;
            }
            if (!this.IsPostBack)
            {
                string userIDText = Request.QueryString["ID"];

                if (string.IsNullOrWhiteSpace(userIDText))
                    return;
                Guid userID = Guid.Parse(userIDText);
                var mUser = UserInfoManager.GetUser(userID);
                if (mUser == null)                       //Account non-existent transfor to UserList
                {
                    Response.Redirect("UserList.aspx");
                    return;
                }
                this.ltlAccount.Text = mUser.Account;

                this.ckbRoleList.DataSource = RoleManager.GetRoleList();
                this.ckbRoleList.DataBind();

                //讀取現有角色
                List<Role> list = RoleManager.GetUserRoleList(userID);
                this.rptRoleList.DataSource = list;
                this.rptRoleList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> willSaveIDList = new List<string>();

            foreach (ListItem li in this.ckbRoleList.Items)
            {
                if (li.Selected)
                    willSaveIDList.Add(li.Value);
            }
            if (willSaveIDList.Count == 0)
                return;

            var roleList =
                willSaveIDList.Select(obj => Guid.Parse(obj)).ToArray();

            string userIDText = Request.QueryString["ID"];
            Guid userID = Guid.Parse(userIDText);

            Auth.AuthManager.MapUserAndRole(userID, roleList);
        }

        protected void rptRoleList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string userIDText = Request.QueryString["ID"];

                if (string.IsNullOrWhiteSpace(userIDText))
                    return;

                Guid userID = Guid.Parse(userIDText);
                var mUser = UserInfoManager.GetUser(userID);

                if (mUser == null)
                {
                    Response.Redirect("UserList.aspx");
                }

                if (e.CommandName == "DeleteRole")
                {
                    string roleIDText = e.CommandArgument as string;
                    Guid roleID = Guid.Parse(roleIDText);

                    RoleManager.DeleteUserRole(userID, roleID);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}