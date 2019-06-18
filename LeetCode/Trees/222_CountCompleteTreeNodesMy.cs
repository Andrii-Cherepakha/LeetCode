using System;
using NUnit.Framework;

namespace LeetCode.Trees
{

    // Hint: focus on a leave. Leave can be on the last or previous level
    // recursive call the method on left and right nodes with level + 1
    // Total number of nodes = Math.Pow(2, height) - 1; height starts with 0
    // than we need to add leaves on the last level

    // Hint: there is another one solution with <<
    public class CountCompleteTreeNodesMy
    {
        [Test]
        public void TestNull()
        {
            var cnt = CountNodes(null);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(0));
        }

        [Test]
        public void TestOneNode()
        {
            var root = new TreeNode(1);
            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(1));
        }

        [Test]
        public void TestTwoLevels1()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(2));
        }

        [Test]
        public void TestTwoLevels2()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(3));
        }

        [Test]
        public void TestThreeLevels4()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(4));
        }

        [Test]
        public void TestThreeLevels5()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(5));
        }

        [Test]
        public void TestThreeLevels6()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left = new TreeNode(6);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(6));
        }

        [Test]
        public void TestThreeLevels7()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            var cnt = CountNodes(root);
            Console.WriteLine(cnt);
            Assert.That(cnt, Is.EqualTo(7));
        }

        public int CountNodes(TreeNode root) 
        {
            _height = 0;
            var leavesNum = SumOfLeaves(root, 0);
            // Console.WriteLine($"Max level: {_maxLevel} leaves: {leavesNum}");
            return (int) Math.Pow(2, _height) - 1 + leavesNum;
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