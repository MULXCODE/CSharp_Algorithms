using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class CouldHaveWrittenQuestion : IRunnable
    {
        public CouldHaveWrittenQuestion()
        {

        }

        public void Run()
        {
            CouldHaveWritten(new RansomNote()
            {
                Contents = "abcdef"
            },
               new Magazine()
               {
                   Contents = "abcdefg"
               });
        }

        public class Note
        {
            public string Contents { get; set; }
        }
        public class RansomNote : Note
        {

        }
        public class Magazine : Note
        {

        }

        public bool CouldHaveWritten(RansomNote note, Magazine article)
        {
            var noteLettersDic = CreateDictionaryOfLetters(note.Contents);

            // read letter by letter and decrement from the noteLettersDic
            foreach (var c in article.Contents)
            {
                if (noteLettersDic.ContainsKey(c))
                {
                    noteLettersDic[c]--;
                }

                if (noteLettersDic[c] == 0)
                {
                    noteLettersDic.Remove(c);

                    if (noteLettersDic.Count == 0) return true;
                }
            }

            return noteLettersDic.Count == 0;
        }

        private Dictionary<char, int> CreateDictionaryOfLetters(string contents)
        {
            char[] text = contents.ToCharArray();

            var dictionary = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                }
                else
                {
                    dictionary.Add(c, 1);
                }
            }

            return dictionary;
        }
    }
}