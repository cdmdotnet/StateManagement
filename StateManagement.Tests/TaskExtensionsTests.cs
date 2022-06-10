using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinchilla.StateManagement.Tests
{
	[TestClass]
	public class TaskExtensionsTests
	{
		[TestMethod]
		public void StartNewSafely_AnAction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			Task.Factory.StartNewSafely(() => {
				var c2 = new Threaded.ContextItemCollection();
				Assert.AreEqual(t1, c2.GetData<Guid>("T1"));
				Thread.Sleep(1000);
				c2.SetData("T2", t2);
			}).Wait();

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}

		[TestMethod]
		public void StartNewSafely_AnAsyncFunction_ValuesTransfer()
		{
			// Arrange
			var c1 = new Threaded.ContextItemCollection();
			var t1 = Guid.NewGuid();
			var t2 = Guid.NewGuid();
			c1.SetData("T1", t1);

			// Act
			var task1 = Task.Factory.StartNewSafely(async () => {
				await Task.Run(() => {
					var c2 = new Threaded.ContextItemCollection();
					var c2Value = c2.GetData<Guid>("T1");
					Assert.AreEqual(t1, c2Value);
					Thread.Sleep(1000);
					c2.SetData("T2", t2);
				});
			});
			task1.Wait();

			// Asserts
			var _t2 = c1.GetData<Guid>("T2");
			Assert.AreEqual(t2, _t2);
		}

		[TestMethod]
		public void StartNewSafely_AnOddAsyncFunction_ValuesTransfer()
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
					Assert.AreEqual(t1, c2.GetData<Guid>("T1"));
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

			task1.Wait();

			// Asserts
			Assert.AreEqual(t2, c1.GetData<Guid>("T2"));
		}
	}
}