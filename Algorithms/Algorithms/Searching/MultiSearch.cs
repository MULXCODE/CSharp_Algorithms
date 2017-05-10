using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Searching
{
    /// <summary>
    /// 17.17 - Multi Search: Given a string b, and an array of smaller strings T, design a method to 
    /// search b for each smaller string in T
    /// 
    /// T = {"is", "ppi", "hi", "sis", "i", "ssippi"}
    /// b = "mississippi"
    /// </summary>
    public class MultiSearch
    {
        public Dictionary<string, List<int>> Find(string b, string[] T)
        {
            var lookup = new Dictionary<string, List<int>>();

            foreach (var small in T)
            {
                var locations = _search(b, small);
                lookup.Add(small, locations);
            }

            return lookup;
        }

        private List<int> _search(string big, string small)
        {
            var locations = new List<int>();

            for (int i = 0; i < big.Length - small.Length + 1; i++)
            {
                if (_isSubstringAtLocation(big, small, i))
                {
                    locations.Add(i);
                }
            }
            return locations;
        }

        private bool _isSubstringAtLocation(string big, string small, int offset)
        {
            for (int i = 0; i < small.Length; i++)
            {
                if (big[offset + i] != small[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    [TestFixture]
    public class MultiSearch_Tests
    {
        [Test]
        public void MultiSearch_Test()
        {
            var ms = new MultiSearch();

            var resultSet = ms.Find("mississippi", new string[] { "is", "ppi", "hi", "sis", "i", "ssippi" });

            Assert.That(resultSet.Keys.Contains("is"), Is.True);
        }
    }
}
