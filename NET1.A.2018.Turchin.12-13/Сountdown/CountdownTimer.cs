using System;
using System.Timers;

using Countdown.Interfaces;

namespace Сountdown
{
	/// <summary>
	/// Timer which works one time.
	/// </summary>
    public class CountdownTimer : IObservableTimer<string>
	{
		private event Action<object, string> notifier;

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
		/// Register a new observer.
		/// </summary>
		/// <param name="observer">The observer.</param>
		public void Register(IObserverTimer<string> observer)
		{
			notifier += observer.Update;
		}

		/// <summary>
		/// Unregister a new observer.
		/// </summary>
		/// <param name="observer">The observer.</param>
		public void Unregister(IObserverTimer<string> observer)
		{
			notifier -= observer.Update;
		}

		/// <summary>
		/// Notify all observers.
		/// </summary>
		/// <param name="observer">Observers.</param>
		protected virtual void Notify(string message)
		{
			notifier(this, message);
		}

		/// <summary>
		/// Implementation of <see cref="IObserver{T}"/> interface.
		/// </summary>
		/// <param name="message">The message.</param>
		void IObservableTimer<string>.Notify(string message)
		{
			Notify(message);
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
