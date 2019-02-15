using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

   public class FormatBarcodeCustodianHome
    {
       public FormatBarCodeCustodian BarcodeCustodianObj = null;
       public FormatBarcodeCustodianHome()
       {
           BarcodeCustodianObj = new FormatBarCodeCustodian();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeCustodianObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeCustodianObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeCustodianObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeCustodianObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeCustodianObj);
               Manager.Engine.PersistChanges(BarcodeCustodianObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
       public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeCustodian> CollectionBarCodeCustodian)
       {
           try
           {
               foreach (FormatBarCodeCustodian TempBarCodeCustodian in CollectionBarCodeCustodian)
               {
                   Manager.Engine.MarkForDeletion(TempBarCodeCustodian);
                   Transactions.PersistChanges(TempBarCodeCustodian);
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

