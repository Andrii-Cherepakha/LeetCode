using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Trees
{
    class MaximumDepth
    {
        [Test]
        public void MaximumDepthTest()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);

            root.left.right = new TreeNode(11);

            root.left.right.left = new TreeNode(12);

            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            Console.WriteLine(MaxDepth(root));
        }
        public int MaxDepthRecursion(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(MaxDepthRecursion(root.left), MaxDepthRecursion(root.right));
        }
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                depth++;
                int cnt = queue.Count; // remember size, it is changed !!!
                for (int i = 0; i < cnt; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return depth;
        }
    }
}