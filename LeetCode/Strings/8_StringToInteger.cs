namespace LeetCode.Strings
{
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            string number = ExtractNumber(str);

            if (number == "")
            {
                // If no valid conversion could be performed, a zero value is returned.
                return 0;
            }

            bool isNegative = number[0] == '-';

            if (isNegative)
            {
                number = number.Remove(0, 1);
            }

            return StrToInt(number, isNegative);
        }

        private int StrToInt(string number, bool isNegative)
        {
            int threshold = int.MaxValue / 10; // or Int32.MinValue, does not matter due to division by 10

            int result = 0;
            foreach (var chr in number)
            {
                // 0 - 48
                // 1 - 49
                // 9 - 57
                int numeral = (int) chr - 48;

                if (result > threshold)
                {
                    return isNegative ? int.MinValue : int.MaxValue;
                }

                if (result == threshold)
                {
                    if (isNegative && numeral > 8)
                    {
                        return int.MinValue;
                    }

                    if (!isNegative && numeral > 7)
                    {
                        return int.MaxValue;
                    }
                }

                result = result * 10 + numeral;
            }

            if (isNegative)
            {
                result = result * -1;
            }

            return result;
        }

        private string ExtractNumber(string str)
        {
            if (str == null)
            {
                return "";
            }

            bool foundNumber = false;
            bool isNegative = false;
            string result = "";

            foreach (char chr in str)
            {
                if (chr == ' ' && !foundNumber)
                {
                    continue;
                }

                if (chr == '+' && !foundNumber)
                {
                    foundNumber = true;
                    continue;
                }

                if (chr == '-' && !foundNumber)
                {
                    foundNumber = true;
                    isNegative = true;
                    continue;
                }

                if (chr >= '0' && chr <= '9') // digit
                {
                    foundNumber = true;
                    result = result + chr;
                    continue;
                }

                break; // not digit
            }

            if (isNegative && result.Length != 0)
            {
                result = "-" + result;
            }

            return result;
        }
    }
}