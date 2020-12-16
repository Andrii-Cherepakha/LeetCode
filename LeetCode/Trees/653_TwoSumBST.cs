using System.Collections.Generic;

namespace LeetCode.Trees
{
    public class _653_TwoSumBST
    {
        public bool FindTarget(TreeNode root, int k)
        {
            var current = root;
            var stack = new Stack<TreeNode>();
            var hash = new HashSet<int>();

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                hash.Add(current.val);

                current = current.right;
            }

            foreach (var val in hash)
            {
                int diff = k - val;
                if (val != diff && hash.Contains(diff))
                    return true;
            }

            return false;
        }
    }
}
