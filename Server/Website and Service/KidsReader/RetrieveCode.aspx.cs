using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KR
{
    public partial class RetrieveCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCode.Text = Session["Code"].ToString();
        }
    }
}