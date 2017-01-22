using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Dynamic_Programming
{
    /// <summary>
    /// http://www.geeksforgeeks.org/dynamic-programming-set-10-0-1-knapsack-problem/
    /// Given weights and values of n items, put these items in a knapsack of capacity W to get the 
    /// maximum total value in the knapsack.  In other words, given two integer arrays 
    /// val[0..n-1] and wt[0..n-1] which represent values and weights associated with n items respectively. 
    /// 
    /// Also given an integer W which represents knapsack capacity, 
    /// find out the maximum value subset of val[] such that sum of the weights of this subset is 
    /// smaller than or equal to W. You cannot break an item, either pick the complete item, 
    /// or don’t pick it (0-1 property).
    /// </summary>
    public class Knapsack0_1
    {
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        /// <summary>
        /// Maximize value given max weight
        /// </summary>
        /// <param name="W">max weight</param>
        /// <param name="wt">weights of items</param>
        /// <param name="val">values of items</param>
        /// <param name="n">number of items</param>
        /// <returns></returns>
        public int Compute(int W, int[] wt, int[] val, int n)
        {
            if (n == 0 || W == 0)
            {
                return 0;
            }
            
            if (wt[n-1] > W)
            {
                return Compute(W, wt, val, n - 1);
            }

            // return max of this item included or not included
            return Max(
                val[n - 1] + Compute(W - wt[n - 1], wt, val, n - 1),
                Compute(W, wt, val, n - 1));
        }
    }
}
