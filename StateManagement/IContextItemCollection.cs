#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace Chinchilla.StateManagement
{
	/// <summary>
	/// A collection of items with a specific context.
	/// </summary>
	public interface IContextItemCollection
	{
		/// <summary>
		/// Retrieves an object with the specified name
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <returns>
		/// The object associated with the specified name.
		/// </returns>
		TData GetData<TData>(string name);

		/// <summary>
		/// Stores a given object and associates it with the specified name.
		/// </summary>
		/// <param name="name">The name with which to associate the new item.</param>
		/// <param name="data">The object to store.</param>
		TData SetData<TData>(string name, TData data);
	}
}
