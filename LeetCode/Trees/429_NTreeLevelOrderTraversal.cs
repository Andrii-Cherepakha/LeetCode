using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    class NTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var topLevelQueue = new Queue<Node>();
            Queue<Node> nextLevelQueue = null;
            topLevelQueue.Enqueue(root);

            while(nextLevelQueue == null || nextLevelQueue.Count > 0)
            {
                nextLevelQueue = new Queue<Node>();
                var intermediate = new List<int>();

                while (topLevelQueue.Count > 0)
                {
                    var node = topLevelQueue.Dequeue();
                    intermediate.Add(node.val);
                    if (node.children != null)
                        foreach (var child in node.children)
                            nextLevelQueue.Enqueue(child);
                }
                result.Add(intermediate);
                topLevelQueue = nextLevelQueue;
            }
                       
            return result;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}
