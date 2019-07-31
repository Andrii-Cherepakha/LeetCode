using System.Linq;

namespace LeetCode.Strings
{
    public class ValidAnagram
    {


        public bool IsAnagram(string s, string t)
        {
            if (s == null || t == null || s.Length != t.Length)
            {
                return false;
            }

            s = string.Concat(s.OrderBy(c => c));
            t = string.Concat(t.OrderBy(c => c));

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}