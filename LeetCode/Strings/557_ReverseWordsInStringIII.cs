
namespace LeetCode.Strings
{
    public class _557_ReverseWordsInStringIII
    {
        public string ReverseWords(string s)
        {
            var str = s.ToCharArray();

            int start = 0;
            int end = -1;

            for(int i=0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    ReversWord(str, start, end);
                    start = i + 1;
                    end = i;
                }
                else 
                    end++;
            }

            ReversWord(str, start, end);

            return new string(str);
        }

        private void ReversWord(char[] s, int start, int end)
        {
            while (start < end)
            {
                char tmp = s[start];
                s[start] = s[end];
                s[end] = tmp;

                start++;
                end--;
            }
        }
    }
}
