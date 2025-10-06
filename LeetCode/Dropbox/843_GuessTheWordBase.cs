
namespace LeetCode.Dropbox
{
    public class GuessTheWordBase
    {
        public class Master
        {
            public readonly string secret;

            public Master(string[] words)
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
