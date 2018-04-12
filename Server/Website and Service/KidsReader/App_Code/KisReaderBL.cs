using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

public class KidsReaderBL
{
    public string POSDEL = "~_~";
    public string LINEDEL = "XZQX";
    public string gloWSStatus;
    SQLHelper01 sqlh;
    public KidsReaderBL()
    {
        gloWSStatus = "";
        sqlh = new SQLHelper01(SQLHelper01.MDBBaseLoc.CurrentDomainBaseDirectory, "App_Data\\KidsReader.accdb");
        string VisitorsIPAddr = GetUserIP();
        DateTime adjDate = DateTime.Now.AddDays(-7);
        sqlh.ExecuteSQLParamed("DELETE * FROM tblTraffic WHERE DateLogged<@P0", adjDate.ToString());
        string[][] data = sqlh.GetMultiValuesOfSQL("SELECT Count(*) FROM tblBlockedIPs WHERE BlockedIP=@P0", VisitorsIPAddr);
        string Amnt = "0";
        try
        {
            Amnt = data[0][0];
        }
        catch (Exception ex)
        {
            gloWSStatus = "DB Locked Up";
            return;
            //throw;
        }

        int iAmnt = Convert.ToInt16(Amnt);
        //iAmnt = 0;
        if (iAmnt > 0)
        {
            gloWSStatus = "User Banned";
            return;
        }
        sqlh.ExecuteSQLParamed("INSERT INTO tblTraffic (RecdIP, DateLogged) VALUES (@P0, @P1)", VisitorsIPAddr, DateTime.Now.ToString());
        adjDate = DateTime.Now.AddDays(-1);
        data = sqlh.GetMultiValuesOfSQL("SELECT Count(*) FROM tblTraffic WHERE RecdIP=@P0 AND DateLogged>@P1", VisitorsIPAddr, adjDate.ToString());
        try
        {
            Amnt = data[0][0];
        }
        catch (Exception ex)
        {
            gloWSStatus = "DB Locked Up";
            return;
            //throw;
        }
        iAmnt = Convert.ToInt16(Amnt);
        //iAmnt = 0;
        if (iAmnt > 300)
        {
            sqlh.ExecuteSQLParamed("INSERT INTO tblBlockedIPs (BlockedIP,DateLogged) VALUES (@P0,@P1)", VisitorsIPAddr, DateTime.Now.ToString());
            gloWSStatus = "User Banned";
        }
    }
    public void CloseIt()
    {
        try { sqlh.CloseIt(); }
        catch (Exception ex) { }
    }
    public string IsConnected()
    {
        string retVal = "1";
        return retVal;
    }
    public string LogUsage(string pUUID, string pChannel)
    {
        string retVal = "";
        string retStat = sqlh.ExecuteSQLParamed("INSERT INTO tblAppUsers (UUID,Channel,DateLogged) VALUES (@P0,@P1,@P2)", pUUID, pChannel, DateTime.Now.ToString());
        retStat = sqlh.ExecuteSQLParamed("INSERT INTO tblAppUsage (UUID,DateLogged) VALUES (@P0,@P1)", pUUID, DateTime.Now.ToString());
        retVal = retStat.ToString();
        return retVal;
    }
    public string GetUserDoc(string pCode)
    {
        string retVal = "";
        retVal = sqlh.GetSingleValuesOfSQL("SELECT FullText FROM tblUserData WHERE RetrievalID=@P0", pCode);
        retVal = retVal.Replace("\r\n", "<newkrline>");
        return retVal;
    }
    public string GetOurContent()
    {
        string POSDEL = "p#d";
        string LINEDEL = "l#d";
        string retVal = "";
        string[][] data = sqlh.GetMultiValuesOfSQL("SELECT * FROM tblOurData");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int max = data.Length;
        for (int i = 0; i < max; i++)
        {
//            string pID = data[i][0];
            string pDescription = data[i][1];
            string pFullText = data[i][2];
            pFullText = pFullText.Replace("\r\n", "<newkrline>");
            string pCategory = data[i][3];
            string pGradeLevel = data[i][4];
            string ConcatData = pDescription + POSDEL + pCategory + POSDEL + pFullText + POSDEL + pGradeLevel + LINEDEL;
            sb.Append(ConcatData);
        }
        retVal = sb.ToString();
        return retVal;
    }

    public string SaveUserDoc(string pUUID, string pAllText)
    {
        string retVal = "";
        string pRandID = Decode.RandomStringAlphaCaps(5);
        string retStat = sqlh.ExecuteSQLParamed("INSERT INTO tblUserData (UUID,FullText,RetrievalID,DateLogged) VALUES (@P0,@P1,@P2,@P3)", pUUID, pAllText,pRandID,DateTime.Now.ToString());
        if (retStat=="1")
        {
            retVal = pRandID;
        }
        else
        {
            retVal = "Oops!  Our server blew up on whatever you tried sending; email us at service@mc2techservices with the content you tried sending.";
        }
        return retVal;
    }

    private static string GetUserIP()
    {
        string VisitorsIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr;
    }

}
