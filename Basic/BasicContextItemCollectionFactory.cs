namespace cdmdotnet.StateManagement.Basic
{
	/// <summary />
	public class BasicContextItemCollectionFactory : IContextItemCollectionFactory
	{
		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetGlobalContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetUserContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetTransientUserContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetCurrentContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetIncomingContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetOutgoingContext()
		{
			return new DictionaryBasedContextItemCollection();
		}
	}
}