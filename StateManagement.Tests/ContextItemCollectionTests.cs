using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinchilla.StateManagement.Tests
{
	[TestClass]
	public class ContextItemCollectionTests
	{
		[TestMethod]
		public void ContextItemCollection_SetData_TwoThreadsHaveDifferentValues()
		{
			// Arrange
			bool thread1Done = false;
			bool thread2ReadyToStart = false;
			bool thread2Done = false;
			int? finalTest1Result = null;
			int? finalTest2Result = null;

			// Act
			var thread1 = new Thread(() => {
				var cic1 = new Threaded.ContextItemCollection();
				cic1.SetData("key", 1);
				thread2ReadyToStart = true;
				while (!thread2Done)
				{
					Thread.Sleep(250);
				}
				thread1Done = true;
				Task.Factory.StartNewSafely(() =>
				{
					finalTest1Result = cic1.GetData<int>("key");
					Console.WriteLine($"Thread 1 obtained {finalTest1Result}");
				});
			});
			thread1.Start();

			var thread2 = new Thread(() => {
				var cic2 = new Threaded.ContextItemCollection();
				while (!thread2ReadyToStart)
				{
					Thread.Sleep(250);
				}
				cic2.SetData("key", 2);
				thread2Done = true;
				while (!thread1Done)
				{
					Thread.Sleep(250);
				}
				Task.Factory.StartNewSafely(() =>
				{
					finalTest2Result = cic2.GetData<int>("key");
					Console.WriteLine($"Thread 2 obtained {finalTest2Result}");
				});
			});
			thread2.Start();

			while (finalTest1Result == null || finalTest2Result == null)
			{
				Thread.Sleep(250);
			}

			// Assert
			Assert.AreEqual(1, finalTest1Result.Value);
			Assert.AreEqual(2, finalTest2Result.Value);
			var cic = new Threaded.ContextItemCollection();
		}
	}
}