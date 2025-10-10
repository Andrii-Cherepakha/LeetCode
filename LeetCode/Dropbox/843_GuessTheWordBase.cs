
namespace LeetCode.Dropbox
{
    public class GuessTheWordBase
    {
        public class Master
        {
            public string secret;
            // private HashSet<char> misses = new HashSet<char>();
            private readonly List<char> alphabet = "qazwsxedcrfvtgbyhnujmikolp".ToList();

            public Master(string[] words)
            {
                SelectWord(words);
            }

            public void SelectWord(string[] words)
            {
                Random rnd = new Random();
                int i = rnd.Next(words.Length);
                secret = words[i];
            }

            public Master(string word)
            {
                secret = word;
            }

            public int guess(string word)
            {
                return GetMatchCount(secret, word);
            }

            public int[] IsSecretContainsChar(char c)
            {
                var positions = new List<int>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == c)
                    {
                        positions.Add(i);
                    }
                }
                return positions.ToArray();
            }

            public int[] IsSecretContainsCharSabotageLetter(char c, string[] words, char[] mask, HashSet<char> misses)
            {
                var positions = new List<int>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == c)
                    {
                        positions.Add(i);
                    }
                }

                if (positions.Count != 0)
                {
                    char letterToChange = ' ';

                    // get all letters
                    var lettersInWords = new HashSet<char>();
                    foreach (var word in words)
                    {
                        foreach (var cc in word)
                        {
                            lettersInWords.Add(cc);
                        }
                    }

                    var rest = alphabet.Except(misses).Except(lettersInWords);
                    // var rest = new List<char>();

                    if (rest.Any())
                    {
                        letterToChange = rest.First();
                    }
                    else
                    {
                        letterToChange = GetLeastFrequientChar(words, mask, misses);
                        if (letterToChange == ' ')
                        {
                            letterToChange = c;
                        }
                    }

                    string oldSecret = secret;
                    foreach (var p in positions)
                    {
                        secret = secret.Replace(c, letterToChange);
                    }

                    for(int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Equals(oldSecret))
                        {
                            words[i] = secret;
                            break;
                        }
                    }

                    if (!letterToChange.Equals(c))
                        positions.Clear();
                }

                return positions.ToArray();
            }

            private char GetLeastFrequientChar(string[] words, char[] mask, HashSet<char> misses)
            {
                var dict = new Dictionary<char, int>();

                foreach (var word in words)
                {
                    for (int i=0; i < 6; i++)
                    {
                        if (mask[i] == ' ' && !misses.Contains(word[i]))
                        {
                            dict[word[i]] = dict.ContainsKey(word[i]) ? dict[word[i]] + 1 : 1;
                        }
                    }
                }

                char c = ' ';
                int min = int.MaxValue;
                foreach (var ch in dict.Keys)
                {
                    if (dict[ch] < min)
                    {
                        min = dict[ch];
                        c = ch;
                    }
                }

                return c;
            }
        }

        public static int GetMatchCount(string word1, string word2)
        {
            int matches = 0;
            for (int i = 0; i < 6; i++)
            {
                if (word1[i] == word2[i])
                    matches++;
            }
            return matches;
        }
    }
}
