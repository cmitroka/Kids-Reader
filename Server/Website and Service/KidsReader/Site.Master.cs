using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void cmdCreateContent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateContent.aspx");
        }

        protected void cmdContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("Feedback.aspx");
        }
    }
