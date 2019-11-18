#if NETCOREAPP3_0
#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Http;

namespace Chinchilla.StateManagement.Web
{
	/// <summary>
	/// An instance of <see cref="IContextItemCollection"/> with a user context
	/// </summary>
	public class WebUserContextItemCollection : IContextItemCollection
	{
		/// <summary>
		/// The reference to the internal storage cache.
		/// </summary>
		protected IHttpContextAccessor HttpContextAccessor { get; }

		/// <summary>
		/// Instantiates a new instance of the <see cref="WebUserContextItemCollection"/> class.
		/// </summary>
		public WebUserContextItemCollection(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// Retrieves an object with the specified name from the <see cref="ISession"/>
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>
		/// The object in the call context associated with the specified name.
		/// </returns>
		public virtual TData GetData<TData>(string name)
		{
			if (HttpContextAccessor.HttpContext.Session.TryGetValue(name, out byte[] value))
			{
				using (var stream = new MemoryStream())
				{
					var binForm = new BinaryFormatter();
					stream.Write(value, 0, value.Length);
					stream.Seek(0, SeekOrigin.Begin);
					object result = binForm.Deserialize(stream);
					return (TData)result;
				}
			}
			return default;
		}

		/// <summary>
		/// Stores a given object and associates it with the specified name in the <see cref="ISession"/>
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="data">The object to store in the call context.</param>
		public virtual TData SetData<TData>(string name, TData data)
		{
			BinaryFormatter bf = new BinaryFormatter();
			byte[] value;
			using (var stream = new MemoryStream())
			{
				bf.Serialize(stream, data);
				value = stream.ToArray();
			}

			HttpContextAccessor.HttpContext.Session.Set(name, value);
			return data;
		}
	}
}
#endif