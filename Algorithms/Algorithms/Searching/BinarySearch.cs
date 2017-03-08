using System;
using NUnit.Framework;

namespace Algorithms
{
	public class BinarySearch
	{
		public BinarySearch()
		{
		}

		/// <summary>
		/// Assumption is that the array is sorted
		/// </summary>
		/// <returns>The index.</returns>
		/// <param name="arr">Sorted array.</param>
		/// <param name="val">Value.</param>
		public int FindIndex(int[] arr, int val)
		{
			int lo = 0;
			int hi = arr.Length - 1;

			return _binarySearch(arr, val, lo, hi);
		}

		private int _binarySearch(int[] arr, int val, int lo, int hi)
		{
			if (lo <= hi)
			{
				int midIndex = (lo + hi) / 2;
				int midValue = arr[midIndex];

				if (val == midValue)
				{
					return midIndex;
				}
				else if (val > midValue) // look on the right
				{
					return _binarySearch(arr, val, midIndex + 1, hi);
				}
				else // look on the left
				{
					return _binarySearch(arr, val, lo, midIndex - 1);
				}
			}

			return -1;
		}

		/// <summary>
		/// Returns the index of the range in which the val searched for occurs
		/// FindRangeSearch([(1,3), (4,6), (7,9)], 6) would return 1
		/// </summary>
		/// <returns>The range search.</returns>
		/// <param name="range">A sorted array of ranges</param>
		/// <param name="val">Value.</param>
		public int FindRangeIndex(Range[] arr, int val)
		{
			int lo = 0;
			int hi = arr.Length - 1;

			return _rangeBinarySearch(arr, val, lo, hi);
		}

		private int _rangeBinarySearch(Range[] arr, int val, int lo, int hi)
		{
			if (lo <= hi)
			{
				int midIndex = (lo + hi) / 2;
				Range midValue = arr[midIndex];

				if (midValue.Start <= val && val <= midValue.End)
				{
					return midIndex;
				}
				else if (val <= midValue.Start) // search left
				{
					return _rangeBinarySearch(arr, val, lo, midIndex - 1);
				}
				else // search right
				{
					return _rangeBinarySearch(arr, val, midIndex + 1, hi);
				}
			}

			return -1;
		}
	}

	public class Range
	{
		public int Start { get; set; }
		public int End { get; set; }
	}


	[TestFixture]
	public class BinarySearch_Tests
	{
		[Test]
		public void BinarySearch_FindIndex_Test()
		{
			var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			// (val, expectedIndex)
			var testCases = new Tuple<int, int>[]
			{
				new Tuple<int, int>(1, 1),
				new Tuple<int, int>(0, 0),
				new Tuple<int, int>(10, 10),
				new Tuple<int, int>(6, 6)
			};

			var binarySearcher = new BinarySearch();

			foreach (var testCase in testCases)
			{
				var result = binarySearcher.FindIndex(arr, testCase.Item1);

				Assert.That(result, Is.EqualTo(testCase.Item2));
			}
		}


		[Test]
		public void BinarySearch_FindRangeIndex_Test()
		{
			var arr = new int[] { 0, 2, 5, 7, 8, 10 };

			int LENGTH = 3;
			var rangeArray = new Range[LENGTH];
			for (int i = 0; i < rangeArray.Length; i++)
			{
				rangeArray[i] = new Range()
				{
					Start = arr[2 * i],
					End = arr[2 * i + 1]
				};
			}

			// (val, expectedIndex)
			var testCases = new Tuple<int, int>[]
			{
				new Tuple<int, int>(3, -1),
				new Tuple<int, int>(0, 0),
				new Tuple<int, int>(7, 1),
				new Tuple<int, int>(10, 2)
			};

			var binarySearcher = new BinarySearch();

			foreach (var testCase in testCases)
			{
				var result = binarySearcher.FindRangeIndex(rangeArray, testCase.Item1);

				Assert.That(result, Is.EqualTo(testCase.Item2));
			}
		}
	}
}
