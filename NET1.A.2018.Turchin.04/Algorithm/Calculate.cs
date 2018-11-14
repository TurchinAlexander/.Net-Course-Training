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
		public static IEnumerable<TResult> TransformTo<TSource, TResult>(
			this IEnumerable<TSource> collection,
			ITransformer<TSource, TResult> transformer)
		{
			return TransformTo(collection, transformer.Transform);
		}

		public static IEnumerable<TResult> TransformTo<TSource, TResult>(
			this IEnumerable<TSource> collection,
			Func<TSource, TResult> transformer)
		{
			if (collection == null) throw new ArgumentNullException($"{nameof(collection)} cannot be null.");
			if (transformer == null) throw new ArgumentNullException($"{nameof(transformer)} cannot be null");

			return Transformation();

			IEnumerable<TResult> Transformation()
			{
				foreach (var element in collection)
				{
					yield return transformer(element);
				}
			}
		}

		public static IEnumerable<TSource> Filter<TSource>(
			this IEnumerable<TSource> collection,
			IFilter<TSource> filter)
		{
			return Filter(collection, filter.IsValid);
		}

		public static IEnumerable<TSource> Filter<TSource>(
			this IEnumerable<TSource> collection,
			Func<TSource, bool> filter)
		{
			if (collection == null) throw new ArgumentNullException($"{nameof(collection)} cannot be null.");
			if (filter == null) throw new ArgumentNullException($"{nameof(filter)} cannot be null");

			return FilteredCollection();

			IEnumerable<TSource> FilteredCollection()
			{
				foreach (var element in collection)
				{
					if (filter(element))
					{
						yield return element;
					}
				}
			}
		}

		public static TSource[] ToArray<TSource>(
			this IEnumerable<TSource> collection)
		{
			List<TSource> result = new List<TSource>();

			foreach(var element in collection)
			{
				result.Add(element);
			}

			return result.ToArray();
		}
	}	
}
