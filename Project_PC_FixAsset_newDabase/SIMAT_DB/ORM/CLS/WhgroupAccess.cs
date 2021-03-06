//This code was generated by a tool as of 2007-06-19 10:07:28.843.

using System;
using System.Collections;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class WhgroupAccess : IObjectHelper, IObjectNotification
	{
		private string usGroupID;
		private string scID;
		private bool addR;
		private bool deleteR;
		private bool editR;
		private Screen screenObject; // Strongly Type as Screen if not Lazy-Loading
		private WhGroup whGroupObject; // Strongly Type as WhGroup if not Lazy-Loading

		public string UsGroupID
		{
			get { return this.usGroupID; }
            set { this.usGroupID = value; }
		}

		public string ScID
		{
			get { return this.scID; }
			set { this.scID = value; }
		}

		public bool AddR
		{
			get { return this.addR; }
			set { this.addR = value; }
		}

		public bool DeleteR
		{
			get { return this.deleteR; }
			set { this.deleteR = value; }
		}

		public bool EditR
		{
			get { return this.editR; }
			set { this.editR = value; }
		}

		// Return the primary key property from the primary key object
		public Screen ScreenObject
		{
			get { return this.screenObject; }
		}

        // Return the primary key property from the primary key object
        public WhGroup WhGroupObject
        {
            get { return this.whGroupObject; }
        }


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "usGroupID": return this.usGroupID;
					case "scID": return this.scID;
					case "addR": return this.addR;
					case "deleteR": return this.deleteR;
					case "editR": return this.editR;
					case "screenObject": return this.screenObject;
					case "whGroupObject": return this.whGroupObject;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "usGroupID": this.usGroupID = (string) value; break;
					case "scID": this.scID = (string) value; break;
					case "addR": this.addR = (bool) value; break;
					case "deleteR": this.deleteR = (bool) value; break;
					case "editR": this.editR = (bool) value; break;
					case "screenObject": this.screenObject = (Screen) value; break;
					case "whGroupObject": this.whGroupObject = (WhGroup) value; break;
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
