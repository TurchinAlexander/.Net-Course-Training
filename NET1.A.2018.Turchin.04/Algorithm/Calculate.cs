using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

using Algorithm.Interfaces;


namespace Algorithm
{
	public class TransformerDoubleToWord : ITransformer<double, string>
	{
		public string Transform(double number)
		{
			string specialValueOfDouble = SpecialValueOfDouble(number);

			if (!string.IsNullOrEmpty(specialValueOfDouble))
			{
				return specialValueOfDouble;
			}

			string symbolOfNumber = "0123456789.-+E";
			string[] wordsOfSymbols = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "point", "minus", "plus", "E"};

			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");

			string numberInStringView = number.ToString();
			StringBuilder numberInWordView = new StringBuilder();

			foreach (char symbol in numberInStringView)
			{
				int index = symbolOfNumber.IndexOf(symbol);
				numberInWordView.Append($"{wordsOfSymbols[index]} ");
			}

			numberInWordView.Length -= 1;

			return numberInWordView.ToString();
		}

		private static string SpecialValueOfDouble(double number)
		{
			if (double.IsNaN(number))
				return "NaN";

			if (double.IsPositiveInfinity(number))
				return "Positive Infinite";

			if (double.IsNegativeInfinity(number))
				return "Negative Infinite";

			return null;
		}
	}

	public class TransformerDoubleToIEEEFormat : ITransformer<double, string>
	{
		public string Transform(double number) => number.DoubleToBinaryString();
	}

	public static class DoubleExtensions
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct OneSpace
		{
			[FieldOffset(0)]
			public double doubleNumber;

			[FieldOffset(0)]
			public long longNumber;
		}

		public static string DoubleToBinaryString(this double number)
		{
			StringBuilder result = new StringBuilder();
			OneSpace oneSpace = new OneSpace();

			int size = 64;

			oneSpace.doubleNumber = number;
			long doubleLikeLong = oneSpace.longNumber;

			for (int i = 0; i < size; i++)
			{
				result.Insert(
					0, 
					doubleLikeLong & 1
					);

				doubleLikeLong >>= 1;
			}

			return result.ToString();
		}
	}

	public static class ArrayExtensions
	{
		public static TResult[] TransformTo<TSource, TResult>(this TSource[] numbers, ITransformer<TSource, TResult> transformer)
		{
			return TransformTo(numbers, transformer.Transform);
		}

		public static TResult[] TransformTo<TSource, TResult>(this TSource[] numbers, Func<TSource, TResult> transformer)
		{
			InputValidation(numbers, transformer);

			TResult[] numbersInFormatView = new TResult[numbers.Length];

			for (int i = 0; i < numbers.Length; i++)
			{
				numbersInFormatView[i] = transformer(numbers[i]);
			}

			return numbersInFormatView;
		}

		public static TSource[] Filter<TSource>(this TSource[] array, Func<TSource, bool> filter)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
			if (filter == null) throw new ArgumentNullException($"{nameof(filter)} cannot be null");

			List<TSource> validList = new List<TSource>();

			foreach (TSource element in array)
			{
				if (filter(element))
					validList.Add(element);
			}

			return validList.ToArray();
		}

		private static void InputValidation<TSource, TResult>(TSource[] numbers, Func<TSource, TResult> tranformer)
		{
			if (numbers == null) throw new ArgumentNullException($"{nameof(numbers)} cannot be null.");
			if (tranformer == null) throw new ArgumentNullException($"{nameof(tranformer)} cannot be null");
		}
	}	
}
