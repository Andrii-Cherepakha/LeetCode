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

        public IList<IList<int>> PathSumPreOrder(TreeNode root, int sum)
        {
            var result = new List<IList<int>>();

            if (root == null) return result;

            var stack = new Stack<TreeNode>();
            var sumStack = new Stack<int>();
            var pathStack = new Stack<List<int>>();

            stack.Push(root);
            sumStack.Push(root.val);
            pathStack.Push(new List<int> { root.val });

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var s = sumStack.Pop();
                var path = pathStack.Pop();

                // find all root-to-leaf paths where each path's sum equals the given sum.
                if (node.left == null && node.right == null && s == sum)
                {
                    result.Add(new List<int>( path ));
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                    sumStack.Push(s + node.right.val);

                    var newPath = new List<int>(path);
                    newPath.Add(node.right.val);
                    pathStack.Push(newPath);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    sumStack.Push(s + node.left.val);

                    var newPath = new List<int>(path);
                    newPath.Add(node.left.val);
                    pathStack.Push(newPath);
                }
            }

            return result;
        }
    }
}