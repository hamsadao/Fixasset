//This code was generated by a tool as of 2007-07-17 10:58:58.546.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class Vendor : IObjectHelper, IObjectNotification
	{
		private string iD;
		private string firstName;
		private string lastName;
		private string address1;
		private string address2;
		private string city;
		private string state;
		private string zip;
		private string phone;
		private string fax;
		private string email;
		private string contact;
		private string flag;
		private string remark;

		public string ID
		{
			get { return this.iD; }
            set { this.iD = value; }
		}

		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
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

		public string City
		{
			get { return this.city; }
			set { this.city = value; }
		}

		public string State
		{
			get { return this.state; }
			set { this.state = value; }
		}

		public string Zip
		{
			get { return this.zip; }
			set { this.zip = value; }
		}

		public string Phone
		{
			get { return this.phone; }
			set { this.phone = value; }
		}

		public string Fax
		{
			get { return this.fax; }
			set { this.fax = value; }
		}

		public string Email
		{
			get { return this.email; }
			set { this.email = value; }
		}

		public string Contact
		{
			get { return this.contact; }
			set { this.contact = value; }
		}

		public string Flag
		{
			get { return this.flag; }
			set { this.flag = value; }
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
					case "iD": return this.iD;
					case "firstName": return this.firstName;
					case "lastName": return this.lastName;
					case "address1": return this.address1;
					case "address2": return this.address2;
					case "city": return this.city;
					case "state": return this.state;
					case "zip": return this.zip;
					case "phone": return this.phone;
					case "fax": return this.fax;
					case "email": return this.email;
					case "contact": return this.contact;
					case "flag": return this.flag;
					case "remark": return this.remark;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "iD": this.iD = (string) value; break;
					case "firstName": this.firstName = (string) value; break;
					case "lastName": this.lastName = (string) value; break;
					case "address1": this.address1 = (string) value; break;
					case "address2": this.address2 = (string) value; break;
					case "city": this.city = (string) value; break;
					case "state": this.state = (string) value; break;
					case "zip": this.zip = (string) value; break;
					case "phone": this.phone = (string) value; break;
					case "fax": this.fax = (string) value; break;
					case "email": this.email = (string) value; break;
					case "contact": this.contact = (string) value; break;
					case "flag": this.flag = (string) value; break;
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
