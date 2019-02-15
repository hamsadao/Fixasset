using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeModelHome
    {
       public FormatBarCodeModel BarcodeModelObj = null;
       public FormatBarcodeModelHome()
       {
           BarcodeModelObj = new FormatBarCodeModel();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeModelObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeModelObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeModelObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeModelObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeModelObj);
               Manager.Engine.PersistChanges(BarcodeModelObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeModel> CollectionBarCodeModel)
       {
           try
           {
               foreach (FormatBarCodeModel TempBarCodeModel in CollectionBarCodeModel)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeModel);
                   Transactions.PersistChanges(TempBarCodeModel);
               }
           }
           catch (Exception Err)
           {

               Transactions.Rollback();
           }
           return true;
       }
    }
}

