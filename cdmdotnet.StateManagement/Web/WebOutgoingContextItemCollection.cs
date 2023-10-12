﻿#if NETSTANDARD2_0
#else
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Web;

namespace Chinchilla.StateManagement.Web
{
	/// <summary>
	/// An instance of <see cref="T:Chinchilla.StateManagement.IContextItemCollection"/> with an outgoing context
	/// </summary>
	public class WebOutgoingContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// Does nothing as this is an outgoing context.
		/// </summary>
		public virtual TData GetData<TData>(string name)
		{
			return default(TData);
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="T:System.Web.HttpResponse"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			HttpContext.Current.Response.Headers[name] = (string)(object)data;
			return data;
		}
	}
}
#endif