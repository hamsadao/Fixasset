using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.DB.ORM
{

    public class FormatBarcodeBuildingHome
    {
       public FormatBarCodeBuilding BarcodeBuildingObj = null;
       public FormatBarcodeBuildingHome()
       {
           BarcodeBuildingObj = new FormatBarCodeBuilding();
       }

       public bool Add()
       {
           try
           {
               Manager.Engine.StartTracking(BarcodeBuildingObj, Wilson.ORMapper.InitialState.Inserted);
               Manager.Engine.PersistChanges(BarcodeBuildingObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
           
       }

       public bool Edit()
       {
           try
            {

                Manager.Engine.StartTracking(BarcodeBuildingObj, Wilson.ORMapper.InitialState.Updated);
                Manager.Engine.PersistChanges(BarcodeBuildingObj);
            }
            catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

            return true;
       }

       public bool Delete()
       {
           try
           {
               Manager.Engine.MarkForDeletion(BarcodeBuildingObj);
               Manager.Engine.PersistChanges(BarcodeBuildingObj);
           }
           catch (Exception Ex) { throw new Exception(Ex.Message, Ex); }

           return true;
       }
        public bool Delete(Wilson.ORMapper.Transaction Transactions, List<FormatBarCodeBuilding> CollectionBuilding)
        {
            try
            {
                foreach (FormatBarCodeBuilding TempBarCodeBuilding in CollectionBuilding)
                {
                    Manager.Engine.MarkForDeletion(TempBarCodeBuilding);
                    Transactions.PersistChanges(TempBarCodeBuilding);
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

