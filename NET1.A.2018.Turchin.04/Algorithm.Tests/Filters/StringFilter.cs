namespace Algorithm.Tests.Filters
{
	public static class StringFilter
	{
		/*public static bool Length(string element)
		{
			const int length = 5;

			return (element.Length >= length);
		}*/

		public static bool LowerCase(string element)
		{
			string lowerCase = element.ToLower();

			return (element.Equals(lowerCase));
		}
	}
}
