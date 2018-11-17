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
		private Comparer<T> comparer;

		/// <summary>
		/// Creation of the <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		public BinarySearchTree()
		{
			this.comparer = Comparer<T>.Default;
		}

		/// <summary>
		/// Creation of the <see cref="BinarySearchTree{T}"/> of initial elements.
		/// </summary>
		/// <param name="collection"></param>
		public BinarySearchTree(IEnumerable<T> collection)
		{
			this.comparer = Comparer<T>.Default;
			this.Add(collection);
		}

		/// <summary>
		/// Creation of the <see cref="BinarySearchTree{T}"/> with <see cref="Comparer{T}"/>.
		/// </summary>
		/// <param name="thirdPartyComparer">The <see cref="Comparer{T}"/>.</param>
		public BinarySearchTree(Comparer<T> thirdPartyComparer)
		{
			this.comparer = thirdPartyComparer;
		}

		public BinarySearchTree(IEnumerable<T> collection, Comparer<T> thirdPartyComparer)
		{
			this.comparer = thirdPartyComparer;
			this.Add(collection);
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
				temp = (resultComparison >= 0)
					? temp.rightNode
					: temp.leftNode;
			}

			temp = new Node(item);
			if (prev != null)
			{
				if (comparer.Compare(item, prev.value) >= 0)
				{
					prev.rightNode = temp;
				}
				else
				{
					prev.leftNode = temp;
				}
			}

			if (root == null)
			{
				root = temp;
			}

			this.Count++;
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
				if(resultComparison == 0)
				{
					return true;
				}
				else if(resultComparison > 0)
				{
					temp = temp.rightNode;
				}
				else
				{
					temp = temp.leftNode;
				}
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

			throw new NotImplementedException();
		}

		/// <summary>
		/// Get enumerator to go through <see cref="BinarySearchTree{T}"/>.
		/// </summary>
		/// <returns>The <see cref="IEnumerator{T}"/>.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			foreach(T element in PreOrder(root))
			{
				yield return element;
			}

			IEnumerable<T> PreOrder(Node current)
			{
				if (current != null)
				{
					foreach (T element in PreOrder(current.leftNode))
					{
						yield return element;
					}

					yield return current.value;

					foreach (T element in PreOrder(current.rightNode))
					{
						yield return element;
					}
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
					return true;
				}
				else if (resultComparison > 0)
				{
					temp = temp.rightNode;
				}
				else
				{
					temp = temp.leftNode;
				}
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

		public IEnumerable<T> InOrder()
		{
			foreach(T element in InOrder(root))
			{
				yield return element;
			}

			IEnumerable<T> InOrder(Node current)
			{
				if (current != null)
				{
					yield return current.value;

					foreach (T element in InOrder(current.leftNode))
					{
						yield return element;
					}

					foreach (T element in InOrder(current.rightNode))
					{
						yield return element;
					}
				}
			}
		}

		public IEnumerable<T> PostOrder()
		{
			foreach (T element in PostOrder(root))
			{
				yield return element;
			}

			IEnumerable<T> PostOrder(Node current)
			{
				if (current != null)
				{ 
					foreach (T element in PostOrder(current.leftNode))
					{
						yield return element;
					}

					foreach (T element in PostOrder(current.rightNode))
					{
						yield return element;
					}

					yield return current.value;
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
	}

	
}
