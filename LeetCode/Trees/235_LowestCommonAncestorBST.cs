namespace LeetCode.Trees
{
    public class LowestCommonAncestorBST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (p.val < root.val && q.val < root.val)
                {
                    root = root.left;
                    continue;
                }

                if (p.val > root.val && q.val > root.val)
                { 
                    root = root.right;
                    continue;
                }

                break;
            }

            return root;
        }

        public TreeNode LowestCommonAncestor_r(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);

            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);

            return root;
        }
    }
}