using System;
using Sorts;

namespace SearchElements
{
	public static class Find
	{
		/// <summary>
		/// Find the <paramref name="power"/> degree root of <paramref name="number"/>.
		/// </summary>
		/// <param name="number">The initial number.</param>
		/// <param name="power">The degree of root.</param>
		/// <param name="accuracy">The accuracy of operation.</param>
		/// <returns>The result of operation</returns>
		/// <exception cref="ArgumentException">If input values are invalid.</exception>
		public static double NthRoot(double number, int power, double accuracy)
		{
			if (power == 1)
			{
				return number;
			}

			CheckConditions.NthRoot(number, power, accuracy);

			double prevResult, currentResult = 1;

			do
			{
				prevResult = currentResult;

				currentResult = ((power - 1) * prevResult + DivideWithArgumentInPower(number, prevResult, power - 1));
				currentResult /= power;
			}
			while (Math.Abs(prevResult - currentResult) > accuracy);

			return currentResult;
		}

		/// <summary>
		/// Find a value, which is bigger than <paramref name="number"/>.
		/// The value is the closest to <paramref name="number"/>
		/// and consists of digits of <paramref name="number"/>
		/// </summary>
		/// <param name="number">The value, which what we should seek.</param>
		/// <returns>The value, if we find it. Otherwise -1.</returns>
		public static int? NextBiggerNumber(int number)
		{
			if (number < 10)
			{
				return number;
			}

			int[] temp = number.ToArray();
			bool found = false;

			int i = 0;
			int lastIndex = temp.Length - 1;

			while ((!found) && (i < lastIndex))
			{
				int checkArray = lastIndex - i;
				int compareIndex = lastIndex - i - 1;

				Sort.Quick(temp, checkArray, lastIndex);

				int j = checkArray;

				while ((j <= lastIndex) && (temp[compareIndex] >= temp[j]))
				{
					j++;
				}

				if (j <= lastIndex)
				{
					found = true;
					Swap(ref temp[compareIndex], ref temp[j]);
				}
				else
				{
					i++;
				}
			}

			return (found) 
				? (int?)temp.ToInt() 
				: null;
		}

		private static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}

		/// <summary>
		/// Extension method, which helps convert <see cref="int"/> to array of <see cref="int"/>.
		/// </summary>
		/// <param name="number">The value, which should be converted</param>
		/// <returns>Array of digits of <paramref name="number"/>.</returns>
		/// <exception cref="ArgumentException">If the <paramref name="number"/> is negative.</exception>
		private static int[] ToArray(this int number)
		{
			if (number < 0)
			{
				throw new ArgumentException(nameof(number));
			}

			int length = (int)Math.Log10(number) + 1;
			int[] result = new int[length];

			int i = length - 1;
			while (number > 0)
			{
				result[i--] = number % 10;
				number /= 10;
			}

			return result;
		}

		/// <summary>
		/// Converts array of digits to <see cref="int"/>.
		/// </summary>
		/// <param name="array">The array of digit.</param>
		/// <returns>The <see cref="int"/>.</returns>
		/// <exception cref="ArgumentException">If <paramref name="array"/> doesn't consist digits.</exception>
		private static int ToInt(this int[] array)
		{
			int result = 0;

			for (int i = 0; i < array.Length; i++)
			{
				result = result * 10 + array[i];
			}

			return result;
		}

		/// <summary>
		/// Divide the number with argument in power.
		/// </summary>
		/// <param name="number">The number should be divided.</param>
		/// <param name="argument">The number which should divide.</param>
		/// <param name="power">The power of <paramref name="argument"/></param>
		/// <returns>The result of the division.</returns>
		private static double DivideWithArgumentInPower(double number, double argument, int power)
		{
			double result = number;

			for (int i = 0; i < power; i++)
			{
				result /= argument;
			}

			return result;
		}

		/// <summary>
		/// Check validation of input values from methods.
		/// </summary>
		private static class CheckConditions
		{
			/// <summary>
			/// Check conditions of NthRoot method.
			/// </summary>
			/// <param name="number">The initial number.</param>
			/// <param name="power">The degree of root.</param>
			/// <param name="accuracy">The accuracy of operation.</param>
			/// <exception cref="ArgumentException">If one or more parameters are invalid.</exception>
			public  static void NthRoot(double number, int power, double accuracy)
			{
				//double epsilon = 1E-12;

				//if ((number < 0) || (number < epsilon))
				if (number == 0)
				{
					throw new ArgumentException(nameof(number));
				}

				if ((power < 0) || ((power % 2 == 0) && (number < 0)))
				{
					throw new ArgumentException(nameof(power));
				}

				//if ((accuracy < 0 ) || (accuracy < epsilon))
				if (accuracy <= 0)
				{
					throw new ArgumentException(nameof(accuracy));
				}
			}

			/// <summary>
			/// Checks, if all elements of <paramref name="array"/> are one digit.
			/// </summary>
			/// <param name="array">The array of digits.</param>
			/// <exception cref="ArgumentException">If element is not one digit.</exception>
			public static void ArrayToInt(int[] array)
			{
				for (int i = 9; i < array.Length; i++)
				{
					if (Math.Log10(array[i]) != 0)
					{
						throw new ArgumentException(nameof(array));
					}
				}
			}
		}
    }
}
