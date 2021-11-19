#if NETSTANDARD2_0
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

// ReSharper disable once CheckNamespace
// ReSharper disable EmptyGeneralCatchClause
namespace System.Threading.Tasks
{
	/// <summary>
	/// A set of extension methods to allow a much safer usage of tasks.
	/// </summary>
	public static class TaskExtensions
	{
		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action action)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch{ }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action();
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action();
			}, cancellationToken);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action action, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action();
			}, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action();
			}, cancellationToken, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action<object> action, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action(rawState);
			}, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action<object> action, object state, CancellationToken cancellationToken)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action(rawState);
			}, state, cancellationToken);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action<object> action, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action(rawState);
			}, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				action(rawState);
			}, state, cancellationToken, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Func<Task> asyncAction)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(async () =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				await asyncAction();
			}).Result;
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Func<Task> asyncAction, CancellationToken cancellationToken)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(async () =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				await asyncAction();
			}, cancellationToken);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Func<Task> asyncAction, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(async () =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				await asyncAction();
			}, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task StartNewSafely(this TaskFactory taskFactory, Func<Task> asyncAction, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(async () =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				await asyncAction();
			}, cancellationToken, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<TResult> function)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function();
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<TResult> function, CancellationToken cancellationToken)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function();
			}, cancellationToken);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<TResult> function, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function();
			}, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(() =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function();
			}, cancellationToken, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<object, TResult> function, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function(rawState);
			}, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<object, TResult> function, object state, CancellationToken cancellationToken)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function(rawState);
			}, state, cancellationToken);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<object, TResult> function, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function(rawState);
			}, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> StartNewSafely<TResult>(this TaskFactory taskFactory, Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.StartNew(rawState =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return function(rawState);
			}, state, cancellationToken, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task FromAsyncSafely(this TaskFactory taskFactory, IAsyncResult asyncResult, Action<IAsyncResult> endMethod)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task FromAsyncSafely(this TaskFactory taskFactory, IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task FromAsyncSafely(this TaskFactory taskFactory, IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely(this TaskFactory taskFactory, Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely(this TaskFactory taskFactory, Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1, TArg2>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, arg2, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1, TArg2>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, arg2, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1, TArg2, TArg3>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, args3, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, arg3, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, arg2, arg3, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task FromAsyncSafely<TArg1, TArg2, TArg3>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, args3, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, arg3, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				endMethod(rawResult);
			}, arg1, arg2, arg3, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> FromAsyncSafely<TResult>(this TaskFactory taskFactory, IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			});
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> FromAsyncSafely<TResult>(this TaskFactory taskFactory, IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Task<TResult> FromAsyncSafely<TResult>(this TaskFactory taskFactory, IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync(asyncResult, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, creationOptions, scheduler);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TResult>(this TaskFactory taskFactory, Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TResult>(this TaskFactory taskFactory, Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TResult>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TResult>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TArg2, TResult>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, arg2, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TArg2, TResult>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, arg2, state, creationOptions);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TArg2, TArg3, TResult>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, args3, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, args3, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, arg2, arg3, state);
		}

		/// <summary>
		/// This method will ensure all thread based storage values are copied into the <see cref="Thread"/> used by this <see cref="Task"/>.
		/// This will ensure logging and eventing will work far more smoothly.
		/// </summary>
		/// <remarks>Value changes will be passed back out.</remarks>
		public static Task<TResult> FromAsyncSafely<TArg1, TArg2, TArg3, TResult>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions)
		{
			IDictionary<string, object> cache = null;
			try
			{
				cache = new ContextItemCollection().GetCache();
			}
			catch { }
			return taskFactory.FromAsync((args1, args2, args3, callBack, rawState) =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return beginMethod(args1, args2, args3, callBack, rawState);
			}, rawResult =>
			{
				if (cache != null)
				{
					try
					{
						new ContextItemCollection().SetCache(cache);
					}
					catch { }
				}
				return endMethod(rawResult);
			}, arg1, arg2, arg3, state, creationOptions);
		}
	}
}
// ReSharper restore EmptyGeneralCatchClause
#endif