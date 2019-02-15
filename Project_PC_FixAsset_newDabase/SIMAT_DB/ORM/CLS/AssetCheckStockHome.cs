using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
    public class AssetCheckStockHome
    {
        public AssetCheckstock AssetCheckStockObj = null;
        public AssetCheckStockHome()
        {
            AssetCheckStockObj = new AssetCheckstock();
            //this.MemberwiseClone();

        }
        public bool Add()
        {
            try
            {

                Manager.Engine.StartTracking(AssetCheckStockObj, Wilson.ORMapper.InitialState.Inserted);
                Manager.Engine.PersistChanges(AssetCheckStockObj);
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                return false;

            }
            return true;
        }

        public bool Delete()
        {
            try
            {
                Manager.Engine.MarkForDeletion(AssetCheckStockObj);
                Manager.Engine.PersistChanges(AssetCheckStockObj);
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                return false;
            }
            return true;
        }
        public bool Delete(Wilson.ORMapper.Transaction Transactions, List<AssetCheckstock> CollectionCheckStock)
        {
            try
            {
                foreach (AssetCheckstock TemCheckstock in CollectionCheckStock)
                {
                    Manager.Engine.MarkForDeletion(TemCheckstock);
                    Transactions.PersistChanges(TemCheckstock);
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
                Manager.Engine.StartTracking(AssetCheckStockObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(AssetCheckStockObj);

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                return false;
            }
            return true;
        }
        #region IObjectHelper Members
        public object this[string memberName]
        {
            get
            {
                switch (memberName)
                {
                    default: throw new Exception("Invalid Member");
                }
            }
            set
            {
                switch (memberName)
                {
                    default: throw new Exception("Invalid Member");
                }
            }
        }
        #endregion
    }
}