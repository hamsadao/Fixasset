//This code was generated by a tool as of 2007-04-09 17:48:03.937.

using System;
using System.Collections;
using Wilson.ORMapper;

namespace SimatSoft.DB.ORM
{
	public class AssetImage : IObjectHelper, IObjectNotification
	{
		private string assetID;
		private string modelID;
		private byte[] itemImage;
		private Asset assetObject; // Strongly Type as Asset if not Lazy-Loading
		private Model modelObject; // Strongly Type as Model if not Lazy-Loading

		public string AssetID
		{
			get { return this.assetID; }
		}

		public string ModelID
		{
			get { return this.modelID; }
			set { this.modelID = value; }
		}

		public byte[] ItemImage
		{
			get { return this.itemImage; }
			set { this.itemImage = value; }
		}

		// Return the primary key property from the primary key object
		public Asset AssetObject
		{
			get { return this.assetObject; }
		}

		// Return the primary key property from the primary key object
		public Model ModelObject
		{
			get { return this.modelObject; }
		}


		#region IObjectHelper Members
		public object this[string memberName]
		{
			get {
				switch (memberName) {
					case "assetID": return this.assetID;
					case "modelID": return this.modelID;
					case "itemImage": return this.itemImage;
					case "assetObject": return this.assetObject;
					case "modelObject": return this.modelObject;
					default: throw new Exception("Invalid Member");
				}
			}
			set {
				switch (memberName) {
					case "assetID": this.assetID = (string) value; break;
					case "modelID": this.modelID = (string) value; break;
					case "itemImage": this.itemImage = (byte[]) value; break;
					case "assetObject": this.assetObject = (Asset) value; break;
					case "modelObject": this.modelObject = (Model) value; break;
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
