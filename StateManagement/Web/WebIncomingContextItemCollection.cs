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
	/// An instance of <see cref="IContextItemCollection"/> with an incoming context
	/// </summary>
	public class WebIncomingContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }

		/// <summary>
		/// Instantiates a new instance of the <see cref="WebIncomingContextItemCollection"/> class.
		/// </summary>
		public WebIncomingContextItemCollection(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="HttpRequest"/>.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			string result = HttpContextAccessor.HttpContext.Request.Query[name];
			if (string.IsNullOrWhiteSpace(result))
				result = HttpContextAccessor.HttpContext.Request.Form[name];
			if (string.IsNullOrWhiteSpace(result))
				result = HttpContextAccessor.HttpContext.Request.Cookies[name];
			return (TData)(object)result;
		}

		/// <summary>
		/// Does nothing as this is an incoming context.
		/// </summary>
		public virtual TData SetData<TData>(string name, TData data)
		{
			return data;
		}
	}
}
#endif