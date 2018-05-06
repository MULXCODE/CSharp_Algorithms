using System;
using NUnit.Framework;

namespace Algorithms.DynamicProgramming
{
    public class Fibonacci
    {
        private int[] _fibCache;

        public Fibonacci()
        {
            _fibCache = new int[64];    
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

    [Category("Fib Test")]
    [TestFixture]
    public class Fibonacci_Tests {

        [Test]
        public void Fibonacci_Test() 
        {
            var fibonacciComputer = new Fibonacci();

            var res = fibonacciComputer.Compute(33);

            Assert.That(res, Is.Not.Null);
        }

    }
}
