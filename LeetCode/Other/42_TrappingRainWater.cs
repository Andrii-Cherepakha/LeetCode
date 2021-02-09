using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Other
{
    class _42_TrappingRainWater
    {
        public int Trap(int[] height)
        {
            int res = 0;

            for (int i = 0; i < height.Length; i++)
            {
                // how many water can give current cell?
                int leftTall = height[i];
                int rigthTall = height[i];

                int j = i - 1;
                while (j >= 0)
                {
                    leftTall = Math.Max(leftTall, height[j]);
                    j--;
                }

                j = i + 1;
                while (j < height.Length)
                {
                    rigthTall = Math.Max(rigthTall, height[j]);
                    j++;
                }

                res += Math.Min(leftTall, rigthTall) - height[i];
            }

            return res;
        }
    }
}
