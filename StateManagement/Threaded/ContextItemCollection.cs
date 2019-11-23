#if NETSTANDARD2_0
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Chinchilla.StateManagement.Threaded
{
	/// <summary />
	public class ContextItemCollection : StateManagement.ContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected static ThreadLocal<IDictionary<string, object>> Cache { get; private set; }

		// ReSharper disable RedundantOverridenMember
		/// <summary>
		/// Retrieves an object with the specified <paramref name="name"/> from an internal collection in <see cref="ThreadLocal{T}"/>.
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
		/// Stores the given <paramref name="data"/> with the specified <paramref name="name"/> to an internal collection in <see cref="ThreadLocal{T}"/>.
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
				var _cache = Cache;
				if (_cache != null)
					cache = _cache.Value;
			}
			catch { }
			return cache ?? SetCache();
		}

		internal override IDictionary<string, object> SetCache(IDictionary<string, object> cache = null)
		{
			cache = (cache ?? new ConcurrentDictionary<string, object>());
			(Cache ?? (Cache = new ThreadLocal<IDictionary<string, object>>())).Value = cache;

			return cache;
		}
	}
}
#endif