using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Algorithms
{
	public class MatrixUtilities
	{
		public static void Print(int[][] matrix)
		{
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					Debug.Write(matrix[i][j] + ", ");
				}

				Debug.WriteLine("");
			}
		}

		public static string ToString(int[][] matrix)
		{
			var sb = new StringBuilder();
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					sb.Append(matrix[i][j] + ", ");
				}

				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
	public class MatrixTestsGenerator
	{
		/// <summary>
		/// Returns a 5x5 test array with values 1 - 25
		/// </summary>
		/// <returns>The test array.</returns>
		public static int[][] GetTestArray()
		{
			return new int[][] 
			{
				new int[] { 1, 2, 3, 4, 5},
				new int[] { 6, 7, 8, 9, 10},
				new int[] { 11, 12, 13, 14, 15},
				new int[] { 16, 17, 18, 19, 20},
				new int[] { 21, 22, 23, 24, 25 }
			};
		}

		/// <summary>
		/// Returns a size x size array of all 0s 
		/// </summary>
		/// <returns>The test array.</returns>
		public static int[][] GetZeroedArray(int size)
		{
			var arr = new int[size][];
			for (var i = 0; i < size; i++)
			{
				arr[i] = new int[size];
			}
			return arr;
		}
	}
	public class MatrixBoardGenerator
	{
		
	}

	[TestFixture]
	public class MatrixUtilities_Tests
	{
		[Test]
		public void MatrixUtilities_Test()
		{
			var arr = MatrixTestsGenerator.GetTestArray();

			var result = MatrixUtilities.ToString(arr);

			Assert.That(result, Is.EqualTo(@"1, 2, 3, 4, 5, 
6, 7, 8, 9, 10, 
11, 12, 13, 14, 15, 
16, 17, 18, 19, 20, 
21, 22, 23, 24, 25, 
"));
		}
	}
}
