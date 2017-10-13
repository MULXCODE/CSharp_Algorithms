using System;
using NUnit.Framework;

namespace Algorithms
{
	public class SequentialSearch : ISearch
    {
		public SequentialSearch()
		{
		}

        /// <summary>
        /// Find the index of a particular value in an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="val"></param>
        /// <returns></returns>
		public int FindIndex(int[] arr, int val)
		{
			for(var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == val)
                {
                    return i;
                }
            }
            return -1;
		}
	}

    [Category("Searching: SequentialSearch")]
	[TestFixture]
	public class SequentialSearch_Tests
    {
		[Test]
		public void SequentialSearch_FindIndex_Test()
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

			var searcher = new SequentialSearch();

			foreach (var testCase in testCases)
			{
				var result = searcher.FindIndex(arr, testCase.Item1);

				Assert.That(result, Is.EqualTo(testCase.Item2));
			}
		}
	}
}
