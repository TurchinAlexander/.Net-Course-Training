using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Interfaces
{
	/// <summary>
	/// Interface to compare two int values.
	/// </summary>
	public interface ICompare
	{
		/// <summary>
		/// Method to compare to int values.
		/// </summary>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		/// <returns><c> if we should swap elements. Otherwise, <c>false</c>.</returns>
		bool Compare(int a, int b);

		/// <summary>
		/// Method to indicate, what value we used to compare.
		/// </summary>
		/// <param name="array">Initial array.</param>
		/// <returns>The key value.</returns>
		int KeyValue(int[] array);
	}
}
