
using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class LetterCombinationsOfPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            var result = new LinkedList<string>();

            if (digits == null || digits.Length == 0)
            {
                return result.ToList();
            }

            string[] characters = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            result.AddFirst("");
            for (int i = 0; i < digits.Length; i++)
            {
                int ii = digits[i] - 50; // '2' == 50
                while (result.First.Value.Length == i)
                {
                    string t = result.First.Value;
                    result.RemoveFirst();
                    foreach (char c in characters[ii])
                    {
                        result.AddLast(t + c);
                    }
                }
            }

            return result.ToList();
        }

        [Test]
        public void test1()
        {
            var l = LetterCombinations("23");
        }
    }

}
