using NUnit.Framework;
using System;
using System.Collections.Generic;

// similar to 124

namespace LeetCode.Trees
{
    class _687_LongestUnivaluePath
    {

        [Test]
        public void Test1()
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(5);
            root.right = new TreeNode(5);

            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(5);

            root.right.right = new TreeNode(5);

            LongestUnivaluePath(root);
        }

        private int max;

        public int LongestUnivaluePathLeetCode(TreeNode root)
        {
            if (root == null) return 0;
            max = 0;
            GetLongest(root, root.val);
            return max;
        }

        private int GetLongest(TreeNode node, int val)
        {
            if (node == null) return 0;
            int left = GetLongest(node.left, node.val);
            int right = GetLongest(node.right, node.val);
            max = Math.Max(max, left + right);
            if (node.val == val) return Math.Max(left, right) + 1;
            return 0;
        }

        // my

        public int LongestUnivaluePath(TreeNode root)
        {

            if (root == null) return 0;

            var queue = new Queue<TreeNode>();

            max = 1;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var l = GetLongest(node); // !!! do not combine like max = Math.Max(max, GetLongest(node));
                max = Math.Max(max, l);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return max - 1;
        }

        private int GetLongest(TreeNode node)
        {
            int left = 0;
            int right = 0;

            if (node.left != null && node.left.val == node.val)
            {
                left = GetLongest(node.left);
            }

            if (node.right != null && node.right.val == node.val)
            {
                right = GetLongest(node.right);
            }

            if (node.left != null && node.left.val == node.val &&
              node.right != null && node.right.val == node.val)
            {
                max = Math.Max(max, 1 + left + right);
            }

            return 1 + Math.Max(left, right);
        }
    }
}
