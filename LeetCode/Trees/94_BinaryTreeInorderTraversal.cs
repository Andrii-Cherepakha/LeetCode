using System.Collections.Generic;

namespace LeetCode.Trees
{
    class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            InorderTraversalRecursion(root);
            return result;
        }

        IList<int> result = new List<int>();

        private void InorderTraversalRecursion(TreeNode node)
        {
            if (node == null) return;

            if (node.left != null) InorderTraversalRecursion(node.left);
            result.Add(node.val);
            if (node.right != null) InorderTraversalRecursion(node.right);
        }
    }
}
