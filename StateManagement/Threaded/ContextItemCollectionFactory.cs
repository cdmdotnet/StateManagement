#if NETSTANDARD2_0
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;

namespace Chinchilla.StateManagement.Threaded
{
	/// <summary>
	/// A factory to obtain instances of <see cref="IContextItemCollection"/> from.
	/// </summary>
	public class ContextItemCollectionFactory : IContextItemCollectionFactory
	{
		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a global context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetGlobalContext()
		{
			return new GlobalContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetUserContext()
		{
			throw new NotSupportedException("The user context is not support without over-riding.");
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetTransientUserContext()
		{
			throw new NotSupportedException("The transient user context is not support without over-riding.");
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetCurrentContext()
		{
			return new ContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetIncomingContext()
		{
			throw new NotSupportedException("The incoming context is not support without over-riding.");
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetOutgoingContext()
		{
			throw new NotSupportedException("The outgoing context is not support without over-riding.");
		}
	}
}
#endif