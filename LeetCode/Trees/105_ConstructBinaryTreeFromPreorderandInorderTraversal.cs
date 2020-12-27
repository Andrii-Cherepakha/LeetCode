using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    public class _105_ConstructBinaryTreeFromPreorderandInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            if (inorder == null || inorder.Length == 0) return null;

            return BuildTree(preorder, inorder, 0, inorder.Length - 1, 0);
        }

        private TreeNode BuildTree(int[] preorder, int[] inorder, int inorderStart, int inorderEnd, int preorderStart)
        {
            if (preorderStart > preorder.Length - 1) return null;
            if (inorderStart > inorderEnd) return null;

            TreeNode node = new TreeNode(preorder[preorderStart]);

            int rootIndex = 0;
            for (int i = inorderStart; i <= inorderEnd; i++)
            {
                if (inorder[i] == preorder[preorderStart])
                {
                    rootIndex = i;
                    break;
                }
            }

            node.left = BuildTree(preorder, inorder, inorderStart, rootIndex - 1, preorderStart + 1); // index ???
            node.right = BuildTree(preorder, inorder, rootIndex + 1, inorderEnd, preorderStart + rootIndex - inorderStart + 1); // index ???
            return node;
        }
    }
}

