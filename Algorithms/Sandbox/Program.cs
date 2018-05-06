using System;

namespace Sandbox
{
    /// <summary>
    /// Main Entry Point into test harness
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var runSeries = ReflectiveEnumerator.GetEnumerableOfType<IRunnable>();

            foreach (var t in runSeries)
            {
                t.Run();
            }

            Console.ReadKey();
        }
    }
}
