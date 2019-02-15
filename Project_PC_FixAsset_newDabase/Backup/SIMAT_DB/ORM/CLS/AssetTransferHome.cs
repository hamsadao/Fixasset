using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{
   public class AssetTransferHome
    {
       public AssetTransfer AssetTransferObj= null;
       public AssetTransferDT AssetTransferDTObj= null;
       public AssetTransferHD AssetTransferHDObj=null;
       public AssetTransferSerial AssetTransferSerialObj= null;

       public AssetTransferHome()
       {
           AssetTransferDTObj = new AssetTransferDT();
           AssetTransferHDObj = new AssetTransferHD();
           AssetTransferObj = new AssetTransfer();
           AssetTransferSerialObj = new AssetTransferSerial();
       }

       public bool AddHD(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferHDObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(AssetTransferHDObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
           
       }

       public bool Delete()
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.MarkForDeletion(AssetTransferHDObj);
               SimatSoft.DB.ORM.Manager.Engine.PersistChanges(AssetTransferHDObj);
           }
           catch (Exception Ex) { return false; }
           return true;
       }
      

       public bool EditHD(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferHDObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(AssetTransferHDObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool AddDT(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferDTObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(AssetTransferDTObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }


       public bool EditDT(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferDTObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(AssetTransferDTObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool DeleteDT(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.MarkForDeletion(AssetTransferDTObj);
               TempTransaction.PersistChanges(AssetTransferDTObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool AddTransfer(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(AssetTransferObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool EditTransfer(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(AssetTransferObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool DeleteTransfer(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.MarkForDeletion(AssetTransferObj);
               TempTransaction.PersistChanges(AssetTransferObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool AddTransferSerial(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferSerialObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(AssetTransferSerialObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool EditTransferSerial(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetTransferSerialObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(AssetTransferSerialObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool DeleteTransferSerial(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.MarkForDeletion(AssetTransferSerialObj);
               TempTransaction.PersistChanges(AssetTransferSerialObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
   }
}
