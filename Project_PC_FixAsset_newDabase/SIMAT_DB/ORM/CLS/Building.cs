//This code was generated by a tool as of 2007-05-24 15:47:47.703.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Building : IObjectHelper, IObjectNotification
	{
		private string buildID;
		private string buildName;
		private string facCode;

		public string BuildID
		{
			get { return this.buildID; }
            set { this.buildID = value; }
		}

		public string BuildName
		{
			get { return this.buildName; }
			set { this.buildName = value; }
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
					case "buildID": return this.buildID;
					case "buildName": return this.buildName;
					case "facCode": return this.facCode;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "buildID": this.buildID = (string) value; break;
					case "buildName": this.buildName = (string) value; break;
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