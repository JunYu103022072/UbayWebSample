using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class ucPager2 : System.Web.UI.UserControl
    {
        public int Pagesiz { get; set; }
        public int CurrentPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int GetCurrentPage()
        {
            string pageText = this.Request.QueryString["page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int pageIndex = 0;

            if (!int.TryParse(pageText, out pageIndex))
                return 1;
            if (!int.TryParse(pageText, out pageIndex))
                return 1;

            return 0;
        }
        public void Bind()
        {
            //依照目前的頁數計算
            this.CurrentPage = this.GetCurrentPage();
            if(this.CurrentPage ==1)
            {
            }
        }
    }
}