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
	/// An instance of <see cref="IContextItemCollection"/> with a transient user context
	/// </summary>
	public class WebTransientUserContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }

		/// <summary>
		/// Instantiates a new instance of the <see cref="WebTransientUserContextItemCollection"/> class.
		/// </summary>
		public WebTransientUserContextItemCollection(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="IRequestCookieCollection"/>
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			string cookie = HttpContextAccessor.HttpContext.Request.Cookies[name];
			if (cookie == null)
				return (TData)(object)null;
			return (TData)(object)cookie;
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="IResponseCookies"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			HttpContextAccessor.HttpContext.Response.Cookies.Append("name", (string)(object)data);
			return data;
		}
	}
}
#endif