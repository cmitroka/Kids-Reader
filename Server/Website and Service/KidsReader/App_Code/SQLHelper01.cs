using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

public class SQLHelper01
{
    public enum MDBBaseLoc { EnvironmentCurrentDirectory, DirectoryGetCurrentDirectory, CurrentDomainBaseDirectory, Direct };
    public OleDbConnection aConnection;
    public SQLHelper01(MDBBaseLoc baseloc, string mdbtouse)
    {
        GetAndOpenOleDbConnection(baseloc, mdbtouse);
    }

    public void CloseIt()
    {
        aConnection.Close();
    }

    private OleDbConnection GetAndOpenOleDbConnection(MDBBaseLoc mdbbl, string mdbtouse)
    {
        string MDBPath = "";
        MDBPath = System.AppDomain.CurrentDomain.BaseDirectory;
        if (mdbbl.ToString() == "EnvironmentCurrentDirectory")
        {
            MDBPath = Environment.CurrentDirectory + "\\" + mdbtouse;
        }
        else if (mdbbl.ToString() == "CurrentDomainBaseDirectory")
        {
            MDBPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + mdbtouse;
        }
        else if (mdbbl.ToString() == "Direct")
        {
            MDBPath = mdbtouse;
        }
        try
        {
            aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MDBPath);
            aConnection.Open();
        }
        catch (Exception ex)
        {
            //retVal = ex.Message;
            //return "E10 - " + retVal;
            return null;
        }
        return aConnection;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, "", "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, "", "", "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, "", "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, "", "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, "", "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, "", "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, "", "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, P8, "");
        return retVal;
    }
    public string[][] GetMultiValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
    {
        string[][] retVal;
        retVal = GetMultiValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9);
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, "", "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, "", "", "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, "", "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, "", "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, "", "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, "", "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, "", "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, P8, "");
        return retVal;
    }
    public string GetSingleValuesOfSQL(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
    {
        string retVal;
        retVal = GetSingleValuesOfSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9);
        return retVal;
    }

    public string ExecuteSQLParamed(string SQLin)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, "", "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, "", "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, "", "", "", "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, "", "", "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, "", "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, P4, "", "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, "", "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, "", "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, "", "");
        return retVal;
    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8)
    {
        string retVal;
        retVal = ExecuteSQLParamed(SQLin, P0, P1, P2, P3, P4, P5, P6, P7, P8, "");
        return retVal;
    }


    private string[][] GetMultiValuesOfSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
    {
        string[][] retVal;
        //string sql = "INSERT INTO tblFeedback (UDID, Name, ContactInfo, Feedback, IP, TimeLogged) VALUES  (@UDID, @NameP, @ContactInfo, @Feedback, @IP, @TimeLogged);";
        OleDbCommand cmdQry = new OleDbCommand(SQLin, aConnection);
        cmdQry.Connection = aConnection;
        //cmdQry.CommandType = CommandType.Text;
        if (P0 != "") { cmdQry.Parameters.AddWithValue("P0", P0); } else { cmdQry.Parameters.AddWithValue("P0", DBNull.Value); }
        if (P1 != "") { cmdQry.Parameters.AddWithValue("P1", P1); } else { cmdQry.Parameters.AddWithValue("P1", DBNull.Value); }
        if (P2 != "") { cmdQry.Parameters.AddWithValue("P2", P2); } else { cmdQry.Parameters.AddWithValue("P2", DBNull.Value); }
        if (P3 != "") { cmdQry.Parameters.AddWithValue("P3", P3); } else { cmdQry.Parameters.AddWithValue("P3", DBNull.Value); }
        if (P4 != "") { cmdQry.Parameters.AddWithValue("P4", P4); } else { cmdQry.Parameters.AddWithValue("P4", DBNull.Value); }
        if (P5 != "") { cmdQry.Parameters.AddWithValue("P5", P5); } else { cmdQry.Parameters.AddWithValue("P5", DBNull.Value); }
        if (P6 != "") { cmdQry.Parameters.AddWithValue("P6", P6); } else { cmdQry.Parameters.AddWithValue("P6", DBNull.Value); }
        if (P7 != "") { cmdQry.Parameters.AddWithValue("P7", P7); } else { cmdQry.Parameters.AddWithValue("P7", DBNull.Value); }
        if (P8 != "") { cmdQry.Parameters.AddWithValue("P8", P8); } else { cmdQry.Parameters.AddWithValue("P8", DBNull.Value); }
        if (P9 != "") { cmdQry.Parameters.AddWithValue("P9", P9); } else { cmdQry.Parameters.AddWithValue("P9", DBNull.Value); }
        System.Data.DataSet ds = new System.Data.DataSet();
        try
        {
            if (P0 == "")
            {
                OleDbDataAdapter da = new OleDbDataAdapter(SQLin, aConnection);
                //GCGCommon.SupportMethods.WriteFile("C:\\out.txt",SQLin,true);
                da.Fill(ds, "RandomData");
            }
            else
            {
                OleDbDataAdapter da = new OleDbDataAdapter(cmdQry);
                da.Fill(ds, "RandomData");
            }
            int curP1Index = 0;
            int arrP1Size = ds.Tables["RandomData"].Rows.Count - 1;
            if (arrP1Size == -1)
            {
                retVal = null;
                string[] fake = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                retVal = new string[1][];
                retVal[0] = fake;
                return retVal;
            }
            retVal = new string[arrP1Size + 1][];
            foreach (System.Data.DataRow dr in ds.Tables["RandomData"].Rows)
            {
                List<string> myCollection = new List<string>();
                for (int i = 0; i < ds.Tables["RandomData"].Columns.Count; i++)
                {
                    string tempLine = dr[i].ToString();
                    myCollection.Add(tempLine);
                }
                string[] addToMulti = myCollection.ToArray();
                retVal[curP1Index] = addToMulti;
                if (curP1Index == arrP1Size) break;
                curP1Index++;
            }
            return retVal;
        }
        catch (OleDbException ex)
        {
            Console.WriteLine(ex.Message);
            //throw new Exception("Error message: " + ex.Message, ex.InnerException);
            //return null;
            retVal = null;
        }
        return retVal;

    }

    private string GetSingleValuesOfSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
    {
        string retVal = "";
        //string sql = "INSERT INTO tblFeedback (UDID, Name, ContactInfo, Feedback, IP, TimeLogged) VALUES  (@UDID, @NameP, @ContactInfo, @Feedback, @IP, @TimeLogged);";
        OleDbCommand cmdQry = new OleDbCommand(SQLin, aConnection);
        cmdQry.Connection = aConnection;
        //cmdQry.CommandType = CommandType.Text;
        if (P0 != "") { cmdQry.Parameters.AddWithValue("P0", P0); } else { cmdQry.Parameters.AddWithValue("P0", DBNull.Value); }
        if (P1 != "") { cmdQry.Parameters.AddWithValue("P1", P1); } else { cmdQry.Parameters.AddWithValue("P1", DBNull.Value); }
        if (P2 != "") { cmdQry.Parameters.AddWithValue("P2", P2); } else { cmdQry.Parameters.AddWithValue("P2", DBNull.Value); }
        if (P3 != "") { cmdQry.Parameters.AddWithValue("P3", P3); } else { cmdQry.Parameters.AddWithValue("P3", DBNull.Value); }
        if (P4 != "") { cmdQry.Parameters.AddWithValue("P4", P4); } else { cmdQry.Parameters.AddWithValue("P4", DBNull.Value); }
        if (P5 != "") { cmdQry.Parameters.AddWithValue("P5", P5); } else { cmdQry.Parameters.AddWithValue("P5", DBNull.Value); }
        if (P6 != "") { cmdQry.Parameters.AddWithValue("P6", P6); } else { cmdQry.Parameters.AddWithValue("P6", DBNull.Value); }
        if (P7 != "") { cmdQry.Parameters.AddWithValue("P7", P7); } else { cmdQry.Parameters.AddWithValue("P7", DBNull.Value); }
        if (P8 != "") { cmdQry.Parameters.AddWithValue("P8", P8); } else { cmdQry.Parameters.AddWithValue("P8", DBNull.Value); }
        if (P9 != "") { cmdQry.Parameters.AddWithValue("P9", P9); } else { cmdQry.Parameters.AddWithValue("P9", DBNull.Value); }
        System.Data.DataSet ds = new System.Data.DataSet();
        try
        {
            if (P0 == "")
            {
                OleDbDataAdapter da = new OleDbDataAdapter(SQLin, aConnection);
                da.Fill(ds, "RandomData");
            }
            else
            {
                OleDbDataAdapter da = new OleDbDataAdapter(cmdQry);
                da.Fill(ds, "RandomData");
            }
            if (ds.Tables["RandomData"].Rows.Count <= 0)
            {
                retVal = "";
                return retVal;
            }
            System.Data.DataRow currdr = ds.Tables["RandomData"].Rows[0];
            retVal = currdr[0].ToString();
            return retVal;
        }
        catch (OleDbException ex)
        {
            Console.WriteLine(ex.Message);
            //throw new Exception("Error message: " + ex.Message, ex.InnerException);
            //return null;
            retVal = null;
        }
        return retVal;

    }
    public string ExecuteSQLParamed(string SQLin, string P0, string P1, string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9)
    {
        string retVal;
        OleDbCommand cmdID = new OleDbCommand("Select @@IDENTITY", aConnection);
        string ID = null;
        OleDbCommand cmdExec = new OleDbCommand(SQLin, aConnection);
        cmdExec.Connection = aConnection;
        cmdExec.CommandText = SQLin;
        if (P0 != "") { cmdExec.Parameters.AddWithValue("P0", P0); } else { cmdExec.Parameters.AddWithValue("P0", DBNull.Value); }
        if (P1 != "") { cmdExec.Parameters.AddWithValue("P1", P1); } else { cmdExec.Parameters.AddWithValue("P1", DBNull.Value); }
        if (P2 != "") { cmdExec.Parameters.AddWithValue("P2", P2); } else { cmdExec.Parameters.AddWithValue("P2", DBNull.Value); }
        if (P3 != "") { cmdExec.Parameters.AddWithValue("P3", P3); } else { cmdExec.Parameters.AddWithValue("P3", DBNull.Value); }
        if (P4 != "") { cmdExec.Parameters.AddWithValue("P4", P4); } else { cmdExec.Parameters.AddWithValue("P4", DBNull.Value); }
        if (P5 != "") { cmdExec.Parameters.AddWithValue("P5", P5); } else { cmdExec.Parameters.AddWithValue("P5", DBNull.Value); }
        if (P6 != "") { cmdExec.Parameters.AddWithValue("P6", P6); } else { cmdExec.Parameters.AddWithValue("P6", DBNull.Value); }
        if (P7 != "") { cmdExec.Parameters.AddWithValue("P7", P7); } else { cmdExec.Parameters.AddWithValue("P7", DBNull.Value); }
        if (P8 != "") { cmdExec.Parameters.AddWithValue("P8", P8); } else { cmdExec.Parameters.AddWithValue("P8", DBNull.Value); }
        if (P9 != "") { cmdExec.Parameters.AddWithValue("P9", P9); } else { cmdExec.Parameters.AddWithValue("P9", DBNull.Value); }
        string OK = "-1";
        try
        {
            retVal = "1";
            OK = cmdExec.ExecuteNonQuery().ToString();
            retVal = OK;
            return retVal;
        }
        catch (Exception ex)
        {
            retVal = "-1";
            //throw "X";
            return ex.Message;
        }
        try
        {
            string temp = cmdID.ExecuteScalar().ToString();
            retVal = temp;
        }
        catch (Exception ex)
        {
            retVal = "-2";
            return retVal;
        }
        return retVal;
    }
}
