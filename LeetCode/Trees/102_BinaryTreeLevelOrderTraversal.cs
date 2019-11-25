using System.Collections.Generic;

namespace LeetCode.Trees
{
    class BinaryTreeLevelOrderTraversal
    {

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var topLevelQueue = new Queue<TreeNode>();
            Queue<TreeNode> nextLevelQueue = null;
            topLevelQueue.Enqueue(root);

            while (nextLevelQueue == null || nextLevelQueue.Count > 0)
            {
                nextLevelQueue = new Queue<TreeNode>();
                var intermidiate = new List<int>();

                while (topLevelQueue.Count > 0)
                {
                    var node = topLevelQueue.Dequeue();
                    intermidiate.Add(node.val);

                    if (node.left != null) nextLevelQueue.Enqueue(node.left);
                    if (node.right != null) nextLevelQueue.Enqueue(node.right);                    
                }

                result.Add(intermidiate);
                topLevelQueue = nextLevelQueue;
            }
            
            return result;
        }
    }
}
