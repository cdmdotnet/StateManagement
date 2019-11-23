#if NETSTANDARD2_0
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
	/// An instance of <see cref="IContextItemCollection"/> with an outgoing context
	/// </summary>
	public class WebOutgoingContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }

		/// <summary>
		/// Instantiates a new instance of the <see cref="WebOutgoingContextItemCollection"/> class.
		/// </summary>
		public WebOutgoingContextItemCollection(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// Does nothing as this is an outgoing context.
		/// </summary>
		public virtual TData GetData<TData>(string name)
		{
			return default;
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="HttpResponse"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			HttpContextAccessor.HttpContext.Response.Headers[name] = (string)(object)data;
			return data;
		}
	}
}
#endif