using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public  class AssetHome
    {
        public Asset Assetobj = null;
        public AssetHome()
        {
            Assetobj = new Asset();
        }

      public bool Add()
      {
          try
          {

              Manager.Engine.StartTracking(Assetobj, Wilson.ORMapper.InitialState.Inserted);
              Manager.Engine.PersistChanges(Assetobj);
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
              Manager.Engine.MarkForDeletion(Assetobj);
              Manager.Engine.PersistChanges(Assetobj);
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              //return false;
              throw new Exception(Err.Message);
          }
          return true;    
      }

      public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Asset> CollectionAsset)
      {
          try
          {
              foreach (Asset TempAsset in CollectionAsset)
              {
                  Manager.Engine.MarkForDeletion(TempAsset);
                  Transactions.PersistChanges(TempAsset);
              }
          }
          catch (Exception Ex)
          {
              Transactions.Rollback();
          }
          return true;
      }

      public bool Edit()
      {
          try
          {
              Manager.Engine.StartTracking(Assetobj, Wilson.ORMapper.InitialState.Updated);
              Manager.Engine.PersistChanges(Assetobj);
              return true;
          }
          catch (Exception Err)
          {
              //SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              throw new Exception(Err.Message);
          }
          return true;
      }

      public bool AddAsset(Wilson.ORMapper.Transaction TempTransaction)
      {
          try
          {
              SimatSoft.DB.ORM.Manager.Engine.StartTracking(Assetobj, Wilson.ORMapper.InitialState.Inserted);
              TempTransaction.PersistChanges(Assetobj);
          }
          catch (Exception Ex)
          {
              TempTransaction.Rollback();
              return false;
          }
          return true;
      }
      public bool EditAsset(Wilson.ORMapper.Transaction TempTransaction)
      {
          try
          {
              SimatSoft.DB.ORM.Manager.Engine.StartTracking(Assetobj, Wilson.ORMapper.InitialState.Updated);
              TempTransaction.PersistChanges(Assetobj);
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
