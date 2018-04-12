using System;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private bool SendMail()
    {
        bool retVal = true;
        retVal = SiteSpecific.SendMail(txtName.Text, txtEmail.Text, txtComment.Text, "");
        return retVal;
    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {
        bool result=SendMail();
        if (result == true)
        {
            Response.Redirect("ThankYou.aspx");
        }
        else
        {
            Response.Write("We're sorry, an error has occured.  Please email us at service@mc2techservices to let us know about this, and you comment/suggestion about YMCA Check In.");
        }
    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
