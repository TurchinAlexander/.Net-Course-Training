using System;
using System.Configuration;
using System.Text;

namespace Polinom
{
	/// <summary>
	/// Represent polynomial class.
	/// </summary>
	public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
	{
		public static double epsilon;
		/// <summary>
		/// Array of coefficients.
		/// </summary>
		private readonly double[] _values;

		/// <summary>
		/// Gets the maximum power of the polynomial.
		/// </summary>
		public int MaxPower { get; }

		/// <summary>
		/// Indexer to get coefficients of polinomial.
		/// </summary>
		/// <param name="number">Degree of polynomial.</param>
		/// <returns>The value of coefficient.</returns>
		public double this[int number]
		{
			get
			{
				if (number > MaxPower)
					throw new ArgumentOutOfRangeException(nameof(number));

				return _values[number];
			}
		}

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
			this._values = new double[array.Length];

			array.CopyTo(this._values, 0);
		}

		/// <summary>
		/// Overload sum operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of sum of two polynomials</returns>
		public static Polynomial operator +(Polynomial a, Polynomial b)
		{
			return Add(a, b);
		}

		/// <summary>
		/// Overload sum operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of sum</returns>
		public static Polynomial operator +(Polynomial a, int b)
		{
			return Add(a, b);
		}

		/// <summary>
		/// Overload subtraction operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of subtraction of two polynomials</returns>
		public static Polynomial operator -(Polynomial a, Polynomial b)
		{
			return Subtract(a, b);
		}

		/// <summary>
		/// Overload subtraction operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of subtraction.</returns>
		public static Polynomial operator -(Polynomial a, int b)
		{
			return Subtract(a, b);
		}

		/// <summary>
		/// Overload multiply operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of multiply of two polynomials</returns>
		public static Polynomial operator *(Polynomial a, Polynomial b)
		{
			return Multiply(a, b);
		}

		/// <summary>
		/// Overload multiply operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of multiply.</returns>
		public static Polynomial operator *(Polynomial a, int b)
		{
			return Multiply(a, b);
		}


		/// <summary>
		/// Check if two polynomials have the same coefficients.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns><c>true</c> if they have the same coefficients. Otherwise <c>falseW</c></returns>
		public static bool operator ==(Polynomial a, Polynomial b)
		{
			return a.Equals(b);
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
		/// Overload sum operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of sum of two polynomials</returns>
		public static Polynomial Add(Polynomial a, Polynomial b)
		{
			Polynomial result;
			double[] array;

			if (a._values.Length < b._values.Length)
			{
				result = b.Clone();
				array = a._values;
			}
			else
			{
				result = a.Clone();
				array = b._values;
			}

			for (int i = 0; i < array.Length; i++)
			{
				result._values[i] += array[i];
			}

			return result;
		}

		/// <summary>
		/// Overload sum operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of sum</returns>
		public static Polynomial Add(Polynomial a, double b)
		{
			a._values[0] += b;

			return new Polynomial(a._values);
		}

		/// <summary>
		/// Overload subtraction operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of subtraction of two polynomials</returns>
		public static Polynomial Subtract(Polynomial a, Polynomial b)
		{
			ChangeSign(b._values);

			return Add(a, b);
		}

		/// <summary>
		/// Overload subtraction operation between polynomial and digit.
		/// </summary>
		/// <param name="a">The polynomial</param>
		/// <param name="b">The digit.</param>
		/// <returns>The result of subtraction.</returns>
		public static Polynomial Subtract(Polynomial a, double b)
		{
			a._values[0] -= b;

			return new Polynomial(a._values);
		}

		/// <summary>
		/// Overload multiply operation for two polynomials.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The result of multiply of two polynomials</returns>
		public static Polynomial Multiply(Polynomial a, Polynomial b)
		{
			double[] resultArray = new double[a._values.Length + b._values.Length - 1];

			for (int i = 0; i < a._values.Length; i++)
			{
				for (int j = 0; j < b._values.Length; j++)
				{
					resultArray[i + j] += a._values[i] * b._values[j];
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
		public static Polynomial Multiply(Polynomial a, double b)
		{
			double[] resultArray = new double[a._values.Length];

			for (int i = 0; i < a._values.Length; i++)
			{
				resultArray[i] = a._values[i] * b;
			}

			return new Polynomial(resultArray);
		}


		/// <summary>
		/// Create a new instance of <see cref="Polynomial"/> through interface 
		/// with the same values as the existing instance.
		/// </summary>
		/// <returns>New <see cref="Polynomial"/>.</returns>
		object ICloneable.Clone()
		{
			return Clone();
		}

		/// <summary>
		/// Create a new instance of <see cref="Polynomial"/> with the same values as the existing instance.
		/// </summary>
		/// <returns>New <see cref="Polynomial"/>.</returns>
		public Polynomial Clone()
		{
			return new Polynomial(this._values);
		}

		/// <summary>
		/// Determines whether the specified object is equal to current object
		/// </summary>
		/// <param name="obj">The object to be compared.</param>
		/// <returns><c>true</c>If equals. Otherwise <c>false</c></returns>
		public override bool Equals(object obj)
		{ 
			return this.Equals(obj as Polynomial);
		}

		/// <summary>
		/// Determines whether the specified <see cref="Polynomial"/> instance has the same values.
		/// </summary>
		/// <param name="other">The <see cref="Polynomial"/> instance.</param>
		/// <returns><c>true</c>If equals. Otherwise <c>false</c></returns>
		public bool Equals(Polynomial other)
		{
			if (ReferenceEquals(this, other)) return true;
			if (this.MaxPower != other.MaxPower) return false;
			if (ReferenceEquals(this, null) || ReferenceEquals(other, null)) return false;

			return CheckValues(this._values, other._values);
		}

		/// <summary>
		/// Gets hash of the instance.
		/// </summary>
		/// <returns>Hash code of the instance.</returns>
		public override int GetHashCode()
		{
			const int IntSize = 32;
			double sumValues = 0;

			for (int i = 0; i < this._values.Length; i++)
			{
				sumValues += this._values[i];
			}

			long longtemp = (long)sumValues;
			int intPart2 = (int)longtemp;
			int intPart1 = (int)longtemp >> IntSize;

			return (intPart1 ^ intPart2) + this._values.Length;
		}

		/// <summary>
		/// Converts the value of the instance to <see cref="string"/>.
		/// </summary>
		/// <returns>The <see cref="string"/>.</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = this._values.Length - 1; i > 1; i--)
			{
				stringBuilder.AppendFormat("{0}x^{1} + ", this._values[i], i);
			}

			if (this._values.Length >= 2)
			{
				stringBuilder.AppendFormat("{0}x + ", this._values[1]);
			}

			stringBuilder.AppendFormat("{0}", this._values[0]);

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
			double epsilon = 0.0001;
			int i = 0;

			while ((i < firstArray.Length) && isEqual)
			{
				isEqual = (Math.Abs(firstArray[i] - secondArray[i]) < epsilon);
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
