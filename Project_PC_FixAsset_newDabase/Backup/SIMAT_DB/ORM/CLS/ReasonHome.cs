using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public  class ReasonHome
    {
      public Reason Reasonobj = null;
      public ReasonHome()
      {
          Reasonobj = new Reason();
      }

      public bool Add()
      {
          try
          {

              Manager.Engine.StartTracking(Reasonobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Reasonobj);
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
              Manager.Engine.MarkForDeletion(Reasonobj);
              Manager.Engine.PersistChanges(Reasonobj);
          }
          catch (Exception Err)
          {
             // SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;     
      }
      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Reason> CollectionReason)
      {
          try
          {
              foreach (Reason TempReason in CollectionReason)
              {
                  Manager.Engine.MarkForDeletion(TempReason);
                  Transactions.PersistChanges(TempReason);
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
              Manager.Engine.StartTracking(Reasonobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Reasonobj);
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
