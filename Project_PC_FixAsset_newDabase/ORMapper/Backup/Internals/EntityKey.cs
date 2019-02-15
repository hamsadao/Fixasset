//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
// Includes Support for Composite Primary Keys from Jerry Shea (http://www.RenewTek.com)
// Includes Support for Member Properties from Chris Schletter (http://www.thzero.com)
using System;
using System.Collections;
using System.Reflection;

namespace Wilson.ORMapper.Internals
{
	internal class EntityKey
	{
		private string type;
		private object value;

		private static Hashtable keys = new Hashtable();

		public string Type {
			get { return this.type; }
		}

		public object Value {
			get { return this.value; }
		}

		internal EntityKey(Type objectType, object objectKey) {
			this.type = objectType.ToString();
			this.value = objectKey;
		}

		internal EntityKey(Context context, object entityObject, bool isPersisted) {
			string type = entityObject.GetType().ToString();
			this.type = type;
			this.value = EntityKey.GetObjectKey(context.Mappings[type], entityObject, isPersisted);
		}

		private static object GetMember(EntityMap entityMap, object entityObject, string keyMember) {
			if (entityMap.HasHelper) {
				return ((IObjectHelper) entityObject)[keyMember];
			}
			else {
				// RTS/GOP: code below is replaced:
//				if (entityMap.Member(keyMember) is FieldInfo) {
//					return (entityMap.Member(keyMember) as FieldInfo).GetValue(entityObject);
//				}
//				else {
//					return (entityMap.Member(keyMember) as PropertyInfo).GetValue(entityObject, null);
//				}

				// RTS/GOP: code below is copied and modified from Instance.GetField () method
				// It allows to use embedded objects for key members.
				try {
					// Improved Support for Embedded Objects from Chris Schletter (http://www.thzero.com)
					object memberValue = entityObject;
					string[] memberParts = keyMember.Split('.');
					for (int index = 0; index < memberParts.Length; index++) {
						string typeName = memberValue.GetType().ToString();
						MemberInfo memberField = EntityMap.FindField(typeName, memberParts[index]);
						if (memberField is FieldInfo) {
							memberValue = (memberField as FieldInfo).GetValue(memberValue);
						}
						else {
							memberValue = (memberField as PropertyInfo).GetValue(memberValue, null);
						}
					}
					return memberValue;
				}
				catch (Exception exception) {
					throw new ORMapperException("GetField failed for " + keyMember, exception);
				}
				// RTS/GOP: end of insertion

			}
		}

		private static object GetObjectKey(EntityMap entityMap, object entityObject, bool isPersisted) {
			object keyValue = null;
			FieldMap[] keyFields = entityMap.KeyFields;
			if (keyFields.Length > 1) {
				object[] keyArray = new object[keyFields.Length];
				for (int index = 0; index < keyFields.Length; index++)
					keyArray[index] = GetMember(entityMap, entityObject, keyFields[index].Member);
				return keyArray;
			}
			else if (entityMap.KeyType == KeyType.None) {
				// Paul Welter (http://www.LoreSoft.com) -- allow inserts by using all columns as key
				object[] keyArray = new object[entityMap.FieldCount];
				for (int index = 0; index < entityMap.FieldCount; index++) {
					object member = GetMember(entityMap, entityObject, entityMap[index].Member);
					keyArray[index] = member != null ? member : string.Empty;
				}
				return keyArray;

			}
			else {
				string keyMember = entityMap.KeyFields[0].Member;
				keyValue = GetMember(entityMap, entityObject, keyMember);
				if (EntityKey.IsNull(keyValue, isPersisted)) {
					switch (entityMap.KeyType) {
						case KeyType.Auto: keyValue = EntityKey.GetAutoKey(keyValue, entityMap.Type); break;
						case KeyType.Guid: keyValue = EntityKey.GetGuidKey(keyValue is Guid); break;
						default: throw new ORMapperException("ObjectSpace: Entity Object is missing Key - " + entityMap.Type);
					}
					if (entityMap.HasHelper) {
						((IObjectHelper) entityObject)[keyMember] = keyValue;
					}
					else {
						if (entityMap.Member(keyMember) is FieldInfo) {
							(entityMap.Member(keyMember) as FieldInfo).SetValue(entityObject, keyValue);
						}
						else {
							(entityMap.Member(keyMember) as PropertyInfo).SetValue(entityObject, keyValue, null);
						}
					}
				}
			}
			return keyValue;
		}

		// Includes Additional Null Tests by Gerrod Thomas (http://www.Gerrod.com)
		private static bool IsNull(object keyValue, bool isPersisted) {
			// Bug-Fix to properly handle Primary Keys that are Zero-Valued
			if (isPersisted) {
				return (keyValue == null);
			}
			else {
				return (keyValue == null
					|| (keyValue is long && (long) keyValue == 0L)
					|| (keyValue is int && (int) keyValue == 0)
					|| (keyValue is short && (short) keyValue == 0)
					|| (keyValue is Guid && (Guid) keyValue == Guid.Empty)
					|| (keyValue is string && ((string) keyValue).Length == 0)
					|| (keyValue is DateTime && (DateTime) keyValue == DateTime.MinValue));
			}
		}

		// Includes Additional Auto Types by Gerrod Thomas (http://www.Gerrod.com)
		private static object GetAutoKey(object keyValue, string typeName) {
			object nextKey;
			lock (typeof(EntityKey)) {
				if (keyValue is Guid) {
					nextKey = Guid.NewGuid();
				}
				else {
					object lastKey = EntityKey.keys[typeName];
					if (lastKey == null) lastKey = 0;
					nextKey = Convert.ToInt32(lastKey) - 1;
					if (!(keyValue is Int32)) {
						nextKey = QueryHelper.ChangeType(nextKey, keyValue.GetType());
					}
				}
				EntityKey.keys[typeName] = nextKey;
			}
			return nextKey;
		}

		private static object GetGuidKey(bool isGuid) {
			Guid newGuid = Guid.NewGuid();
			if (isGuid) return newGuid;
			return newGuid.ToString();
		}
	
		public override string ToString() {
			if (this.value is object[]) {
				string values = string.Empty;
				for (int index = 0; index < (this.value as object[]).Length; index++) {
					values += (this.value as object[])[index].ToString() + ",";
				}
				return this.type + ":" + values.Remove(values.Length - 1, 1);
			}
			else {
				return this.type + ":" + this.value.ToString();
			}
		}
	}
}
