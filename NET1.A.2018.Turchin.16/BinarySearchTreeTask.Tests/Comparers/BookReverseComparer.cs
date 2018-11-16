using System.Collections.Generic;
using BinarySearchTreeTask.Tests.Classes;

namespace BinarySearchTreeTask.Tests.Comparers
{
	public class BookReverseComparer : Comparer<Book>
	{
		public override int Compare(Book x, Book y)
		{
			return -(x.CompareTo(y));
		}
	}
}
