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
			double[] bigArray, smallArray;
			double[] resultArray;

			if (a.values.Length < b.values.Length)
			{
				bigArray = b.values;
				smallArray = a.values;
			}
			else
			{
				bigArray = a.values;
				smallArray = b.values;
			}

			resultArray = new double[bigArray.Length];

			for (int i = 0; i < smallArray.Length; i++)
			{
				resultArray[i] = smallArray[i] + bigArray[i];
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
			double[] bigArray, smallArray;
			double[] resultArray;

			if (a.values.Length < b.values.Length)
			{
				bigArray = b.values;
				smallArray = a.values;
			}
			else
			{
				bigArray = a.values;
				smallArray = b.values;
			}

			resultArray = new double[bigArray.Length];

			for (int i = 0; i < smallArray.Length; i++)
			{
				resultArray[i] = smallArray[i] - bigArray[i];
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

    }
}
