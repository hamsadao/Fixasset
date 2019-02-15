//This code was generated by a tool as of 2007-05-28 17:32:44.921.

using System;
using System.Collections;
using Wilson.ORMapper;

//namespace SimatSoft.DB.ORM
//{
//    public class Pohd : IObjectHelper, IObjectNotification
//    {
//        private string poid;
//        private string deptID;
//        private string vendorID;
//        private string pOType;
//        private DateTime pODate;
//        private string userName;
//        private string remark;
//        private string facCode;
//        private string statusID;
//        private IList podts; // Supports both ObjectSet and Lazy-Loaded ObjectList
//        private IList pOReceives; // Supports both ObjectSet and Lazy-Loaded ObjectList

//        public string Poid
//        {
//            get { return this.poid; }
//            set { this.poid = value; }
//        }

//        public string DeptID
//        {
//            get { return this.deptID; }
//            set { this.deptID = value; }
//        }

//        public string VendorID
//        {
//            get { return this.vendorID; }
//            set { this.vendorID = value; }
//        }

//        public string POType
//        {
//            get { return this.pOType; }
//            set { this.pOType = value; }
//        }

//        public DateTime PODate
//        {
//            get { return this.pODate; }
//            set { this.pODate = value; }
//        }

//        public string UserName
//        {
//            get { return this.userName; }
//            set { this.userName = value; }
//        }

//        public string Remark
//        {
//            get { return this.remark; }
//            set { this.remark = value; }
//        }

//        public string FacCode
//        {
//            get { return this.facCode; }
//            set { this.facCode = value; }
//        }

//        public string StatusID
//        {
//            get { return this.statusID; }
//            set { this.statusID = value; }
//        }

//        public IList Podts
//        {
//            get { return this.podts; }
//        }

//        public IList POReceives
//        {
//            get { return this.pOReceives; }
//        }


//        #region IObjectHelper Members
//        public object this[string memberName]
//        {
//            get {
//                switch (memberName) {
//                    case "poid": return this.poid;
//                    case "deptID": return this.deptID;
//                    case "vendorID": return this.vendorID;
//                    case "pOType": return this.pOType;
//                    case "pODate": return this.pODate;
//                    case "userName": return this.userName;
//                    case "remark": return this.remark;
//                    case "facCode": return this.facCode;
//                    case "statusID": return this.statusID;
//                    case "podts": return this.podts;
//                    case "pOReceives": return this.pOReceives;
//                    default: throw new Exception("Invalid Member");
//                }
//            }
//            set {
//                switch (memberName) {
//                    case "poid": this.poid = (string) value; break;
//                    case "deptID": this.deptID = (string) value; break;
//                    case "vendorID": this.vendorID = (string) value; break;
//                    case "pOType": this.pOType = (string) value; break;
//                    case "pODate": this.pODate = (DateTime) value; break;
//                    case "userName": this.userName = (string) value; break;
//                    case "remark": this.remark = (string) value; break;
//                    case "facCode": this.facCode = (string) value; break;
//                    case "statusID": this.statusID = (string) value; break;
//                    case "podts": this.podts = (IList) value; break;
//                    case "pOReceives": this.pOReceives = (IList) value; break;
//                    default: throw new Exception("Invalid Member");
//                }
//            }
//        }
//        #endregion

//        #region IObjectNotification Members
//        public void OnCreated(Transaction transaction)
//        {
//            // TODO
//        }

//        public void OnCreating(Transaction transaction)
//        {
//            // TODO
//        }

//        public void OnDeleted(Transaction transaction)
//        {
//            // TODO
//        }

//        public void OnDeleting(Transaction transaction)
//        {
//            // TODO
//        }

//        public void OnMaterialized(System.Data.IDataRecord dataRecord)
//        {
//            // TODO
//        }

//        public void OnPersistError(Transaction transaction, Exception exception)
//        {
//            // TODO
//        }

//        public void OnUpdated(Transaction transaction)
//        {
//            // TODO
//        }

