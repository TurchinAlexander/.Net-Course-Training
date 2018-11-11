namespace Algorithm.Interfaces
{
	/// <summary>
	/// Interface to transform.
	/// </summary>
	/// <typeparam name="TSource"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public interface ITransformer<in TSource, out TResult>
	{
		TResult Transform(TSource source);
	}
}
