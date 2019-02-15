using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class AreaHome
    {
       public Area Areaobj = null;
       public AreaHome()
       {
           Areaobj = new Area();
       }
       
       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(Areaobj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(Areaobj);
           }
           catch(Exception Err) 
           {
               //return false;
               throw new Exception(Err.Message);
           }
           return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(Areaobj);
               Manager.Engine.PersistChanges(Areaobj);
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Area> CollectionArea)
       {
           try
           {
               foreach (Area TempArea in CollectionArea)
               {
                   Manager.Engine.MarkForDeletion(TempArea);
                   Transactions.PersistChanges(TempArea);
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
               Manager.Engine.StartTracking(Areaobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Areaobj);
               return true;
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               throw new Exception(Err.Message);
           }
           return true;
       }

    }
}
