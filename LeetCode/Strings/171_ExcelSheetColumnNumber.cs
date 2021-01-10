namespace LeetCode.Strings
{
    class _171_ExcelSheetColumnNumber
    {
        public int TitleToNumber(string s)
        {
            // A = 65 Z = 90

            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {
                res = res * 26 + (s[i] - 64);
            }

            return res;
        }
    }
}
