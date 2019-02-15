using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class CheckStockHome
    {
       public CheckStock CheckStockObj = null;
       public CheckStockHome()
       {
           CheckStockObj = new CheckStock();
           //this.MemberwiseClone();

       }
       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(CheckStockObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(CheckStockObj);
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
               Manager.Engine.MarkForDeletion(CheckStockObj);
               Manager.Engine.PersistChanges(CheckStockObj);
           }
           catch (Exception Err)
           {
               SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               return false;
           }
           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<CheckStock> CollectionCheckStock)
       {
           try
           {
               foreach (CheckStock TemCheckstock in CollectionCheckStock)
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
               Manager.Engine.StartTracking(CheckStockObj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(CheckStockObj);
               
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
