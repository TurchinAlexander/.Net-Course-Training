using System;

using Сountdown;

namespace CheckTimer
{
	class Program
	{
		static void Main(string[] args)
		{
			Check check = new Check();
			int time = 2000;

			CountdownTimer timer = new CountdownTimer(time);
			timer.NewMail += check.Update;

			Console.ReadKey();
		}
	}

	/// <summary>
	/// Class which has method to catch information from timer.
	/// </summary>
	public class Check
	{
		public void Update(object sender, string message)
		{
			Console.WriteLine(sender);
			Console.WriteLine(message);
		}
	}
}
