using System.Web;

namespace cdmdotnet.StateManagement.Web
{
	/// <summary>
	/// An instance of <see cref="IContextItemCollection"/> with a current request context
	/// </summary>
	public class WebContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="HttpContext.Items"/>.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public TData GetData<TData>(string name)
		{
			return (TData)HttpContext.Current.Items[name];
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name.
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the <see cref="HttpContext.Items"/> collection.</param>
		/// <param name="data">The object to store in the <see cref="HttpContext.Items"/> collection.</param>
		public TData SetData<TData>(string name, TData data)
		{
			HttpContext.Current.Items[name] = data;
			return data;
		}
	}
}
