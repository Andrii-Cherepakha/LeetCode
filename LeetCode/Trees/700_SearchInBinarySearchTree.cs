

namespace LeetCode.Trees
{
    public class SearchInBinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val == val) return root;

            if (val < root.val) 
                return SearchBST(root.left, val);

            return SearchBST(root.right, val);
        }
    }
}
