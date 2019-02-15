//This code was generated by a tool as of 2007-05-18 10:44:02.734.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Department : IObjectHelper, IObjectNotification
	{
		private string deptID;
		private string deptName;
		private string facCode;

		public string DeptID
		{
			get { return this.deptID; }
            set { this.deptID = value;   }
		}

		public string DeptName
		{
			get { return this.deptName; }
			set { this.deptName = value; }
		}

		public string FacCode
		{
			get { return this.facCode; }
			set { this.facCode = value; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "deptID": return this.deptID;
					case "deptName": return this.deptName;
					case "facCode": return this.facCode;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "deptID": this.deptID = (string) value; break;
					case "deptName": this.deptName = (string) value; break;
					case "facCode": this.facCode = (string) value; break;
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