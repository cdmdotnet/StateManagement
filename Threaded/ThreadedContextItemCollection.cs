using System.Runtime.Remoting.Messaging;

namespace cdmdotnet.StateManagement.Threaded
{
	/// <summary />
	public class ThreadedContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name from the System.Runtime.Remoting.Messaging.CallContext.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			return (TData)CallContext.GetData(name);
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name.
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			CallContext.SetData(name, (object)data);
			return data;
		}
	}
}
