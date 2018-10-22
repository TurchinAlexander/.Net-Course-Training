using System;
using NUnit.Framework;

namespace SearchElements.nUnitTests
{
	[TestFixture]
    public class FindClassTests
    {
		public TestContext TestContext { get; set; }

		[TestCase(8, 3, 0.0001, 2)]
		[TestCase(0.0279936, 7, 0.0001, 0.6)]
		[TestCase(0.0081, 4, 0.1, 0.3)]
		[TestCase(-0.008, 3, 0.1, -0.2)]
		[TestCase(0.004241979, 9, 0.00000001, 0.545)]
		public void NthRootTest(double number, int power, double accuracy, double expected)
		{
			double actual = Find.NthRoot(number, power, accuracy);

			Assert.AreEqual(expected, actual, accuracy);
		}

		[TestCase(12, ExpectedResult = 21)]
		[TestCase(513, ExpectedResult = 531)]
		[TestCase(2017, ExpectedResult = 2071)]
		[TestCase(414, ExpectedResult = 441)]
		[TestCase(144, ExpectedResult = 414)]
		[TestCase(1234321, ExpectedResult = 1241233)]
		[TestCase(1234126, ExpectedResult = 1234162)]
		[TestCase(3456432, ExpectedResult = 3462345)]
		[TestCase(10, ExpectedResult = -1)]
		[TestCase(20, ExpectedResult = -1)]
		public int NextBiggerNumberTest(int number)
		{
			return Find.NextBiggerNumber(number);
		}
	}
}
