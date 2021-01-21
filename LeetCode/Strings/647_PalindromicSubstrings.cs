

namespace LeetCode.Strings
{
    class _647_PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                result += GetNumberOfPalindroms(s, i, i);
                result += GetNumberOfPalindroms(s, i, i+1);
            }

            return result;
        }

        private int GetNumberOfPalindroms(string s, int i, int j)
        {
            int cnt = 0;

            while (i >=0 && j < s.Length)
            {
                if (s[i] == s[j])
                {
                    cnt++;
                }
                else break;
                i--;
                j++;
            }

            return cnt;
        }

    }
}
