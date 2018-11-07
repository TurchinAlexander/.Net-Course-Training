using System;

using Сountdown;
using Countdown.Interfaces;

namespace CheckTimer
{
	class Program
	{
		static void Main(string[] args)
		{
			Check check = new Check();
			int time = 2000;

			CountdownTimer timer = new CountdownTimer(time);
			timer.Register(check);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// Class which has method to catch information from timer.
	/// </summary>
	public class Check : IObserverTimer<string>
	{
		public void Update(object sender, string message)
		{
			Console.WriteLine(sender);
			Console.WriteLine(message);
		}
	}
}
