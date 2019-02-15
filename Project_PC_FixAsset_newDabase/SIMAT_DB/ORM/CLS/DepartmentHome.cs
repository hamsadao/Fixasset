using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public  class DepartmentHome
    {
      public Department Departmentobj=null;
      public DepartmentHome()
      {
          Departmentobj = new Department();
      }

      public bool Add()
      {
          try
          {

              Manager.Engine.StartTracking(Departmentobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Departmentobj);
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
              Manager.Engine.MarkForDeletion(Departmentobj);
              Manager.Engine.PersistChanges(Departmentobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;     
      }
      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Department> CollectionDepartment)
      {
          try
          {
              foreach (Department TempDepartment in CollectionDepartment)
              {
                  Manager.Engine.MarkForDeletion(TempDepartment);
                  Transactions.PersistChanges(TempDepartment);
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
              Manager.Engine.StartTracking(Departmentobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Departmentobj);
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
