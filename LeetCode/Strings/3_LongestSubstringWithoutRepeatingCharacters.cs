using System;
using System.Collections.Generic;

namespace LeetCode.Strings
{
    class _3_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            
            int p = 0;
            int max = 0;
            var hash = new HashSet<char>();
            hash.Add(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                if (hash.Contains(s[i]))
                {
                    max = Math.Max(max, i - p);
                    while (hash.Contains(s[i]))
                    {
                        hash.Remove(s[p]);
                        p++;
                    }
                }
                hash.Add(s[i]);
            }

            max = Math.Max(max, s.Length - p);

            return max;
        }


    }
}
