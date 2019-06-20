namespace LeetCode.Integers
{
    public class PalindromeNumber
    {

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            if (x < 9)
            {
                return true;
            }

            //int digits = (int)Math.Floor(Math.Log10(x)) + 1;
            //int divisor = (int)Math.Pow(10, digits - 1);

            int digits = 1;
            int divisor = 1;
            int a = x / 10;

            while (a > 0)
            {
                digits++;
                divisor = divisor * 10;
                a = a / 10;
            }


            while (digits > 1)
            {
                int last = x % 10;
                int first = (x - (x % divisor)) / divisor;

                if (first != last)
                {
                    return false;
                }

                x = x % divisor; // get rid of first
                x = x / 10; // get rid of last
                digits = digits - 2;
                divisor = divisor / 100;
            }
            
            return true;
        }
    }
}