using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask.Tests.Comparers
{
	class StringReverseComparer : Comparer<string>
	{
		public override int Compare(string x, string y)
		{
			return -(x.CompareTo(y));
		}
	}
}
