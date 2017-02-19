using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /// <summary>
    /// The Test class is the main class to clone
    /// </summary>
    public class Test
    {
        public int I { get; set; }
        public string S { get; set; }
        public Teacher T { get; set; }

        public Test ShallowCopy()
        {
            return (Test)this.MemberwiseClone();
        }
        public Test DeepCopy()
        {
            var t = (Test)this.MemberwiseClone();
            t.T = new Teacher()
            {
                Name = t.T.Name
            };
            return t;
        }
    }

    /// <summary>
    /// This is a class referenced by Test
    /// </summary>
    public class Teacher
    {
        public string Name { get; set; }
    }
    
    /// <summary>
    /// This is our execution harness
    /// </summary>
    public class CloningTests : IRunnable
    {
        public CloningTests()
        {

        }

        public void Run()
        {
            // create the main object test
            Test t = new Test()
            {
                I = 0,
                S = "Hi",
                T = new Teacher()
                {
                    Name = "Jon"
                }
            };
            // shallow copy
            Test t2 = t.ShallowCopy();
            t2.T.Name = "Jaime";
            t2.S = "No Way";
            // deep copy
            Test t3 = t.DeepCopy();
            t3.T.Name = "Trevor";
            t3.S = "X";

            Console.WriteLine(t.I + t.S + t.T.Name);
            Console.WriteLine(t2.I + t2.S + t2.T.Name);
            Console.WriteLine(t3.I + t3.S + t3.T.Name);
        }
    }
}
