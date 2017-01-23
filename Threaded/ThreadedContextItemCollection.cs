#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace cdmdotnet.StateManagement.Threaded
{
	/// <summary />
	public class ThreadedContextItemCollection : ContextItemCollection
	{
		// ReSharper disable RedundantOverridenMember
		/// <summary>
		/// Retrieves an object with the specified <paramref name="name"/> from an internal collection in <see cref="System.Runtime.Remoting.Messaging.CallContext"/>.
		/// </summary>
		/// <param name="name">The name of the item in the internal cache.</param>
		/// <returns>
		/// The object in the internal cache associated with the specified name.
		/// </returns>
		public override TData GetData<TData>(string name)
		{
			return base.GetData<TData>(name);
		}

		/// <summary>
		/// Stores the given <paramref name="data"/> with the specified <paramref name="name"/> to an internal collection in <see cref="System.Runtime.Remoting.Messaging.CallContext"/>.
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the internal cache.</param>
		/// <param name="data">The object to store in the internal cache.</param>
		public override TData SetData<TData>(string name, TData data)
		{
			return base.SetData(name, data);
		}
		// ReSharper restore RedundantOverridenMember

		/// <summary>
		/// Access the internal cache
		/// </summary>
		internal override IDictionary<string, object> GetCache()
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = (IDictionary<string, object>)CallContext.GetData(CurrentContextKeysDictionaryName);
			}
			catch (NullReferenceException)
			{
				SetCache();
			}
			return cache;
		}

		internal override IDictionary<string, object> SetCache(IDictionary<string, object> cache = null)
		{
			cache = (cache ?? new ConcurrentDictionary<string, object>());
			CallContext.SetData(CurrentContextKeysDictionaryName, cache);

			return cache;
		}
	}
}
