using System.Text;

namespace LeetCode.Strings
{
    class _168_ExcelSheetColumnTitle
    {
        public string ConvertToTitle(int n)
        {
            //if (n <= 0) return "";

            var sb = new StringBuilder();

            // A = 65 Z = 90

            while (n > 0)
            {
                int ch = n % 26;
                if (ch == 0) ch = 26;

                sb.Insert(0, (char) (ch + 64));

                n = n / 26;

                if (ch == 26) n = n - 1;                
            }

            return sb.ToString();
        }
    }
}
