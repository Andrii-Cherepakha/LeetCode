namespace LeetCode.Strings
{
    public class StringToIntegerSimplified
    {
        public int MyAtoi(string str)
        {
            if (str == null)
            {
                return 0;
            }

            int sign = 1, result = 0, i = 0;

            while (i < str.Length && str[i] == ' ') { i++; } // skip leading spaces

            // check sign
            if (i < str.Length && (str[i] == '-' || str[i] == '+'))
            {
                sign = str[i] == '-' ? -1 : 1;
                i++;
            }

            int threshold = int.MaxValue / 10; // or int.MinValue, does not matter due to division by 10

            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                int numeral = (int)str[i] - '0';
                if (result > threshold || (result == threshold && numeral > 7))
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                result = result * 10 + numeral;
                i++;
            }

            return result * sign;
        }
    }
}