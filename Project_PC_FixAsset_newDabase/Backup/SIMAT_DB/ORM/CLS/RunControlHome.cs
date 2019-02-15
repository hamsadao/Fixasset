using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;
using System.Data;

namespace SimatSoft.DB.ORM
{
   public class RunControlHome
    {
       public static string currentNo="" ;

       public RunControl Runcontrolobj = null;
       string Str_SQL = null;

       public static string GlobalVar
       {
           get { return currentNo; }
           set { currentNo = value; }
       }

       public RunControlHome()
       {
           Runcontrolobj = new RunControl();
       }
       public bool AddRunControl()
       {
           try
           {
               string Str_Command = " INSERT INTO RunControl " +
                         " ( PORun) " +
                         " VALUES ('" + Runcontrolobj.PORun + "')";
               Manager.Engine.ExecuteScalar(Str_Command);
           }
           catch (Exception Err)
           {
               SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);

           }
           return true;
       }
       private string Function_GetrunningID(string Str_ID)
       {
           string Str_TempID = "";
           if (Str_ID != "")
           {
               int Int_RunningID = Convert.ToInt32(Str_ID.ToString());
               Int_RunningID++;
               //Str_TempID = Convert.ToString(Int_RunningID).PadLeft(10, '0');
               Str_TempID = Int_RunningID.ToString();
           }
           else
           {
               Str_TempID = "0000000001";
           }
           return Str_TempID;
       }
       public string Function_ExcuteGetrunningCommand(string Str_RunIDType) 
       {
           string Str_returnID = "";
           Str_SQL = "SELECT " + Str_RunIDType + " FROM RunControl";
           string Str_Command =Convert.ToString(Manager.Engine.ExecuteScalar(Str_SQL));
           Str_returnID = Function_GetrunningID(Str_Command);
           return Str_returnID;
       }

       // Edit on 04-01-09 for CEVA
    public string Function_ExcuteGetrunningCommand_1(string Str_RunIDType, int runID) 
       {
           //string Str_returnID = "";
           //Str_SQL = "SELECT " + Str_RunIDType + " FROM SysRunNo WHERE RunID = " + runID + " "; // internal transfer
           //string Str_Command =Convert.ToString(Manager.Engine.ExecuteScalar(Str_SQL));
           //Str_returnID = Function_GetrunningID(Str_Command);
           //return Str_returnID;
        ////////////// Edit on 06-01-09 ////
           string nextNo = "";
           try
           {
               string qry = "SELECT Prefix, " + Str_RunIDType + " FROM SysRunNo WHERE RunID = " + runID + " "; // 4 internal transfer
               //string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE (RunID IN ";
               //qry += "(SELECT RunID FROM SysRunNoAssetMapping WHERE (FacCode = '" + Global.ConfigDatabase.Str_Company + "')))";

               DataSet ds = new DataSet();
               ds = Manager.Engine.GetDataSet(qry);

               if (ds.Tables[0].Rows.Count > 0)
               {
                   string prefix = ds.Tables[0].Rows[0][0].ToString();
                   int current = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                   int lenght = ds.Tables[0].Rows[0][1].ToString().Length;
                   current++;
                   string str_current = current.ToString();
                   string runningid = "";
                   if (lenght > str_current.Length)
                   {
                       for (int i = 0; i < lenght - current.ToString().Length; i++)
                           runningid += "0";
                       runningid += str_current;
                   }
                   currentNo = runningid;
                   nextNo = prefix + runningid;
                   GlobalVar = currentNo; // set value
               }

           }
           catch { }

           return nextNo;
        ///////////
       }
       public void SaveRunControlID(string Str_RunIDType, string Str_Control)
       {
           //if (Convert.ToUInt32(Str_Control) == 1)
           //    Str_SQL = "INSERT INTO RunControl(" + Str_RunIDType + ")VALUES ('" + Str_Control + "')";
           //else
               Str_SQL = "UPDATE RunControl SET " + Str_RunIDType + " = '" + Str_Control + "' FROM RunControl";
           SimatSoft.DB.ORM.Manager.Engine.ExecuteScalar(Str_SQL);
       }

       // Edit on 04-01-09 for CEVA
       public void SaveRunControlID_1(string Str_RunIDType, string Str_Control, int runID)
       {
           //Str_SQL = "UPDATE SysRunNo SET " + Str_RunIDType + " = '" + Str_Control + "' WHERE RunID = " + runID + " "; // internal transfer 
           currentNo = GlobalVar; 
           Str_SQL = "UPDATE SysRunNo SET " + Str_RunIDType + " = '" + currentNo + "' WHERE RunID = " + runID + " "; // internal transfer 
           SimatSoft.DB.ORM.Manager.Engine.ExecuteScalar(Str_SQL);
       }
    }
}
