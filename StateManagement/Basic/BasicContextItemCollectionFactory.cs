﻿#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace Chinchilla.StateManagement.Basic
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
		public virtual IContextItemCollection GetGlobalContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetUserContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a user context that is transient with each request
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetTransientUserContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with a current request/thread context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetCurrentContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an incoming context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetIncomingContext()
		{
			return new DictionaryBasedContextItemCollection();
		}

		/// <summary>
		/// Gets an instance of <see cref="IContextItemCollection"/> with an outgoing context
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IContextItemCollection"/>
		/// </returns>
		public virtual IContextItemCollection GetOutgoingContext()
		{
			return new DictionaryBasedContextItemCollection();
		}
	}
}