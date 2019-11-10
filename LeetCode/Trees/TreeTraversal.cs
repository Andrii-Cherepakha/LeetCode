using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trees
{
    class TreeTraversal
    {
        [Test]
        public void Test()
        {
            var root = new TreeNode(10);
            root.left = new TreeNode(6);
            root.right = new TreeNode(14);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(8);

            root.right.left = new TreeNode(12);
            root.right.right = new TreeNode(16);

            Console.WriteLine("The pre-order traversal is 10, 6, 4, 8, 14, 12, 16.");
            Console.Write("Actual:                            ");
            PreOrderTraversal(root);
            Console.WriteLine("");
            Console.Write("Actual (loop):                 ");
            PreOrderTraversalLoop(root);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The in-order traversal is 4, 6, 8, 10, 12, 14, 16");
            Console.Write("Actual:                            ");
            InOrderTraversal(root);
            Console.WriteLine("");
            Console.Write("Actual (loop):                 ");
            InOrderTraversalLoop(root);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The post-order traversal is 4, 8, 6, 12, 16, 14, 10");
            Console.Write("Actual:                            ");
            PostOrderTraversal(root);
            Console.WriteLine("");
            Console.Write("Actual (loop):                 ");
            PostOrderTraversalLoop(root);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The Breadth First Traversal is 10, 6, 14, 4, 8, 12, 16");
            Console.Write("Actual:                            ");
            BreadthFirstTraversal(root);
        }

        // The root of a binary tree is visited first,
        // then its left children, and finally its right children
        public void PreOrderTraversal(TreeNode root)
        {
            if (root == null) return;

            Console.Write(root.val + " ");
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        public void PreOrderTraversalLoop(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                Console.Write(node.val + " ");
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
        }

        // Left children of a binary tree are visited first, 
        // then its root, and finally its right children
        public void InOrderTraversal(TreeNode root)
        {
            if (root == null) return;

            InOrderTraversal(root.left);
            Console.Write(root.val + " ");
            InOrderTraversal(root.right);
        }

        public void InOrderTraversalLoop(TreeNode root)
        {
            if (root == null) return;
            
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;

            // current != null - нет правого node, тогда достаем из stack (пока есть что доставать)
            while (current != null || stack.Count != 0)
            {
                // find the leftmost node
                // каждый раз от текущего node идем в самое лево
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                // достигли "дна", поднялись на один вверх
                current = stack.Pop();
                Console.Write(current.val + " ");

                // идем вправо. Если это leaf, то будет null, предыдущий цикл пропускаем
                // и сразу достаем root и печатаем, потом идем вправо на один и ... смотри цикл влево
                current = current.right;
            }
        }

        // Left children of a binary tree are visited first, then its right children,
        // and finally its root.
        public void PostOrderTraversal(TreeNode root)
        {
            if (root == null) return;

            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.Write(root.val + " ");
        }

        public void PostOrderTraversalLoop(TreeNode root)
        {
            if (root == null) return;
            // TODO
        }

        // Nodes in the first level are traversed, then nodes in the second level,
        // …, and finally nodes in the bottom level.
        public void BreadthFirstTraversal(TreeNode root)
        {
            if (root == null) return;

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.val + " ");

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
    }
}
