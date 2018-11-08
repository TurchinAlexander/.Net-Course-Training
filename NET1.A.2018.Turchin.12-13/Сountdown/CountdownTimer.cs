using System;
using System.Timers;

namespace Сountdown
{
	/// <summary>
	/// Timer which works one time.
	/// </summary>
    public class CountdownTimer
	{
		public event EventHandler<string> NewMail = delegate { };

		/// <summary>
		/// Creation of <see cref="CountdownTimer"/> and hidden <see cref="Timer"/>.
		/// </summary>
		/// <param name="time">Time in milliseconds.</param>
		public CountdownTimer(int time)
		{
			Timer timer = new Timer(time);

			timer.Elapsed += OnTimer;
			timer.Enabled = true;
			timer.AutoReset = false;
		}

		/// <summary>
		/// Notify all observers.
		/// </summary>
		/// <param name="observer">Observers.</param>
		protected virtual void Notify(string message)
		{
			NewMail(this, message);
		}

		/// <summary>
		/// Handler of the timer.
		/// </summary>
		/// <param name="sender">Who send event.</param>
		/// <param name="e">Parameters.</param>
		private void OnTimer(object sender, ElapsedEventArgs e)
		{
			string message = "Timer is done";
			Notify(message);
		}
    }
}
