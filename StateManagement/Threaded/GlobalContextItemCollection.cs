#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Chinchilla.StateManagement.Threaded
{
	/// <summary>
	/// An Instance of <see cref="IContextItemCollection"/> with a global context
	/// </summary>
	public class GlobalContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected static IDictionary<string, object> Storage { get; private set; }

		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="HttpContext.app"/>
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			object value;
			if (Storage.TryGetValue(name, out value))
				return (TData)value;
			return default;
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="T:System.Web.HttpApplicationState"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			if (Storage.ContainsKey(name))
				Storage[name] = data;
			else
				Storage.Add(name, data);

			return data;
		}
	}
}
