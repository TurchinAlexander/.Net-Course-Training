using System;
using NUnit.Framework;

namespace WorkWithBits.nUnitTests
{
	[TestFixture]
    public class NumberClassTests
    {
		[TestCase(1, 0)]
		[TestCase(-1, 0)]
		[TestCase(-2, -1)]
		public void InsertBits_LeftAndRightBound_ReturnArgumentException(int right, int left)
		{
			Assert.Throws<ArgumentException>(() => Number.InsertBits(1, 1, right, left));
		}
    }
}
