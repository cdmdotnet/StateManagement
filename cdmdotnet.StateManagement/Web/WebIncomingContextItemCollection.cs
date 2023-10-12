#if NETSTANDARD2_0
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
	/// An instance of <see cref="IContextItemCollection"/> with an incoming context
	/// </summary>
	public class WebIncomingContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="T:System.Web.HttpRequest"/>.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			string result = HttpContext.Current.Request[name];
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