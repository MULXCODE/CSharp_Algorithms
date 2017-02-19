using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
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


        public static class ReflectiveEnumerator
        {
            static ReflectiveEnumerator() { }

            /// <summary>
            /// Ensure that type T contains a parameterless constructor
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static IEnumerable<T> GetEnumerableOfType<T>() where T : class
            {
                return from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(T))
                               && t.GetConstructor(Type.EmptyTypes) != null
                       select Activator.CreateInstance(t) as T;
            }
        }
    }
}
