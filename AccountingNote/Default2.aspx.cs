using AccountingNote.DBsourse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataRow drTotal = AccountingManager.GetTotal();
            DataRow drAc = AccountingManager.GetFirstAndLastAccount();

            this.lblFirst.Text = drAc["FIRST"].ToString();
            this.lblLast.Text = drAc["LAST"].ToString();
            string totalAcc = drTotal["TotalAccount"].ToString();
            string totalUser = drTotal["TotalUser"].ToString();
            this.lblAmount.Text = $"共 {totalAcc} 筆";
            this.lblMemCount.Text = $"共 {totalUser} 人";
        }
    }
}