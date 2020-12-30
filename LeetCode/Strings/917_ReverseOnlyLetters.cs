

namespace LeetCode.Strings
{
    public class _917_ReverseOnlyLetters
    {
        public string ReverseOnlyLetters(string S)
        {
            if (S == null || S.Length == 0 || S.Length == 1) return S;
            
            var str = S.ToCharArray();

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                while (left <= str.Length - 1 && !IsLetter(str[left]))
                {
                    left++;
                }

                while (right >= 0 && !IsLetter(str[right]))
                {
                    right--;
                }

                if (left > right) break;

                var tmp = str[left];
                str[left] = str[right];
                str[right] = tmp;

                left++;
                right--;
            }

            return new string(str);
        }

        private bool IsLetter(char ch)
        {
            return (((int)ch >= 65 && (int)ch <= 90) || ((int)ch >= 97 && (int)ch <= 122));
        }
    }
}
