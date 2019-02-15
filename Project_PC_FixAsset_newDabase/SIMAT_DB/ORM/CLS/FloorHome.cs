using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;


namespace SimatSoft.DB.ORM
{
  public class FloorHome
    {
      public Floor Floorobj = null;
      public FloorHome()
      {
          Floorobj = new Floor();
      }

      public Boolean Add()
      {
          try
          {

              Manager.Engine.StartTracking(Floorobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Floorobj);
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
              Manager.Engine.MarkForDeletion(Floorobj);
              Manager.Engine.PersistChanges(Floorobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;   
      }

      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Floor> CollectionFloor)
      {
          try
          {
              foreach (Floor TempFloor in CollectionFloor)
              {
                  Manager.Engine.MarkForDeletion(TempFloor);
                  Transactions.PersistChanges(TempFloor);
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
              Manager.Engine.StartTracking(Floorobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Floorobj);
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
