using System;
using NUnit.Framework;

namespace Algorithms
{
	public class OptimizedQuickSort
	{
		private void _swap(int[] arr, int a, int b)
		{
			int temp = arr[a];
			arr[a] = arr[b];
			arr[b] = temp;
		}
		public OptimizedQuickSort()
		{

		}

		public void QuickSort(int[] arr)
		{
			_quickSort(arr, 0, arr.Length - 1);
		}

		private void _quickSort(int[] arr, int left, int right)
		{
			int midIndex = (left + right) / 2;
			int pivotValue = arr[midIndex];
			int i = left;
			int j = right;

			while (i <= j)
			{
				while (arr[i] <= pivotValue)
				{
					i++;
				}
				while (arr[j] >= pivotValue)
				{
					j--;
				}

				if (i < j)
				{
					// swap
					_swap(arr, i, j);
					i++;
					j--;
				}
			}

			if (left < j)
			{
				_quickSort(arr, left, j);
			}
			if (i < right)
			{
				_quickSort(arr, i, right);
			}
		}
	}

	[TestFixture]
	public class OptimizedQuickSort_Tests
	{
		[Test]
		public void OptimizedQuickSort_Test()
		{
			var arr = new int[5] { 2, 4, 3, 5, 1 };
			OptimizedQuickSort oqs = new OptimizedQuickSort();
			oqs.QuickSort(arr);

			foreach(var r in arr)
			{
				Console.Write(r);
			}
		}
	}
}
