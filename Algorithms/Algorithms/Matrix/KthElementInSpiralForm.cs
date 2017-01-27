using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Matrix
{
    public class KthElementInSpiralForm
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/print-kth-element-spiral-form-matrix/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindK(int[][] a, int n, int m, int k)
        {
            if (n < 1 || m < 1)
            {
                return -1;
            }

            if (k <= m)
            {
                return a[0][k - 1];
            }

            if (k <= (m+n-1))
            {
                return a[k - m][m - 1];
            }

            if (k <= (m+n-1+m-1))
            {
                return a[n - 1][m - 1 - (k - (m + n - 1))];
            }

            if (k <= (m+n-1+m-1+n-2))
            {
                return a[n - 1 - (k - (m + n - 1 + m - 1))][0];
            }

            return FindK(a, n - 2, m - 2, k - (2 * n + 2 * m - 4));

        }
    }
}
