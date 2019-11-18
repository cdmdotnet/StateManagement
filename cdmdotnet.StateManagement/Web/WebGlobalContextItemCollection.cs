#if NET40
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
	/// An Instance of <see cref="IContextItemCollection"/> with a global context
	/// </summary>
	public class WebGlobalContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="T:System.Web.HttpApplicationState"/>
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			return (TData)HttpContext.Current.Application[name];
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="T:System.Web.HttpApplicationState"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			HttpContext.Current.Application[name] = data;
			return data;
		}
	}
}
#endif