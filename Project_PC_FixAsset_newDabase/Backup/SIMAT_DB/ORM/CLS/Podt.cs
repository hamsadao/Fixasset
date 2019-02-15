//This code was generated by a tool as of 2007-05-28 17:31:46.593.

using System;
using System.Collections;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Podt : IObjectHelper, IObjectNotification
	{
		private string poid;
		private string modelID;
		private int pOSeq;
		private int pOQty;
		private int receiveQty;
		private decimal pOPrice;
		private decimal pOCost;
		private string remark;
		//private Model modelObject; // Strongly Type as Model if not Lazy-Loading
		private Pohd pohdObject; // Strongly Type as Pohd if not Lazy-Loading
		private IList pOReceives; // Supports both ObjectSet and Lazy-Loaded ObjectList
		
		public string Poid
		{
			get { return this.poid; }
            set { this.poid = value; }
		}

		public string ModelID
		{
			get { return this.modelID; }
			set { this.modelID = value; }
		}

		public int POSeq
		{
			get { return this.pOSeq; }
			set { this.pOSeq = value; }
		}

		public int POQty
		{
			get { return this.pOQty; }
			set { this.pOQty = value; }
		}

		public int ReceiveQty
		{
			get { return this.receiveQty; }
			set { this.receiveQty = value; }
		}

		public decimal POPrice
		{
			get { return this.pOPrice; }
			set { this.pOPrice = value; }
		}

		public decimal POCost
		{
			get { return this.pOCost; }
			set { this.pOCost = value; }
		}

		public string Remark
		{
			get { return this.remark; }
			set { this.remark = value; }
		}

		// Return the primary key property from the primary key object
        //public Model ModelObject
        //{
        //    get { return this.modelObject; }
        //}

		// Return the primary key property from the primary key object
		public Pohd PohdObject
		{
			get { return this.pohdObject; }
		}

        //public IList POReceives
        //{
        //    get { return this.pOReceives; }
        //}

		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "poid": return this.poid;
					case "modelID": return this.modelID;
					case "pOSeq": return this.pOSeq;
					case "pOQty": return this.pOQty;
					case "receiveQty": return this.receiveQty;
					case "pOPrice": return this.pOPrice;
					case "pOCost": return this.pOCost;
					case "remark": return this.remark;
					//case "modelObject": return this.modelObject;
					case "pohdObject": return this.pohdObject;
					//case "pOReceives": return this.pOReceives;
					
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "poid": this.poid = (string) value; break;
					case "modelID": this.modelID = (string) value; break;
					case "pOSeq": this.pOSeq = (int) value; break;
					case "pOQty": this.pOQty = (int) value; break;
					case "receiveQty": this.receiveQty = (int) value; break;
					case "pOPrice": this.pOPrice = (decimal) value; break;
					case "pOCost": this.pOCost = (decimal) value; break;
					case "remark": this.remark = (string) value; break;
					//case "modelObject": this.modelObject = (Model) value; break;
					case "pohdObject": this.pohdObject = (Pohd) value; break;
					//case "pOReceives": this.pOReceives = (IList) value; break;
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