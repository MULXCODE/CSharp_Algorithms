using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
	public class BFSTests
	{
		[Test]
		public void BFS_Test()
		{
			var graph = GraphSeeder.GetTestStructure();

			BFS bfs = new BFS(graph);
			bfs.Search();
		}
	}

	public class GraphSeeder
	{
		public static Graph<string> GetTestStructure()
		{
			var graph = new Graph<string>();

			graph.AddNode("Privacy.htm");
			graph.AddNode("People.aspx");
			graph.AddNode("About.htm");
			graph.AddNode("Index.htm");
			graph.AddNode("Products.aspx");
			graph.AddNode("Contact.aspx");

			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("People.aspx"), (GraphNode<string>)graph.Nodes.FindByValue("Privacy.htm"), 0);

			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("Privacy.htm"), (GraphNode<string>)graph.Nodes.FindByValue("Index.htm"), 0);
			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("Privacy.htm"), (GraphNode<string>)graph.Nodes.FindByValue("About.htm"), 0);

			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("About.htm"), (GraphNode<string>)graph.Nodes.FindByValue("Privacy.htm"), 0);
			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("About.htm"), (GraphNode<string>)graph.Nodes.FindByValue("People.aspx"), 0);
			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("About.htm"), (GraphNode<string>)graph.Nodes.FindByValue("Contact.aspx"), 0);

			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("Index.htm"), (GraphNode<string>)graph.Nodes.FindByValue("About.htm"), 0);
			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("Index.htm"), (GraphNode<string>)graph.Nodes.FindByValue("Contact.aspx"), 0);
			graph.AddDirectedEdge((GraphNode<string>)graph.Nodes.FindByValue("Index.htm"), (GraphNode<string>)graph.Nodes.FindByValue("Products.aspx"), 0);
			//web.AddDirectedEdge((GraphNode<string>)web.Nodes.FindByValue("Products.aspx" }, web.Nodes.FindByValue("Index.htm" }, 0);
			//web.AddDirectedEdge((GraphNode<string>)web.Nodes.FindByValue("Products.aspx" }, web.Nodes.FindByValue("People.aspx" }, 0);

			return graph;
		}
	}

	public class BFS
	{
		public void Search(Graph<string> graph)
		{
			// Mark all vertices as not visited (by default, set to false)
			var visited = new HashSet<Node<string>>();

			// Create queue for BFS
			var queue = new List<Node<string>>();

			// Mark current node as visted and enqueue
			var startNode = graph.Nodes.FindByValue("People.aspx");
			visited.Add(startNode);
			queue.Add(startNode);

			while (queue.Count != 0)
			{
				// Dequeue a vertex from queue and print it
				var node = (GraphNode<string>)queue[0];
				queue.RemoveAt(0);

				Debug.Write(node.Value + " ");

				// Get all adjacent vertices of the dequeued vertex s
				// If a adjacent has not been visited, then mark it
				// visited and enqueue it
				foreach (var neighborNode in node.Neighbors)
				{
					if (!visited.Contains(neighborNode))
					{
						visited.Add(neighborNode);
						queue.Add(neighborNode);
					}
				}
			}

		}
	}



}
