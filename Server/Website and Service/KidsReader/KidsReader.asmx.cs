using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for AppWS
/// </summary>
[WebService(Namespace = "kidsreader.mc2techservices.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class KidsReader : System.Web.Services.WebService
{
    [WebMethod]
    public string IsConnected()
    {
        string retVal = "";
        KidsReaderBL bl = new KidsReaderBL();
        retVal = bl.gloWSStatus;
        if (bl.gloWSStatus == "")
        {
            //retVal = bl.IsConnected();
        }
        bl.CloseIt();
        return retVal;
    }

    [WebMethod]
    public string LogUsage(string pUUID, string pChannel)
    {
        string retVal = "";
        KidsReaderBL bl = new KidsReaderBL();
        retVal = bl.gloWSStatus;
        if (bl.gloWSStatus == "")
        {
            retVal = bl.LogUsage(pUUID,pChannel);
        }
        bl.CloseIt();
        return retVal;
    }

    [WebMethod]
    public string SaveUserDoc(string pUUID, string pAllText)
    {
        string retVal = "";
        KidsReaderBL bl = new KidsReaderBL();
        retVal = bl.gloWSStatus;
        if (bl.gloWSStatus == "")
        {
            retVal = bl.SaveUserDoc(pUUID, pAllText);
        }
        bl.CloseIt();
        return retVal;
    }

    [WebMethod]
    public string GetUserDoc(string pCode)
    {
        string retVal = "";
        KidsReaderBL bl = new KidsReaderBL();
        retVal = bl.gloWSStatus;
        if (bl.gloWSStatus == "")
        {
            retVal = bl.GetUserDoc(pCode);
        }
        bl.CloseIt();
        return retVal;
    }
    [WebMethod]
    public string GetOurContent()
    {
        string retVal = "";
        KidsReaderBL bl = new KidsReaderBL();
        retVal = bl.gloWSStatus;
        if (bl.gloWSStatus == "")
        {
            retVal = bl.GetOurContent();
        }
        bl.CloseIt();
        return retVal;
    }
}
