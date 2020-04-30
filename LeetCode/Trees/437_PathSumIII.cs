namespace LeetCode.Trees
{
    public class PathSumIII
    {
        public int PathSum(TreeNode root, int sum) // PostOrder
        {
            if (root == null) return 0;
            int count = 0;




            return count;
        }


        //public int PathSum(TreeNode root, int sum) // PostOrder
        //{
        //    if (root == null) return 0;
        //    PostOrder(root, sum);
        //    return Count;
        //}

        //private int Count = 0;

        //private int PostOrder(TreeNode node, int sum)
        //{
        //    if (node == null) return 0;

        //    int left = PostOrder(node.left, sum);
        //    int right = PostOrder(node.right, sum);

        //    if (node.val == sum) Count++;
        //    if (left == sum) Count++;
        //    if (right == sum) Count++;

        //    return node.val + left + right; // return sum of tree
        //}

    }
}
