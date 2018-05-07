using NUnit.Framework;

namespace Algorithms.DynamicProgramming
{
    public class Fibonacci
    {
        private int[] _fibCache;

        public Fibonacci()
        {
            _fibCache = new int[64];

            _fibCache[0] = 0;
            _fibCache[1] = 1;
            for (int i = 2; i < 64; i++)
            {
                _fibCache[i] = _fibCache[i - 1] + _fibCache[i - 2];
            }
        }

        public int Compute(int n) {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (_fibCache[n] == 0) {
                _fibCache[n] = _fibCache[n - 1] + _fibCache[n - 2];
            }

            return _fibCache[n];
        }
    }
}
