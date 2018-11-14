using System;
using NUnit.Framework;

using GenericQueue.Tests.Classes;

namespace GenericQueue.Tests
{
	[TestFixture]
    public class QueueGenericTests
    {
		[Test]
		public void EnqueueMethod_ValueTypes_Enqueued()
		{
			QueueGeneric<int> queue = new QueueGeneric<int>();
			queue.Enqueue(1);
			queue.Enqueue(2);

			Assert.AreEqual(queue.Count, 2);
		}

		[Test]
		public void EnqueueMethod_RefferenceTypes_Enqueued()
		{
			string[] array = new string[] { "hello", "this", "is", "just", "a", "test" };
			QueueGeneric<string> queue = new QueueGeneric<string>(array);

			Assert.AreEqual(queue.Count, array.Length);
		}

		[Test]
		public void DequeueMethod_DequeueFromQueueWithTwoElements_QueueWithOneElement()
		{
			PersonInfo[] array = new PersonInfo[]
			{
				new PersonInfo {Name = "Jonh", Surname = "Newman"},
				new PersonInfo {Name = "Olly", Surname = "Murs"}
			};

			QueueGeneric<PersonInfo> queue = new QueueGeneric<PersonInfo>(array);
			Assert.AreEqual(queue.Count, 2);

			queue.Dequeue();

			Assert.AreEqual(queue.Count, 1);
		}

		[Test]
		public void DequeueMethod_DequeueFromQueueWithTwoElements_TakeFirstElementFromQueue()
		{
			PersonInfo[] array = new PersonInfo[]
			{
				new PersonInfo {Name = "Jonh", Surname = "Newman"},
				new PersonInfo {Name = "Olly", Surname = "Murs"}
			};

			QueueGeneric<PersonInfo> queue = new QueueGeneric<PersonInfo>(array);
			PersonInfo human = queue.Dequeue();

			Assert.AreEqual(human.Name, array[0].Name);
		}

		[Test]
		public void	PeekMethod_PeekFromQueueWithTwoElements_ShowLastElementFromQueue()
		{
			PersonInfo[] array = new PersonInfo[]
			{
				new PersonInfo {Name = "Jonh", Surname = "Newman"},
				new PersonInfo {Name = "Olly", Surname = "Murs"}
			};

			QueueGeneric<PersonInfo> queue = new QueueGeneric<PersonInfo>(array);
			PersonInfo peekHuman = queue.Peek();

			Assert.AreEqual(peekHuman.Name, array[array.Length - 1].Name);
		}

		[Test]
		public void ContainsMethod_QueueWithThreeIntElements_ElementIsInQueue()
		{
			QueueGeneric<int> queue = new QueueGeneric<int>(new int[] { 1, 5, 7 });

			Assert.IsTrue(queue.Contains(5));
		}

		[Test]
		public void ContainsMethod_QueueWithThreeIntElements_ElementIsInNotQueue()
		{
			QueueGeneric<int> queue = new QueueGeneric<int>(new int[] { 1, 5, 7 });

			Assert.IsFalse(queue.Contains(10));
		}

		[Test]
		public void ContainsMethod_QueueWithTwoPersonInfo_ElementIsNotFound()
		{
			PersonInfo[] array = new PersonInfo[]
			{
				new PersonInfo {Name = "Jonh", Surname = "Newman"},
				new PersonInfo {Name = "Olly", Surname = "Murs"}
			};

			QueueGeneric<PersonInfo> queue = new QueueGeneric<PersonInfo>(array);

			Assert.IsTrue(queue.Contains(array[0]));
			Assert.IsFalse(queue.Contains(new PersonInfo { Name = "Jonh", Surname = "Newman" }));
		}

		[Test]
		public void ContainsMethod_QueueWithTwoPersonInfoEquatable_ElementIsNotFound()
		{
			PersonInfoEquatable[] array = new PersonInfoEquatable[]
			{
				new PersonInfoEquatable {Name = "Jonh", Surname = "Newman"},
				new PersonInfoEquatable {Name = "Olly", Surname = "Murs"}
			};

			QueueGeneric<PersonInfoEquatable> queue = new QueueGeneric<PersonInfoEquatable>(array);

			Assert.IsTrue(queue.Contains(array[0]));
			Assert.IsTrue(queue.Contains(new PersonInfoEquatable { Name = "Jonh", Surname = "Newman" }));
		}

		[Test]
		public void ContainsMethod_QueueWithTwoPersonInfoObjectEquals_ElementIsNotFound()
		{
			PersonInfoObjectEquals[] array = new PersonInfoObjectEquals[]
			{
				new PersonInfoObjectEquals {Name = "Alexander", Surname = "Turchin"},
				new PersonInfoObjectEquals {Name = "Site", Surname = "Github"}
			};

			QueueGeneric<PersonInfoObjectEquals> queue = new QueueGeneric<PersonInfoObjectEquals>(array);

			Assert.IsTrue(queue.Contains(array[1]));
			Assert.IsTrue(queue.Contains(new PersonInfoObjectEquals { Name = "Site", Surname = "Github" }));
		}
	}
}
