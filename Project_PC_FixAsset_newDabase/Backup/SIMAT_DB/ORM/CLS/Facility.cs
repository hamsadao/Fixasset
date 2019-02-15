//This code was generated by a tool as of 2007-05-24 15:50:37.890.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Facility : IObjectHelper, IObjectNotification
	{
		private string facCode;
		private string facName;
		private string address1;
		private string address2;
		private string phone;
		private string facCity;

		public string FacCode
		{
			get { return this.facCode; }
            set { this.facCode = value; }
		}

		public string FacName
		{
			get { return this.facName; }
			set { this.facName = value; }
		}

		public string Address1
		{
			get { return this.address1; }
			set { this.address1 = value; }
		}

		public string Address2
		{
			get { return this.address2; }
			set { this.address2 = value; }
		}

		public string Phone
		{
			get { return this.phone; }
			set { this.phone = value; }
		}

		public string FacCity
		{
			get { return this.facCity; }
			set { this.facCity = value; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "facCode": return this.facCode;
					case "facName": return this.facName;
					case "address1": return this.address1;
					case "address2": return this.address2;
					case "phone": return this.phone;
					case "facCity": return this.facCity;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "facCode": this.facCode = (string) value; break;
					case "facName": this.facName = (string) value; break;
					case "address1": this.address1 = (string) value; break;
					case "address2": this.address2 = (string) value; break;
					case "phone": this.phone = (string) value; break;
					case "facCity": this.facCity = (string) value; break;
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
