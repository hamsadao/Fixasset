using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public  class TypeHome
    {
      public Type Typeobj = null;
      public TypeHome()
      {
       Typeobj = new Type();
      }

      public bool Add()
      {
          try
          {

              Manager.Engine.StartTracking(Typeobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Typeobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              throw new Exception(Err.Message);

          }
          return true;
      }

      public bool Delete()
      {
          try
          {
              Manager.Engine.MarkForDeletion(Typeobj);
              Manager.Engine.PersistChanges(Typeobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;   
      }
      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<SimatSoft.DB.ORM.Type> CollectionType)
      {
          try
          {
              foreach (SimatSoft.DB.ORM.Type TempType in CollectionType)
              {
                  Manager.Engine.MarkForDeletion(TempType);
                  Transactions.PersistChanges(TempType);
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
              Manager.Engine.StartTracking(Typeobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Typeobj);
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
