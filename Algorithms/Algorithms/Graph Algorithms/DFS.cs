using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
	public class DFSTests
	{
		[Test]
		public void DFS_Test()
		{
			//Graph2 g = new Graph2(4);

			//g.AddEdge(0, 1);
			//g.AddEdge(0, 2);
			//g.AddEdge(1, 2);
			//g.AddEdge(2, 0);
			//g.AddEdge(2, 3);
			//g.AddEdge(3, 3);

			//Debug.WriteLine("Following is Breadth First Traversal " +
			//				   "(starting from vertex 2)");

			//g.BreadthFirstSearch(2);
			var graph = GraphSeeder.GetTestStructure();

			DFS bfs = new DFS();
			bfs.Search("People.aspx", graph);
		}
	}


	public class DFS
	{
		public void Search(string startValue, Graph<string> graph)
		{
			Search(startValue, graph, new HashSet<Node<string>>());
		}

		public void Search(string startValue, Graph<string> graph, HashSet<Node<string>> visited)
		{
			var startNode = (GraphNode<string>)graph.Nodes.FindByValue(startValue);
			visited.Add(startNode);
			Debug.Write(startValue + " ");

			foreach (var neighborNode in startNode.Neighbors)
			{
				if (!visited.Contains(neighborNode))
				{
					Search(neighborNode.Value, graph, visited);
				}
			}

		}
	}



}
