using System;
using NUnit.Framework;

namespace Algorithms
{
	/// <summary>
	/// https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore%E2%80%93Horspool_algorithm
	/// http://www.mathcs.emory.edu/~cheung/Courses/323/Syllabus/Text/Matching-Boyer-Moore2.html
	/// </summary>
	public class BoyerMooreHorspool
	{
		public BoyerMooreHorspool()
		{
		}

		/// <summary>
		/// Computes the last occ.
		/// </summary>
		/// <returns>The last occ.</returns>
		/// <param name="pattern">pattern</param>
		public int[] Preprocess(string pattern)
		{
			const int ASCII_CHARSET_LENGTH = 128;

			int[] table = new int[ASCII_CHARSET_LENGTH]; // assume ASCII character set

			for (int i = 0; i < ASCII_CHARSET_LENGTH; i++)
			{
				table[i] = pattern.Length;
			}

			for (int i = 0; i < pattern.Length - 1; i++)
			{
				table[pattern[i]] = pattern.Length - 1 - i;
			}

			return table;
		}


		/// <summary>
		/// Returns the index of the first occurrence of the word
		/// </summary>
		/// <returns>The search.</returns>
		/// <param name="needle">Needle.</param>
		/// <param name="haystack">Haystack.</param>
		public int Search(string needle, string haystack)
		{
			int[] table = Preprocess(needle);

			int skip = 0;

			while (haystack.Length - skip >= needle.Length)
			{
				int i = needle.Length - 1;

				while (haystack[skip + i] == needle[i])
				{
					if (i == 0)
					{
						return skip;
					}
					i--;
				}

				skip = skip + table[haystack[skip + needle.Length - 1]];
			}

			return -1;
		}
	}

	[Category("String Tests")]
	[TestFixture]
	public class BoyerMooreHorspool_Tests
	{
		[Test]
		public void Test()
		{
			var bmh = new BoyerMooreHorspool();
			var firstIndex = bmh.Search("hello", "where am i goin to say hello to this young hello mahn");
			Assert.That(firstIndex, Is.EqualTo(23));
			firstIndex = bmh.Search("hello", "hello to this young hello mahn");
			Assert.That(firstIndex, Is.EqualTo(0));
			firstIndex = bmh.Search("hello", "helio to this young hello");
			Assert.That(firstIndex, Is.EqualTo(20));
			firstIndex = bmh.Search("hello", "elloho");
			Assert.That(firstIndex, Is.EqualTo(-1));
		}
	}
}
