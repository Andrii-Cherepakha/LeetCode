using System;
using System.Collections.Generic;

namespace LeetCode.Trees
{
    class MinimumDepthOfBinaryTree
    {
        public int MinDepth(TreeNode root) // BFT
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 1;

            while (queue.Count > 0)
            {
                int cnt = queue.Count;

                for (int i = 0; i < cnt; i++)
                {
                    var node = queue.Dequeue();

                    if (node.left == null && node.right == null) return depth;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                depth++;
            }

            return depth;
        }


        public int MinDepthDft(TreeNode root) // DFT
        {
            if (root == null) return 0;

            var stack = new Stack<TreeNode>();
            var level = new Stack<int>();
            int depth = int.MaxValue;

            stack.Push(root);
            level.Push(1);


            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var lvl = level.Pop();

                if (node.left == null && node.right == null) // leaf
                {
                    depth = Math.Min(depth, lvl);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    level.Push(lvl + 1);
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                    level.Push(lvl + 1);
                }
            }

            return depth;
        }
    }
}