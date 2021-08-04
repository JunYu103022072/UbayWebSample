using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControl
{
    public partial class ucControl : System.Web.UI.UserControl
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
           // Bind(); use AccountingList Call it    
        }

        public void Bind()
        {
            int totalPages = this.GetTotalPages();

            this.ltlPager.Text = $"共 {this.TotalSize} 筆, 共 {totalPages} 頁, 目前在第{this.GetCurrentPage()}頁 <br/>";
            for (var i = 1; i <= totalPages; i++)
            {
                this.ltlPager.Text += $"<a href={this.Url}>{i}</a>&nbsp;";
            }
        }
        //取頁
        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private int GetTotalPages()
        {
            int pages = this.TotalSize / this.PageSize;
            if ((this.TotalSize / this.PageSize % 10) > 0)
                pages += 1;
            return pages;
        }

    }
}