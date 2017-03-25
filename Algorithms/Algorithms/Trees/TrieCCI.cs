using System;
using System.Collections.Generic;

namespace Algorithms
{
	public class TrieCCI
	{
		// the root of the trie
		private TrieNodeCCI _root;

		public TrieCCI(List<string> list)
		{
			_root = new TrieNodeCCI();
			foreach(var word in list) {
				_root.AddWord(word);
			}
		}

		// take a list of strings as an argument and constructs a trie that stores these strings
		public TrieCCI(String[] list)
		{
			_root = new TrieNodeCCI();
			foreach (var word in list)
			{
				_root.AddWord(word);
			}
		}

		// checks whether this trie contains a prefix
		public bool Contains(string prefix, bool exact)
		{
			var lastNode = _root;

			for (int i = 0; i < prefix.Length; i++)
			{
				lastNode = lastNode.Neighbors[prefix[i]];
				if (lastNode == null)
				{
					return false;
				}
			}

			return !exact || lastNode.Terminates;
		}

	}

	public class TrieNodeCCI
	{
		public Dictionary<char, TrieNodeCCI> Neighbors { get; set; }
		public bool Terminates { get; set; }
		public char Letter { get; set; }

		public TrieNodeCCI()
		{
			Neighbors = new Dictionary<char, TrieNodeCCI>();
		}

		public TrieNodeCCI(char letter)
		{
			Letter = letter;
			Terminates = false;
		}

		public void AddWord(string word)
		{
			// add the char at word 0
			if (string.IsNullOrEmpty(word))
			{
				return;
			}

			var firstChar = word[0];

			var remainingWord = word.Substring(1);

			if (Neighbors.ContainsKey(firstChar))
			{
				var nextNode = Neighbors[firstChar];
				nextNode.AddWord(remainingWord);
			}
			else
			{
				var newNode = new TrieNodeCCI(firstChar);

				if (remainingWord.Length == 0)
				{
					newNode.Terminates = true;
				}

				Neighbors[firstChar] = newNode;

				newNode.AddWord(remainingWord);
			}
		}
	}
}
