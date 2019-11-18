#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Collections.Generic;

namespace Chinchilla.StateManagement
{
	/// <summary>
	/// An instance of <see cref="IContextItemCollection"/> with a current request context
	/// </summary>
	public abstract class ContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// An internal key used within threads.
		/// </summary>
		public const string CurrentContextKeysDictionaryName = "µÞ♫Ᵽ∩∆₲₱";

		/// <summary>
		/// Retrieves an object with the specified <paramref name="name"/> from the internal cache.
		/// </summary>
		/// <param name="name">The name of the item in the internal cache.</param>
		/// <returns>
		/// The object in the internal cache associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			IDictionary<string, object> cache = GetCache();

			object value;
			if (cache.TryGetValue(name, out value))
				return (TData)value;
			return default(TData);
		}

		/// <summary>
		/// Stores the given <paramref name="data"/> and associates it with the specified <paramref name="name"/> to the internal cache.
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the internal cache.</param>
		/// <param name="data">The object to store in the internal cache.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			IDictionary<string, object> cache = GetCache();

			if (cache.ContainsKey(name))
				cache[name] = data;
			else
				cache.Add(name, data);

			return data;
		}

		/// <summary>
		/// Access the internal cache
		/// </summary>
		internal abstract IDictionary<string, object> GetCache();

		internal abstract IDictionary<string, object> SetCache(IDictionary<string, object> cache = null);
	}
}