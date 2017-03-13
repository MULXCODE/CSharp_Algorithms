using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms.Matrix
{
	/// <summary>
	/// This class implementation is similar to: 
	/// http://www.geeksforgeeks.org/gold-mine-problem/
	/// </summary>
    public class GoldmineMatrixPath
    {

		public GoldmineMatrixPath()
		{

		}


		public int GetShortestPath(int[][] arr, MatrixPoint start, MatrixPoint end)
		{
			var distances = GetDistancesArray(arr);

			return _getShortestPath(arr, distances, start, end, 0);
		}

		private int _getShortestPath(int[][] arr, int[][] distances, MatrixPoint start, MatrixPoint end, int curDistance)
		{
			// if out of bounds, return
			if (start.R < 0 || start.R >= arr.Length || start.C < 0 || start.C >= arr.Length)
			{
				return int.MaxValue;
			}

			// if already visited, return
			if (distances[start.R][start.C] != int.MaxValue) return int.MaxValue;

			// set distance to the shortest distance to this block
			distances[start.R][start.C] = Math.Min(distances[start.R][start.C], curDistance);

			var queue = new Queue<MatrixPoint>();
			queue.Enqueue(start); // enqueue first point

			while (queue.Count != 0)
			{

			}

			// breadth first to fill out entire distances matrix
			_getShortestPath(arr, distances, new MatrixPoint(start.R + 1, start.C), end, curDistance + 1);
			_getShortestPath(arr, distances, new MatrixPoint(start.R - 1, start.C), end, curDistance + 1);
			_getShortestPath(arr, distances, new MatrixPoint(start.R, start.C + 1), end, curDistance + 1);
			_getShortestPath(arr, distances, new MatrixPoint(start.R, start.C - 1), end, curDistance + 1);

			return distances[end.R][end.C];
		}

		public int[][] GetDistancesArray(int[][] arr)
		{
			int[][] distances = new int[arr.Length][];
			for (int i = 0; i < arr.Length; i++)
			{
				distances[i] = new int[arr[0].Length];
			}

			// default value
			for (int i = 0; i < distances.Length; i++)
			{
				for (int j = 0; j < distances[i].Length; j++)
				{
					distances[i][j] = int.MaxValue;
				}
			}

			return distances;
		}
	}

	public class MatrixPoint
	{
		public int R { get; set; }
		public int C { get; set; }

		public MatrixPoint(int r, int c)
		{
			R = r;
			C = c;
		}
	}


	[Category("Matrix Tests")]
	[TestFixture]
	public class GoldmineMatrixPath_Tests
	{
		[Test]
		public void GoldmineMatrixPath_Test()
		{
			var goldmineMatrixPath = new GoldmineMatrixPath();

			var arr = MatrixTestsGenerator.GetZeroedArray(5);

			// we have a 5x5 array of 0s
			// assume start is arr[1][0] and end is [4][2]

			var start = new MatrixPoint(1, 0);
			var end = new MatrixPoint(4, 2);

			var shortedPathLength = goldmineMatrixPath.GetShortestPath(arr, start, end);

			MatrixUtilities.Print(arr);
		}


	}
}
