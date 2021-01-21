
namespace LeetCode.Strings
{
    class _5_LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                string str = GetLongetsPalindrom(s, i, i);

                if (str.Length > result.Length) result = str;

                str = GetLongetsPalindrom(s, i, i+1);

                if (str.Length > result.Length) result = str;
            }

            return result;
        }

        private string GetLongetsPalindrom(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length)
            {
                if (s[i] != s[j]) break;
                i--;
                j++;
            }

            i++;
            j--;

            return i <= j ? s.Substring(i, j - i + 1) : "";
        }
    }
}
