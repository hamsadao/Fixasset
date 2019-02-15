using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;
namespace SimatSoft.DB.ORM
{
   public class ModelHome
    {
       public Model Modelobj = null;
       public ModelHome()
       {
           Modelobj = new Model();
       }

       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(Modelobj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(Modelobj);
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
               Manager.Engine.MarkForDeletion(Modelobj);
               Manager.Engine.PersistChanges(Modelobj);
           }
           catch (Exception Err)
           {
               
               //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);

           }
           return true;     
       }

       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Model> CollectionModel)
       {
           try
           {
               foreach (Model TempModel in CollectionModel)
               {
                   Manager.Engine.MarkForDeletion(TempModel);
                   Transactions.PersistChanges(TempModel);
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
               Manager.Engine.StartTracking(Modelobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Modelobj);
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
