using System.Collections.Generic;

namespace LeetCode.Trees
{
    class _1022_SumofRootToLeafBinaryNumbers
    {
        public int SumRootToLeaf_preorder(TreeNode root)
        {

            if (root == null) return 0;

            int sum = 0;
            var stack = new Stack<(TreeNode node, int number)>();

            stack.Push((root, 0));

            while (stack.Count > 0)
            {
                var item = stack.Pop();

                int num = (item.number << 1) | item.node.val;

                if (item.node.left == null && item.node.right == null)
                {
                    sum += num;
                }

                if (item.node.left != null) stack.Push((item.node.left, num));
                if (item.node.right != null) stack.Push((item.node.right, num));
            }

            return sum;
        }

        public int SumRootToLeaf(TreeNode root)
        {
            sum = 0;
            SumRootToLeaf(root, 0);
            return sum;
        }

        private int sum;

        private void SumRootToLeaf(TreeNode node, int number)
        {
            if (node == null) return;

            number = (number << 1) | node.val;

            if (node.left == null && node.right == null)
            {
                sum += number;
            }

            SumRootToLeaf(node.left, number);
            SumRootToLeaf(node.right, number);
        }
    }
}
