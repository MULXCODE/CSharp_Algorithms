using Algorithms.DynamicProgramming;
using System;

namespace Algorithms.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci f = new Fibonacci();

            int n = 8;
            
            var result = f.Compute(n);

            Console.WriteLine($"The {n}th fibonacci number is: {result}");
        }
    }
}
