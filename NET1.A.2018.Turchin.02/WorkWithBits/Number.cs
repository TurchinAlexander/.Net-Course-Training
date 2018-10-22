using System;

namespace WorkWithBits
{
    /// <summary>
    /// Represent a class which contains method with bits.
    /// </summary>
    public static class Number
    {
        /// <summary>
        /// Insert bits in a range of <see cref="int"/>.
        /// </summary>
        /// <param name="numberSource">Where to put bits.</param>
        /// <param name="numberIn">From what take bits.</param>
        /// <param name="from">Right bound of the range.</param>
        /// <param name="to">Left bound of the range.</param>
        /// <returns><see cref="int"/> with bits put.</returns>
		public static int InsertBits(int numberSource, int numberIn, int from, int to)
		{
			const int IntBits = 32;

			CheckConditions(from, to, IntBits);

			int defaultMask, invertMask, result;
			bool isNegative = false;

			if (numberIn < 0)
			{
				if (to == IntBits - 1)
				{
					isNegative = true;
				}

				numberIn = -numberIn;
			}
			else if (numberSource < 0)
			{
				if (to != IntBits - 1)
				{
					isNegative = true;
				}

				numberSource = -numberSource;
			}

			defaultMask = int.MaxValue >> from;
			defaultMask = defaultMask << (IntBits - (to - from) + 1);
			defaultMask = defaultMask >> (IntBits - to + 1);

			numberIn = numberIn << from;

			invertMask = int.MaxValue - defaultMask;

			result = numberIn & defaultMask;
			result = result | (numberSource & invertMask);

			result *= (isNegative) ? -1 : 1;

			return result;
		}

		/// <summary>
		/// Checks input bounds.
		/// </summary>
		/// <param name="from">Right bound.</param>
		/// <param name="to">Left bound.</param>
		/// <param name="maxValue">Biggest value, that <paramref name="from"/> and <paramref name="to"/> can have.</param>
		private static void CheckConditions(int from, int to, int maxValue)
        {
            if (((from > maxValue) || (from < 0)) || 
				((to > maxValue) || (to < 0)) || 
				(from > to))
            {
                throw new ArgumentException();
            }
        }
    }
}
