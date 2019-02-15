//This code was generated by a tool as of 2007-08-27 09:29:03.015.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class FormatBarCodeArea : IObjectHelper, IObjectNotification
	{
		private string areaID;
		private int position;
		private string barCode;
		private string remark;

		public string AreaID
		{
			get { return this.areaID; }
            set { this.areaID = value; }
		}

		public int Position
		{
			get { return this.position; }
			set { this.position = value; }
		}

		public string BarCode
		{
			get { return this.barCode; }
			set { this.barCode = value; }
		}

		public string Remark
		{
			get { return this.remark; }
			set { this.remark = value; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "areaID": return this.areaID;
					case "position": return this.position;
					case "barCode": return this.barCode;
					case "remark": return this.remark;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "areaID": this.areaID = (string) value; break;
					case "position": this.position = (int) value; break;
					case "barCode": this.barCode = (string) value; break;
					case "remark": this.remark = (string) value; break;
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
