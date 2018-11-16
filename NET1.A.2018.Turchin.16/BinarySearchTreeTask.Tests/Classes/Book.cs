using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask.Tests.Classes
{
	public class Book : IComparable<Book>, IEquatable<Book>
	{
		public string Title { get; set; }
		public string Author { get; set; }

		public int CompareTo(Book other)
		{
			return this.Title.CompareTo(other.Title);
		}

		public bool Equals(Book other)
		{
			return (this.Title == other.Title) &&
				(this.Author == other.Author);
		}
	}
}
