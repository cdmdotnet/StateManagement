#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Chinchilla.StateManagement.Threaded;

namespace System.Threading.Tasks
{
	/// <summary>
	/// A set of extension methods to allow a much safer usage of parallel execution.
	/// </summary>
	public static class ParallelSafely
	{
		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.ForEach(source, s =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult ForEach<TSource, TLocal>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.ForEach(source, parallelOptions, s => 
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.For(fromInclusive, toExclusive, s =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, Action<long> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.For(fromInclusive, toExclusive, s =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.For(fromInclusive, toExclusive, parallelOptions, s =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="ParallelLoopResult"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ParallelLoopResult For(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, Action<long> body)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return Parallel.For(fromInclusive, toExclusive, parallelOptions, s =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				body(s);
			});
		}
	}
}