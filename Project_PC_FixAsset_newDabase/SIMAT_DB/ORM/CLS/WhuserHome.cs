using System;
using System.Data;  
using System.Collections.Generic;
using System.Text;
using Wilson.ORMapper;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;


namespace SimatSoft.DB.ORM
{
    public class WhuserHome
    {
       public Whuser WhUserobj = new Whuser();
       public WhuserAccess WhUserAccessObj = new WhuserAccess();
        /// <summary>
        /// name
        /// </summary>
        /// <param name="userid">Useid_SS</param>
        /// <param name="password">Paassss</param>
        /// <returns>Boolea  ddddd</returns>
        public Boolean Function_CheckUserName(string Str_userid)
        {
            WhUserobj = Manager.Engine.GetObject<Whuser>(Str_userid);

            if (WhUserobj != null)
                return true;
            else
                return false;
        }

        public Boolean Function_CheckPassword(string Str_UserID, string Str_UserPass)
        {
            WhUserobj = Manager.Engine.GetObject<Whuser>(Str_UserID);

            if (WhUserobj.UsPass == Str_UserPass)
                return true;
            else
                return false;
        }

        public String GetUserName(string userid)
        {
            return Manager.Engine.GetObject<Whuser>(userid).UsFirstName;
        }

        public DataSet getscreen(string userid, string Sctype, string SCsubType)
        {
            string sqlcommand = "";
            sqlcommand = "SELECT Screen.scid, Screen.scName, Screen.scType,SCsubType FROM whUser INNER JOIN " +
                                        " whuser_Access ON whUser.usID = whuser_Access.usID INNER JOIN Screen ON whuser_Access.scID = Screen.scID " +
                                        " where Screen.scType ='" + Sctype + "' and whUser.usID ='" + userid + "'  and Screen.SCsubType='" + SCsubType  +"'  order by Screen.scOrder";

            return Manager.Engine.GetDataSet(sqlcommand );    
            
        }
        public DataSet getreportmenu(string userid, string Sctype, string SCsubType)
        {
            string sqlcommand = "";
            sqlcommand = "SELECT Screen.scid, Screen.scName, Screen.scType FROM whUser INNER JOIN " +
                                                 " whuser_Access ON whUser.usID = whuser_Access.usID INNER JOIN Screen ON whuser_Access.scID = Screen.scID " +
                                                 " where Screen.scType ='" + Sctype + "' and whUser.usID ='" + userid + "'  and Screen.SCsubType='" + SCsubType + "'  order by Screen.scOrder";
            return Manager.Engine.GetDataSet(sqlcommand);

        }
        public DataSet getmainmenu()
        {
            string sqlcommand;
            sqlcommand = "SELECT DISTINCT SysScreenSubType.SCsubType, SysScreenSubType.ScsubTypeDes " +
                                        " FROM         SysScreenSubType LEFT OUTER JOIN " +
                                        " Screen ON SysScreenSubType.SCsubType = Screen.SCsubType where ScsubFlag = '1' ";
            return Manager.Engine.GetDataSet(sqlcommand);
        }
        public bool AddwhUser(Wilson.ORMapper.Transaction TempTransaction)
        {
            try
            {
                Manager.Engine.StartTracking(WhUserobj, Wilson.ORMapper.InitialState.Inserted);
                TempTransaction.PersistChanges(WhUserobj);
            }
            catch (Exception Ex)
            {
                TempTransaction.Rollback();
                return false;
            }
            return true;
        }
        public bool AddGroupAccess(Wilson.ORMapper.Transaction TempTransaction)
        {
            try
            {
                Manager.Engine.StartTracking(WhUserAccessObj, Wilson.ORMapper.InitialState.Inserted);
                TempTransaction.PersistChanges(WhUserAccessObj);
            }
            catch (Exception Ex)
            {
                TempTransaction.Rollback();
                return false;
            }
            return true;
        }
        public bool Delete()
        {
            try
            {
                Manager.Engine.StartTracking(WhUserobj, InitialState.Unchanged);
                Manager.Engine.MarkForDeletion(WhUserobj);
                Manager.Engine.PersistChanges(WhUserobj);
            }
            catch (Exception Ex) { return false; }
            return true;
        }
    }
}

