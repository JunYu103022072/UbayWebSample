using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //還沒登入的話 導回登入頁
            if (!AuthManager.Islogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();
            //帳號不存在轉登入頁
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            this.ValidateLevelAndRole(currentUser);
        }
        /// <summary> 管理者 / 角色權益請益 </summary>
        /// <param name="currentUser"></param>
        private void ValidateLevelAndRole(UserInfoModel currentUser)
        {
            if (!(this.Page is AdminPageBass))
                return;

            var adminPage = (AdminPageBass)this.Page;

            if (adminPage.RequiredLevel == UserLevelEnum.Admin && currentUser.Level != UserLevelEnum.Admin)
            {
                Response.Redirect("UserInfo.aspx");
                return;
            }
            if (adminPage.RequiredLevel == UserLevelEnum.Regular &&
                !AuthManager.IsGrant(currentUser.ID, adminPage.RequiredRoles))
            {
                Response.Redirect("UserInfo.aspx");
                return;
            }
        }
    }
}