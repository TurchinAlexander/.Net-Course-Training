using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Turchin._05
{
    public class Polinomial
    {
		private readonly double[] values;

		/// <summary>
		/// Create an intance of Polinomial with coefficients.
		/// </summary>
		/// <param name="array">Input coefficients.</param>
		/// <exception cref="ArgumentNullException">If the input array is null.</exception>
		/// <exception cref="ArgumentException">If the input array is empty.</exception>
		public Polinomial(params double[] array)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));

			if (array.Length == 0) throw new ArgumentException(nameof(array));

			values = new double[array.Length];

			array.CopyTo(values, 0);
		}

		/// <summary>
		/// Overload sum operation for two polinomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of sum of two polinomials</returns>
		public static Polinomial operator +(Polinomial a, Polinomial b)
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

			return new Polinomial(resultArray);
		}

		/// <summary>
		/// Overload sum operation between polinomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of sum</returns>
		public static Polinomial operator +(Polinomial a, int b)
		{
			a.values[0] += b;

			return new Polinomial(a.values);
		}

		/// <summary>
		/// Overload substraction operation for two polinomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of substraction of two polinomials</returns>
		public static Polinomial operator -(Polinomial a, Polinomial b)
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
				resultArray[i] = a.values[i] - b.values[i];
			}

			return new Polinomial(resultArray);
		}

		/// <summary>
		/// Overload substraction operation between polinomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of substraction.</returns>
		public static Polinomial operator -(Polinomial a, int b)
		{
			a.values[0] -= b;

			return new Polinomial(a.values);
		}

		/// <summary>
		/// Overload multiply operation for two polinomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of multiply of two polinomials</returns>
		public static Polinomial operator *(Polinomial a, Polinomial b)
		{
			double[] resultArray = new double[a.values.Length + b.values.Length];

			for (int i = 0; i < a.values.Length; i++)
				for (int j = 0; j < b.values.Length; j++)
				{
					resultArray[i + j] += a.values[i] * b.values[j];
				}

			return new Polinomial(resultArray);
		}

		/// <summary>
		/// Overload multiply operation between polinomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of multiply.</returns>
		public static Polinomial operator *(Polinomial a, int b)
		{
			double[] resultArray = new double[a.values.Length];

			for (int i = 0; i < a.values.Length; i++)
			{
				resultArray[i] = a.values[i] * b;
			}

			return new Polinomial(resultArray);
		}

		/// <summary>
		/// Check if two polimomials have the same coefficients.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns><c>true</c> if they have the same coefficients. Otherwise <c>falseW</c></returns>
		public static bool operator ==(Polinomial a, Polinomial b)
		{
			return CheckValues(a.values, b.values);
		}

		/// <summary>
		/// Check if two polimomials have the different coefficients.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns></returns>
		public static bool operator !=(Polinomial a, Polinomial b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Determines whether the specified object is equal to current object
		/// </summary>
		/// <param name="obj">The object to be compared.</param>
		/// <returns><c>true</c>If equals. Otherwise <c>false</c></returns>
		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType()) return false;

			Polinomial other = (Polinomial)obj;
			return CheckValues(this.values, other.values);
		}

		/// <summary>
		/// Gets hash of the intance.
		/// </summary>
		/// <returns>Hash code of the intance.</returns>
		public override int GetHashCode()
		{
			const int intSize = 32;
			double sumValues = 0;

			for (int i = 0; i < values.Length; i++)
			{
				sumValues += values[i];
			}

			long longtemp = (long)sumValues;
			int intPart2 = (int)longtemp;
			int intPart1 = (int)longtemp >> intSize;

			return (intPart1 ^ intPart2) + values.Length;
		}

		/// <summary>
		/// Converts the value of the instance to <see cref="string"/>.
		/// </summary>
		/// <returns>The <see cref="string"/>.</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < this.values.Length; i++)
			{
				stringBuilder.AppendFormat("{0} ", this.values[i]);
			}

			stringBuilder.Length--;

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
			const double precision = 0.01;
			int i = 0;

			while ((i < firstArray.Length) && isEqual)
			{
				isEqual = (Math.Abs(firstArray[i] - secondArray[i]) < precision);
			}

			return isEqual;
		}
	}
}
