using System;
using NUnit.Framework;

namespace Polinom.Tests
{
	[TestFixture]
    public class PolinominalClassTests
    {
		[TestCase]
		public void Polinomial_PolinominalsSum_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(1, 2, 3);
			Polinomial argument2 = new Polinomial(1, 4, 7);

			Polinomial expected = new Polinomial(2, 6, 10);

			Polinomial result = argument1 + argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinomial_SumWithDigit_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(1, 2, 3);
			int argument2 = 2;

			Polinomial expected = new Polinomial(3, 2, 3);

			Polinomial result = argument1 + argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinomial_PolinominalsSubstraction_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(5, 10);
			Polinomial argument2 = new Polinomial(1, 3, 7);

			Polinomial expected = new Polinomial(4, 7, -7);

			Polinomial result = argument1 - argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinomial_SubstractionWithDigit_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(1, 2, 3);
			int argument2 = 2;

			Polinomial expected = new Polinomial(-1, 2, 3);

			Polinomial result = argument1 - argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinomial_PolinominalsMultiply_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(5, 10, -3);
			Polinomial argument2 = new Polinomial(1, 3, 7);

			Polinomial expected = new Polinomial(5, 25, 62, 61, -21);

			Polinomial result = argument1 * argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinomial_MultiplyWithDigit_IsCorrect()
		{
			Polinomial argument1 = new Polinomial(1, 2, 3);
			int argument2 = 2;

			Polinomial expected = new Polinomial(2, 4, 6);

			Polinomial result = argument1 * argument2;

			Assert.AreEqual(expected, result);
		}

		[TestCase]
		public void Polinominal_Equal_isTrue()
		{
			Polinomial argument1 = new Polinomial(5, 10, -3);
			Polinomial argument2 = new Polinomial(5, 10, -3);

			Assert.IsTrue(argument1.Equals(argument2));
		}

		[TestCase]
		public void Polinominal_Equal_isFalse()
		{
			Polinomial argument1 = new Polinomial(5, 10, -3);
			Polinomial argument2 = new Polinomial(1, 2, 3);

			Assert.IsFalse(argument1.Equals(argument2));
		}

		[TestCase]
		public void Polinominal_ToString_IsCorrect()
		{
			Polinomial argument = new Polinomial(5, 10, -3);
			string expected = "-3x^2 + 10x + 5";

			string result = argument.ToString();

			Assert.IsTrue(expected.Equals(result));
		}

		[TestCase]
		public void Polinominal_ToString_IsNotCorrect()
		{
			Polinomial argument = new Polinomial(10, -3);
			string expected = "-3x^1 + 5";

			string result = argument.ToString();

			Assert.IsFalse(expected.Equals(result));
		}

		[TestCase]
		public void Polinominal_ToString_ThrowNullRefference()
		{
			Polinomial argument = null;

			Assert.Throws<NullReferenceException>(() => argument.ToString());
		}

		[TestCase]
		public void Polinominal_Constructor_ThrowArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new Polinomial(null));
		}

		[TestCase]
		public void Polinominal_Constructor_ThrowArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Polinomial(new double[] { }));
		}
	}
}
