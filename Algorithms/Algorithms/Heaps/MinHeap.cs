using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
	public class MinHeap<T> where T : IComparable
	{
		private List<T> _data = new List<T>();

		public void Insert(T o)
		{
			_data.Add(o);

			int i = _data.Count - 1;

			while (i > 0)
			{
				// Reference to parent (even or odd indices)
				int j = (i + 1) / 2 - 1;

				// Check if the invariant holds for the element in data[i]  
				T v = _data[j];
				if (v.CompareTo(_data[i]) < 0 || v.CompareTo(_data[i]) == 0)
				{
					break;
				}

				// Swap the elements  
				T tmp = _data[i];
				_data[i] = _data[j];
				_data[j] = tmp;

				// check the next parent up the heap
				i = j;
			}
		}

		/// <summary>
		/// Extracts the min / top element and runs heapify on the remainder of the heap
		/// </summary>
		/// <returns>The minimum.</returns>
		public T ExtractMin()
		{
			if (_data.Count == 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			T min = _data[0];
			_data[0] = _data[_data.Count - 1];
			_data.RemoveAt(_data.Count - 1);
			this.MinHeapify(0);
			return min;
		}

		/// <summary>
		/// Get top element
		/// </summary>
		/// <returns>The peek.</returns>
		public T Peek()
		{
			return _data[0];
		}

		public int Count
		{
			get { return _data.Count; }
		}

		/// <summary>
		/// Internal method to heapify the remaining
		/// </summary>
		/// <param name="i">The index.</param>
		private void MinHeapify(int i)
		{
			int smallest;
			int l = 2 * (i + 1) - 1;		// left child
			int r = 2 * (i + 1) - 1 + 1;	// right child

			// ensure left in bounds and the data val at [l] is less than [i], either use index 1 or 0
			if (l < _data.Count && 
			    (_data[l].CompareTo(_data[i]) < 0))
			{
				smallest = l;
			}
			else
			{
				smallest = i;
			}

			// if _data[r] is less than _data[smallest]
			if (r < _data.Count && 
			    (_data[r].CompareTo(_data[smallest]) < 0))
			{
				smallest = r;
			}

			// swap is smallest is new
			if (smallest != i)
			{
				T tmp = _data[i];
				_data[i] = _data[smallest];
				_data[smallest] = tmp;

				this.MinHeapify(smallest); // heapify down the rest of the tree
			}
		}
	}

	[TestFixture]
	public class MinHeap_Tests
	{
		[Test]
		public void MinHeap_Test()
		{
			var minHeap = new MinHeap<int>();

			minHeap.Insert(5);
			minHeap.Insert(3);
			minHeap.Insert(1);
			minHeap.Insert(4);
			minHeap.Insert(2);

			var result = minHeap.ExtractMin();

			Assert.That(result, Is.EqualTo(1));

			var secondResult = minHeap.ExtractMin();

			Assert.That(secondResult, Is.EqualTo(2));
		}
	}
}
