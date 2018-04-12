using System;
using System.Net;
using System.Net.Mail;

public static class SiteSpecific
{
    public static bool Test1()
    {
        return true;
    }
    public static bool SendMail(string pName, string pEmail, string pMessage, string pOtherInfo)
    {
        bool retVal = true;
        try
        {
            var fromAddress = new MailAddress("temp1@mc2techservices.com", "Template App Support Page");
            var toAddress = new MailAddress("service@mc2techservices.com", "Template App Support Page");
            const string fromPassword = "Temppass1";
            const string subject = "Template App Webpage Feedback";
            string body = "Name: " + pName + Environment.NewLine + "Email: " + pEmail + Environment.NewLine + pOtherInfo;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            retVal = false;
        }
        return retVal;
    }
}
