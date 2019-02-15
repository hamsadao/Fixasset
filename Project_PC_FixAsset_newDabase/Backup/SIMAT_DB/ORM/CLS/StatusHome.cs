using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class StatusHome
    {
       public Status Statusobj = null;
       public StatusHome()
       {
           Statusobj = new Status();
       }

       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(Statusobj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(Statusobj);
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(Statusobj);
               Manager.Engine.PersistChanges(Statusobj);
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;     
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Status> CollectionStatus)
       {
           try
           {
               foreach (Status TempStatus in CollectionStatus)
               {
                   Manager.Engine.MarkForDeletion(TempStatus);
                   Transactions.PersistChanges(TempStatus);
               }
           }
           catch (Exception Err)
           {
               Transactions.Rollback();
           }
           return true;
       }
       public bool Edit()
       {
           try
           {
               Manager.Engine.StartTracking(Statusobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Statusobj);
               return true;
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;
       }

    }
}
