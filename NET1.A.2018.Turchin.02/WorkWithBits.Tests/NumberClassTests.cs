using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkWithBits.Tests
{
	[TestClass]
	public class NumberClassTests
	{
		[TestMethod]
		public void InputMethodTest_SameIntsWith1BitToChange_ReturnSameInt()
		{
			Assert.AreEqual(15, Number.InsertBits(15, 15, 0, 0));
		}

		[TestMethod]
		public void InputMethodTest_SameIntsWithAllBitsToChange_ReturnSameInt()
		{
			Assert.AreEqual(15, Number.InsertBits(15, 15, 0, 31));
		}

		[TestMethod]
		public void InputMethodTest_OneNegativeIntsWithFirstBitsToChange_ReturnPositiveInt()
		{
			Assert.AreEqual(15, Number.InsertBits(9, -15, 0, 8));
		}

		[TestMethod]
		public void InputMethodTest_OneNegativeIntsWithAllBitsToChange_ReturnNegativeInt()
		{
			Assert.AreEqual(-15, Number.InsertBits(9, -15, 0, 31));
		}
	}
}
