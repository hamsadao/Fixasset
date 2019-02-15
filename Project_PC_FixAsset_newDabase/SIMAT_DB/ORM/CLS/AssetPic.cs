//This code was generated by a tool as of 2007-06-21 11:05:40.093.

using System;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class AssetPic : IObjectHelper, IObjectNotification
	{
		private string assetID;
		private string modelID;
		private byte[] picture;
		private string pathPicture;

		public string AssetID
		{
			get { return this.assetID; }
            set { this.assetID = value; }
		}

		public string ModelID
		{
			get { return this.modelID; }
			set { this.modelID = value; }
		}

		public byte[] Picture
		{
			get { return this.picture; }
			set { this.picture = value; }
		}

		public string PathPicture
		{
			get { return this.pathPicture; }
			set { this.pathPicture = value; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "assetID": return this.assetID;
					case "modelID": return this.modelID;
					case "picture": return this.picture;
					case "pathPicture": return this.pathPicture;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "assetID": this.assetID = (string) value; break;
					case "modelID": this.modelID = (string) value; break;
					case "picture": this.picture = (byte[]) value; break;
					case "pathPicture": this.pathPicture = (string) value; break;
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
