using NUnit.Framework;

namespace LeetCode.Integers
{
    public class PalindromeNumberString
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            string number = x.ToString();

            int length = number.Length;


            int left = length / 2 - 1; // -1 => index starts from 0
            int right = left + 1; // even

            if (length % 2 == 1) // odd
            {
                right = left + 2;
            }

            while (left >= 0)
            {
                if (number[left] != number[right])
                {
                    return false;
                }
                left--;
                right++;
            }

            return true;
        }
    }
}