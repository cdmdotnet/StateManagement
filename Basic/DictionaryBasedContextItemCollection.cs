using System.Collections.Generic;

namespace cdmdotnet.StateManagement.Basic
{
	/// <summary />
	public class DictionaryBasedContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The internal dictionary that can be manually manipulated or assessed.
		/// </summary>
		public IDictionary<string, object> InternalStateDictionary { get; set; }

		/// <summary />
		public DictionaryBasedContextItemCollection()
		{
			InternalStateDictionary = new Dictionary<string, object>();
		}

		/// <summary>
		/// Retrieves an object with the specified name
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <returns>
		/// The object associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			return (TData)(InternalStateDictionary.ContainsKey(name) ? InternalStateDictionary[name] : (object)null);
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name.
		/// 
		/// </summary>
		/// <param name="name">The name with which to associate the new item.</param>
		/// <param name="data">The object to store.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			InternalStateDictionary[name] = data;
			return data;
		}
	}
}
