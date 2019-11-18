#if NETCOREAPP3_0
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using Microsoft.AspNetCore.Http;

namespace Chinchilla.StateManagement.Web
{
	/// <summary>
	/// A factory to obtain instances of <see cref="IContextItemCollection"/> from.
	/// </summary>
	public class WebContextItemCollectionFactory : IContextItemCollectionFactory
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }

		/// <summary>
		/// Instantiates a new instance of the <see cref="WebContextItemCollectionFactory"/> class.
		/// </summary>
		public WebContextItemCollectionFactory(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetGlobalContext()
		{
			return (IContextItemCollection)new WebGlobalContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetUserContext()
		{
			return (IContextItemCollection)new WebUserContextItemCollection(HttpContextAccessor);
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetTransientUserContext()
		{
			return (IContextItemCollection)new WebTransientUserContextItemCollection(HttpContextAccessor);
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetCurrentContext()
		{
			return (IContextItemCollection)new WebContextItemCollection(HttpContextAccessor);
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetIncomingContext()
		{
			return (IContextItemCollection)new WebIncomingContextItemCollection(HttpContextAccessor);
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetOutgoingContext()
		{
			return (IContextItemCollection)new WebOutgoingContextItemCollection(HttpContextAccessor);
		}
	}
}
#endif