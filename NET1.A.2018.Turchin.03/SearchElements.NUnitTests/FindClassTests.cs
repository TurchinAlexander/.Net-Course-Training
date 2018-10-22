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

		[TestCase(12, 21)]
		[TestCase(513, 531)]
		[TestCase(2017, 2071)]
		[TestCase(414, 441)]
		[TestCase(144, 414)]
		[TestCase(1234321, 1241233)]
		[TestCase(1234126, 1234162)]
		[TestCase(3456432, 3462345)]
		public void NextBiggerNumberTest(int number, int expected)
		{
			int? result = Find.NextBiggerNumber(number);

			Assert.AreEqual(expected, result.Value);
		}

		[TestCase(321)]
		[TestCase(987654321)]
		public void NextBiggerNumberMethod_BadInteger_ReturnNull(int number)
		{
			int? result = Find.NextBiggerNumber(number);

			Assert.IsFalse(result.HasValue);
		}
	}
}
