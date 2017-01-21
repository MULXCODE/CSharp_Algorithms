using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Greedy_Algorithms
{
    /// <summary>
    /// http://quiz.geeksforgeeks.org/greedy-algorithm-to-find-minimum-number-of-coins/
    /// 
    /// Given a value V, if we want to make change for V Rs, 
    /// and we have infinite supply of each of the denominations in Indian currency, 
    /// i.e., we have infinite supply of { 1, 2, 5, 10, 20, 50, 100, 500, 1000} valued coins/notes, 
    /// what is the minimum number of coins and/or notes needed to make the change?
    /// 
    /// Input: V = 70
    /// Output: 2
    /// We need a 50 Rs note and a 20 Rs note.
    /// 
    /// Input: V = 121
    /// Output: 3
    /// We need a 100 Rs note, a 20 Rs note and a 
    /// 1 Rs coin. 
    /// 
    /// </summary>
    public class MinCoins
    {
        public int[] Currencies { get; set; }

        public MinCoins(int[] currencies)
        {
            Currencies = currencies;
        }

        public int[] MinChange(int val)
        {
            List<int> change = new List<int>();

            for (int i = Currencies.Length - 1; i >= 0; i--)
            {
                while (val >= Currencies[i])
                {
                    val -= Currencies[i];
                    change.Add(Currencies[i]);
                }
            }

            return change.ToArray();
        }


    }
}
