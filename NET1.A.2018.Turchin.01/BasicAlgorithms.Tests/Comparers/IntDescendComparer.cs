using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAlgorithms.Tests.Comparers
{
	public class IntDescendComparer : IComparer<int>
	{
		public int Compare(int a, int b)
		{
			if (a > b)
				return -1;
			else if (a < b)
				return 1;

			return 0;
		}
	}
}
