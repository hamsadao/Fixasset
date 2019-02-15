using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeDepartmentHome
    {
       public FormatBarCodeDepartment BarcodeDepartmentObj = null;
       public FormatBarcodeDepartmentHome()
       {
           BarcodeDepartmentObj = new FormatBarCodeDepartment();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeDepartmentObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeDepartmentObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeDepartmentObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeDepartmentObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeDepartmentObj);
               Manager.Engine.PersistChanges(BarcodeDepartmentObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeDepartment> CollectionBarCodeDept)
       {
           try
           {
               foreach (FormatBarCodeDepartment TempBarCodeDept in CollectionBarCodeDept)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeDept);
                   Transactions.PersistChanges(TempBarCodeDept);
               }
           }
           catch (Exception)
           {
               Transactions.Rollback();
           }
           return true;
       }

    }
}

