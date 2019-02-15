//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Collections;
using System.Threading;

namespace Wilson.ORMapper.Internals
{
	// Avoid Infinite Relationship Loop for non-Lazy-Loaded Collections
	sealed internal class LocalStore
	{
		// Each External Method Should call Reset and No Internal Method Should
		static public void Reset(Type type) {
			LocalStore.Level = 0;
			LocalStore.Types.Clear();
			LocalStore.Types.Add(type.ToString(), true);
		}

		static public int Level {
			get {
				LocalDataStoreSlot store = Thread.GetNamedDataSlot("WilsonORMapperLevel");
				if (Thread.GetData(store) == null) return 0;
				return (int) Thread.GetData(store);
			}
			set {
				LocalDataStoreSlot store = Thread.GetNamedDataSlot("WilsonORMapperLevel");
				Thread.SetData(store, value);
			}
		}

		// Only Necessary to Check IsLoaded for non-Lazy-Loaded Collections
		static public bool IsLoaded(Type type) {
			string typeName = type.ToString();
			if (LocalStore.Types.Contains(typeName)) {
				return true;
			}
			else {
				LocalStore.Types.Add(typeName, true);
				return false;
			}
		}

		// Use Thread Local Storage for Tracking Loaded Types for Each Thread
		static private Hashtable Types {
			get {
				LocalDataStoreSlot store = Thread.GetNamedDataSlot("WilsonORMapperTypes");
				object data = Thread.GetData(store);
				if (data == null) {
					data = new Hashtable();
					Thread.SetData(store, data);
				}
				return data as Hashtable;
			}
		}

		private LocalStore() {}
	}
}
