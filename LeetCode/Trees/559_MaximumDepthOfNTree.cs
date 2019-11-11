using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    class MaximumDepthOfNTree
    {
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

        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (node.children != null)
                        foreach (var child in node.children)
                            queue.Enqueue(child);
                }
                depth++;
            }

            return depth;
        }


    }
}
