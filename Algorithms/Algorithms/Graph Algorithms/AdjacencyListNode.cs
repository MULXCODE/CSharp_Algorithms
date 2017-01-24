using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph_Algorithms
{
    /// <summary>
    /// http://www.geeksforgeeks.org/graph-and-its-representations/
    /// </summary>
    public class AdjacencyListNode
    {
        public int Dest { get; set; }
        public AdjacencyListNode Next { get; set; }
    }

    public class AdjacencyList
    {
        public AdjacencyListNode Head { get; set; }
    }

    public class Graph
    {
        public int V { get; set; }
        public AdjacencyListNode Nodes { get; set; }
    }
}
