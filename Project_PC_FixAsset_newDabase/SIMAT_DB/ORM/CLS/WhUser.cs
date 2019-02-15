//This code was generated by a tool as of 2007-06-20 11:39:05.078.

using System;
using System.Collections;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Whuser : IObjectHelper, IObjectNotification
	{
		private string usID;
		private string deptID;
		private string usFirstName;
		private string usLastName;
		private string usPass;
		private string usGroupID;
		private DateTime createdDate;
		private bool activeFlag;
		private string facCode;
		private IList whuserAccesses; // Supports both ObjectSet and Lazy-Loaded ObjectList

		public string UsID
		{
			get { return this.usID; }
            set { this.usID = value; }
		}

		public string DeptID
		{
			get { return this.deptID; }
			set { this.deptID = value; }
		}

		public string UsFirstName
		{
			get { return this.usFirstName; }
			set { this.usFirstName = value; }
		}

		public string UsLastName
		{
			get { return this.usLastName; }
			set { this.usLastName = value; }
		}

		public string UsPass
		{
			get { return this.usPass; }
			set { this.usPass = value; }
		}

		public string UsGroupID
		{
			get { return this.usGroupID; }
			set { this.usGroupID = value; }
		}

		public DateTime CreatedDate
		{
			get { return this.createdDate; }
			set { this.createdDate = value; }
		}

		public bool ActiveFlag
		{
			get { return this.activeFlag; }
			set { this.activeFlag = value; }
		}

		public string FacCode
		{
			get { return this.facCode; }
			set { this.facCode = value; }
		}

		public IList WhuserAccesses
		{
			get { return this.whuserAccesses; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "usID": return this.usID;
					case "deptID": return this.deptID;
					case "usFirstName": return this.usFirstName;
					case "usLastName": return this.usLastName;
					case "usPass": return this.usPass;
					case "usGroupID": return this.usGroupID;
					case "createdDate": return this.createdDate;
					case "activeFlag": return this.activeFlag;
					case "facCode": return this.facCode;
					case "whuserAccesses": return this.whuserAccesses;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "usID": this.usID = (string) value; break;
					case "deptID": this.deptID = (string) value; break;
					case "usFirstName": this.usFirstName = (string) value; break;
					case "usLastName": this.usLastName = (string) value; break;
					case "usPass": this.usPass = (string) value; break;
					case "usGroupID": this.usGroupID = (string) value; break;
					case "createdDate": this.createdDate = (DateTime) value; break;
					case "activeFlag": this.activeFlag = (bool) value; break;
					case "facCode": this.facCode = (string) value; break;
					case "whuserAccesses": this.whuserAccesses = (IList) value; break;
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