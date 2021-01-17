using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Ranges
{
    class _632_SmallestRangeCoveringElementsfromKLists
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var current = new int[nums.Count];
            int whereIsMinimum = 0;

            int rangeMin = 0;
            int rangeMax = 0;
            int rangeMinLength = int.MaxValue;

            while (current[whereIsMinimum] < nums[whereIsMinimum].Count)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i].ElementAt(current[i]) < min) { min = nums[i].ElementAt(current[i]); whereIsMinimum = i; }
                    if (nums[i].ElementAt(current[i]) > max) max = nums[i].ElementAt(current[i]);
                }

                if (max - min < rangeMinLength)
                {
                    rangeMin = min;
                    rangeMax = max;
                    rangeMinLength = max - min;
                }

                current[whereIsMinimum]++;
            }

            return new int[] { rangeMin, rangeMax };
        }
    }
}
