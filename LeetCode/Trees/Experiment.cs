using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Trees
{
    class Experiment
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

            root.left.left.right = new TreeNode(15);

            root.left.right.left = new TreeNode(19);

            root.right.right.left = new TreeNode(11);

            //PreOrderRecursion(root, 0);
            //InOrderRecursion(root, 0);
            //PostOrderRecursion(root, 0);
            PreOrderLoop(root);
        }

        private List<int> path = new List<int>();

        public void PreOrderRecursion(TreeNode node, int sum)
        {
            if (node == null) return;

            // N - do smth with the node

            path.Add(node.val);

            // examinations

            if (node.left == null && node.right == null) // leaf
            {
                // let's print path
                Console.WriteLine();
                Console.WriteLine($"Leaf reached: {node.val}");
                string pathStr = string.Join(" - ", path);
                Console.WriteLine($"Path from root: {pathStr}");
                Console.WriteLine($"Sum from root: {sum + node.val}");
            }

            // L - go left
            if (node.left != null)
            {
                PreOrderRecursion(node.left, sum + node.val);
            }

            // R - go right
            if (node.right != null)
            {
                PreOrderRecursion(node.right, sum + node.val);
            }

            path.RemoveAt(path.Count - 1); // Remove last (current) node
        }

        public void InOrderRecursion(TreeNode node, int sum)
        {
            if (node == null) return;

            // L - go left
            if (node.left != null)
            {
                InOrderRecursion(node.left, sum + node.val);
            }

            // N - do smth with the node
            path.Add(node.val);

            // R - go right
            if (node.right != null)
            {
                InOrderRecursion(node.right, sum + node.val);
            }

            // examination
            if (node.left == null && node.right == null) // leaf
            {
                // let's print path
                Console.WriteLine();
                Console.WriteLine($"Leaf reached: {node.val}");
                string pathStr = string.Join(" - ", path);
                Console.WriteLine($"Path from root: {pathStr}");
                Console.WriteLine($"Sum from root: {sum + node.val}");
            }

            path.RemoveAt(path.Count - 1); // Remove last (current) node
        }
        public void PostOrderRecursion(TreeNode node, int sum)
        {
            if (node == null) return;

            // L - go left
            if (node.left != null)
            {
                PostOrderRecursion(node.left, sum + node.val);
            }

            // R - go right
            if (node.right != null)
            {
                PostOrderRecursion(node.right, sum + node.val);
            }

            // N - do smth with the node
            path.Add(node.val);

            // examination
            if (node.left == null && node.right == null) // leaf
            {
                // let's print path
                Console.WriteLine();
                Console.WriteLine($"Leaf reached: {node.val}");
                string pathStr = string.Join(" - ", path);
                Console.WriteLine($"Path from root: {pathStr}");
                Console.WriteLine($"Sum from root: {sum + node.val}");
            }

            path.RemoveAt(path.Count - 1); // Remove last (current) node
        }


        public void PreOrderLoop(TreeNode root)
        {
            if (root == null) return;

            var stack = new Stack<TreeNode>();
            var sumStack = new Stack<int>();
            var pathStack = new Stack<List<int>>();

            stack.Push(root);
            sumStack.Push(root.val);
            pathStack.Push(new List<int>() { root.val });

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var sum = sumStack.Pop();
                var path = pathStack.Pop();

                // N - do smth with node

                if (node.right != null)
                {
                    stack.Push(node.right);
                    sumStack.Push(sum + node.right.val);

                    var newPath = new List<int>(path);
                    newPath.Add(node.right.val);
                    pathStack.Push(newPath);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    sumStack.Push(sum + node.left.val);

                    var newPath = new List<int>(path);
                    newPath.Add(node.left.val);
                    pathStack.Push(newPath);
                }

                // examination
                if (node.left == null && node.right == null)
                {
                    // let's print path
                    Console.WriteLine();
                    Console.WriteLine($"Leaf reached: {node.val}");
                    string pathStr = string.Join(" - ", path.ToList());
                    Console.WriteLine($"Path from root: {pathStr}");
                    Console.WriteLine($"Sum from root: {sum}");                    
                }
            }
        }
    }
}