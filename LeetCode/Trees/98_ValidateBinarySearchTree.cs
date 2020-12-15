using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Trees
{
    public class ValidateBinarySearchTree
    {
        [Test]
        public void Test()
        {
            var root = new TreeNode(1);

            root.left = new TreeNode(2);
            root.right = new TreeNode(2);

            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3); // time limit

            IsValidBST(root);
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            if (!IsValidBST(root.left)) return false;

            if (previous != null && root.val <= previous.val)
                return false;

            previous = root;

            return IsValidBST(root.right);
        }

        private TreeNode previous;

        public bool IsValidBSTStack(TreeNode root)
        {
            TreeNode current = root;
            var stack = new Stack<TreeNode>();

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();

                if (previous != null && current.val <= previous.val)
                    return false;

                previous = current;

                current = current.right;
            }

            return true;
        }
    }
}
