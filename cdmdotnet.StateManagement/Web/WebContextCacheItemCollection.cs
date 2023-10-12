﻿#if NETSTANDARD2_0
#else
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Web;
using System.Web.Caching;
using Chinchilla.StateManagement.Threaded;

namespace Chinchilla.StateManagement.Web
{
	/// <summary />
	public class WebContextCacheItemCollection : ContextCacheItemCollection, IWebContextCacheItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the System.Runtime.Remoting.Messaging.CallContext.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public override object GetData(string name)
		{
			if (HttpContext.Current != null)
				return HttpContext.Current.Cache.Get(name);
			return base.GetData(name);
		}

		/// <summary>
		/// Adds the specified item with expiration.
		/// </summary>
		/// <param name="name">The cache key used to reference the item.</param>
		/// <param name="data">The item to be added to the cache.</param>
		/// <param name="dependency">The file or cache key dependencies for the item. When any dependency changes, the <see cref="!:data">object</see> becomes invalid and is removed from the cache. If there are no dependencies, this parameter contains null</param>
		/// <param name="absoluteExpiration">The time at which the added <see cref="!:data">object</see> expires and is removed from the cache. If you are using <see cref="!:slidingExpiration">sliding expiration</see>, the <see cref="!:absoluteExpiration"/> parameter must be System.Web.Caching.Cache.NoAbsoluteExpiration.</param>
		/// <param name="slidingExpiration">The interval between the time the added <see cref="!:data">object</see> was last accessed and the time at which that <see cref="!:data">object</see> expires. If this value is the equivalent of 20 minutes, the object expires and is removed from the cache 20 minutes after it is last accessed. If you are using <see cref="!:absoluteExpiration">absolute expiration</see>, the <see cref="!:slidingExpiration"/> parameter must be System.Web.Caching.Cache.NoSlidingExpiration.</param>
		public override object SetData(string name, object data, string dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
		{
			if (HttpContext.Current != null)
				return SetData(name, data, string.IsNullOrEmpty(dependency) ? null : new CacheDependency(dependency), absoluteExpiration, slidingExpiration, CacheItemPriority.Normal, null);
			return base.SetData(name, data, dependency, absoluteExpiration, slidingExpiration);
		}

		/// <summary>
		/// Adds the specified item to the System.Web.Caching.Cache object with dependencies, expiration and priority policies, and a delegate you can use to notify your application when the inserted item is removed from the Cache.
		/// </summary>
		/// <param name="name">The cache key used to reference the item.</param>
		/// <param name="data">The item to be added to the cache.</param>
		/// <param name="dependencies">The file or cache key dependencies for the item. When any dependency changes, the <see cref="!:data">object</see> becomes invalid and is removed from the cache. If there are no dependencies, this parameter contains null</param>
		/// <param name="absoluteExpiration">The time at which the added <see cref="!:data">object</see> expires and is removed from the cache. If you are using <see cref="!:slidingExpiration">sliding expiration</see>, the <see cref="!:absoluteExpiration"/> parameter must be System.Web.Caching.Cache.NoAbsoluteExpiration.</param><param name="slidingExpiration">The interval between the time the added <see cref="!:data">object</see> was last accessed and the time at which that <see cref="!:data">object</see> expires. If this value is the equivalent of 20 minutes, the object expires and is removed from the cache 20 minutes after it is last accessed. If you are using <see cref="!:absoluteExpiration">absolute expiration</see>, the <see cref="!:slidingExpiration"/> parameter must be System.Web.Caching.Cache.NoSlidingExpiration.</param>
		/// <param name="priority">The relative cost of the <see cref="!:data">object</see>, as expressed by the CacheItemPriority enumeration. The cache uses this value when it evicts objects; objects with a lower cost are removed from the cache before objects with a higher cost.</param>
		/// <param name="onRemoveCallback">A delegate that, if provided, is called when an object is removed from the cache. You can use this to notify applications when their objects are deleted from the cache.</param>
		/// <returns>
		/// An object if the item was previously stored in the Cache; otherwise, null.
		/// </returns>
		public virtual object SetData(string name, object data, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
		{
			return HttpContext.Current.Cache.Add(name, data, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
		}
	}
}
#endif