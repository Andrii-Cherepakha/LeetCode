using NUnit.Framework;

namespace LeetCode.Strings
{
    public class _344_ReverseString
    {
        [Test]
        public void Test()
        {
            ReverseString(new[] {'h','e','l','l','o'});
        }
        
        public void ReverseString(char[] s)
        {
            if (s == null || s.Length == 0 || s.Length == 1) return;

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                char tmp = s[left];
                s[left] = s[right];
                s[right] = tmp;

                left++;
                right--;
            }
        }
    }
}
