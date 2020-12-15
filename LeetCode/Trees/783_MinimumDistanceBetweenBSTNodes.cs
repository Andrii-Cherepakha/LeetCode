using System;

namespace LeetCode.Trees
{
    class MinimumDistanceBetweenBSTNodes // == 530
    {
        public int MinDiffInBST(TreeNode root)
        {
            if (root == null) return min;

            MinDiffInBST(root.left);

            if (prev != null)
            {
                min = Math.Min(min, root.val - prev.val);
            }

            prev = root;

            MinDiffInBST(root.right);

            return min;
        }

        private int min = int.MaxValue;
        private TreeNode prev;
    }
}
