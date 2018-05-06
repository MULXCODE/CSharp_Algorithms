using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Algorithms
{
	public class BinaryTree_CompressPath
	{
		private Dictionary<string, TreeNode> _visitedNodes = new Dictionary<string, TreeNode>();

		public BinaryTree_CompressPath()
		{
			_visitedNodes = new Dictionary<string, TreeNode>();
		}

		/// <summary>
		/// The tree might look like
		/// 
		/// 					10
		/// 			5				15
		/// 	3					5
		/// 					3
		/// 
		/// 	Reurns a compressed tree that may look like:
		/// 
		/// 				10
		/// 			  /		\
		/// 			 /		15
		/// 				 /
		/// 			5
		/// 		  /
		/// 		 3
		/// </summary>
		/// <returns>The path.</returns>
		/// <param name="root">Root.</param>
		public TreeNode CompressPath(TreeNode root)
		{
			if (root == null)
			{
				return null;
			}

			// compute path
			var path = ComputePath(root);

			if (!_visitedNodes.ContainsKey(path))
			{
				// add current node to visited list
				_visitedNodes.Add(path, root);
			}
			else
			{
				// we can return if we have already visited this
				return _visitedNodes[path];
			}

			// if we have already visited this node, then we can

			// created a visited list to track the paths that we have visited
			root.Left = CompressPath(root.Left);
			root.Right = CompressPath(root.Right);

			// find duplicate paths and hash
			return root;
		}

		/// <summary>
		/// returns a comma separated path
		/// </summary>
		/// <returns>The path.</returns>
		/// <param name="root">Root.</param>
		public string ComputePath(TreeNode root)
		{
			var s = _computePath(root, new StringBuilder());

			return s;
		}
		private string _computePath(TreeNode root, StringBuilder pathBuilder)
		{
			if (root == null) return "";
			pathBuilder.Append(root.Value + ",");
			_computePath(root.Left, pathBuilder);
			_computePath(root.Right, pathBuilder);
			return pathBuilder.ToString();
		}
	}


	[TestFixture]
	[Category("Tree Algorithms")]
	public class BinaryTree_CompressPath_Tests
	{
		[Test]
		public void DictionaryGeneratorTest()
		{
			var root = GenerateTree();

			var btcp = new BinaryTree_CompressPath();
			var result = btcp.CompressPath(root);

			Assert.That(result, Is.Not.Null);

		}

		public void Print(TreeNode root, int level)
		{
			if (root != null)
			{
				// padding
				var str = "";
				for (var i = -20; i < level; i++)
				{
					str += ' ';
				}

				Debug.WriteLine(str + root.Value);
				Print(root.Left, level - 3);
				Print(root.Right, level + 3);
			}
		}


		public TreeNode GenerateTree()
		{
			var root = new TreeNode();

			// root has a left and a right
			var n3 = new TreeNode()
			{
				Value = 3
			};
			var n2 = new TreeNode()
			{
				Value = 5,
				Left = n3
			};

			var n8 = new TreeNode()
			{
				Value = 3
			};
			var n6 = new TreeNode()
			{
				Value = 5,
				Left = n8
			};
			var n5 = new TreeNode()
			{
				Value = 15,
				Left = n6
			};
			var n4 = new TreeNode()
			{
				Value = 10,
				Left = n2,
				Right = n5
			};

			root = n4;

			return root;
		}
	}
}
