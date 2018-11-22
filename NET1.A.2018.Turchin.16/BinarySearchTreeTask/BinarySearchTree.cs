using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTask
{
	public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private Node root = null;
		private IComparer<T> comparer;
		private int version = 0;

		public BinarySearchTree()
		{
			if (typeof(IComparable).IsAssignableFrom(typeof(T)) ||
				(typeof(IComparable<T>).IsAssignableFrom(typeof(T))))
			{
				comparer = Comparer<T>.Default;
			}
			else
			{
				throw new InvalidOperationException($"{nameof(T)} doesn't implement {nameof(IComparable)} or {nameof(IComparable<T>)}");
			}
		}

		public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
		{
			this.comparer = comparer;
			this.Add(collection);
		}

		public BinarySearchTree(IEnumerable<T> collection) : this()
		{
			this.Add(collection);
		}

		public BinarySearchTree(IComparer<T> comparer)
		{
			this.comparer = comparer;
		}

		

		/// <summary>
		/// Count of elements in the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Information if 
		/// </summary>
		public bool IsReadOnly => false;

		/// <summary>
		/// Add the element to the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <param name="item">The item, which should be added.</param>
		public void Add(T item)
		{
			Node prev = null;
			Node temp = root;
			while (temp != null)
			{
				int resultComparison = comparer.Compare(item, temp.value);
				prev = temp;
				temp = (resultComparison > 0)
					? temp.rightNode
					: temp.leftNode;
			}

			temp = new Node(item);
			SetConnection(prev, temp);
			

			this.Count++;
			this.version++;
		}

		/// <summary>
		/// Add the array of elements to the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <param name="collection">The array of elements.</param>
		public void Add(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException($"{nameof(collection)} cannot be null.");

			foreach(T item in collection)
			{
				this.Add(item);
			}
		}

		/// <summary>
		/// Clear the <see cref="BinarySearchTree{T}"/> from elements.
		/// </summary>
		public void Clear()
		{
			this.root = null;
			this.Count = 0;
			this.version++;
		}

		/// <summary>
		/// Check if the <see cref="BinarySearchTree{T}"/> has the <paramref name="item"/>.
		/// </summary>
		/// <param name="item">The item, which should check.</param>
		/// <returns><c>true</c>, if the <paramref name="item"/> contained. Otherwise, <c>false</c>.</returns>
		public bool Contains(T item)
		{
			Node temp = root;
			while(temp != null)
			{
				int resultComparison = comparer.Compare(item, temp.value);

				if (resultComparison == 0)
					return true;

				temp = (resultComparison > 0)
					? temp = temp.rightNode
					: temp = temp.leftNode;
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException($"{nameof(array)} cannot be null!");
			if (array.Length < Count)
				throw new ArgumentException($"{nameof(array.Length)} cannot be less than {Count}!");
			if (array.Length - arrayIndex < Count)
				throw new ArgumentException($"{nameof(arrayIndex)} cannot be greater than {array.Length - Count}");

			foreach(var element in this)
			{
				array[arrayIndex++] = element;
			}
		}

		/// <summary>
		/// Get enumerator to go through <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <returns>The <see cref="IEnumerator{T}"/>.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			int version = this.version;
			return InOrder(root).GetEnumerator();

			IEnumerable<T> InOrder(Node current)
			{
				Node temp = root;
				Stack<Node> stack = new Stack<Node>();

				while (true)
				{
					while ((temp != null) && (version == this.version))
					{
						stack.Push(temp);
						temp = temp.leftNode;
					}

					if (version != this.version)
					{
						throw new InvalidOperationException($"You cannot call {nameof(this.Add)} in foreach");
					}

					if (stack.Count == 0)
						break;

					temp = stack.Pop();
					yield return temp.value;

					temp = temp.rightNode;
				}
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Remove <see cref="Node"/> from the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <param name="item">The <see cref="Node"/> to remove.</param>
		/// <returns>
		/// <c>true</c>, if the node was removed. Otherwise,<c>false</c>. 
		/// <para>Also <c>false</c>, if the node was foundn't.</para>
		/// </returns>
		public bool Remove(T item)
		{
			if (!this.Contains(item))
				return false;

			Node temp = root;
			while (temp != null)
			{
				int resultComparison = comparer.Compare(item, temp.value);

				if (resultComparison == 0)
				{
					RemoveLogic(temp);
					this.Count--;
					this.version++;

					return true;
				}

				temp = (resultComparison > 0)
					? temp = temp.rightNode
					: temp = temp.leftNode;
			}

			return false;
		}

		/// <summary>
		/// Logic of removing the node form the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <param name="currentNode">The <see cref="Node"/> to delete.</param>
		private void RemoveLogic(Node currentNode)
		{
			if (currentNode.rightNode != null)
			{
				currentNode.value = currentNode.rightNode.value;
				currentNode = currentNode.rightNode;
			} 
			else if (currentNode.leftNode != null)
			{
				currentNode.value = currentNode.leftNode.value;
				currentNode = currentNode.leftNode;
			}

			currentNode = null;
		}

		public IEnumerable<T> PreOrder()
		{
			int version = this.version;
			return PreOrder(root);

			IEnumerable<T> PreOrder(Node current)
			{
				Node temp = root;
				Stack<Node> stack = new Stack<Node>();

				while (true)
				{
					while ((temp != null) && (version == this.version))
					{
						yield return temp.value;

						stack.Push(temp);
						temp = temp.leftNode;
					}

					if (version != this.version)
					{
						throw new InvalidOperationException($"You cannot call {nameof(this.Add)} in foreach");
					}

					if (stack.Count == 0)
						break;

					temp = stack.Pop();
					temp = temp.rightNode;
				}
			}
		}

		public IEnumerable<T> PostOrder()
		{
			int version = this.version;
			return PostOrder(root);

			IEnumerable<T> PostOrder(Node current)
			{
				Node temp = root;
				Stack<Node> stack = new Stack<Node>();

				while (true)
				{
					while ((temp != null) && (version == this.version))
					{
						stack.Push(temp);
						temp = temp.leftNode;
					}

					if (version != this.version)
					{
						throw new InvalidOperationException($"You cannot call {nameof(this.Add)} in foreach");
					}

					if (stack.Count == 0)
						break;

					temp = stack.Pop();
					temp = temp.rightNode;

					if (temp != null)
						yield return temp.value;
				}
			}
		}

		/// <summary>
		/// Represent each element in the <see cref="BinarySearchTree{T}"/>
		/// </summary>
		class Node
		{
			public T value;
			public Node rightNode;
			public Node leftNode;

			public Node(T value)
			{
				this.value = value;
				rightNode = null;
				leftNode = null;
			}
		}

		private void SetConnection(Node prev, Node temp)
		{
			if (prev != null)
			{
				if (comparer.Compare(temp.value, prev.value) > 0)
				{
					prev.rightNode = temp;
				}
				else
				{
					prev.leftNode = temp;
				}
			}
			else
			{
				prev = temp;
				root = prev;
			}
		}
	}

	
}
