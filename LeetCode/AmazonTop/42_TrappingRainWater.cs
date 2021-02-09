using System;

namespace LeetCode.AmazonTop
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

        public int Trap_remember(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int res = 0;

            int[] leftTall = new int[height.Length];
            leftTall[0] = height[0];
            for (int i = 1; i < height.Length; i++) leftTall[i] = Math.Max(leftTall[i - 1], height[i]);

            int[] rightTall = new int[height.Length];
            rightTall[height.Length - 1] = height[height.Length - 1];
            for (int i = height.Length - 1 - 1; i >= 0; i--) rightTall[i] = Math.Max(rightTall[i + 1], height[i]);

            for (int i = 0; i < height.Length; i++)
            {
                res += Math.Min(leftTall[i], rightTall[i]) - height[i];
            }

            return res;
        }
    }
}
