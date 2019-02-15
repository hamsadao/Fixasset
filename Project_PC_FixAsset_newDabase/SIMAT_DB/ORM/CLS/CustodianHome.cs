using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public  class CustodianHome
    {
      public Custodian Custodianobj = null;
      public CustodianHome()
      {
          Custodianobj = new Custodian();
      }

      public bool Add()
      {
          try
          {

              Manager.Engine.StartTracking(Custodianobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Custodianobj);
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
              Manager.Engine.MarkForDeletion(Custodianobj);
              Manager.Engine.PersistChanges(Custodianobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;  
      }
      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Custodian> CollectionCustodian)
      {
          try
          {
              foreach (Custodian TempCustodian in CollectionCustodian)
              {
                  Manager.Engine.MarkForDeletion(TempCustodian);
                  Transactions.PersistChanges(TempCustodian);
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
              Manager.Engine.StartTracking(Custodianobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Custodianobj);
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
