namespace Countdown.Interfaces
{
	/// <summary>
	/// Defines a provider for notification.
	/// </summary>
	/// <typeparam name="T">The object that provides notification information.</typeparam>
	public interface IObservableTimer<T>
	{
		/// <summary>
		/// Registers the observer
		/// </summary>
		/// <param name="observer">The object that is to receive notifications.</param>
		void Register(IObserverTimer<T> observer);

		/// <summary>
		/// Unregisters the observer
		/// </summary>
		/// <param name="observer">The object that is to receive notifications.</param>
		void Unregister(IObserverTimer<T> observer);

		/// <summary>
		/// Notifies the observer that the provider has raised event.
		/// </summary>
		///<param name="sender">The object that is to raised notifications.</param>
		///<param name="info">The current notification information.</param>
		void Notify(T info);
	}
}
