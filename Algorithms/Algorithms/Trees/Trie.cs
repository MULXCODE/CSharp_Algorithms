using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Algorithms
{
	public class TrieNode
	{
		private const int SIZE_CHAR_SET = 255;

		public char Letter { get; set; }
		public TrieNode Previous { get; set; }
		public TrieNode[] Next { get; set; }
		public int Frequency { get; set; }
		public bool IsEndOfWord { get; set; }

		public TrieNode(char letter, TrieNode previous)
		{
			Letter = letter;
			Previous = previous;
			Next = new TrieNode[SIZE_CHAR_SET];
		}
	}

	public class Trie
	{
		public TrieNode Root { get; set; }

		public class WordFrequency
		{
			public string Word { get; set; }
			public int Frequency { get; set; }

			public WordFrequency(string w, int f)
			{
				Word = w;
				Frequency = f;
			}
		}

		public Trie(int sizeCharSet)
		{
			Root = new TrieNode('&', null);
		}

		public bool Insert(string word)
		{
			TrieNode current = Root;
			current.Frequency++;
			for (int i = 0; i < word.Length; i++)
			{
				int letter = word[i] - 'A';
				if (current.Next[letter] == null)
				{
					current.Next[letter] = new TrieNode(word[i], current);
				}

				current.Next[letter].Frequency++;
				current = current.Next[letter];
			}

			current.IsEndOfWord = true;

			if (current.IsEndOfWord)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public List<WordFrequency> Search(string prefix)
		{
			// returns a list of words with the given prefix
			var autoCompletion = new List<WordFrequency>();

			TrieNode current = Root;

			foreach (var c in prefix.ToCharArray())
			{
				if (current.Next[c - 'A'] == null)
				{
					return autoCompletion;
				}
				else
				{
					current = current.Next[c - 'A'];
				}
			}

			var suffix = new List<WordFrequency>();
			DepthFirstSearch(current, suffix, new StringBuilder());

			foreach(var wf in suffix)
			{
				wf.Word = prefix + wf.Word;
				autoCompletion.Add(wf);
			}

			//you may rank the autoCompletion by frequency according to the requirement in the follow-up question
			return autoCompletion;
		}

		public void DepthFirstSearch(TrieNode current, List<WordFrequency> suffix, StringBuilder str)
		{
			if (current == null) return;

			str.Append(current.Letter);

			if (current.IsEndOfWord && str.Length > 0)
			{
				suffix.Add(new WordFrequency(str.ToString().Substring(1), current.Frequency));  //word found
			}

			foreach (TrieNode nextLetter in current.Next)
			{
				DepthFirstSearch(nextLetter, suffix, str);
			}
			str.Remove(str.Length-1, 1);
		}
	}

	[TestFixture]
	[Category("Trie Tests")]
	public class TrieTests
	{
		private Trie _trie;

		[SetUp]
		public void SetUp()
		{
			_trie = new Trie(255);

			int v = 26 - 'a';

			if (v + 1 ==  2)
			{
				return;
			}
		}

		[Test]
		public void Trie_Test()
		{
			_trie.Insert("hello");
			_trie.Insert("world");
			_trie.Insert("hey");
			_trie.Insert("wong");
			_trie.Insert("WHALE");
			_trie.Insert("worthy");
			_trie.Insert("worse");


			var res = _trie.Search("wo");

			Assert.That(res.Count, Is.GreaterThan(3));
		}

	}
}
