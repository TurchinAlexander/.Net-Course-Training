using System;

namespace JaggedArray.Delegates
{
	/// <summary>
	/// Represent all delegates which the project has.
	/// </summary>
	public static class DelegateType
	{
		/// <summary>
		/// Delegate which contains method to compare two arrays.
		/// </summary>
		/// <param name="a">First array.</param>
		/// <param name="b">Second array.</param>
		/// <returns>Greater than 0, if <paramref name="a"/> > <paramref name="b"/>. 0 if equals.
		/// And less than 0, if <paramref name="a"/> < <paramref name="b"/>.</returns>
		public delegate int Comparer(int[] a, int[] b);
	}
}
