
using System.Linq;

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
                _opponentWords = words.ToList();
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

            private List<string> _opponentWords;

            public int[] IsSecretContainsCharSabotageWord(char charToGuess, char[] mask, HashSet<char> misses)
            {
                var words = GetWordsMatchingMask(_opponentWords, mask, misses);

                List<string> contains = new List<string>();
                foreach (var word in words)
                {
                    if (word.Contains(charToGuess))
                    {
                        contains.Add(word);
                    }
                }


                if (words.Count - contains.Count >= contains.Count)
                {
                    return new int[] { }; // NO
                }

                char[] bestNewMask = new char[mask.Length];
                int bestSatisfyCount = -1;
                foreach (var word in contains)
                {
                    // new mask with charToGuess
                    char[] newMask = new char[mask.Length];
                    mask.CopyTo(newMask, 0);
                    for (int i=0; i < 6; i++)
                    {
                        if (word[i] == charToGuess) newMask[i] = charToGuess;
                    }

                    // how many words satisfy new mask?
                    var ww = GetWordsMatchingMask(contains, newMask, misses);
                    int satisfyCount = ww.Count;
                    if (satisfyCount > bestSatisfyCount)
                    {
                        bestSatisfyCount = satisfyCount;
                        newMask.CopyTo(bestNewMask, 0);                        
                    }
                }

                // return
                var positions = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    if (bestNewMask[i].Equals(charToGuess))
                    {
                        positions.Add(i);
                    }
                }

                return positions.ToArray();
            }

            /*
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
            */
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

        public static List<string> GetWordsMatchingMask(List<string> words, char[] mask, HashSet<char> misses)
        {
            var result = new List<string>();
            foreach (var word in words)
            {
                bool match = true;
                for (int i=0; i < 6; i++)
                {
                    match = match && (mask[i] == ' ' || word[i] == mask[i]) && !misses.Contains(word[i]);
                    if (!match) break;
                }
                if (match) result.Add(word);
            }
            return result;
        }
    }
}
