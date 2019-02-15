using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
    public class AssetPicHome
    {
        public AssetPic AssetPicobj = null;
        public AssetPicHome()
        {
            AssetPicobj = new AssetPic();
        }

        public bool Add()
        {
            try
            {

                ManagerPic.Engine.StartTracking(AssetPicobj, Wilson.ORMapper.InitialState.Inserted);
                ManagerPic.Engine.PersistChanges(AssetPicobj);
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
                ManagerPic.Engine.MarkForDeletion(AssetPicobj);
                ManagerPic.Engine.PersistChanges(AssetPicobj);
            }
            catch (Exception Err)
            {
               // SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                //return false;
                throw new Exception(Err.Message);
            }
            return true;     
        }
        public bool Delete(Wilson.ORMapper.Transaction Transactions, List<AssetPic> CollectionAssetPic)
        {
            try
            {
                foreach (AssetPic TempAssetPic in CollectionAssetPic)
                {
                    //ManagerPic.Engine.StartTracking(TempAssetPic, Wilson.ORMapper.InitialState.Unchanged);
                    ManagerPic.Engine.MarkForDeletion(TempAssetPic);
                    Transactions.PersistChanges(TempAssetPic);
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
                ManagerPic.Engine.StartTracking(AssetPicobj, Wilson.ORMapper.InitialState.Updated);
                ManagerPic.Engine.PersistChanges(AssetPicobj);
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
