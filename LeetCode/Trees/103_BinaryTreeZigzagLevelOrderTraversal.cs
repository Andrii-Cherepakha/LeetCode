using System.Collections.Generic;

namespace LeetCode.Trees
{
    class _103_BinaryTreeZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {

            var qNode = new Queue<TreeNode>();
            var qLevel = new Queue<int>();

            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list = new List<int>();

            if (root == null) return res;

            qNode.Enqueue(root);
            qLevel.Enqueue(1);
            int currentLevel = 1;

            while (qNode.Count > 0)
            {
                var node = qNode.Dequeue();
                var lvl = qLevel.Dequeue();

                if (lvl != currentLevel)
                {
                    res.Add(list);
                    currentLevel = lvl;
                    list = new List<int>();
                }

                if (currentLevel % 2 == 1)
                {
                    list.Add(node.val);
                }
                else
                {
                    list.Insert(0, node.val);
                }

                if (node.left != null)
                {
                    qNode.Enqueue(node.left);
                    qLevel.Enqueue(lvl + 1);
                }

                if (node.right != null)
                {
                    qNode.Enqueue(node.right);
                    qLevel.Enqueue(lvl + 1);
                }
            }

            res.Add(list);

            return res;
        }
    }
}
