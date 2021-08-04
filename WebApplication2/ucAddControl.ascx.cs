using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ucAddControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = "lblText";

            TextBox txt = new TextBox();
            txt.Text = "txtText";
            txt.ID = "ttxt";

            Button button = new Button();
            button.Text = "btnText";
            button.Click += Button_Click;

            this.Controls.Add(lbl);
            this.Controls.Add(txt);
            this.Controls.Add(button);
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            var txt = this.FindControl("ttxt") as TextBox;
            Response.Write(txt.Text);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Session["ControlList"] = new string[] { "Label", "txt", "Button" };
        }
    }
}