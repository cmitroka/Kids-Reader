using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KR
{
    public partial class AddModDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            KidsReaderBL kbl = new KidsReaderBL();
            string rep = kbl.SaveUserDoc("Web", TextBox1.Text);
            string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
            myScript += "alert('" + rep+ "');";
            myScript += "\n\n </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
        }
    }
}