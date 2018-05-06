using System;
using NUnit.Framework;

namespace Algorithms.Sorts
{
	/// <summary>
	/// Question 43: Given an array that contains only 0, 1 or 2, sort it without using any sorting function
	/// input: 0, 1, 1, 0, 2, 1
	/// output: 0, 0, 1, 1, 1, 2
	/// </summary>
	public class Sort012
	{
		public void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}

		/// <summary>
		/// Sort an array of 0s, 1s and 2s
		/// 	Runtime: O(N)
		/// 	Space Complexity: O(1)
		/// </summary>
		/// <returns>A sorted array.</returns>
		/// <param name="arr">An array of 0s, 1s and 2s.</param>
		/// <param name="l">L.</param>
		/// <param name="h">The height.</param>
		public void Sort(int[] arr)
		{
			if (arr == null)
			{
				return;
			}
			int start = 0,
				mid = 0,
				end = arr.Length - 1;

			while (mid <= end)
			{
				switch (arr[mid])
				{
					case 0:
						Swap(arr, start, mid);
						start++;
						mid++;
						break;
					case 1:
						mid++;
						break;
					case 2:
						Swap(arr, mid, end);
						end--;
						break;
				}
			}
		}
	}

	/// <summary>
	/// Test multiple cases of 0, 1, 2 sort
	/// </summary>
	[TestFixture]
	public class Sort012_Tests
	{
		[Test]
		public void Sort012_Test()
		{
			var testCases = new int[][]
			{
				new int[] { 0, 2, 1, 2, 1, 2, 0 }, // 0s, 1s and 2s
				new int[] { 0, 0, 0 }, 	// all 0s
				new int[] {}, 			// no elements
				new int[] { 2, 2, 2 }, 	// only 2s
				new int[] { 1, 1, 1 }, 	// only 1s
				new int[] { 0, 0 },    	// only 0s
				new int[] { 2, 0, 0, 0, 0 } // start with 2 and only 0s
			};

			Sort012 sorter = new Sort012();
			foreach (var arr in testCases)
			{
				sorter.Sort(arr);

				if (!_allIncreasing(arr))
				{
					throw new Exception("Array not sorted");
				}
			}
		}

		private bool _allIncreasing(int[] arr)
		{
			if (arr == null || arr.Length == 0) return true;

			int index = 1;
			int prev = arr[0];
			while (index < arr.Length - 1)
			{
				if (arr[index] < prev)
				{
					return false;
				}
				prev = arr[index];
				index++;
			}
			return true;
		}
	}
}