//        public void OnUpdating(Transaction transaction)
//        {
//            // TODO
//        }
//        #endregion
//    }
//}


namespace SimatSoft.DB.ORM
{
    public class Pohd : IObjectHelper, IObjectNotification
    {
        private string poid;
        private string deptID;
        private string vendorID;
        private string pOType;
        private DateTime pODate;
        private string userName;
        private string remark;
        private string facCode;
        private string statusID;
        private string customfiled1;
        private string customfiled2;
        private string customfiled3;
        private string customfiled4;
        private string customfiled5;
        private IList podts; // Supports both ObjectSet and Lazy-Loaded ObjectList
        private IList pOReceives; // Supports both ObjectSet and Lazy-Loaded ObjectList

        public string Poid
        {
            get { return this.poid; }
            set { this.poid = value; }
        }

        public string DeptID
        {
            get { return this.deptID; }
            set { this.deptID = value; }
        }

        public string VendorID
        {
            get { return this.vendorID; }
            set { this.vendorID = value; }
        }

        public string POType
        {
            get { return this.pOType; }
            set { this.pOType = value; }
        }

        public DateTime PODate
        {
            get { return this.pODate; }
            set { this.pODate = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
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

        public string StatusID
        {
            get { return this.statusID; }
            set { this.statusID = value; }
        }

        public string Customfiled1
        {
            get { return this.customfiled1; }
            set { this.customfiled1 = value; }
        }

        public string Customfiled2
        {
            get { return this.customfiled2; }
            set { this.customfiled2 = value; }
        }

        public string Customfiled3
        {
            get { return this.customfiled3; }
            set { this.customfiled3 = value; }
        }

        public string Customfiled4
        {
            get { return this.customfiled4; }
            set { this.customfiled4 = value; }
        }

        public string Customfiled5
        {
            get { return this.customfiled5; }
            set { this.customfiled5 = value; }
        }

        public IList Podts
        {
            get { return this.podts; }
        }

        public IList POReceives
        {
            get { return this.pOReceives; }
        }


        #region IObjectHelper Members
        public object this[string memberName]
        {
            get
            {
                switch (memberName)
                {
                    case "poid": return this.poid;
                    case "deptID": return this.deptID;
                    case "vendorID": return this.vendorID;
                    case "pOType": return this.pOType;
                    case "pODate": return this.pODate;
                    case "userName": return this.userName;
                    case "remark": return this.remark;
                    case "facCode": return this.facCode;
                    case "statusID": return this.statusID;
                    case "customfiled1": return this.customfiled1;
                    case "customfiled2": return this.customfiled2;
                    case "customfiled3": return this.customfiled3;
                    case "customfiled4": return this.customfiled4;
                    case "customfiled5": return this.customfiled5;
                    case "podts": return this.podts;
                    case "pOReceives": return this.pOReceives;
                    default: throw new Exception("Invalid Member");
                }
            }
            set
            {
                switch (memberName)
                {
                    case "poid": this.poid = (string)value; break;
                    case "deptID": this.deptID = (string)value; break;
                    case "vendorID": this.vendorID = (string)value; break;
                    case "pOType": this.pOType = (string)value; break;
                    case "pODate": this.pODate = (DateTime)value; break;
                    case "userName": this.userName = (string)value; break;
                    case "remark": this.remark = (string)value; break;
                    case "facCode": this.facCode = (string)value; break;
                    case "statusID": this.statusID = (string)value; break;
                    case "customfiled1": this.customfiled1 = (string)value; break;
                    case "customfiled2": this.customfiled2 = (string)value; break;
                    case "customfiled3": this.customfiled3 = (string)value; break;
                    case "customfiled4": this.customfiled4 = (string)value; break;
                    case "customfiled5": this.customfiled5 = (string)value; break;
                    case "podts": this.podts = (IList)value; break;
                    case "pOReceives": this.pOReceives = (IList)value; break;
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