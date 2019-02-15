using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class FacilityHome
    {
       public Facility Facilityobj = null;
       public FacilityHome()
       {
           Facilityobj = new Facility();
       }

       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(Facilityobj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(Facilityobj);
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
               Manager.Engine.MarkForDeletion(Facilityobj);
               Manager.Engine.PersistChanges(Facilityobj);
           }
           catch (Exception Err)
           {
              /// SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;    
       }

       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Facility> CollectionFacility)
       {
           try
           {
               foreach (Facility TempFacility in CollectionFacility)
               {
                   Manager.Engine.MarkForDeletion(TempFacility);
                   Transactions.PersistChanges(TempFacility);
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
               Manager.Engine.StartTracking(Facilityobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Facilityobj);
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
