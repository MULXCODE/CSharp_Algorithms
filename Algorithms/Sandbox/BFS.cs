using System;
using System.Collections.Generic;

namespace Sandbox
{
    public class GraphTraversals : IRunnable
    {
        public int V { get; set; }
        public LinkedList<int>[] AdjacencyList { get; set; }

        public GraphTraversals()
        {

        }

        public GraphTraversals(int v)
        {
            V = v;
            AdjacencyList = new LinkedList<int>[v];
            for(int i = 0; i < v; i++)
            {
                AdjacencyList[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            AdjacencyList[v].AddLast(w);
        }
        
        /// <summary>
        /// Prints BFS traversal from source s
        /// http://www.geeksforgeeks.org/breadth-first-traversal-for-a-graph/
        /// </summary>
        /// <param name="s"></param>
        public void BFS(int s)
        {
            // mark all vertices as not visited by default
            var visited = new bool[V];

            // create a queue
            var queue = new LinkedList<int>();

            // mark the current node as visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);

            while(queue.Count != 0)
            {
                // dequeue a vertex from queue and printi t
                s = queue.First.Value;
                queue.RemoveFirst();
                Console.Write(s + " ");

                // get all adjacent vertices of the dequeued vertex s
                // if a adjacent has not been visited then mark it as visited and enqueue it
                var enumerator = AdjacencyList[s].GetEnumerator();
                while(enumerator.MoveNext())
                {
                    int n = enumerator.Current;
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.AddLast(n);
                    }
                }
            }
        }

        /// <summary>
        /// Prints DFS traversal from source s
        /// http://www.geeksforgeeks.org/depth-first-traversal-for-a-graph/
        /// </summary>
        /// <param name="s"></param>
        public void DFS(int s)
        {
            bool[] visited = new bool[V];

            DFSRecurse(s, visited);
        }
        public void DFSRecurse(int v, bool[] visited)
        {
            // mark current node
            visited[v] = true;
            Console.Write(v + " ");

            var enumerator = AdjacencyList[v].GetEnumerator();
            while (enumerator.MoveNext())
            {
                var neighbor = enumerator.Current;

                if (!visited[neighbor])
                {
                    DFSRecurse(neighbor, visited);
                }
            }
        }

        public void Run()
        {
            GraphTraversals g = new GraphTraversals(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 2)");

            g.BFS(2);

            Console.WriteLine("Following is Depth First Traversal " +
                               "(starting from vertex 2)");
            g.DFS(2);
        }
    }
}
