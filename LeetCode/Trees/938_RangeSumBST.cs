using System.Collections.Generic;

namespace LeetCode.Trees
{
    public class _938_RangeSumBST
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            var stack = new Stack<TreeNode>();
            var current = root;
            int sum = 0;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();

                if (low <= current.val && current.val <= high)
                    sum += current.val;

                if (high < current.val)
                    return sum;

                current = current.right;
            }

            return sum;
        }

            public int RangeSumBST_r(TreeNode root, int low, int high)
        {
            if (root == null) return 0;

            RangeSumBST_r(root.left, low, high);

            if (low <= root.val && root.val <= high)
                sum += root.val;

            if (root.val > high) return sum;

            RangeSumBST_r(root.right, low, high);

            return sum;
        }

        private int sum = 0;
    }
}
