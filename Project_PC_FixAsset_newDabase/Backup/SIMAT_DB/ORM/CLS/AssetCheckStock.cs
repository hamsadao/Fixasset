using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
    public class AssetCheckstock : IObjectHelper, IObjectNotification
    {
        private string assetID;
        private string assetName;
        private string serialNo;
        private string modelID;
        private string deptID;
        private string floorID;
        private string buildID;
        private string areaID;
        private string reasonCode;
        private string typeID;
        private string statusID;
        private string vendorID;
        private decimal assetPrice;
        private DateTime warrantyStartDate;
        private DateTime warrantyEndDate;
        private string custodianID;
        private string previosCustodian;
        private DateTime createdDate;
        private string userName;
        private DateTime updateDate;
        private string remark;
        private string facCode;

        public string AssetID
        {
            get { return this.assetID; }
            set { this.assetID = value; }
        }

        public string AssetName
        {
            get { return this.assetName; }
            set { this.assetName = value; }
        }

        public string SerialNo
        {
            get { return this.serialNo; }
            set { this.serialNo = value; }
        }

        public string ModelID
        {
            get { return this.modelID; }
            set { this.modelID = value; }
        }

        public string DeptID
        {
            get { return this.deptID; }
            set { this.deptID = value; }
        }

        public string FloorID
        {
            get { return this.floorID; }
            set { this.floorID = value; }
        }

        public string BuildID
        {
            get { return this.buildID; }
            set { this.buildID = value; }
        }

        public string AreaID
        {
            get { return this.areaID; }
            set { this.areaID = value; }
        }

        public string ReasonCode
        {
            get { return this.reasonCode; }
            set { this.reasonCode = value; }
        }

        public string TypeID
        {
            get { return this.typeID; }
            set { this.typeID = value; }
        }

        public string StatusID
        {
            get { return this.statusID; }
            set { this.statusID = value; }
        }

        public string VendorID
        {
            get { return this.vendorID; }
            set { this.vendorID = value; }
        }

        public decimal AssetPrice
        {
            get { return this.assetPrice; }
            set { this.assetPrice = value; }
        }

        public DateTime WarrantyStartDate
        {
            get { return this.warrantyStartDate; }
            set { this.warrantyStartDate = value; }
        }

        public DateTime WarrantyEndDate
        {
            get { return this.warrantyEndDate; }
            set { this.warrantyEndDate = value; }
        }

        public string CustodianID
        {
            get { return this.custodianID; }
            set { this.custodianID = value; }
        }

        public string PreviosCustodian
        {
            get { return this.previosCustodian; }
            set { this.previosCustodian = value; }
        }

        public DateTime CreatedDate
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public DateTime UpdateDate
        {
            get { return this.updateDate; }
            set { this.updateDate = value; }
        }

        public string Remark
        {
            get { return this.remark; }
            set { this.remark = value; }
        }

        public string FacCode
        {
            get { return this.facCode; }
            set { this.facCode = value; }
        }


        #region IObjectHelper Members
        public object this[string memberName]
        {
            get
            {
                switch (memberName)
                {
                    case "assetID": return this.assetID;
                    case "assetName": return this.assetName;
                    case "serialNo": return this.serialNo;
                    case "modelID": return this.modelID;
                    case "deptID": return this.deptID;
                    case "floorID": return this.floorID;
                    case "buildID": return this.buildID;
                    case "areaID": return this.areaID;
                    case "reasonCode": return this.reasonCode;
                    case "typeID": return this.typeID;
                    case "statusID": return this.statusID;
                    case "vendorID": return this.vendorID;
                    case "assetPrice": return this.assetPrice;
                    case "warrantyStartDate": return this.warrantyStartDate;
                    case "warrantyEndDate": return this.warrantyEndDate;
                    case "custodianID": return this.custodianID;
                    case "previosCustodian": return this.previosCustodian;
                    case "createdDate": return this.createdDate;
                    case "userName": return this.userName;
                    case "updateDate": return this.updateDate;
                    case "remark": return this.remark;
                    case "facCode": return this.facCode;
                    default: throw new Exception("Invalid Member");
                }
            }
            set
            {
                switch (memberName)
                {
                    case "assetID": this.assetID = (string)value; break;
                    case "assetName": this.assetName = (string)value; break;
                    case "serialNo": this.serialNo = (string)value; break;
                    case "modelID": this.modelID = (string)value; break;
                    case "deptID": this.deptID = (string)value; break;
                    case "floorID": this.floorID = (string)value; break;
                    case "buildID": this.buildID = (string)value; break;
                    case "areaID": this.areaID = (string)value; break;
                    case "reasonCode": this.reasonCode = (string)value; break;
                    case "typeID": this.typeID = (string)value; break;
                    case "statusID": this.statusID = (string)value; break;
                    case "vendorID": this.vendorID = (string)value; break;
                    case "assetPrice": this.assetPrice = (decimal)value; break;
                    case "warrantyStartDate": this.warrantyStartDate = (DateTime)value; break;
                    case "warrantyEndDate": this.warrantyEndDate = (DateTime)value; break;
                    case "custodianID": this.custodianID = (string)value; break;
                    case "previosCustodian": this.previosCustodian = (string)value; break;
                    case "createdDate": this.createdDate = (DateTime)value; break;
                    case "userName": this.userName = (string)value; break;
                    case "updateDate": this.updateDate = (DateTime)value; break;
                    case "remark": this.remark = (string)value; break;
                    case "facCode": this.facCode = (string)value; break;
                    default: throw new Exception("Invalid Member");
                }
            }
        }
        #endregion

        #region IObjectNotification Members
        public void OnCreated(Transaction transaction)
        {
            // TODO
        }

        public void OnCreating(Transaction transaction)
        {
            // TODO
        }

        public void OnDeleted(Transaction transaction)
        {
            // TODO
        }

        public void OnDeleting(Transaction transaction)
        {
            // TODO
        }

        public void OnMaterialized(System.Data.IDataRecord dataRecord)
        {
            // TODO
        }

        public void OnPersistError(Transaction transaction, Exception exception)
        {
            // TODO
        }

        public void OnUpdated(Transaction transaction)
        {
            // TODO
        }

        public void OnUpdating(Transaction transaction)
        {
            // TODO
        }
        #endregion
    }
}

