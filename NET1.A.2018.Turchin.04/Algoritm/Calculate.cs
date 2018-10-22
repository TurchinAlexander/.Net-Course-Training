using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NET1.A._2018.Turchin._04
{
	/// <summary>
	/// Class help convert double to verbal description and binary representation.
	/// </summary>
    public static class Calculate
    {
		/// <summary>
		/// Help to convert double to verbal description.
		/// </summary>
		private static Dictionary<char, string> dictionary = new Dictionary<char, string>
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

		/// <summary>
		/// Converts real numbers in verbal description.
		/// </summary>
		/// <param name="array">Array of <see cref="double"/> numbers.</param>
		/// <returns>The array of verbal descriptions of real numbers.</returns>
		public static string[] TransformToWords(double[] array)
		{
			string[] result = new string[array.Length];
			
			for (int i = 0; i < array.Length; i++)
			{
				string stringValue = array[i].ToString();
				StringBuilder stringBuilder = new StringBuilder();

				for (int j = 0; j < stringValue.Length; j++)
				{
					stringBuilder.AppendFormat("{0} ", dictionary[stringValue[j]]);
				}

				stringBuilder.Length--;

				result[i] = stringBuilder.ToString();
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
				result.Append(((oneSpace.ulongNumber & mask) != 0) ? '1' : '0');
				mask >>= 1;
			}

			return result.ToString();
		}

		/// <summary>
		/// Used to submit double like long.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		private struct OneSpace
		{
			[FieldOffset(0)]
			public double doubleNumber;

			[FieldOffset(0)]
			public ulong ulongNumber;
		}
	}
}
