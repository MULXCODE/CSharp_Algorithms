using System;
using System.Collections.Generic;
using Algorithms;
using NUnit.Framework;

namespace Algorithms
{
	public class Node<K, V>
	{
		public K Key { get; set; }
		public V Value { get; set; }
		public Node<K, V> Next;
		public Node<K, V> Previous;

		public Node()
		{

		}
		public Node(K k, V v, Node<K, V> next, Node<K, V> prev)
		{
			Key = k;
			Value = v;
			Next = next;
			Previous = prev;
		}
	}
	public class LinkedList<K, V>
	{
		public Node<K, V> First { get; set; }
		public Node<K, V> Last { get; set; }
		public int Count { get; private set; }

		public LinkedList()
		{
			First = null;
			Last = null;
			Count = 0;
		}
		public LinkedList(Node<K, V> first)
		{
			First = first;
			Last = first;
			Count = 1;
		}

		public Node<K, V> AddFirst(K key, V val)
		{
			var n = new Node<K>();
			var newNode = new Node<K, V>(key, val, null, null);
			return AddFirst(newNode);
		}

		public Node<K, V> AddFirst(Node<K, V> node)
		{
			if (First == null)
			{
				First = node;
				Last = node;
				Count++;
				return node;
			}

			node.Next = First;
			First = node;
			Count++;

			return node;
		}

		public Node<K, V> Add(K key, V val)
		{
			var n = new Node<K>();
			var newNode = new Node<K, V>(key, val, null, null);
			return Add(newNode);
		}
		public Node<K, V> Add(Node<K, V> node)
		{
			if (First == null)
			{
				First = node;
				Last = node;
				Count++;
				return node;
			}

			Last.Next = node;
			Last = Last.Next;
			Count++;

			return node;
		}

		public Node<K, V> Remove(Node<K, V> node)
		{
			if (node == null) return null;

			var previousNode = node.Previous;
			var nextNode = node.Next;
			if (previousNode != null)
			{
				previousNode.Next = nextNode;
				nextNode.Previous = previousNode;
				Count--;

				// check to see if we need to adjust last node
				if (node == Last)
				{
					Last = previousNode;
				}
			}
			else if (nextNode != null) // && previousNode == null
			{
				// this must be the first node
				First = nextNode;
				Count--;
			}
			else // both are null
			{
				First = null;
				Last = null;
				Count--;
			}
			return node;
		}

		public Node<K, V> RemoveLast()
		{
			var lastNode = Last;
			if (lastNode == null) return null;

			return Remove(lastNode);
		}
	}

	/// <summary>
	/// LRU - Last Recently Used Cache
	/// </summary>
	public class LRUCache<K, V>
	{
		/// <summary>
		/// This is an O(1) state access store
		/// </summary>
		/// <value>The key cache.</value>
		public Dictionary<K, Node<K, V>> _nodeMap { get; set; }

		/// <summary>
		/// The head value is the least recently used
		/// </summary>
		/// <value>The priority queue.</value>
		public LinkedList<K, V> _queue { get; set; }

		/// <summary>
		/// The maximum capacity of the Priority Queue
		/// </summary>
		private int _capacity;

		/// <summary>
		/// Tracks the current size of the cache
		/// </summary>
		private int _count;
		public int Count
		{
			get
			{
				return _count;
			}
		}


		public LRUCache()
		{
			_nodeMap = new Dictionary<K, Node<K, V>>();
			_queue = new LinkedList<K, V>();
			_capacity = 10;
			_count = 0;
		}

		/// <summary>
		/// Adds an element to the cache.  KeyCache Add is a constant time operation.
		/// PriorityQueue Contains is an O(n) operation.
		/// PriorityQueue Remove is also an O(n) operation.  
		/// PrioirtyQueue AddLast is a constant time operation.
		/// </summary>
		/// <returns>The add.</returns>
		/// <param name="t">T.</param>
		public void Add(K key, V val)
		{
			if (_nodeMap.ContainsKey(key))
			{
				return;
			}

			// put the new node at the left most end of the linked-list
			var newNode = _queue.AddFirst(key, val);
			_nodeMap.Add(key, newNode);

			// delete the right-most entry and update the LRU pointer
			if (_queue.Count > _capacity)
			{
				var lastNode = _queue.Last;
				_nodeMap.Remove(lastNode.Key);
				_queue.RemoveLast();
			}
		}

		public V Get(K key)
		{
			if (!_nodeMap.ContainsKey(key))
			{
				return default(V);
			}

			var tempNode = _nodeMap[key];

			// update priority
			var previousNode = tempNode.Previous;
			var nextNode = tempNode.Next;

			if (previousNode != null)
			{
				previousNode.Next = nextNode;
				nextNode.Previous = previousNode;
			}

			_queue.Remove(tempNode);
			return _queue.AddFirst(tempNode).Value;
		}

		/// <summary>
		/// Contains the key in the cache
		/// </summary>
		/// <returns>The contains.</returns>
		/// <param name="t">T.</param>
		public bool Contains(K key)
		{
			return _nodeMap.ContainsKey(key);
		}

		/// <summary>
		/// Gets the top element
		/// </summary>
		/// <returns>The get.</returns>
		public V GetMostRecentlyUsed()
		{
			if (_queue.Count > 0)
			{
				return _queue.First.Value;
			}
			else
			{
				return default(V);
			}
		}

		/// <summary>
		/// Gets the least recently used element
		/// </summary>
		/// <returns>The least recently used.</returns>
		public V GetLeastRecentlyUsed()
		{
			if (_queue.Count > 0)
			{
				return _queue.Last.Value;
			}
			else
			{
				return default(V);
			}
		}
	}

	[TestFixture]
	public class LRUCache_Tests
	{
		[Test]
		public void LRUCache_Test()
		{
			var sut = new Algorithms.LRUCache<int, int>();

			for (int i = 1; i < 12; i++)
			{
				sut.Add(i, i + 1);
			}

			var val = sut.Get(1);
			var val2 = sut.Get(11);

			Assert.That(val, Is.EqualTo(0));
			Assert.That(val2, Is.EqualTo(12));

		}
	}
}
