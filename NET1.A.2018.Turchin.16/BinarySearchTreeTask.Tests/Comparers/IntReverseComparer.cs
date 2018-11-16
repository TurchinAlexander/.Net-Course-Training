using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask.Tests.Comparers
{
	class IntReverseComparer : Comparer<int>
	{
		public override int Compare(int x, int y)
		{
			return -(x - y);
		}
	}
}
