using System;
using System.Collections.Generic;

namespace LeetCode.Trees._222_CountCompleteTreeNodes
{

    public class CountCompleteTreeNodesDraft
    {
        public int CountNodes(TreeNode root) // correct but bad memory usage
        {
            _leavesNum = 0;
            _maxLevel = 0;

            PreOrder(root, 0);
            //var full = (int) Math.Pow(2, _maxLevel) - 1;
            //var count = full + _leavesNum;
            Console.WriteLine($"Max level: {_maxLevel} leaves: {_leavesNum}");
            return (int) Math.Pow(2, _maxLevel) - 1 + _leavesNum;
        }

        private int _leavesNum;
        private int _maxLevel;

        private void PreOrder(TreeNode node, int level)
        {
            if (node == null)
            {
                return;
            }

            // if we found a node with no children and have never updated the max level before
            // then it is high time to do it
            if (node.left == null && node.right == null && _maxLevel == 0)
            {
                _maxLevel = level;
            }

            // if we found a node with no children on high level
            // then need to calculate it
            if (node.left == null && node.right == null && _maxLevel == level)
            {
                _leavesNum++;
                return;
            }
            
            PreOrder(node.left, level + 1);
            PreOrder(node.right, level + 1);
        }

        public int CountNodesQueue(TreeNode root) // correct but bad memory usage
        {
            if (root == null)
            {
                return 0;
            }

            int count = 0;
            var storage = new Queue<TreeNode>();
            storage.Enqueue(root);

            while (storage.Count != 0)
            {
                var node = storage.Dequeue();
                count++;

                if (node.left != null)
                {
                    storage.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    storage.Enqueue(node.right);
                }
            }

            return count;
        }

        public int CountNodesBadMemoryUsage(TreeNode root) // correct but bad memory usage
        {
            int count = 0;
            bool nullNodeFound = false;
            var storage = new List<TreeNode>();
            storage.Add(root);

            while (!nullNodeFound)
            {
                var buffer = new List<TreeNode>();

                foreach (var node in storage) // O( 2 ^ (log(N) - 1) )
                {
                    if (node != null)
                    {
                        count++;
                        buffer.Add(node.left);  // the order does matter
                        buffer.Add(node.right); // the order does matter
                    }

                    if (node == null)
                    {
                        nullNodeFound = true;
                        break;
                    }
                }

                storage = buffer; // O(1)
            }

            return count;
        }

        public int CountNodes1(TreeNode root)
        {
            int count = 0;

            _storage = new List<TreeNode>();
            _storage.Add(root);

            while (true)
            {
                bool needToExit = false;

                foreach (var node in _storage)
                {
                    if (node != null)
                    {
                        count++;
                    }

                    if (node == null)
                    {
                        needToExit = true;
                    }
                }

                if (needToExit)
                {
                    break;
                }

                UpdateStorage();
            }

            return count;
        }

        private void UpdateStorage() // O( 2 ^ (log(N) - 1) )
        {
            var currentLevelNodes = new List<TreeNode>();

            foreach (var node in _storage)
            {
                if (node != null)
                {
                    currentLevelNodes.Add(node.left);
                    currentLevelNodes.Add(node.right);
                }
            }

            _storage = currentLevelNodes;
        }

        //private List<TreeNode> _currentLevelNodes = new List<TreeNode>();
        private List<TreeNode> _storage;

        public int CountNodesWrong2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int level = 0;
            int count = 1; // == (int) Math.Pow(2, level)
            TreeNode currentNode = root;

            while (currentNode != null)
            {
                level++;

                if (currentNode.left != null)
                {
                    count = count + (int) Math.Pow(2, level);

                    if (currentNode.right == null)
                    {
                        count = count - 1;
                    }
                }

                currentNode = currentNode.right; // go to next level
            }

            return count;
        }

        public int CountNodesWrong1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int count = 0;
            int level = 0;
            TreeNode currentNode = root;

            while (true)
            {
                count = count + (int) Math.Pow(2, level);

                if (currentNode.right == null) // need to exit
                {
                    if (currentNode.left != null)
                    {
                        count = count + (int) Math.Pow(2, level + 1) - 1;
                    }

                    break;
                }

                currentNode = currentNode.right; // go to next level
                level++;
            }

            return count;
        }
    }
}