using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using BinarySearchTreeTask.Tests.Comparers;
using BinarySearchTreeTask.Tests.Classes;

namespace BinarySearchTreeTask.Tests
{
	[TestFixture]
    public class BinarySearchTreeTests
	{
		private static int IntFailureResult = -1000;
		private static object[] IntArray = new object[]
		{
			new int[] {1, 2, 3, 4},
			new int[] {-28, 0, 4, 199, -5647}
		};
		private static object[] StringArray = new object[]
		{
			new string[] {"Hello", "there"},
			new string[] {"General", "Kenobi"}
		};
		private static object[] BookArray = new object[]
		{
			new Book[]
			{
				new Book {Title = "C#", Author = "Richter"},
				new Book {Title = "C++", Author = "Schildt"}
			}
		};
		private static object[] PointArray = new object[]
		{
			new Point[]
			{
				new Point {X = 100, Y = 100},
				new Point {X = 50, Y = 156}
			}
		};
		[TestCaseSource("IntArray")]
		public void ConstructorMethod_IntArray_CountEqualsArrayLength(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

			Assert.AreEqual(tree.Count, array.Length);
		}

		[TestCaseSource("IntArray")]
		public void AddMethod_IntElements_CountEqualsArrayLength(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			foreach (int element in array)
				tree.Add(element);

			Assert.AreEqual(tree.Count, array.Length);
		}

		[TestCaseSource("IntArray")]
		public void AddMethod_IntArray_CountEqualsArrayLength(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();
			tree.Add(array);

			Assert.AreEqual(tree.Count, array.Length);
		}

		[TestCaseSource("IntArray")]
		public void ContainsMethod_IntItem_ItemIsContained(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
			bool isContained = tree.Contains(array[0]);

			Assert.IsTrue(isContained);
		}

		[TestCaseSource("IntArray")]
		public void ContainsMethod_IntItem_ItemIsNotContained(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
			bool isContained = tree.Contains(IntFailureResult);

			Assert.IsFalse(isContained);
		}

		[TestCaseSource("IntArray")]
		public void RemoveMethod_IntItem_SuccessRemove(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
			bool isSuccess = tree.Remove(array[0]);

			Assert.IsTrue(isSuccess);
		}

		[TestCaseSource("IntArray")]
		public void RemoveMethod_IntItem_FailureRemove(int[] array)
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
			bool isSuccess = tree.Remove(IntFailureResult);

			Assert.IsFalse(isSuccess);
		}

		[TestCaseSource("IntArray")]
		public void ShowElements_IntArray_ArrayAndTreeElementsInSameOrder(int[] array)
		{
			List<int> treeElements = new List<int>();
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
			foreach(int element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(SameOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("IntArray")]
		public void ShowElements_IntArrayAndReverseComparer_ArrayAndTreeElementsInDifferOrder(int[] array)
		{
			List<int> treeElements = new List<int>();
			BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new IntReverseComparer());
			foreach (int element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(ReverseOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("StringArray")]
		public void ShowElements_StringArray_ArrayAndTreeElementsInSameOrder(string[] array)
		{
			List<string> treeElements = new List<string>();
			BinarySearchTree<string> tree = new BinarySearchTree<string>(array);
			foreach (string element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(SameOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("StringArray")]
		public void ShowElements_StringArrayAndReverseComparer_ArrayAndTreeElementsInDifferOrder(string[] array)
		{
			List<string> treeElements = new List<string>();
			BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new StringReverseComparer());
			foreach (string element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(ReverseOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("BookArray")]
		public void ShowElements_BookArray_ArrayAndTreeElementsInSameOrder(Book[] array)
		{
			List<Book> treeElements = new List<Book>();
			BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array);
			foreach (Book element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(SameOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("BookArray")]
		public void ShowElements_BookArrayAndReverseComparer_ArrayAndTreeElementsInDifferOrders(Book[] array)
		{
			List<Book> treeElements = new List<Book>();
			BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array, new BookReverseComparer());
			foreach (Book element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array);

			Assert.IsTrue(ReverseOrder(array, treeElements.ToArray()));
		}

		[TestCaseSource("PointArray")]
		public void ShowElements_PointArrayAndComparer_ArrayAndTreeElementsInSameOrder(Point[] array)
		{
			List<Point> treeElements = new List<Point>();
			BinarySearchTree<Point> tree = new BinarySearchTree<Point>(array, new PointComparer());
			foreach (Point element in tree)
			{
				treeElements.Add(element);
			}

			Array.Sort(array, new PointComparer());

			Assert.IsTrue(SameOrder(array, treeElements.ToArray()));
		}


		private bool SameOrder<T>(T[] expected, T[] actual)
		{
			for (int i = 0; i < expected.Length; i++)
			{
				if (!expected[i].Equals(actual[i]))
					return false;
			}

			return true;
		}

		private bool ReverseOrder<T>(T[] expected, T[] actual)
		{
			for (int i = actual.Length - 1; i >= 0; i--)
			{
				if (!expected[actual.Length - i - 1].Equals(actual[i]))
					return false;
			}

			return true;
		}
	}
}
