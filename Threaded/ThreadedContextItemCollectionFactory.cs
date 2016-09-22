namespace cdmdotnet.StateManagement.Threaded
{
	/// <summary>
	/// A factory to obtain instances of <see cref="IContextItemCollection"/> from.
	/// </summary>
	public class ThreadedContextItemCollectionFactory : IContextItemCollectionFactory
	{
		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetGlobalContext()
		{
			return new ThreadedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetUserContext()
		{
			return new ThreadedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetTransientUserContext()
		{
			return new ThreadedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetCurrentContext()
		{
			return new ThreadedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetIncomingContext()
		{
			return new ThreadedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetOutgoingContext()
		{
			return new ThreadedContextItemCollection();
		}
	}
}
