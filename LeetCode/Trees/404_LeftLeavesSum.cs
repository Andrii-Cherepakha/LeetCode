using System.Collections.Generic;

namespace LeetCode.Trees
{
    class LeftLeavesSum
    {

        public int SumOfLeftLeavesInOrder(TreeNode root) // BFT 
        {
            if (root == null) return 0;
            int sum = 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.left != null)
                {
                    if (node.left.left == null && node.left.right == null)
                        sum += node.left.val; // left node of current is a leaf
                    else
                        queue.Enqueue(node.left);
                }

                if (node.right != null)
                    queue.Enqueue(node.right);

            }

            return sum;
        }

        public int SumOfLeftLeaves(TreeNode root) // DFT pre-order
        {
            if (root == null) return 0;
            int sum = 0;

            var stack = new Stack<TreeNode>();
            var isLeft = new Stack<bool>();

            stack.Push(root);
            isLeft.Push(false);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var _isLeft = isLeft.Pop();

                if (node.left == null && node.right == null && _isLeft) { sum += node.val; continue; }

                if (node.right != null) { stack.Push(node.right); isLeft.Push(false); }
                if (node.left != null) { stack.Push(node.left); isLeft.Push(true); }
            }

            return sum;
        }
    }
}