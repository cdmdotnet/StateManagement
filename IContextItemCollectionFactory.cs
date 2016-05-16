#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace cdmdotnet.StateManagement
{
	/// <summary>
	/// A factory to obtain instances of <see cref="IContextItemCollection"/> from.
	/// </summary>
	public interface IContextItemCollectionFactory
	{
		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetGlobalContext();

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetUserContext();

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetTransientUserContext();

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetCurrentContext();

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetIncomingContext();

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		IContextItemCollection GetOutgoingContext();
	}
}
