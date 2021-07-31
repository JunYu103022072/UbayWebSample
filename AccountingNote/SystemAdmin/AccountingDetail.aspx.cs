using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote.DBsourse;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] == null)      //Session沒東西, 強導回登入 checkLogin
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            string account = this.Session["UserLoginInfo"] as string;
            //要傳入Accounting的資料,要知道User的ID
            var drUserInfo = UserInfoManager.GetUserInfoByAccount(account);             //* id = 0  idText=null drUserInfo = System.DataRow

            if (drUserInfo == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            if (!this.IsPostBack)
            {
                //檢查URL有沒有帶ID參數
                if (this.Request.QueryString["ID"] == null)
                {
                    this.btnDelete.Visible = false;         //新增模式下
                }
                else
                {
                    this.btnDelete.Visible = true;          //修改模式

                    //避免不能轉成ID流水號
                    string idText = this.Request.QueryString["ID"];
                    int id;
                    if (int.TryParse(idText, out id))
                    {
                        //多出使用者ID保護資料
                        var drAccounting = AccountingManager.GetAccounting(id,drUserInfo["ID"].ToString());

                        if (drAccounting == null)
                        {
                            this.ltlMsg.Text = "Data doesn't exist";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;
                        }
                        else
                        {
                            this.ddlActType.SelectedValue = drAccounting["ActType"].ToString();
                            this.txtAmount.Text = drAccounting["Amount"].ToString();
                            this.txtCaption.Text = drAccounting["Caption"].ToString();
                            this.txtDesc.Text = drAccounting["Body"].ToString();
                        }
                    }
                    else
                    {
                        this.ltlMsg.Text = "ID is required";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //List<string> msgList = new List<string>();
            //if (!this.CheckInput(out msgList))
            //{
            //    this.ltlMsg.Text = string.Join("<br/>", msgList);
            //    return;
            //}
            string account = this.Session["UserLoginInfo"] as string;
            var drUserInfo = UserInfoManager.GetUserInfoByAccount(account);

            if (drUserInfo == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            string userID = drUserInfo["ID"].ToString();
            string actTypeText = this.ddlActType.SelectedValue;
            string amountText = this.txtAmount.Text;
            string caption = this.txtCaption.Text;
            string body = this.txtDesc.Text;

            int amount = Convert.ToInt32(amountText);
            int actType = Convert.ToInt32(actTypeText);

            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                //Execute 'Insert Into db'
                AccountingManager.CreateAccounting(userID, caption, amount, actType, body);
            }
            else
            {
                int id;
                if (int.TryParse(idText, out id))
                {
                    AccountingManager.UpdateAccounting(id, userID, caption, amount, actType, body);
                }
            }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }
        /// <summary> 檢查欄位空值 </summary>
        /// <param name="errorMsgList"></param>
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            //Type
            if (this.ddlActType.SelectedValue != "0" && this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type must be 0 or 1");
            }
            //Amount
            if (string.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                msgList.Add("Amount is required");
            }
            else
            {
                int tempInt;
                if (!int.TryParse(this.txtAmount.Text, out tempInt))
                {
                    msgList.Add("Amount must be a number.");
                }
                if (tempInt < 0 || tempInt > 1000000)
                {
                    msgList.Add("Amount must between 0 and 1 and 1,000,000  .");
                }
            }
            errorMsgList = msgList;

            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
                return;

            int id;
            if (int.TryParse(idText, out id))
            {
                AccountingManager.DeleteAccounting(id);
            }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");

        }
    }
}
