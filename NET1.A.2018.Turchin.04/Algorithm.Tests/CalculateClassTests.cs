using NUnit.Framework;

using Algorithm.Tests.Filters;

namespace Algorithm.Tests
{
	[TestFixture]
	public class CalculateClassTests
	{

		private static object[] TestVerbal =
		{
			new object[]
			{
				new double[] { 0 },
				new string[] { "zero" }
			},
			new object[]
			{
				new double[] {-23.809, 0.295, 15.17 },
				new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" }
			},
			new object[]
			{
				new double[] {double.NaN, double.PositiveInfinity, double.NegativeInfinity },
				new string[] { "NaN", "Positive Infinite", "Negative Infinite" }
			},

		};
		private static object[] TestBinary =
		{
			new object[]
			{
				-255.255,
				"1100000001101111111010000010100011110101110000101000111101011100"
			},
			new object[]
			{
				255.255,
				"0100000001101111111010000010100011110101110000101000111101011100"
			},
			new object[]
			{
				4294967295.0,
				"0100000111101111111111111111111111111111111000000000000000000000"
			},
			new object[]
			{
				double.MinValue,
				"1111111111101111111111111111111111111111111111111111111111111111"
			},
			new object[]
			{
				double.MaxValue,
				"0111111111101111111111111111111111111111111111111111111111111111"
			},
			new object[]
			{
				double.Epsilon,
				"0000000000000000000000000000000000000000000000000000000000000001"
			},
			new object[]
			{
				double.NaN,
				"1111111111111000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				double.NegativeInfinity,
				"1111111111110000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				double.PositiveInfinity,
				"0111111111110000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				-0.0,
				"1000000000000000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				0.0,
				"0000000000000000000000000000000000000000000000000000000000000000"
			}
		};
		private static object[] TestToBinary =
		{
			new object[]
			{
				new double[]
				{
					-255.255,
					255.255,
					4294967295.0,
				},
				new string[]
				{
					"1100000001101111111010000010100011110101110000101000111101011100",
					"0100000001101111111010000010100011110101110000101000111101011100",
					"0100000111101111111111111111111111111111111000000000000000000000"
				}
			}
		};

		private static object StringFilterLowerCase = new object[]
		{
			new object[]
			{
				new string[] {"Hello", "hello", "General kenobi", "general kenobi"},
				new string[] {"hello", "general kenobi"}
			},

			new object[]
			{
				new string[] {"HELLO", "hello", "THEre", "there"},
				new string[] {"hello", "there"}
			}
		};
		private static object IntFilterEven = new object[]
		{
			new object[]
			{
				new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
				new int[] {0, 2, 4, 6, 8}
			},

			new object[]
			{
				new int[] {10, 11, 22, 35, 48, 5544, 67, -7, -8, 9},
				new int[] {10, 22, 48, 5544, -8}
			}
		};
		private static object IntFilterNegative = new object[]
		{
			new object[]
			{
				new int[] {0, -1, -2, -3, 4, 5, -6, 7, -8, 9},
				new int[] {-1, -2, -3, -6, -8}
			},

			new object[]
			{
				new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
				new int[] {}
			}
		};
		private static object IntFilterPrime = new object[]
		{
			new object[]
			{
				new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
				new int[] {2, 3, 5, 7}
			}
		};


		[TestCaseSource("TestVerbal")]
		public void TransformToWordsMethod_DoubleArray_ReturnStringArray(double[] numbers, string[] expected)
		{
			string[] result = numbers.TransformTo(new TransformerDoubleToWord());

			Assert.IsTrue(Execute.CheckStringArrays(expected, result));
		}

		[TestCaseSource("TestBinary")]
		public void DoubleToBinMethod_Double_StringDoubleInBin(double number, string expected)
		{
			string result = number.DoubleToBinaryString();

			Assert.IsTrue(expected.Equals(result));
		}

		[TestCaseSource("TestToBinary")]
		public void TransformToBinary_DoubleArray_ReturnStringArray(double[] numbers, string[] expected)
		{
			string[] result = numbers.TransformTo(new TransformerDoubleToIEEEFormat());

			Assert.IsTrue(Execute.CheckStringArrays(expected, result));
		}

		[TestCaseSource("TestToBinary")]
		public void TransformToBinary_DoubleArrayAndDelegate_ReturnStringArray(double[] numbers, string[] expected)
		{
			string[] actual = numbers.TransformTo(new TransformerDoubleToIEEEFormat().Transform);

			Assert.IsTrue(Execute.CheckStringArrays(expected, actual));
		}

		[TestCaseSource("StringFilterLowerCase")]
		public void FilterExtension_StringLowerCaseFilter_FilteredArray(string[] numbers, string[] expected)
		{
			string[] actual = numbers.Filter(StringFilter.LowerCase);

			Assert.IsTrue(Execute.CheckStringArrays(expected, actual));
		}

		[TestCaseSource("IntFilterEven")]
		public void FilterExtension_IntEvenFilter_FilteredArray(int[] numbers, int[] expected)
		{
			int[] actual = numbers.Filter(IntFilter.Even);

			CollectionAssert.AreEqual(expected, actual);
		}

		[TestCaseSource("IntFilterNegative")]
		public void FilterExtension_IntNegativeFilter_FilteredArray(int[] numbers, int[] expected)
		{
			int[] actual = numbers.Filter(IntFilter.Negative);

			CollectionAssert.AreEqual(expected, actual);
		}

		[TestCaseSource("IntFilterPrime")]
		public void FilterExtension_IntPrimeFilter_FilteredArray(int[] numbers, int[] expected)
		{
			int[] actual = numbers.Filter(IntFilter.Prime);

			CollectionAssert.AreEqual(expected, actual);
		}
	}

	class Execute
	{
		public static bool CheckStringArrays(string[] a, string[] b)
		{
			bool isTrue = true;

			for (int i = 0; (i < a.Length) && isTrue; i++)
			{
				isTrue = a[i].Equals(b[i]);
			}

			return isTrue;
		}
	}
}
