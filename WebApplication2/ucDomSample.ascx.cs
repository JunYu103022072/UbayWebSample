using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ucDomSample : System.Web.UI.UserControl
    {
        public Image MyImage1 { get { return this.Image1; } }


        public Image GetImage1()
        {
            return this.Image1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Visible = false;
            this.Label1.Text = "Hello RISU!";

            Control ctl = this.FindControl("PlaceHolder1");

            if (ctl != null)
            {
                ctl.Visible = false;

                var firstSubControl = ctl.Controls[0];

                if (firstSubControl != null)
                    firstSubControl.Visible = false;
            }

            var ltl = this.FindControl("Literal1");

            if (ltl != null)
                ltl.Visible = false;

            this.WriteControlID(this.PlaceHolder2);
        }

        private void WriteControlID(Control ctl)
        {
            if (ctl == null)
                return;

            Response.Write(ctl.ID + "<br/>");

            if (ctl.Controls.Count == 0)
                return;

            foreach (Control item in ctl.Controls)
            {
                this.WriteControlID(item);
            }
        }
    }
}