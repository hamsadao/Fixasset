//This code was generated by a tool as of 2007-06-11 15:53:31.234.

using System;
using System.Collections;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class AssetTransfer : IObjectHelper, IObjectNotification
	{
		private string transferID;
		private string modelID;
		private int transferSeq;
		private int transferQty;
		private DateTime createdDate;
		private string userName;
		private string transferType;
		private string fromFacCode;
		private string toFacCode;
		private string fromDeptID;
		private string toDeptID;
		private decimal transferPrice;
		private decimal transferCost;
        //private AssetTransferDT assetTransferDTObject; // Strongly Type as AssetTransferDT if not Lazy-Loading
        //private AssetTransferDT assetTransferDTObject; // Strongly Type as AssetTransferDT if not Lazy-Loading
        //private AssetTransferDT assetTransferDTObject; // Strongly Type as AssetTransferDT if not Lazy-Loading
        //private AssetTransferHD assetTransferHDObject; // Strongly Type as AssetTransferHD if not Lazy-Loading
        //private Model modelObject; // Strongly Type as Model if not Lazy-Loading
		private IList assetTransferSerials; // Supports both ObjectSet and Lazy-Loaded ObjectList
        //private IList assetTransferSerials; // Supports both ObjectSet and Lazy-Loaded ObjectList
        //private IList assetTransferSerials; // Supports both ObjectSet and Lazy-Loaded ObjectList

		public string TransferID
		{
			get { return this.transferID; }
            set { this.transferID = value; }
		}

		public string ModelID
		{
			get { return this.modelID; }
			set { this.modelID = value; }
		}

		public int TransferSeq
		{
			get { return this.transferSeq; }
			set { this.transferSeq = value; }
		}

		public int TransferQty
		{
			get { return this.transferQty; }
			set { this.transferQty = value; }
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

		public string TransferType
		{
			get { return this.transferType; }
			set { this.transferType = value; }
		}

		public string FromFacCode
		{
			get { return this.fromFacCode; }
			set { this.fromFacCode = value; }
		}

		public string ToFacCode
		{
			get { return this.toFacCode; }
			set { this.toFacCode = value; }
		}

		public string FromDeptID
		{
			get { return this.fromDeptID; }
			set { this.fromDeptID = value; }
		}

		public string ToDeptID
		{
			get { return this.toDeptID; }
			set { this.toDeptID = value; }
		}

		public decimal TransferPrice
		{
			get { return this.transferPrice; }
			set { this.transferPrice = value; }
		}

		public decimal TransferCost
		{
			get { return this.transferCost; }
			set { this.transferCost = value; }
		}


		public IList AssetTransferSerials
		{
			get { return this.assetTransferSerials; }
		}

		

		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "transferID": return this.transferID;
					case "modelID": return this.modelID;
					case "transferSeq": return this.transferSeq;
					case "transferQty": return this.transferQty;
					case "createdDate": return this.createdDate;
					case "userName": return this.userName;
					case "transferType": return this.transferType;
					case "fromFacCode": return this.fromFacCode;
					case "toFacCode": return this.toFacCode;
					case "fromDeptID": return this.fromDeptID;
					case "toDeptID": return this.toDeptID;
					case "transferPrice": return this.transferPrice;
					case "transferCost": return this.transferCost;
					case "assetTransferSerials": return this.assetTransferSerials;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "transferID": this.transferID = (string) value; break;
					case "modelID": this.modelID = (string) value; break;
					case "transferSeq": this.transferSeq = (int) value; break;
					case "transferQty": this.transferQty = (int) value; break;
					case "createdDate": this.createdDate = (DateTime) value; break;
					case "userName": this.userName = (string) value; break;
					case "transferType": this.transferType = (string) value; break;
					case "fromFacCode": this.fromFacCode = (string) value; break;
					case "toFacCode": this.toFacCode = (string) value; break;
					case "fromDeptID": this.fromDeptID = (string) value; break;
					case "toDeptID": this.toDeptID = (string) value; break;
					case "transferPrice": this.transferPrice = (decimal) value; break;
					case "transferCost": this.transferCost = (decimal) value; break;
					case "assetTransferSerials": this.assetTransferSerials = (IList) value; break;
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