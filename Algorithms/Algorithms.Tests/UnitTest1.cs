using Algorithms.DynamicProgramming;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }



        [Category("Fib Test")]
        [TestFixture]
        public class Fibonacci_Tests
        {
            [Test]
            public void Fibonacci_Test()
            {
                var fibonacciComputer = new Fibonacci();

                var res = fibonacciComputer.Compute(8);

                Assert.That(res, Is.Not.Null);
                Assert.AreEqual(res, 21);
            }

        }
    }
}