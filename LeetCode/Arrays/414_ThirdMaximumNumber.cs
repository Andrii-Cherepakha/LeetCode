using NUnit.Framework;

namespace LeetCode.Arrays
{
    class ThirdMaximumNumber
    {
        [Test]
        public void Test1()
        {
            int[] nums = { 2, 1 };
            ThirdMax(nums);
        }

        [Test]
        public void Test2()
        {
            int[] nums = { -2147483648, 1, 2 };
            ThirdMax(nums);
        }

        public int ThirdMax(int[] nums)
        {
            int? max1 = null;
            int? max2 = null;
            int? max3 = null;

            foreach (int num in nums)
            {
                if (num == max1 || num == max2 || num == max3) continue;

                if (max1 == null || num > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (max2 == null || num > max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (max3 == null || num > max3)
                {
                    max3 = num;
                }
            }

            return max3 == null ? max1.Value : max3.Value;
            // return max3 > int.MinValue ? max3 : (max2 > int.MinValue ? max2 : max1);
        }
    }
}
