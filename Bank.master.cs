using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bank : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"].ToString() != "")
            {
                //Response.Redirect("login");
                this.lblUserName.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("login");
            }
        }
    }
}
