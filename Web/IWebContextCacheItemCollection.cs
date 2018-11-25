#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Web.Caching;

namespace cdmdotnet.StateManagement.Web
{
	/// <summary />
	public interface IWebContextCacheItemCollection : IContextCacheItemCollection
	{
		/// <summary>
		/// Adds the specified item to the System.Web.Caching.Cache object with dependencies, expiration and priority policies, and a delegate you can use to notify your application when the inserted item is removed from the Cache.
		/// </summary>
		/// <param name="name">The cache key used to reference the item.</param>
		/// <param name="data">The item to be added to the cache.</param>
		/// <param name="dependencies">The file or cache key dependencies for the item. When any dependency changes, the <see cref="!:data">object</see> becomes invalid and is removed from the cache. If there are no dependencies, this parameter contains null</param>
		/// <param name="absoluteExpiration">The time at which the added <see cref="!:data">object</see> expires and is removed from the cache. If you are using <see cref="!:slidingExpiration">sliding expiration</see>, the <see cref="!:absoluteExpiration"/> parameter must be System.Web.Caching.Cache.NoAbsoluteExpiration.</param>
		/// <param name="slidingExpiration">The interval between the time the added <see cref="!:data">object</see> was last accessed and the time at which that <see cref="!:data">object</see> expires. If this value is the equivalent of 20 minutes, the object expires and is removed from the cache 20 minutes after it is last accessed. If you are using <see cref="!:absoluteExpiration">absolute expiration</see>, the <see cref="!:slidingExpiration"/> parameter must be System.Web.Caching.Cache.NoSlidingExpiration.</param>
		/// <param name="priority">The relative cost of the <see cref="!:data">object</see>, as expressed by the CacheItemPriority enumeration. The cache uses this value when it evicts objects; objects with a lower cost are removed from the cache before objects with a higher cost.</param>
		/// <param name="onRemoveCallback">A delegate that, if provided, is called when an object is removed from the cache. You can use this to notify applications when their objects are deleted from the cache.</param>
		/// <returns>
		/// An object if the item was previously stored in the Cache; otherwise, null.
		/// </returns>
		object SetData(string name, object data, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
	}
}