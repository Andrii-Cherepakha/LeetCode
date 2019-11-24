using System.Collections.Generic;

namespace LeetCode.Trees
{


    class PathSumII
    {

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            RecursionPreOrder(root, sum, new List<int>());
            return result;
        }

        private List<IList<int>> result = new List<IList<int>>();

        private void RecursionPreOrder(TreeNode node, int sum, List<int> path)
        {
            if (node == null) return;
            
            path.Add(node.val);

            if (node.left == null && node.right == null && node.val == sum)
            {
                result.Add(new List<int>(path));
            }

            if (node.left != null)
            {
                RecursionPreOrder(node.left, sum - node.val, path);
            }

            if (node.right != null)
            {
                RecursionPreOrder(node.right, sum - node.val, path);
            }

            path.RemoveAt(path.Count - 1);        
        }
    }
}