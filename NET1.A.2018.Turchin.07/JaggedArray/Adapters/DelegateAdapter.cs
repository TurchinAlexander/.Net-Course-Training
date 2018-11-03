using JaggedArray.Interfaces;
using JaggedArray.Delegates;

namespace JaggedArray.Adapters
{
	/// <summary>
	/// Convert compare delegate to an interface.
	/// </summary>
	public class DelegateAdapter : IComparer
	{
		private DelegateType.Comparer _comparer;

		/// <summary>
		/// Constructor, which has comparer delegate.
		/// </summary>
		/// <param name="comparer"></param>
		public DelegateAdapter(DelegateType.Comparer comparer)
		{
			this._comparer = comparer;
		}

		/// <summary>
		/// Method to compare two int arrays.
		/// </summary>
		/// <param name="a">First array.</param>
		/// <param name="b">Second array.</param>
		/// <returns>Greater than 0, if <paramref name="a"/> > <paramref name="b"/>. 0 if equals.
		/// And less than 0, if <paramref name="a"/> < <paramref name="b"/>.</returns>
		public int Compare(int[] a, int[] b)
		{
			return _comparer(a, b);
		}
	}
}
