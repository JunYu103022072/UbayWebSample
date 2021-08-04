using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string Mytitle { get; set; } = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ltlMsg.Text = this.txtEmail.Text;
        }
        public void SetPageCaption(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
                this.ltlCaption.Text = title;
        }
    }
}