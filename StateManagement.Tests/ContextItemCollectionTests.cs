using System;
using System.Collections.Generic;
using System.Linq;
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
			var cic = new Threaded.ContextItemCollection();
			int? finalTest1Result = null;
			int? finalTest2Result = null;

			// Act
			Task.Factory.StartNew(() => {
				cic.SetData("key", 1);
				thread2ReadyToStart = true;
				while(!thread2Done)
				{
					Thread.Sleep(250);
				}
				thread1Done = true;
				Task.Factory.StartNewSafely(() =>
				{
					finalTest1Result = cic.GetData<int>("key");
				});
			});

			Task.Factory.StartNew(() => {
				while (!thread2ReadyToStart)
				{
					Thread.Sleep(250);
				}
				cic.SetData("key", 2);
				thread2Done = true;
				while(!thread1Done)
				{
					Thread.Sleep(250);
				}
				Task.Factory.StartNewSafely(() =>
				{
					finalTest2Result = cic.GetData<int>("key");
				});
			});

			while (finalTest1Result == null || finalTest2Result == null)
			{
				Thread.Sleep(250);
			}

			// Assert
			Assert.AreEqual(1, finalTest1Result.Value);
			Assert.AreEqual(2, finalTest2Result.Value);
		}
	}
}