using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class POHome
    {
       public Podt Podtobj = null;
       public Pohd Pohdobj = null;
       public POReceive POReceiveObj = null;
       public AssetReceive AssetReceiveObj =null;
       
       
       public POHome()
       {
           Podtobj = new Podt();
           Pohdobj = new Pohd();
           POReceiveObj = new POReceive();
           AssetReceiveObj = new AssetReceive();
       }
       public bool AddHD(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               Manager.Engine.StartTracking(Pohdobj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(Pohdobj);              
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
               Manager.Engine.StartTracking(Podtobj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(Podtobj);

           }
           catch (Exception Ex) { return false; }
           return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(Pohdobj);
               Manager.Engine.PersistChanges(Pohdobj);
           }
           catch (Exception Ex) { return false; }
           return true;
       }
       public bool DeleteDT(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.MarkForDeletion(Podtobj);
               TempTransaction.PersistChanges(Podtobj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool EditHD()
       {
           try
           {
               Manager.Engine.StartTracking(Pohdobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Pohdobj);
           }
           catch (Exception Err)
           {
               SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
           }
           return true;
       }
       public bool EditHDTransaction(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               Manager.Engine.StartTracking(Pohdobj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(Pohdobj);
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
               Manager.Engine.StartTracking(Podtobj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(Podtobj);
               
           }
           catch (Exception Err)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool AddReceive(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(POReceiveObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(POReceiveObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool EditReceive()
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(POReceiveObj, Wilson.ORMapper.InitialState.Updated);
               //TempTransaction.PersistChanges(POReceiveObj);
           }
           catch (Exception Ex)
           {
               //TempTransaction.Rollback();
               return false;
           }
           return true;
       }

       public bool EditReceive(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(POReceiveObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(POReceiveObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool AddAssetReceive(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetReceiveObj, Wilson.ORMapper.InitialState.Inserted);
               TempTransaction.PersistChanges(AssetReceiveObj);
           }
           catch (Exception Ex)
           {
               TempTransaction.Rollback();
               return false;
           }
           return true;
       }
       public bool EditAssetReceive(Wilson.ORMapper.Transaction TempTransaction)
       {
           try
           {
               SimatSoft.DB.ORM.Manager.Engine.StartTracking(AssetReceiveObj, Wilson.ORMapper.InitialState.Updated);
               TempTransaction.PersistChanges(AssetReceiveObj);
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
