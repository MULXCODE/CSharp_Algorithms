using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// http://www.geeksforgeeks.org/greedy-algorithms-set-1-activity-selection-problem/
    /// </summary>
    [TestFixture]
    [Category("Greedy Algorithms")]
    public class ActivitySelectionTests
    {
        /// <summary>
        /// Consider the following 6 activities.
        /// start[]  =  {1, 3, 0, 5, 8, 5};
        /// finish[] =  {2, 4, 6, 7, 9, 9};
        /// The maximum set of activities that can be executed by a single person is {0, 1, 3, 4}
        /// </summary>
        [Test]
        public void Test_GetMaxActivities()
        {
            var result = (new ActivitySelection()).GetMaxActivities(new int[] { 1, 3, 0, 5, 8, 5 }, new int[] { 2, 4, 6, 7, 9, 9 }, 6);
            Assert.That(result, Is.EqualTo(new int[] { 0, 1, 3, 4 }));
        }
    }
    public class ActivitySelection
    {
        public List<int> GetMaxActivities(int[] s, int[] f, int n)
        {
            var list = new List<int>();

            int i = 0, j;
            list.Add(i);

            for (j = 1; j < n; j++)
            {
                if (s[j] >= f[i])
                {
                    list.Add(j);

                    i = j;
                }
            }

            return list;
        }

    }
}
