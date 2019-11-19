using System.Collections.Generic;

namespace LeetCode.Trees
{
    class PathSum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            if (root.left == null && root.right == null)
            {
                if (root.val == sum) return true;
            }

            if (root.left != null)
            {
                if (HasPathSum(root.left, sum - root.val)) return true;
            }

            if (root.right != null)
            {
                if (HasPathSum(root.right, sum - root.val)) return true;
            }

            return false;
        }

        public bool HasPathSumPreOrder(TreeNode root, int sum) // DFT pre-order
        {
            if (root == null) return false;

            var stack = new Stack<TreeNode>();
            var sums = new Stack<int>();

            stack.Push(root);
            sums.Push(root.val);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var s = sums.Pop();

                if (node.left == null && node.right == null && s == sum) return true;

                if (node.right != null)
                {
                    stack.Push(node.right);
                    sums.Push(s + node.right.val);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    sums.Push(s + node.left.val);
                }
            }

            return false;
        }

            public bool HasPathSumMyRecursion(TreeNode root, int sum)
        {
            if (root == null) return false;
            expectedSum = sum;
            return CheckSum(root, 0);
        }

        private int expectedSum = 0;

        private bool CheckSum(TreeNode node, int sum)
        {
            if (node.left == null && node.right == null)
            {
                if (node.val + sum == expectedSum) return true;
            }

            if (node.left != null)
            {
                if (CheckSum(node.left, node.val + sum)) return true;
            }

            if (node.right != null)
            {
                if (CheckSum(node.right, node.val + sum)) return true;
            }

            return false;
        }

        public bool HasPathSumDFT(TreeNode root, int sum) // DFT in-order
        {
            if (root == null) return false;

            var current = root;
            TreeNode previous = null;
            var stack = new Stack<TreeNode>();
            int stackSum = 0;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    stackSum += current.val;
                    current = current.left;
                }
                                
                current = stack.Pop();

                if (current.left == null && current.right == null && stackSum == sum)
                {
                    return true;
                }

                // ??? DO NOT UNDERSTAND
                if (current.right != null && previous != current.right)
                {
                    current = current.right;
                }
                else 
                {
                    previous = current;
                    stack.Pop();
                    stackSum -= current.val;
                    current = null;
                }
            }

            return false;
        }
    }
}
