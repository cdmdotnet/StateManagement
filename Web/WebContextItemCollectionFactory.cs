namespace cdmdotnet.StateManagement.Web
{
	/// <summary>
	/// A factory to obtain instances of <see cref="IContextItemCollection"/> from.
	/// </summary>
	public class WebContextItemCollectionFactory : IContextItemCollectionFactory
	{
		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetGlobalContext()
		{
			return (IContextItemCollection)new WebGlobalContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetUserContext()
		{
			return (IContextItemCollection)new WebUserContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public IContextItemCollection GetTransientUserContext()
		{
			return (IContextItemCollection)new WebTransientUserContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetCurrentContext()
		{
			return (IContextItemCollection)new WebContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetIncomingContext()
		{
			return (IContextItemCollection)new WebIncomingContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetOutgoingContext()
		{
			return (IContextItemCollection)new WebOutgoingContextItemCollection();
		}
	}
}
