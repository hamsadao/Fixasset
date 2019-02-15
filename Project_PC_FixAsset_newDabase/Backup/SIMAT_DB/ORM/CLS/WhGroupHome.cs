using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{
   public class WhGroupHome
    {
       public  WhGroup WhGroupObj = null;
       public  WhgroupAccess WhgroupAccessObj = null;

       public WhGroupHome()
       {
           WhGroupObj = new WhGroup();
           WhgroupAccessObj = new WhgroupAccess();
       }

       public bool AddGroup(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               Manager.Engine.StartTracking(WhGroupObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(WhGroupObj);
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
               Manager.Engine.StartTracking(WhgroupAccessObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(WhgroupAccessObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool EditwhGroup(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               Manager.Engine.StartTracking(WhGroupObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(WhGroupObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool EditwhGroupAccress(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               Manager.Engine.StartTracking(WhgroupAccessObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(WhgroupAccessObj);
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
               Manager.Engine.StartTracking(WhGroupObj, Wilson.ORMapper.InitialState.Unchanged);
               Manager.Engine.MarkForDeletion(WhGroupObj);
               Manager.Engine.PersistChanges(WhGroupObj);
           }
           catch (Exception Ex) { return false; }
           return true;
       }
    }
     
}
