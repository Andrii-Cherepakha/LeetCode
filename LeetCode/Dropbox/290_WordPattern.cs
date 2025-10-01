using System.Collections.Generic;

namespace LeetCode.Dropbox
{
    public class WordPattern
    {
        public bool Solution(string pattern, string s)
        {
            if (pattern == null || s == null || pattern.Length == 0 || s.Length == 0)
            {
                return false;
            }

            string[] ss = s.Split(' ');

            if (pattern.Length != ss.Length)
            {
                return false;
            }

            int patternNextAvailableIndex = 0;
            int ssNextAvailableIndex = 0;

            Dictionary<char, int> patternIndexes = new Dictionary<char, int>();
            Dictionary<string, int> ssIndexes = new Dictionary<string, int>();

            for (int i = 0; i < ss.Length; i++)
            {
                //  pattern = "abba", s = "dog cat cat dog"
                int patternIndex = patternIndexes.ContainsKey(pattern[i]) ? patternIndexes[pattern[i]] : patternNextAvailableIndex++;
                int ssIndex = ssIndexes.ContainsKey(ss[i]) ? ssIndexes[ss[i]] : ssNextAvailableIndex++;
                if (patternIndex != ssIndex)
                {
                    return false;
                }
                patternIndexes[pattern[i]] = patternIndex;
                ssIndexes[ss[i]] = ssIndex;
            }

            return true;
        }
    }
}
