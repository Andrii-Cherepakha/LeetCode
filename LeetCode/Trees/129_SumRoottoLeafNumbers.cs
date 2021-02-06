// similar to 1022

namespace LeetCode.Trees
{
    class _129_SumRoottoLeafNumbers
    {
        public int SumNumbers(TreeNode root)
        {
            SumNumbers(root, 0);
            return sum;
        }

        private int sum = 0;

        private void SumNumbers(TreeNode node, int number)
        {
            if (node == null) return;

            number = number * 10 + node.val;

            if (node.left == null && node.right == null)
            {
                sum += number;
            }

            if (node.left != null) SumNumbers(node.left, number);
            if (node.right != null) SumNumbers(node.right, number);
        }
    }
}
