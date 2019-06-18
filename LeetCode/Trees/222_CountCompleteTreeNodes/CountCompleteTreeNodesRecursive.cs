using System;

namespace LeetCode.Trees._222_CountCompleteTreeNodes
{

    // Hint: focus on a leave. Leave can be on the last or previous level
    // recursive call the method on left and right nodes with level + 1
    // Total number of nodes = Math.Pow(2, height) - 1; height starts with 0
    // than we need to add leaves on the last level
    public class CountCompleteTreeNodesRecursive : ICountCompleteTreeNodes
    {
        public int CountNodes(TreeNode root) 
        {
            _height = 0;
            var leavesNum = SumOfLeaves(root, 0);
            // Console.WriteLine($"Max level: {_maxLevel} leaves: {leavesNum}");
            //return (int) Math.Pow(2, _height) - 1 + leavesNum;  
            int power = 1 << _height;
            return power - 1 + leavesNum;
        }

        private int _height;

        private int SumOfLeaves(TreeNode node, int level)
        {
            if (node == null)
            {
                return 0;
            }

            // if we found a leave (node with no children) and have never updated the max level before
            // then it is high time to do it
            if (node.left == null && node.right == null && _height == 0)
            {
                _height = level;
            }

            // if we found a leave (node with no children) on max level
            // then need to calculate it
            if (node.left == null && node.right == null && _height == level)
            {
                return 1;
            }

            // the order does matter (first left then right)
            return SumOfLeaves(node.left, level + 1) + SumOfLeaves(node.right, level + 1);
        }
    }
}