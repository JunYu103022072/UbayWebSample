using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string Mytitle { get; set; }

        public enum BColor
        {
            Blue,
            Red,
            Green
        }
        public BColor BackColor { get; set; } = BColor.Green;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Mytitle))
            {
                this.ltlTitle.Text = this.Mytitle;
                this.imgCover.Alt = this.Mytitle;
            }
            this.divMain.Style.Add("background-color", this.BackColor.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ltlTitle.Text = "ucCover_Click";
            this.imgCover.Alt = "ucCover_Click";
        }
        public void SetText (string Text)
        {

        }
    }
}