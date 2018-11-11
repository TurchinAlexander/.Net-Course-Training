using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithm
{
	/// <summary>
	/// Class help convert double to verbal description and binary representation.
	/// </summary>
    public static class Calculate
    {
		/// <summary>
		/// Used to submit double like long.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		private struct OneSpace
		{
			[FieldOffset(0)]
			public double doubleNumber;

			[FieldOffset(0)]
			public ulong longNumber;
		}

		/// <summary>
		/// Converts real numbers in some formate.
		/// </summary>
		/// <typeparam name="T">Input type.</typeparam>
		/// <typeparam name="U">Output type.</typeparam>
		/// <param name="array">Array of <see cref="double"/>.</param>
		/// <param name="tranformator">Conversion format.</param>
		/// <returns>The array of verbal descriptions of real numbers.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="array"/>" or <paramref name="tranformator"/> is null.</exception>
		public static U[] TranformTo<T, U>(T[] array, Func<T, U> tranformator)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
			if (tranformator == null) throw new ArgumentNullException($"{nameof(tranformator)} cannot be null");

			U[] result = new U[array.Length];

			for (int i = 0; i < array.Length; i++)
			{
				result[i] = tranformator(array[i]);
			}

			return result;
		}

		/// <summary>
		/// Extension to filter array by some criteria.
		/// </summary>
		/// <typeparam name="T">Type of the array.</typeparam>
		/// <param name="array">Input array.</param>
		/// <param name="IsValid">The criteria</param>
		/// <returns>The filtered array.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="array"/> or <paramref name="filter"/> is null.</exception>
		public static T[] Filter<T>(this T[] array, Func<T, bool> filter)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
			if (filter == null) throw new ArgumentNullException($"{nameof(filter)} cannot be null");

			List<T> validList = new List<T>();

			foreach(T element in array)
			{
				if (filter(element))
					validList.Add(element);
			}

			return validList.ToArray();
		}

		/// <summary>
		/// Converts real numbers in verbal format.
		/// </summary>
		/// <param name="array">Array of <see cref="double"/>.</param>
		/// <returns>The array of verbal descriptions of real numbers.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="array"/> is null.</exception>
		public static string[] TransformToWords(double[] array)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");

			string[] result = new string[array.Length];
			
			for (int i = 0; i < array.Length; i++)
			{
				result[i] = ToWord(array[i]);
			}

			return result;
		}

		/// <summary>
		/// Converts real numbers to binary representation.
		/// </summary>
		/// <param name="array">Array of <see cref="double"/>.</param>
		/// <returns>The array of <see cref="string"/>.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="array"/> is null.</exception>
		public static string[] TransformToBinary(double[] array)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");

			string[] result = new string[array.Length];

			for (int i = 0; i < array.Length; i++)
			{
				result[i] = ToBinary(array[i]);
			}

			return result;
		}

		/// <summary>
		/// Convert a <see cref="double"/> to binary representation.
		/// </summary>
		/// <param name="number">The <see cref="double"/>.</param>
		/// <returns>The <see cref="string"/> of binary representation.</returns>
		public static string ToBinary(this double number)
		{
			StringBuilder result = new StringBuilder();
			OneSpace oneSpace = new OneSpace();

			int size = 64;
			ulong mask = 1uL << size - 1;

			oneSpace.doubleNumber = number;

			for (int i = 0; i < size; i++)
			{
				result.Append(((oneSpace.longNumber & mask) != 0) ? '1' : '0');
				mask >>= 1;
			}

			return result.ToString();
		}

		/// <summary>
		/// Convert a <see cref="double"/> to verbal representation.
		/// </summary>
		/// <param name="number">The <see cref="double"/>.</param>
		/// <returns>The <see cref="string"/> of verbal representation.</returns>
		public static string ToWord(this double number)
		{
			Dictionary<char, string> dictionary = new Dictionary<char, string>
			{
				{ '0', "zero" },
				{ '1', "one" },
				{ '2', "two" },
				{ '3', "three" },
				{ '4', "four" },
				{ '5', "five" },
				{ '6', "six" },
				{ '7', "seven" },
				{ '8', "eight" },
				{ '9', "nine" },
				{ '-', "minus" },
				{ ',', "point" },
			};

			string result = "";

			if (!SpecialCases(number, ref result))
			{
				string stringValue = number.ToString();
				StringBuilder stringBuilder = new StringBuilder();

				for (int j = 0; j < stringValue.Length; j++)
				{
					stringBuilder.AppendFormat("{0} ", dictionary[stringValue[j]]);
				}

				stringBuilder.Length--;

				result = stringBuilder.ToString();
			}

			return result;
		}

		/// <summary>
		/// Check input number for Nan, positive and negative infinite.
		/// </summary>
		/// <param name="number">The input number.</param>
		/// <param name="stringBuilder">Where to write verval description</param>
		/// <returns>If one of cases is worked.</returns>
		private static bool SpecialCases(double number, ref string result)
		{
			bool isSpecialCase = false;

			if (double.IsNaN(number))
			{
				result = "NaN";
				isSpecialCase = true;
			}
			else if (double.IsPositiveInfinity(number))
			{
				result = "Positive Infinite";
				isSpecialCase = true;
			}
			else if (double.IsNegativeInfinity(number))
			{
				result = "Negative Infinite";
				isSpecialCase = true;
			}

			return (isSpecialCase);
		}
	}
}
