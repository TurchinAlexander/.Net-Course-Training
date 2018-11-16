using System.Collections.Generic;

using BinarySearchTreeTask.Tests.Classes;

namespace BinarySearchTreeTask.Tests.Comparers
{
	class PointComparer : Comparer<Point>
	{
		public override int Compare(Point firstPoint, Point secondPoint)
		{
			return (firstPoint.X - secondPoint.X) + (firstPoint.Y - secondPoint.Y);
		}
	}
}
