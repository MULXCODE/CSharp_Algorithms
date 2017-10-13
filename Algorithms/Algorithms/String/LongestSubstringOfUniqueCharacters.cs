using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.String
{
    public class LongestSubstringOfUniqueCharacters
    {
        /// <summary>
        /// This function will find the longest substring of unique characters
        /// </summary>
        public LongestSubstringOfUniqueCharacters()
        {
        }

        public string Solve(string word) {
            var map = new Dictionary<char, int>(); // char represents the most recent character, int is the position of last occurence

            int maxLen = 0;
            int curLength = 0;
            int curStart = 0;
            int maxCurStart = 0;

            for (var i = 0; i < word.Length; i++)
            {
                var cur = word[i];

                if (!map.ContainsKey(cur))
                {
                    map.Add(cur, i);
                }
                else {
					// letter collision, let's start over and we can start from the postion in the map
					var pos = map[cur];
					if (maxLen < curLength)
					{
						maxLen = curLength;
						maxCurStart = curStart;
					}

                    curLength = i - pos - 1; // subtract one as we will still be incrementing this after this conditional

                    curStart = pos + 1;
				}

                curLength++;
			}

            if (maxLen < curLength) {
                maxLen = curLength;
                maxCurStart = word.Length - curLength;
            }

            return word.Substring(maxCurStart, maxLen);
        }
	}

    [Category("String Tests")]
    [TestFixture]
    public class LongestSubstringOfUniqueCharacters_Test
	{
		[Test]
		public void Test()
		{
            var lsouc = new LongestSubstringOfUniqueCharacters();
            var longest = lsouc.Solve("apple");
			Assert.That(longest, Is.EqualTo("ple"));
			
            var longest2 = lsouc.Solve("hogarrett");
			Assert.That(longest2, Is.EqualTo("hogar"));
		}
	}
}
