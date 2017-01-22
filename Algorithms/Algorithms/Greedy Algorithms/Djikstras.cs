using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Greedy_Algorithms
{
    public class Djikstras
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="shortestPathSet"></param>
        /// <returns></returns>
        private const int V = 9;
        public int FindMinDistanceIndex(int[] dist, bool[] shortestPathSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (shortestPathSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Prints the distance array
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="n"></param>
        public void Print(int[] dist, int n)
        {
            Debug.WriteLine("Vertex Distance from Source");
            for (int i = 0; i < V; i++)
            {
                Debug.WriteLine(i + "\t\t" + dist[i]);
            }
        }

        /// <summary>
        /// Compute shortest paths for a graph represented by an adjacency matrix
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="srcIdx"></param>
        public void Compute(int[][] graph, int srcIdx)
        {
            // output array. dist[i] will hold the shortest path from srcIdx to i
            int[] minDistances = new int[V];

            // shortedPathSet[i] will be true if vertex i is included in shortest path tree
            bool[] shortestPathSet = new bool[V];

            // initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                minDistances[i] = int.MaxValue;
                shortestPathSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            minDistances[srcIdx] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices
                // not yet processed. u is always equal to src in first
                // iteration.
                int minIdx = FindMinDistanceIndex(minDistances, shortestPathSet);

                // Mark the picked vertex as processed
                shortestPathSet[minIdx] = true;

                // Update dist value of the adjacent vertices of the
                // picked vertex.
                for (int vIdx = 0; vIdx < V; vIdx++)

                    // Update dist[v] only if is not in sptSet, there is an
                    // edge from u to v, and total weight of path from src to
                    // v through u is smaller than current value of dist[v]
                    if (!shortestPathSet[vIdx] && graph[minIdx][vIdx] != 0 &&
                            minDistances[minIdx] != int.MaxValue &&
                            minDistances[minIdx] + graph[minIdx][vIdx] < minDistances[vIdx])
                    {
                        minDistances[vIdx] = minDistances[minIdx] + graph[minIdx][vIdx];
                    }
            }

            // print the constructed distance array
            Print(minDistances, V);
        }
    }

    [Category("Greedy Algorithms")]
    [TestFixture]
    public class DjikstrasTests
    {
        [Test]
        public void Test_Djikstras()
        {
            /* Let us create the example graph discussed above */
            int[][] graph = new int[][]{
                                    new int[] {0, 4, 0, 0, 0, 0, 0, 8, 0},
                                    new int[] {4, 0, 8, 0, 0, 0, 0, 11, 0},
                                    new int[] {0, 8, 0, 7, 0, 4, 0, 0, 2},
                                    new int[] {0, 0, 7, 0, 9, 14, 0, 0, 0},
                                    new int[] {0, 0, 0, 9, 0, 10, 0, 0, 0},
                                    new int[] {0, 0, 4, 14, 10, 0, 2, 0, 0},
                                    new int[] {0, 0, 0, 0, 0, 2, 0, 1, 6},
                                    new int[] {8, 11, 0, 0, 0, 0, 1, 0, 7},
                                    new int[] {0, 0, 2, 0, 0, 0, 6, 7, 0}
                                 };
            Djikstras d = new Djikstras();
            d.Compute(graph, 0);
        }
    }
}
