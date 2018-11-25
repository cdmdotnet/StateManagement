#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Runtime.Caching;
using System.Web.Caching;

namespace cdmdotnet.StateManagement.Threaded
{
	/// <summary />
	public class ThreadedContextCacheItemCollection : IContextCacheItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the System.Runtime.Remoting.Messaging.CallContext.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual object GetData(string name)
		{
			return MemoryCache.Default.Get(name);
		}

		/// <summary>
		/// Adds the specified item with expiration.
		/// </summary>
		/// <param name="name">The cache key used to reference the item.</param>
		/// <param name="data">The item to be added to the cache.</param>
		/// <param name="dependency">The file or cache key dependencies for the item. When any dependency changes, the <see cref="!:data">object</see> becomes invalid and is removed from the cache. If there are no dependencies, this parameter contains null</param>
		/// <param name="absoluteExpiration">The time at which the added <see cref="!:data">object</see> expires and is removed from the cache. If you are using <see cref="!:slidingExpiration">sliding expiration</see>, the <see cref="!:absoluteExpiration"/> parameter must be System.Web.Caching.Cache.NoAbsoluteExpiration.</param>
		/// <param name="slidingExpiration">The interval between the time the added <see cref="!:data">object</see> was last accessed and the time at which that <see cref="!:data">object</see> expires. If this value is the equivalent of 20 minutes, the object expires and is removed from the cache 20 minutes after it is last accessed. If you are using <see cref="!:absoluteExpiration">absolute expiration</see>, the <see cref="!:slidingExpiration"/> parameter must be System.Web.Caching.Cache.NoSlidingExpiration.</param>
		public virtual object SetData(string name, object data, string dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
		{
			CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
			{
				AbsoluteExpiration = absoluteExpiration,
				SlidingExpiration = slidingExpiration
			};

			// Placing this above in the constructor didn't work... go figure.
			if (absoluteExpiration == Cache.NoAbsoluteExpiration)
				cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.MaxValue;

			return MemoryCache.Default.Add(name, data, cacheItemPolicy);
		}
	}
}