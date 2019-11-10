using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    class NTreePreorderTraversal
    {

        public IList<int> Preorder(Node root)
        {
            var result = new List<int>();

            if (root == null) return result;

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);

                foreach(var child in node.children.Reverse<Node>())
                {
                    stack.Push(child);
                }
            }

            return result;
        }

        //public void AddNodes(IList<Node> children, List<int> result)
        //{
        //    if ()
        //}

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
