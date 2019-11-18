using System.Collections.Generic;

namespace LeetCode.Trees
{
    class BottumUpLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrderBottomInsert(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                IList<int> level = new List<int>();

                for (int i = 0; i < cnt; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                result.Insert(0, level);
            }

            return result;
        }

        public IList<IList<int>> LevelOrderBottomWithStack(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            var stack = new Stack<IList<int>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                List<int> level = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                stack.Push(level);
            }

            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return result;
        }
    }
}
