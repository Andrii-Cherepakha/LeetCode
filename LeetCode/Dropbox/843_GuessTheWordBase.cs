
namespace LeetCode.Dropbox
{
    public class GuessTheWordBase
    {
        public class Master
        {
            public string secret;

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
