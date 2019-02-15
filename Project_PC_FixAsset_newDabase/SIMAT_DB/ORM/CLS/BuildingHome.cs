using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class BuildingHome
    {
       public Building BuildingObj = null;
       //public Building Frm_Building = new Building();
       public BuildingHome()
       {
           BuildingObj = new Building();
       }
       public Boolean Add()
       {
           try
           {
               
               Manager.Engine.StartTracking(BuildingObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BuildingObj);
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;
       }

       public Boolean Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BuildingObj);
               Manager.Engine.PersistChanges(BuildingObj);
           }
           catch (Exception Err)
           {
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;     
       }

       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Building> CollectionBuilding)
       {
           try
           {
               foreach (Building TempBuilding in CollectionBuilding)
               {
                   Manager.Engine.MarkForDeletion(TempBuilding);
                   Transactions.PersistChanges(TempBuilding);
               }
           }
           catch (Exception Err)
           {
               Transactions.Rollback();
           }
           return true;
       }
       public Boolean Edit()
       {
           try
           {
               Manager.Engine.StartTracking(BuildingObj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(BuildingObj);
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
