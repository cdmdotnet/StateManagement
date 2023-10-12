using System;
using System.Threading;
using System.Threading.Tasks;

#if NET6_0
using System.Net.Http;
#endif

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinchilla.StateManagement.Tests
{
	[TestClass]
	public class TaskExtensionsTests
	{
#if NET6_0
		// StartNewSafely and thus StartNewSafelyAsync is known to
		// resume once the first (synchronous) part of an asynchronous method completes, instead of a the entire method.
		// [TestMethod]
		public void StartNewSafely_MultipleAsyncActions_TaskWaitsForAllToComplete()
		{
			// Arrange
			bool t1IsDone = false;
			bool t2IsDone = false;
			bool t3IsDone = false;
			bool t4IsDone = false;
			bool t5IsDone = false;

			Func<int, Task> httpGetter = async sleepInMilliseconds =>
			{
				await Task.CompletedTask;
				using (HttpClient httpClient = new HttpClient{BaseAddress = new Uri("https://www.google.co.nz/")})
				{
					await httpClient.GetAsync("/").ContinueWith(async resultTask => {
						await Task.CompletedTask;
						Thread.Sleep(sleepInMilliseconds);
						await Task.CompletedTask;
					}).ConfigureAwait(continueOnCapturedContext: false);
				}
			};

			Func<int, bool, Task> sleeper = null;
			sleeper = async (sleepInMilliseconds, callAgain) => {
				await Task.CompletedTask;
				Thread.Sleep(sleepInMilliseconds);
				if (callAgain)
					await httpGetter(sleepInMilliseconds).ConfigureAwait(continueOnCapturedContext: false);
				if (callAgain)
					await Task.CompletedTask;
				else
					await Task.CompletedTask;
			};
			Func<Task> t1 = async () => {
				await sleeper(500, true);
				t1IsDone = true;
			};
			Func<Task> t2 = async () => {
				await sleeper(1500, true);
				t2IsDone = true;
			};
			Func<Task> t3 = async () => {
				await sleeper(2500, true);
				t3IsDone = true;
			};
			Func<Task> t4 = async () => {
				await sleeper(350, true);
				t4IsDone = true;
			};
			Func<Task> t5 = async () => {
				await sleeper(650, true);
				t5IsDone = true;
			};

			// Act
			Task.Factory.StartNewSafelyAsync(async () => {
				await t1();
				await t2();
				await t3();
				await t4();
				await t5();
			}).Wait();

			// Asserts
			Assert.IsTrue(t1IsDone);
			Assert.IsTrue(t2IsDone);
			Assert.IsTrue(t3IsDone);
			Assert.IsTrue(t4IsDone);
			Assert.IsTrue(t5IsDone);
		}
#endif

		[TestMethod]
		public async Task StartNewSafely_AnAction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			await Task.Factory.StartNewSafely(() => {
				var c2 = new Threaded.ContextItemCollection();
				Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);
			});

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task StartNewSafely_AnAsyncFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			await Task.Factory.StartNewSafelyAsync(async () => {
				var c2 = new Threaded.ContextItemCollection();
				var c2Value = c2.GetData<Guid>("T1");
				Assert.AreEqual(t1, c2Value, "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);

				await Task.CompletedTask;
			});

			// Asserts
			var _t2 = c1.GetData<Guid>("T2");
			Assert.AreEqual(t2, _t2);
		}

		[TestMethod]
		public async Task StartNewSafely_AnOddSyncFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// adding a loop to a lambda expression turns it from an Action to a Func<Task>... odd
			Action act = () =>
			{
				long loop = 0;
				while (true)
				{
					var c2 = new Threaded.ContextItemCollection();
					Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
					Thread.Sleep(1000);
					c2.SetData("T2", t2);

					if (loop++ % 5 == 0)
						Thread.Yield();
					else
						Thread.Sleep(1000);
					if (loop == long.MaxValue)
						loop = long.MinValue;
					break;
				}
			};

			// Act
			var task1 = Task.Factory.StartNewSafely(act);

			await task1;

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task StartNewSafely_AnAsyncLoopFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// adding a loop to a lambda expression turns it from an Action to a Func<Task>... odd
			Func<Task> act = async () =>
			{
				long loop = 0;
				while (true)
				{
					var c2 = new Threaded.ContextItemCollection();
					Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
					Thread.Sleep(1000);
					c2.SetData("T2", t2);

					if (loop++ % 5 == 0)
						Thread.Yield();
					else
						Thread.Sleep(1000);
					if (loop == long.MaxValue)
						loop = long.MinValue;
					break;
				}
				await Task.CompletedTask;
			};

			// Act
			await Task.Factory.StartNewSafelyAsync(act);

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task StartNewSafely_AnAsyncFunctionWithResult_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			var rnd = new Random();
			var t3 = rnd.Next(10, 100);
			int t4 = int.MinValue;
			c1.SetData("T1", t1);

			// Act
			int t5 = await Task.Factory.StartNewSafelyAsync(async () => {
				var c2 = new Threaded.ContextItemCollection();
				var c2Value = c2.GetData<Guid>("T1");
				Assert.AreEqual(t1, c2Value, "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);

				t4 = rnd.Next(10, 100);

				return await Task.FromResult(t3 + t4);
			});

			// Asserts
			var _t2 = c1.GetData<Guid>("T2");
			Assert.AreEqual(t2, _t2);

			Assert.AreEqual(t5, t3 + t4);
		}

#if NET6_0
		[TestMethod]
		public void RunSafelyAsync_MultipleAsyncActions_TaskWaitsForAllToComplete()
		{
			// Arrange
			bool t1IsDone = false;
			bool t2IsDone = false;
			bool t3IsDone = false;
			bool t4IsDone = false;
			bool t5IsDone = false;

			Func<int, Task> httpGetter = async sleepInMilliseconds =>
			{
				await Task.CompletedTask;
				using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://www.google.co.nz/") })
				{
					await httpClient.GetAsync("/").ContinueWith(async resultTask => {
						await Task.CompletedTask;
						Thread.Sleep(sleepInMilliseconds);
						await Task.CompletedTask;
					}).ConfigureAwait(continueOnCapturedContext: false);
				}
			};

			Func<int, bool, Task> sleeper = null;
			sleeper = async (sleepInMilliseconds, callAgain) => {
				await Task.CompletedTask;
				Thread.Sleep(sleepInMilliseconds);
				if (callAgain)
					await httpGetter(sleepInMilliseconds).ConfigureAwait(continueOnCapturedContext: false);
				if (callAgain)
					await Task.CompletedTask;
				else
					await Task.CompletedTask;
			};
			Func<Task> t1 = async () => {
				await sleeper(150, true);
				t1IsDone = true;
			};
			Func<Task> t2 = async () => {
				await sleeper(150, true);
				t2IsDone = true;
			};
			Func<Task> t3 = async () => {
				await sleeper(150, true);
				t3IsDone = true;
			};
			Func<Task> t4 = async () => {
				await sleeper(150, true);
				t4IsDone = true;
			};
			Func<Task> t5 = async () => {
				await sleeper(150, true);
				t5IsDone = true;
			};

			// Act
			SafeTask.RunSafelyAsync(async () => {
				await t1();
				await t2();
				await t3();
				await t4();
				await t5();
			}).Wait();

			// Asserts
			Assert.IsTrue(t1IsDone);
			Assert.IsTrue(t2IsDone);
			Assert.IsTrue(t3IsDone);
			Assert.IsTrue(t4IsDone);
			Assert.IsTrue(t5IsDone);
		}

		// this method is also unsafe to use this way.
		// [TestMethod]
		public void RunSafely_MultipleAsyncActions_TaskWaitsForAllToComplete()
		{
			// Arrange
			bool t1IsDone = false;
			bool t2IsDone = false;
			bool t3IsDone = false;
			bool t4IsDone = false;
			bool t5IsDone = false;

			Func<int, Task> httpGetter = async sleepInMilliseconds =>
			{
				await Task.CompletedTask;
				using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://www.google.co.nz/") })
				{
					await httpClient.GetAsync("/").ContinueWith(async resultTask => {
						await Task.CompletedTask;
						Thread.Sleep(sleepInMilliseconds);
						await Task.CompletedTask;
					}).ConfigureAwait(continueOnCapturedContext: false);
				}
			};

			Func<int, bool, Task> sleeper = null;
			sleeper = async (sleepInMilliseconds, callAgain) => {
				await Task.CompletedTask;
				Thread.Sleep(sleepInMilliseconds);
				if (callAgain)
					await httpGetter(sleepInMilliseconds).ConfigureAwait(continueOnCapturedContext: false);
				if (callAgain)
					await Task.CompletedTask;
				else
					await Task.CompletedTask;
			};
			Func<Task> t1 = async () => {
				await sleeper(500, true);
				t1IsDone = true;
			};
			Func<Task> t2 = async () => {
				await sleeper(1500, true);
				t2IsDone = true;
			};
			Func<Task> t3 = async () => {
				await sleeper(2500, true);
				t3IsDone = true;
			};
			Func<Task> t4 = async () => {
				await sleeper(350, true);
				t4IsDone = true;
			};
			Func<Task> t5 = async () => {
				await sleeper(650, true);
				t5IsDone = true;
			};

			// Act
			SafeTask.RunSafely(async () => {
				await t1();
				await t2();
				await t3();
				await t4();
				await t5();
			}).Wait();

			// Asserts
			Assert.IsTrue(t1IsDone);
			Assert.IsTrue(t2IsDone);
			Assert.IsTrue(t3IsDone);
			Assert.IsTrue(t4IsDone);
			Assert.IsTrue(t5IsDone);
		}
#endif

		[TestMethod]
		public async Task RunSafely_AnAction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			await SafeTask.RunSafely(() => {
				var c2 = new Threaded.ContextItemCollection();
				Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);
			});

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task RunSafely_AnAsyncFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			await SafeTask.RunSafelyAsync(async () => {
				var c2 = new Threaded.ContextItemCollection();
				var c2Value = c2.GetData<Guid>("T1");
				Assert.AreEqual(t1, c2Value, "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);

				await Task.CompletedTask;
			});

			// Asserts
			var _t2 = c1.GetData<Guid>("T2");
			Assert.AreEqual(t2, _t2);
		}

		[TestMethod]
		public async Task RunSafely_AnOddSyncFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// adding a loop to a lambda expression turns it from an Action to a Func<Task>... odd
			Action act = () =>
			{
				long loop = 0;
				while (true)
				{
					var c2 = new Threaded.ContextItemCollection();
					Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
					Thread.Sleep(1000);
					c2.SetData("T2", t2);

					if (loop++ % 5 == 0)
						Thread.Yield();
					else
						Thread.Sleep(1000);
					if (loop == long.MaxValue)
						loop = long.MinValue;
					break;
				}
			};

			// Act
			var task1 = SafeTask.RunSafely(act);

			await task1;

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task RunSafely_AnAsyncLoopFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// adding a loop to a lambda expression turns it from an Action to a Func<Task>... odd
			Func<Task> act = async () =>
			{
				long loop = 0;
				while (true)
				{
					var c2 = new Threaded.ContextItemCollection();
					Assert.AreEqual(t1, c2.GetData<Guid>("T1"), "Cache did not transfer");
					Thread.Sleep(1000);
					c2.SetData("T2", t2);

					if (loop++ % 5 == 0)
						Thread.Yield();
					else
						Thread.Sleep(1000);
					if (loop == long.MaxValue)
						loop = long.MinValue;
					break;
				}
				await Task.CompletedTask;
			};

			// Act
			await SafeTask.RunSafelyAsync(act);

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public async Task RunSafely_AnAsyncFunctionWithResult_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			var rnd = new Random();
			var t3 = rnd.Next(10, 100);
			int t4 = int.MinValue;
			c1.SetData("T1", t1);

			// Act
			int t5 = await SafeTask.RunSafelyAsync(async () => {
				var c2 = new Threaded.ContextItemCollection();
				var c2Value = c2.GetData<Guid>("T1");
				Assert.AreEqual(t1, c2Value, "Cache did not transfer");
				Thread.Sleep(1000);
				c2.SetData("T2", t2);

				t4 = rnd.Next(10, 100);

				return await Task.FromResult(t3 + t4);
			});

			// Asserts
			var _t2 = c1.GetData<Guid>("T2");
			Assert.AreEqual(t2, _t2);

			Assert.AreEqual(t5, t3 + t4);
		}
	}
}