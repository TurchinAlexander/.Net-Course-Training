using System;
using NUnit.Framework;

namespace Polinom.Tests
{
	[TestFixture]
    public class PolinominalClassTests
    {
		[Test]
		public void Polynomial_PolinominalsSum_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(1, 2, 3);
			Polynomial argument2 = new Polynomial(1, 4, 7);

			Polynomial expected = new Polynomial(2, 6, 10);

			Polynomial result = argument1 + argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polynomial_SumWithDigit_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(1, 2, 3);
			int argument2 = 2;

			Polynomial expected = new Polynomial(3, 2, 3);

			Polynomial result = argument1 + argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polynomial_PolinominalsSubstraction_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(5, 10);
			Polynomial argument2 = new Polynomial(1, 3, 7);

			Polynomial expected = new Polynomial(4, 7, -7);

			Polynomial result = argument1 - argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polynomial_SubstractionWithDigit_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(1, 2, 3);
			int argument2 = 2;

			Polynomial expected = new Polynomial(-1, 2, 3);

			Polynomial result = argument1 - argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polynomial_PolinominalsMultiply_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(5, 10, -3);
			Polynomial argument2 = new Polynomial(1, 3, 7);

			Polynomial expected = new Polynomial(5, 25, 62, 61, -21);

			Polynomial result = argument1 * argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polynomial_MultiplyWithDigit_IsCorrect()
		{
			Polynomial argument1 = new Polynomial(1, 2, 3);
			int argument2 = 2;

			Polynomial expected = new Polynomial(2, 4, 6);

			Polynomial result = argument1 * argument2;

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Polinominal_Equal_isTrue()
		{
			Polynomial argument1 = new Polynomial(5, 10, -3);
			Polynomial argument2 = new Polynomial(5, 10, -3);

			Assert.IsTrue(argument1.Equals(argument2));
		}

		[Test]
		public void Polinominal_Equal_isFalse()
		{
			Polynomial argument1 = new Polynomial(5, 10, -3);
			Polynomial argument2 = new Polynomial(1, 2, 3);

			Assert.IsFalse(argument1.Equals(argument2));
		}

		[Test]
		public void Polinominal_ToString_IsCorrect()
		{
			Polynomial argument = new Polynomial(5, 10, -3);
			string expected = "-3x^2 + 10x + 5";

			string result = argument.ToString();

			Assert.IsTrue(expected.Equals(result));
		}

		[Test]
		public void Polinominal_ToString_IsNotCorrect()
		{
			Polynomial argument = new Polynomial(10, -3);
			string expected = "-3x^1 + 5";

			string result = argument.ToString();

			Assert.IsFalse(expected.Equals(result));
		}

		[Test]
		public void Polinominal_ToString_ThrowNullRefference()
		{
			Polynomial argument = null;

			Assert.Throws<NullReferenceException>(() => argument.ToString());
		}

		[Test]
		public void Polinominal_Constructor_ThrowArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
		}

		[Test]
		public void Polinominal_Constructor_ThrowArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));
		}

		[Test]
		public void Polinominal_Clone_ReturnSameIntance()
		{
			Polynomial expected = new Polynomial(1, 2, 3);

			Polynomial actual = (Polynomial)expected.Clone();

			Assert.IsTrue(expected == actual);
		}
	}
}
