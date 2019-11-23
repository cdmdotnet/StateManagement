#if NETSTANDARD2_0
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Chinchilla.StateManagement.Web
{
	/// <summary>
	/// An instance of <see cref="IContextItemCollection"/> with a current request context
	/// </summary>
	public class WebContextItemCollection : Threaded.ContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }


		/// <summary>
		/// Instantiates a new instance of the <see cref="WebContextItemCollection"/> class.
		/// </summary>
		public WebContextItemCollection(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		// ReSharper disable RedundantOverridenMember
		/// <summary>
		/// Retrieves an object with the specified name 
		/// first using <see cref="HttpContext.Items"/> if <see cref="IHttpContextAccessor.HttpContext"/> is not null
		/// if <see cref="IHttpContextAccessor.HttpContext"/> is null OR there is a <see cref="NullReferenceException"/> then
		/// trying from, within this <see cref="Thread"/>.
		/// </summary>
		/// <param name="name">The name of the item in the internal cache.</param>
		/// <returns>
		/// The object in the internal cache associated with the specified name.
		/// </returns>
		/// <remarks>
		/// The usage of checking also checking outside of <see cref="HttpContext.Items"/>, is that when you use a <see cref="Task"/>, it has no access to <see cref="IHttpContextAccessor.HttpContext"/>.
		/// </remarks>
		public override TData GetData<TData>(string name)
		{
			return base.GetData<TData>(name);
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name within this <see cref="Thread"/> that can be read via <see cref="GetData{TData}"/>.
		/// If <see cref="IHttpContextAccessor.HttpContext"/> is not null then also tries and sets it using <see cref="HttpContext.Items"/>.
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
				if (HttpContextAccessor.HttpContext != null)
					cache = (IDictionary<string, object>)HttpContextAccessor.HttpContext.Items[CurrentContextKeysDictionaryName];
			}
			catch (NullReferenceException)
			{
				if (HttpContextAccessor.HttpContext != null)
					SetCache();
			}
			if (cache == null)
				cache = base.GetCache();
			return cache;
		}

		internal override IDictionary<string, object> SetCache(IDictionary<string, object> cache = null)
		{
			cache = (cache ?? new ConcurrentDictionary<string, object>());
			if (HttpContextAccessor.HttpContext != null)
				HttpContextAccessor.HttpContext.Items[CurrentContextKeysDictionaryName] = cache;
			base.SetData(CurrentContextKeysDictionaryName, cache);

			return cache;
		}
	}
}
#endif