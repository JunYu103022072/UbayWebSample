using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AccountingNote.DBsourse;
using System.Drawing;
using AccountingNote.Auth;
using AccountingNote.ORM.DBModel;
using Image = System.Web.UI.WebControls.Image;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //還沒登入的話 導回登入頁
            if (!AuthManager.Islogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }
            string account = this.Session["UserLoginInfo"] as string;
            //要傳入Accounting的資料,要知道User的ID
            var currentUser = AuthManager.GetCurrentUser();
            //帳號不存在轉登入頁
            if (currentUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            //Read Accounting Data
            //var dt = AccountingManager.GetAccountingList(currentUser.UserGuid);
            var list = AccountingManager.GetAccountingList(currentUser.ID);
            int total = AccountingManager.GetTotal();

            this.ltlTotal.Text = $"總計金額 : {total} 元";
            

            //if (dt.Rows.Count > 0)
            //{
            //this.gvAccountList.DataSource = list;
            //this.gvAccountList.DataBind();

            //this.ucPager2.TotalSize = list.Count;
            //this.ucPager2.Bind();

            //int totalPages = this.GetTotalPages(dt);
            //var dtPaged = this.GetPageDataTable(list);
            //this.gvAccountList.DataSource = dt;

            //var pages = (dt.Rows.Count / 10);


            if (list.Count > 0)
            {
                var pagedList = this.GetPageDataTable(list);
                this.gvAccountList.DataSource = pagedList;
                this.gvAccountList.DataBind();
                this.ucPager2.TotalSize = list.Count;
                this.ucPager2.Bind();
            }
            else
            {
                this.gvAccountList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }
        //取頁
        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"]; //get Pages now

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }
        private List<Accounting> GetPageDataTable(List<Accounting> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }
        //取資料如何分頁
        private DataTable GetPageDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            int pageSize = this.ucPager2.PageSize;
            int startIndex = (this.GetCurrentPage() - 1) * pageSize;
            int endIndex = (this.GetCurrentPage()) * pageSize;

            if (endIndex > dt.Rows.Count) //筆數修正
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }
                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }
        /// <summary>Total Pages</summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetTotalPages(DataTable dt)
        {
            int pages = dt.Rows.Count / 10;        // 1 -> 0  ,  12 -> 1  , 10 ->1
            if ((dt.Rows.Count % 10) > 0)
                pages += 1;
            return pages;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;        // = 每一列樣板實體化的內容

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lblActType") as Label;
                Image img = row.FindControl("imgCover") as Image;

                //var dr = row.DataItem as DataRowView;
                //int actType = dr.Row.Field<int>("ActType");
                var rowData = row.DataItem as Accounting;
                int actType = rowData.ActType;

                if (actType == 0)
                {
                    lbl.Text = "支出";
                }
                else
                {

                    lbl.Text = "收入";
                }
                if(!string.IsNullOrEmpty(rowData.CoverImage))
                {
                    img.Visible = true;
                    img.ImageUrl = "../FileDownload/Accounting/" + rowData.CoverImage;
                }
                if (rowData.Amount > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }

    }
}