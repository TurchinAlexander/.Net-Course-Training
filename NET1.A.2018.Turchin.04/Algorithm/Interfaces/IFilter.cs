using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Interfaces
{
	/// <summary>
	/// Interface to filter smth by pattern.
	/// </summary>
	/// <typeparam name="TSource">Input type.</typeparam>
	public interface IFilter<in TSource>
	{
		bool IsValid(TSource source);
	}
}
