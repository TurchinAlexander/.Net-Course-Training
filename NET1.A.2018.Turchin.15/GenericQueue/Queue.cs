using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericQueue
{
	/// <summary>
	/// Represent the queue class.
	/// </summary>
	/// <typeparam name="T">Used type in the queue.</typeparam>
	public class QueueGeneric<T> : IEnumerable<T>, IEnumerable
	{
		private T[] _array;
		private int _head;
		private int _tail;

		private int _size;
		private int _version;
		private const int _standardSize = 5;

		/// <summary>
		/// Creation of the queue.
		/// </summary>
		public QueueGeneric()
		{
			_array = new T[_standardSize];
		}

		/// <summary>
		/// Creation of the <see cref="QueueGeneric{T}"/>.
		/// </summary>
		/// <param name="capacity">The capacity of the <see cref="QueueGeneric{T}"/>.</param>
		/// <exception cref="ArgumentOutOfRangeException">if capacity is negative.</exception>
		public QueueGeneric(int capacity)
		{
			if (capacity < 0)
				throw new ArgumentOutOfRangeException($"{nameof(capacity)} cannot be negative.");

			_array = new T[capacity];
		}

		/// <summary>
		/// Creation of the <see cref="QueueGeneric{T}"/>.
		/// </summary>
		/// <param name="collection">The collection of elements which will be taken to the <see cref="QueueGeneric{T}"/>.</param>
		/// <exception cref="ArgumentNullException">if collection is null.</exception>
		public QueueGeneric(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException($"{nameof(collection)} cannot be null.");

			_array = new T[_standardSize];

			foreach (var element in collection)
				Enqueue(element);
		}

		/// <summary>
		/// Put an item to the queue.
		/// </summary>
		/// <param name="item">The element to the queue.</param>
		public void Enqueue(T item)
		{
			if (_size == _array.Length)
			{
				SetCapacity(_size * 2);
			}

			_array[_tail] = item;
			_tail = (_tail + 1) % _array.Length;
			++_size;
			++_version;
		}

		/// <summary>
		/// Take an item from the queue.
		/// </summary>
		/// <returns>Last item from the queue.</returns>
		public T Dequeue()
		{
			if (_size == 0)
				throw new InvalidOperationException($"{_array} is empty.");

			T temp = _array[_head];
			_array[_head] = default(T);
			_head = (_head + 1) % _array.Length;
			--_size;
			++_version;

			return temp;
		}

		/// <summary>
		/// Show last item form the queue.
		/// </summary>
		/// <returns>Last item from the queue.</returns>
		public T Peek()
		{
			if (_size == 0)
				throw new InvalidOperationException($"{_array} is empty.");

			return _array[_tail - 1];
		}

		/// <summary>
		/// Verify if the queue contains the item.
		/// </summary>
		/// <param name="item">The item to verify.</param>
		/// <returns><c>true</c> if <paramref name="item"/> is contained. Otherwise, <c>false</c>.</returns>
		public bool Contains(T item)
		{
			int index = _head;
			int size = _size;
			EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;

			while (size-- > 0)
			{
				if ((object)item == null)
				{
					if ((object)this._array[index] == null)
						return true;
				}
				else if ((object)this._array[index] != null && equalityComparer.Equals(this._array[index], item))
					return true;

				index = (index + 1) % this._array.Length;
			}

			return false;
		}

		/// <summary>
		/// Take element from the queue by index.
		/// </summary>
		/// <param name="index">The index form the queue</param>
		/// <returns></returns>
		internal T GetElement(int index)
		{
			return _array[(_head + index) % _array.Length];
		}

		/// <summary>
		/// Get enumerator of the <see cref="QueueGeneric{T}"/>.
		/// </summary>
		/// <returns><see cref="Queue{T}.Enumerator"/>.</returns>
		public QueueGeneric<T>.Enumerator GetEnumerator()
		{
			return new QueueGeneric<T>.Enumerator(this);
		}

		/// <summary>
		/// Get enumerator of the <see cref="QueueGeneric{T}"/>.
		/// </summary>
		/// <returns><see cref="Queue{T}.Enumerator"/>.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return (IEnumerator<T>)new QueueGeneric<T>.Enumerator(this);
		}

		/// <summary>
		/// Get enumerator of the <see cref="QueueGeneric{T}"/>.
		/// </summary>
		/// <returns><see cref="Queue{T}.Enumerator"/>.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)new QueueGeneric<T>.Enumerator(this);
		}

		/// <summary>
		/// Convert the <see cref="QueueGeneric{T}"/> to the <see cref="Array"/>.
		/// </summary>
		/// <returns></returns>
		public T[] ToArray()
		{
			T[] objArray = new T[_size];

			if (_size == 0)
				return objArray;

			if (_head < _tail)
			{
				Array.Copy(_array, _head, objArray, 0, _size);
			}
			else
			{
				Array.Copy(_array, _head, objArray, 0, _array.Length - _head);
				Array.Copy(_array, 0, objArray, _array.Length - _head, _tail);
			}

			return objArray;
		}

		/// <summary>
		/// Set the capacity of the queue.
		/// </summary>
		/// <param name="capacity">Size of the queue.</param>
		private void SetCapacity(int capacity)
		{
			T[] objArray = new T[capacity];

			if (_size > 0)
			{
				if (_head < _tail)
				{
					Array.Copy(_array, this._head, objArray, 0, _size);
				}
				else
				{
					Array.Copy(_array, _head, objArray, 0, _array.Length - this._head);
					Array.Copy(_array, 0, objArray, _array.Length - this._head, this._tail);
				}
			}

			_array = objArray;
			_head = 0;
			_tail = _size;
			++_version;
		}

		/// <summary>
		/// Enumerator for the queue.
		/// </summary>
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private QueueGeneric<T> _q;
			private int _version;
			private int _index;

			private T _currentElement;

			/// <summary>
			/// Creation of the enumerator.
			/// </summary>
			/// <param name="q"><see cref="QueueGeneric{T}"/>.</param>
			public Enumerator(QueueGeneric<T> q)
			{
				_q = q;
				_version = q._version;
				_index = -1;

				_currentElement = default(T);
			}

			/// <summary>
			/// Get current element.
			/// </summary>
			public T Current
			{
				get
				{
					if (_index < 0)
						if (_index == -1)
							throw new InvalidOperationException("Iteration has not been started.");
						else
							throw new InvalidOperationException("Iteration has finished.");
					return _currentElement;
				}
			}

			object IEnumerator.Current { get => (object)Current; }

			/// <summary>
			/// Dispose the enumerator.
			/// </summary>
			public void Dispose()
			{
				this._index = -2;
				_currentElement = default(T);
			}

			/// <summary>
			/// Check if we have move.
			/// </summary>
			/// <returns><c>true</c> if we can move. Otherwise, <c>false</c>.</returns>
			public bool MoveNext()
			{
				if (_version != _q._version)
					throw new InvalidOperationException($"The {this._version} differs from {_q._version}");

				if (_index == -2)
					return false;

				++_index;

				if (_index == _q._size)
				{
					_index = -2;
					_currentElement = default(T);
					return false;
				}

				_currentElement = _q.GetElement(_index);
				return true;
			}

			/// <summary>
			/// Set enumerator to the beginning.
			/// </summary>
			public void Reset()
			{
				if (_index == -2)
					throw new InvalidOperationException("Iteration has finished.");

				_index = -1;
				_currentElement = default(T);
			}
		}
	}
}
