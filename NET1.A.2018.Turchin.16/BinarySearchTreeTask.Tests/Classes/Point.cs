using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask.Tests.Classes
{
	public class Point : IEquatable<Point>
	{
		public int X { get; set; }
		public int Y { get; set; }

		public bool Equals(Point other)
		{
			return (this.X == other.X) &&
				(this.Y == other.Y);
		}
	}
}
