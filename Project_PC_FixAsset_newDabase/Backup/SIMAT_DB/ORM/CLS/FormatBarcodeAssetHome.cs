using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeAssetHome
    {
       public FormatBarCodeAsset BarcodeAssetObj = null;
       public FormatBarcodeAssetHome()
       {
           BarcodeAssetObj = new FormatBarCodeAsset();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeAssetObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeAssetObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {
                
                Manager.Engine.StartTracking(BarcodeAssetObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeAssetObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeAssetObj, Wilson.ORMapper.InitialState.Unchanged);
               Manager.Engine.MarkForDeletion(BarcodeAssetObj);
               Manager.Engine.PersistChanges(BarcodeAssetObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }

       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeAsset> CollectionBarCodeAsset)
       {
           try
           {
               foreach (FormatBarCodeAsset TempBarCodeAsset in CollectionBarCodeAsset)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeAsset);
                   Transactions.PersistChanges(TempBarCodeAsset);
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

