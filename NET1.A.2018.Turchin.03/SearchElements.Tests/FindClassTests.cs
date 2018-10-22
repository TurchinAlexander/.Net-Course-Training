using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchElements.Tests
{
	[TestClass]
	public class FindClassTests
	{
		public TestContext TestContext{ get; set; }

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
			"|DataDirectory|\\DataTestSource.xml",
			"Root",
			DataAccessMethod.Sequential)]
		[TestMethod]
		public void NthRootTest()
		{
			double number = Convert.ToDouble(TestContext.DataRow["number"]);
			int power = Convert.ToInt32(TestContext.DataRow["power"]);
			double accuracy = Convert.ToDouble(TestContext.DataRow["accuracy"]);
			double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

			double result = Find.NthRoot(number, power, accuracy);

			Assert.AreEqual(expected, result, accuracy);
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
			"|DataDirectory|\\DataTestSource.xml",
			"RootException",
			DataAccessMethod.Sequential)]
		[TestMethod]
		public void NthRootExceptionTest()
		{
			double number = Convert.ToDouble(TestContext.DataRow["number"]);
			int power = Convert.ToInt32(TestContext.DataRow["power"]);
			double accuracy = Convert.ToDouble(TestContext.DataRow["accuracy"]);

			Assert.ThrowsException<ArgumentException>(() => Find.NthRoot(number, power, accuracy));
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
			"|DataDirectory|\\DataTestSource.xml",
			"NextBigger",
			DataAccessMethod.Sequential)]
		[TestMethod]
		public void NextBiggerNumberTest()
		{
			int number = Convert.ToInt32(TestContext.DataRow["number"]);
			int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

			double result = Find.NextBiggerNumber(number);

			Assert.AreEqual(expected, result);
		}
	}
}
