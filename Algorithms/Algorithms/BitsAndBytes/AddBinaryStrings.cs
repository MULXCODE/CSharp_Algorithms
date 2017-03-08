using System;
using NUnit.Framework;

namespace Algorithms
{
	public class AddBinaryStrings
	{
		public AddBinaryStrings() { }

		/// <summary>
		/// Adds two binary strings together.  "001" + "010" = "011"
		/// </summary>
		/// <returns>The added binary string result.</returns>
		/// <param name="binaryStr1">Binary str1.</param>
		/// <param name="binaryStr2">Binary str2.</param>
		public string Add(string binaryStr1, string binaryStr2)
		{
			int pointer1 = binaryStr1.Length - 1,
				pointer2 = binaryStr2.Length - 1;

			int carry = 0;
			string result = "";

			while (pointer1 >= 0 ||
				   pointer2 >= 0 ||
				   carry != 0)
			{
				int curSum = carry;
				carry = 0;

				curSum += (pointer1 >= 0) ? int.Parse(binaryStr1[pointer1].ToString()) : 0;
				curSum += (pointer2 >= 0) ? int.Parse(binaryStr2[pointer2].ToString()) : 0;

				if (curSum > 1)
				{
					curSum -= 2;
					carry = 1;
				}
				result = curSum.ToString() + result;

				pointer1--;
				pointer2--;
			}

			return result;
		}
	}

	[TestFixture]
	public class AddBinaryStrings_Tests
	{

		[Test]
		public void AddBinaryStrings_Test()
		{
			// 1st param is string1, string2 then expected result
			var testCases = new Tuple<string, string, string>[]
			{
				new Tuple<string, string, string>("110", "111", "1101"),
				new Tuple<string, string, string>("110", "001", "111"),
				new Tuple<string, string, string>("000", "010", "010"),
				new Tuple<string, string, string>("100", "001", "101")
			};

			var tester = new AddBinaryStrings();

			foreach (var testCase in testCases)
			{
				var str1 = testCase.Item1;
				var str2 = testCase.Item2;
				var expected = testCase.Item3;

				var result = tester.Add(str1, str2);

				Assert.AreEqual(expected, result);
			}
		}
	}
}
