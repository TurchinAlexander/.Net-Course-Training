using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
	/// <summary>
	/// Represent polynomial class.
	/// </summary>
	public class Polynomial : ICloneable, IEquatable<Polynomial>
	{
		/// <summary>
		/// Array of coefficients.
		/// </summary>
		private readonly double[] values;

		/// <summary>
		/// Initializes a new instance of the <see cref="Polynomial"/> class.
		/// </summary>
		/// <param name="array">Input coefficients.</param>
		/// <exception cref="ArgumentNullException">If the input array is null.</exception>
		/// <exception cref="ArgumentException">If the input array is empty.</exception>
		public Polynomial(params double[] array)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (array.Length == 0) throw new ArgumentException(nameof(array));

			this.MaxPower = array.Length - 1;
			this.values = new double[array.Length];

			array.CopyTo(this.values, 0);
		}

		/// <summary>
		/// Gets the maximum power of the polynomial.
		/// </summary>
		public int MaxPower { get; }

		/// <summary>
		/// Overload sum operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of sum of two polynomials</returns>
		public static Polynomial operator +(Polynomial a, Polynomial b)
		{
			double[] resultArray;
			int minLength;

			if (a.values.Length < b.values.Length)
			{
				resultArray = new double[b.values.Length];
				minLength = a.values.Length;
			}
			else
			{
				resultArray = new double[a.values.Length];
				minLength = b.values.Length;
			}

			for (int i = 0; i < minLength; i++)
			{
				resultArray[i] = a.values[i] + b.values[i];
			}

			return new Polynomial(resultArray);
		}

		/// <summary>
		/// Overload sum operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of sum</returns>
		public static Polynomial operator +(Polynomial a, int b)
		{
			a.values[0] += b;

			return new Polynomial(a.values);
		}

		/// <summary>
		/// Overload subtraction operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of subtraction of two polynomials</returns>
		public static Polynomial operator -(Polynomial a, Polynomial b)
		{
			double[] smallArray, bigArray;
			double[] resultArray;

			ChangeSign(b.values);

			if (a.values.Length < b.values.Length)
			{
				smallArray = a.values;
				bigArray = b.values;
			}
			else
			{
				smallArray = b.values;
				bigArray = a.values;
			}

			resultArray = new double[bigArray.Length];

			for (int i = 0; i < smallArray.Length; i++)
			{
				resultArray[i] = smallArray[i] + bigArray[i];
			}

			for (int i = smallArray.Length; i < bigArray.Length; i++)
			{
				resultArray[i] = bigArray[i];
			}

			return new Polynomial(resultArray);
		}

		/// <summary>
		/// Overload subtraction operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of subtraction.</returns>
		public static Polynomial operator -(Polynomial a, int b)
		{
			a.values[0] -= b;

			return new Polynomial(a.values);
		}

		/// <summary>
		/// Overload multiply operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of multiply of two polynomials</returns>
		public static Polynomial operator *(Polynomial a, Polynomial b)
		{
			double[] resultArray = new double[a.values.Length + b.values.Length - 1];

			for (int i = 0; i < a.values.Length; i++)
			{
				for (int j = 0; j < b.values.Length; j++)
				{
					resultArray[i + j] += a.values[i] * b.values[j];
				}
			}

			return new Polynomial(resultArray);
		}

		/// <summary>
		/// Overload multiply operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of multiply.</returns>
		public static Polynomial operator *(Polynomial a, int b)
		{
			double[] resultArray = new double[a.values.Length];

			for (int i = 0; i < a.values.Length; i++)
			{
				resultArray[i] = a.values[i] * b;
			}

			return new Polynomial(resultArray);
		}

		/// <summary>
		/// Check if two polynomials have the same coefficients.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns><c>true</c> if they have the same coefficients. Otherwise <c>falseW</c></returns>
		public static bool operator ==(Polynomial a, Polynomial b)
		{
			return CheckValues(a.values, b.values);
		}

		/// <summary>
		/// Check if two polynomials have the different coefficients.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns><c>true</c> if they are not equal. Otherwise, <c>false</c>.</returns>
		public static bool operator !=(Polynomial a, Polynomial b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Create a new instance of <see cref="Polynomial"/> with the same values as the existing instance.
		/// </summary>
		/// <returns>New <see cref="Polynomial"/>.</returns>
		public object Clone()
		{
			return new Polynomial(this.values);
		}

		/// <summary>
		/// Determines whether the specified object is equal to current object
		/// </summary>
		/// <param name="obj">The object to be compared.</param>
		/// <returns><c>true</c>If equals. Otherwise <c>false</c></returns>
		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType()) return false;

			return this.Equals((Polynomial)obj);
		}

		/// <summary>
		/// Determines whether the specified <see cref="Polynomial"/> instance has the same values.
		/// </summary>
		/// <param name="other">The <see cref="Polynomial"/> instance.</param>
		/// <returns><c>true</c>If equals. Otherwise <c>false</c></returns>
		public bool Equals(Polynomial other)
		{
			return CheckValues(this.values, other.values);
		}

		/// <summary>
		/// Gets hash of the instance.
		/// </summary>
		/// <returns>Hash code of the instance.</returns>
		public override int GetHashCode()
		{
			const int IntSize = 32;
			double sumValues = 0;

			for (int i = 0; i < this.values.Length; i++)
			{
				sumValues += this.values[i];
			}

			long longtemp = (long)sumValues;
			int intPart2 = (int)longtemp;
			int intPart1 = (int)longtemp >> IntSize;

			return (intPart1 ^ intPart2) + this.values.Length;
		}

		/// <summary>
		/// Converts the value of the instance to <see cref="string"/>.
		/// </summary>
		/// <returns>The <see cref="string"/>.</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = this.values.Length - 1; i > 1; i--)
			{
				stringBuilder.AppendFormat("{0}x^{1} + ", this.values[i], i);
			}

			if (this.values.Length >= 2)
			{
				stringBuilder.AppendFormat("{0}x + ", this.values[1]);
			}

			stringBuilder.AppendFormat("{0}", this.values[0]);

			return stringBuilder.ToString();
		}

		/// <summary>
		/// Check if two array have the same values.
		/// </summary>
		/// <param name="firstArray">First array.</param>
		/// <param name="secondArray">Second array.</param>
		/// <returns><c>true</c>if equals. Otherwise <c>false</c>.</returns>
		private static bool CheckValues(double[] firstArray, double[] secondArray)
		{
			if (firstArray.Length != secondArray.Length)
			{
				return false;
			}

			bool isEqual = true;
			const double Precision = 0.01;
			int i = 0;

			while ((i < firstArray.Length) && isEqual)
			{
				isEqual = (Math.Abs(firstArray[i] - secondArray[i]) < Precision);
				i++;
			}

			return isEqual;
		}

		/// <summary>
		/// Used in subtraction.
		/// </summary>
		/// <param name="array">Array of values.</param>
		private static void ChangeSign(double[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -array[i];
			}
		}
	}
}
