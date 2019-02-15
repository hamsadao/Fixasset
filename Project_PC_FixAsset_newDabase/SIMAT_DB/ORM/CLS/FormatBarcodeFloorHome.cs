using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeFloorHome
    {
       public FormatBarCodeFloor BarcodeFloorObj = null;
       public FormatBarcodeFloorHome()
       {
           BarcodeFloorObj = new FormatBarCodeFloor();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeFloorObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeFloorObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeFloorObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeFloorObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeFloorObj);
               Manager.Engine.PersistChanges(BarcodeFloorObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeFloor> CollectionBarCodeFloor)
       {
           try
           {
               foreach (FormatBarCodeFloor TempBarCodeFloor in CollectionBarCodeFloor)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeFloor);
                   Transactions.PersistChanges(TempBarCodeFloor);
               }
           }
           catch (Exception)
           {
               Transactions.Rollback();
               throw;
           }
           return true;
       }
    }
}

