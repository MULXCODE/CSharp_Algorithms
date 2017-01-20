using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// http://www.geeksforgeeks.org/greedy-algorithms-set-3-huffman-coding/
    /// </summary>
    [TestFixture]
    [Category("Greedy Algorithms")]
    public class HuffmanCodingTests
    {
        [Test]
        public void Test_HuffmanCoding()
        {
            char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f' };
            int[] freq = { 5, 9, 12, 13, 16, 45 };
            int size = arr.Length;
            MinHeap hc = new MinHeap();
            hc.HuffmanCodes(arr, freq, size);
        }
    }

    /// <summary>
    /// Huffman Tree Node
    /// </summary>
    public class MinHeapNode
    {
        public char Data { get; set; }
        public int Freq { get; set; }
        public MinHeapNode Left { get; set; }
        public MinHeapNode Right { get; set; }
    }

    /// <summary>
    /// Collection of Min Heap or Huffman Tree Nodess
    /// </summary>
    public class MinHeap
    {
        /// <summary>
        /// Current size of min heap
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Max capacity of heap
        /// </summary>
        public int Capacity { get; set; }
        public List<MinHeapNode> Nodes { get; set; }

        public MinHeapNode NewNode(char data, int freq)
        {
            var node = new MinHeapNode();
            node.Left = null;
            node.Right = null;
            node.Data = data;
            node.Freq = freq;
            Nodes = new List<MinHeapNode>();
            return node;
        }

        public MinHeap CreateMinHeap(int capacity)
        {
            MinHeap minHeap = new MinHeap();
            minHeap.Size = 0;
            minHeap.Capacity = capacity;
            minHeap.Nodes = new List<MinHeapNode>();

            return minHeap;
        }

        public void SwapMinHeapNode(List<MinHeapNode> nodes, int i, int j)
        {
            var temp = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = temp;
        }

        public void MinHeapify(MinHeap minHeap, int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < minHeap.Size && minHeap.Nodes[left].Freq < minHeap.Nodes[smallest].Freq)
            {
                smallest = left;
            }
            if (right < minHeap.Size && minHeap.Nodes[right].Freq < minHeap.Nodes[smallest].Freq)
            {
                smallest = right;
            }

            if (smallest != index)
            {
                SwapMinHeapNode(minHeap.Nodes, smallest, index);
                MinHeapify(minHeap, smallest);
            }
        }

        public bool IsSizeOne(MinHeap minHeap)
        {
            return minHeap.Size == 1;
        }

        public MinHeapNode ExtractMin(MinHeap minHeap)
        {
            var temp = minHeap.Nodes[0];
            minHeap.Nodes[0] = minHeap.Nodes[minHeap.Size - 1];
            minHeap.Size--;
            MinHeapify(minHeap, 0);
            return temp;
        }

        public void InsertMinHeap(MinHeap minHeap, MinHeapNode minHeapNode)
        {
            minHeap.Size++;
            minHeap.Nodes.Add(new MinHeapNode());
            int i = minHeap.Size - 1;
            while (i > 0 && minHeapNode.Freq < minHeap.Nodes[(i - 1) / 2].Freq)
            {
                minHeap.Nodes[i] = minHeap.Nodes[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            minHeap.Nodes[i] = minHeapNode;
        }

        public void BuildMinHeap(MinHeap minHeap)
        {
            int n = minHeap.Size - 1;
            for (int i = (n - 1) / 2; i >= 0; --i)
            {
                MinHeapify(minHeap, i);
            }
        }

        public void Print(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Write(arr[i]);
            }
            Debug.WriteLine("");
        }
        public bool IsLeaf(MinHeapNode root)
        {
            return root.Left == null && root.Right == null;
        }

        public MinHeap CreateAndBuildMinHeap(char[] data, int[] freq, int size)
        {
            MinHeap minHeap = CreateMinHeap(size);
            for (int i = 0; i < size; i++)
            {
                minHeap.Nodes.Add(
                    NewNode(data[i], freq[i]));
            }
            minHeap.Size = size;
            BuildMinHeap(minHeap);
            return minHeap;
        }

        public MinHeapNode BuildHuffmanTree(char[] data, int[] freq, int size)
        {
            MinHeapNode left, right, top;
            MinHeap minHeap = CreateAndBuildMinHeap(data, freq, size);

            while (!IsSizeOne(minHeap))
            {
                // extract two min freq items from min heap
                left = ExtractMin(minHeap);
                right = ExtractMin(minHeap);

                top = NewNode('$', left.Freq + right.Freq);
                top.Left = left;
                top.Right = right;
                InsertMinHeap(minHeap, top);
            }
            return ExtractMin(minHeap);
        }
        public void PrintCodes(MinHeapNode root, int[] arr, int top)
        {
            // assign 0 to left edge and recurse
            if (root.Left != null)
            {
                arr[top] = 0;
                PrintCodes(root.Left, arr, top + 1);
            }
            if (root.Right != null)
            {
                arr[top] = 1;
                PrintCodes(root.Right, arr, top + 1);
            }
            if (IsLeaf(root))
            {
                Debug.Write(root.Data + ": ");
                Print(arr, top);
            }
        }
        public void HuffmanCodes(char[] data, int[] freq, int size)
        {
            //  Construct Huffman Tree
            MinHeapNode root = BuildHuffmanTree(data, freq, size);

            int[] arr = new int[100];
            int top = 0;

            PrintCodes(root, arr, top);
        }

    }
}