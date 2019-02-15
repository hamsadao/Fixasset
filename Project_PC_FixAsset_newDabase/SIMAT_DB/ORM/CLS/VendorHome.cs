using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
   public class VendorHome
    {
       public Vendor Vendorobj = null;
       public VendorHome()
       {
           Vendorobj = new Vendor();
       }

       public bool Add()
       {
           try
           {

               Manager.Engine.StartTracking(Vendorobj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(Vendorobj);
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
               Manager.Engine.MarkForDeletion(Vendorobj);
               Manager.Engine.PersistChanges(Vendorobj);
           }
           catch (Exception Err)
           {
              // SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
               //return false;
               throw new Exception(Err.Message);
           }
           return true;   
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<Vendor> CollectionVendor)
       {
           try
           {
               foreach (Vendor TempVendor in CollectionVendor)
               {
                   Manager.Engine.MarkForDeletion(TempVendor);
                   Transactions.PersistChanges(TempVendor);
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
               Manager.Engine.StartTracking(Vendorobj, Wilson.ORMapper.InitialState.Updated);
               Manager.Engine.PersistChanges(Vendorobj);
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
