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
	public interface IComparer
	{
		/// <summary>
		/// Method to compare two int arrays.
		/// </summary>
		/// <param name="a">First array.</param>
		/// <param name="b">Second array.</param>
		/// <returns>Greater than 0, if <paramref name="a"/> > <paramref name="b"/>. 0 if equals.
		/// And less than 0, if <paramref name="a"/> < <paramref name="b"/>.</returns>
		int Compare(int[] a, int[] b);
	}
}
