using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControl
{
    public partial class ucPager2 : System.Web.UI.UserControl
    {
        // Use Property more flexible (彈性)
        /// <summary>頁面 url </summary>
        public string Url { get; set; }
        /// <summary>總筆數 </summary>
        public int TotalSize { get; set; }
        /// <summary>頁面筆數</summary>
        public int PageSize { get; set; }
        /// <summary>目前頁數</summary>
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;           //Default


            int pageIndex = 0;
            if (!int.TryParse(pageText, out pageIndex))
                return 1;

            return pageIndex;
        }
        public void Bind()
        {
            //檢查每一頁筆數
            if (this.PageSize <= 0)
            {
                throw new DivideByZeroException();
            }

            //算總頁數
            int totalPages = this.TotalSize / this.PageSize;
            if (this.TotalSize % this.PageSize > 0)
                totalPages += 1;
            this.aLinkFirst.HRef = $"{this.Url}?page=1";
            this.aLinkLast.HRef = $"{this.Url}?page={totalPages}";


            // 依照目前得頁面做計算 when 3 is currentLink 
            this.CurrentPage = this.GetCurrentPage();
            this.ltlCurrentPage.Text = this.CurrentPage.ToString();

            //計算頁數
            int prevM1 = this.CurrentPage - 1;
            int prevM2 = this.CurrentPage - 2;

            this.aLink2.HRef = $"{this.Url}?page={prevM1}";
            this.aLink2.InnerHtml = prevM1.ToString();
            this.aLink1.HRef = $"{this.Url}?page={prevM2}";
            this.aLink1.InnerHtml = prevM2.ToString();

            int nextP1 = this.CurrentPage + 1;
            int nextP2 = this.CurrentPage + 2;

            this.aLink4.HRef = $"{this.Url}?page={nextP1}";
            this.aLink4.InnerHtml = nextP1.ToString();
            this.aLink5.HRef = $"{this.Url}?page={nextP2}";
            this.aLink5.InnerHtml = nextP2.ToString();

            //依照頁數決定是否隱藏超連結,並處理提示文字
            if (prevM2 <= 0)
                this.aLink1.Visible = false;

            if (prevM1 <= 0)
                this.aLink2.Visible = false;

            if (nextP1 > totalPages)
                this.aLink4.Visible = false;

            if (nextP2 > totalPages)
                this.aLink5.Visible = false;
            this.ltlPager.Text = $"<br/>共 {this.TotalSize} 筆, 共 {totalPages} 頁, 目前在第{this.GetCurrentPage()}頁";
        }
    }
}
