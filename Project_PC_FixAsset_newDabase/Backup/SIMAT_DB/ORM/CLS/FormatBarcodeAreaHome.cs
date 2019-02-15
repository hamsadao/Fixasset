using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeAreaHome
    {
       public FormatBarCodeArea BarcodeAreaObj = null;
       public FormatBarcodeAreaHome()
       {
           BarcodeAreaObj = new FormatBarCodeArea();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeAreaObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeAreaObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeAreaObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeAreaObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeAreaObj);
               Manager.Engine.PersistChanges(BarcodeAreaObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeArea> CollectionBarCodeArea)
       {
           try
           {
               foreach (FormatBarCodeArea TempBarCodeArea in CollectionBarCodeArea)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeArea);
                   Transactions.PersistChanges(TempBarCodeArea);
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

