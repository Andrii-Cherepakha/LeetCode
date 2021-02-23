using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.AmazonTop
{
    class _238_ProductofArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {

            if (nums == null) return null;
            int[] res = new int[nums.Length];

            int product = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i]; // product so far from left to right
                res[i] = product;
            }

            product = 1;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                res[i] = res[i - 1] * product;
                product *= nums[i]; // product so far from right to left
            }

            res[0] = product;

            return res;
        }
    }
}
