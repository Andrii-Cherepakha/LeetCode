using NUnit.Framework;
using System;


namespace LeetCode.Strings
{
    class _821_ShortestDistanceToCharacter
    {
        [Test]
        public void Test()
        {
            string S = "loveleetcode";
            char C = 'e';
            ShortestToChar(S, C);
        }
        
        public int[] ShortestToChar(string S, char C)
        {
            var rightToLeft = new int[S.Length];
            rightToLeft[S.Length - 1] = 0;
            int indexRight = S[S.Length - 1] == C ? S.Length - 1 : - 1;

            for (int i = S.Length - 1 - 1; i >= 0; i--)
            {
                if (S[i] == C)
                {
                    rightToLeft[i] = 0;
                    indexRight = Math.Max(i, indexRight);
                }
                else if (S[i + 1] == C)
                {
                    rightToLeft[i] = 1;
                }
                else if (rightToLeft[i + 1] > 0)
                {
                    rightToLeft[i] = 1 + rightToLeft[i + 1];
                }
            }

            var leftToRight = new int[S.Length];
            leftToRight[0] = 0;
            int indexLeft = S[0] == C ? 0 : S.Length + 1;

            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == C)
                {
                    leftToRight[i] = 0;
                    indexLeft = Math.Min(i, indexLeft);
                }
                else if (S[i - 1] == C)
                {
                    leftToRight[i] = 1;
                }
                else if (leftToRight[i - 1] > 0)
                {
                    leftToRight[i] = leftToRight[i - 1] + 1;
                }
            }

            var result = new int[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                if (i < indexLeft)
                {
                    result[i] = rightToLeft[i];
                }
                else if (i > indexRight)
                {
                    result[i] = leftToRight[i];
                }
                else if (i > indexLeft && i < indexRight)
                {
                    result[i] = Math.Min(rightToLeft[i], leftToRight[i]);
                }                
            }

            return result;
        }
    }
}
