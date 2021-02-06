using System;

// similar to 687

namespace LeetCode.Trees
{
    class _124_BinaryTreeMaximumPathSum
    {
        public int MaxPathSum(TreeNode root)
        {

            GetPathSum(root);
            return max;
        }

        //public int MaxPathSum(TreeNode root)
        //{

        //    if (root == null) return 0;

        //    var queue = new Queue<TreeNode>();

        //    queue.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        var node = queue.Dequeue();
        //        var n = GetPathSum(node);
        //        max = Math.Max(max, n);

        //        if (node.left != null) queue.Enqueue(node.left);
        //        if (node.right != null) queue.Enqueue(node.right);
        //    }

        //    return max;
        //}

        private int max = int.MinValue;

        private int GetPathSum(TreeNode node)
        {
            if (node == null) return 0;

            int left = Math.Max(0, GetPathSum(node.left)); //less than 0, then not take left branch
            int right = Math.Max(0, GetPathSum(node.right)); //less than 0, then not take right branch

            max = Math.Max(max, left + right + node.val);

            return Math.Max(left, right) + node.val;
        }
    }
}
