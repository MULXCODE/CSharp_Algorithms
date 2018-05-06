using System;
using NUnit.Framework;

namespace Algorithms
{
	public interface FindKthSmallest
	{
		int FindKthSmallest(int[] arr, int k);
	}

	//http://www.geeksforgeeks.org/kth-smallestlargest-element-unsorted-array-set-2-expected-linear-time/
	public class KthSmallestElementInUnsorted : FindKthSmallest
	{
		public KthSmallestElementInUnsorted()
		{
		}

		/// <summary>
		/// Runtime O(n * log(n))
		/// </summary>
		/// <returns>The kth smallest.</returns>
		/// <param name="arr">Arr.</param>
		/// <param name="k">K.</param>
		public int FindKthSmallest(int[] arr, int k)
		{
			// push into a heap
			var minHeap = new MinHeap<int>();

			for (var i = 0; i < arr.Length; i++)
			{
				minHeap.Insert(arr[i]);
			}

			// what is insert run time for a heap - log(n)
			var min = int.MaxValue;
			for (int i = 0; i < k; i++)
			{
				min = minHeap.ExtractMin();
			}

			return min;
		}
	}

	public class Quickselect : FindKthSmallest
	{
		/// <summary>
		/// Average runtime O(n)
		/// Worstcase O(n^2)
		/// </summary>
		/// <returns>The kth smallest.</returns>
		/// <param name="arr">Arr.</param>
		/// <param name="k">K.</param>
		public int FindKthSmallest(int[] arr, int k)
		{
			return _kthSmallest(arr, 0, arr.Length - 1, k);
		}
		// This function returns k'th smallest element in arr[l..r]
		// using QuickSort based method.  ASSUMPTION: ALL ELEMENTS
		// IN ARR[] ARE DISTINCT
		private int _kthSmallest(int[] arr, int l, int r, int k)
		{
			// If k is smaller than number of elements in array
			if (k > 0 && k <= r - l + 1)
			{
				// Partition the array around a random element and
				// get position of pivot element in sorted array
				int pos = RandomPartition(arr, l, r);

				// If position is same as k
				if (pos - l == k - 1)
					return arr[pos];

				// If position is more, recur for left subarray
				if (pos - l > k - 1)
					return _kthSmallest(arr, l, pos - 1, k);

				// Else recur for right subarray
				return _kthSmallest(arr, pos + 1, r, k - pos + l - 1);
			}

			// If k is more than number of elements in array
			return int.MaxValue;
		}

		// Standard partition process of QuickSort().  It considers
		// the last element as pivot and moves all smaller element 
		// to left of it and greater elements to right. This function
		// is used by randomPartition()
		public int Partition(int[] arr, int l, int r)
		{
			int x = arr[r], i = l;
			for (int j = l; j <= r - 1; j++)
			{
				if (arr[j] <= x)
				{
					Swap(arr, i, j);
					i++;
				}
			}
			Swap(arr, i, r);
			return i;
		}

		// Picks a random pivot element between l and r and 
		// partitions arr[l..r] arount the randomly picked 
		// element using partition()
		public int RandomPartition(int[] arr, int l, int r)
		{
			int n = r - l + 1;
			var random = new Random();
			int pivot = (int)(random.NextDouble()) % n;
			Swap(arr, l + pivot, r);
			return Partition(arr, l, r);
		}

		public void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}

	[Category("Searching")]
	[TestFixture]
	public class KthSmallestElementInUnsorted_Tests
	{
		// Kth Smallest using a MinHeap
		[TestCase(new int[] { 7, 10, 4, 3, 20, 15 }, 3, 7)]
		[TestCase(new int[] { 7, 10, 4, 3, 20, 15 }, 4, 10)]
		public void KthSmallestElementInUnsorted_Test(int[] arr, int k, int expectedResult)
		{
			var kthSmallest = new KthSmallestElementInUnsorted();

			var res = kthSmallest.FindKthSmallest(arr, k);

			Assert.That(res, Is.EqualTo(expectedResult));
		}

		// Quickselect
		[Test]
		public void KthSmallestElementInUnsorted_Test()
		{
			Quickselect ob = new Quickselect();
			int[] arr = { 12, 3, 5, 7, 4, 19, 26 };
			int n = arr.Length, k = 3;
			Assert.That(ob.FindKthSmallest(arr, k), Is.EqualTo(5));
		}
	}
}
