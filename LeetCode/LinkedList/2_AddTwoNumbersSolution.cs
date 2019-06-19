using System;
using NUnit.Framework;

namespace LeetCode.LinkedList
{
    public class AddTwoNumbersSolution
    {
        [Test]
        public void Test()
        {
            // 342
            ListNode l1_1 = new ListNode(3);
            ListNode l1_2 = new ListNode(4);
            l1_2.next = l1_1;
            ListNode l1_3 = new ListNode(2);
            l1_3.next = l1_2;

            // 465
            ListNode l2_1 = new ListNode(4);
            ListNode l2_2 = new ListNode(6);
            l2_2.next = l2_1;
            ListNode l2_3 = new ListNode(5);
            l2_3.next = l2_2;

            var result = AddTwoNumbers(l1_3, l2_3);
            var iRes = GetNumber(result);

            Console.WriteLine(iRes);
            Assert.That(iRes, Is.EqualTo(342 + 465));
        }

        [Test]
        public void TestDifferentLenght()
        {
            // 3427
            ListNode l1_1 = new ListNode(3);

            ListNode l1_2 = new ListNode(4);
            l1_2.next = l1_1;

            ListNode l1_3 = new ListNode(2);
            l1_3.next = l1_2;

            ListNode l1_4 = new ListNode(7);
            l1_4.next = l1_3;


            // 465
            ListNode l2_1 = new ListNode(4);
            ListNode l2_2 = new ListNode(6);
            l2_2.next = l2_1;
            ListNode l2_3 = new ListNode(5);
            l2_3.next = l2_2;

            var result = AddTwoNumbers(l1_4, l2_3);
            var iRes = GetNumber(result);

            Console.WriteLine(iRes);
            Assert.That(iRes, Is.EqualTo(3427 + 465));
        }

        [Test]
        public void TestCarry()
        {
            // 999
            ListNode l1_1 = new ListNode(9);
            ListNode l1_2 = new ListNode(9);
            l1_2.next = l1_1;
            ListNode l1_3 = new ListNode(9);
            l1_3.next = l1_2;

            // 111
            ListNode l2_1 = new ListNode(1);
            ListNode l2_2 = new ListNode(1);
            l2_2.next = l2_1;
            ListNode l2_3 = new ListNode(1);
            l2_3.next = l2_2;

            var result = AddTwoNumbers(l1_3, l2_3);
            var iRes = GetNumber(result);

            Console.WriteLine(iRes);
            Assert.That(iRes, Is.EqualTo(999 + 111));
        }

        [Test]
        public void TestCarry100()
        {
            // 1
            ListNode l1_1 = new ListNode(1);

            // 99
            ListNode l2_1 = new ListNode(9);
            ListNode l2_2 = new ListNode(9);
            l2_2.next = l2_1;

            var result = AddTwoNumbers(l1_1, l2_2);
            var iRes = GetNumber(result);

            Console.WriteLine(iRes);
            Assert.That(iRes, Is.EqualTo(1 + 99));
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode fakeRoot = new ListNode(-1);
            ListNode current = fakeRoot;
            int carry = 0;

            while (!(l1 == null && l2 == null && carry == 0))
            {
                int v1 = l1?.val ?? 0;
                int v2 = l2?.val ?? 0;

                int sum = v1 + v2 + carry;
                carry = sum / 10;

                var node = new ListNode(sum % 10);

                current.next = node;
                current = node;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            return fakeRoot.next;
        }


        public int GetNumber(ListNode root)
        {
            int number = 0;
            int multiplier = 1;

            while (root != null)
            {
                number = number + root.val * multiplier;
                multiplier = multiplier * 10;
                root = root.next;
            }

            return number;
        }
    }
}