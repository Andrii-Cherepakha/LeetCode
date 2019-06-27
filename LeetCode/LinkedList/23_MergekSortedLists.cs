using NUnit.Framework;

namespace LeetCode.LinkedList
{
    public class MergekSortedLists
    {
        [Test]
        public void Test0()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);

            var lists = new[] {l1};

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test1()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode l3 = new ListNode(2);
            l3.next = new ListNode(6);

            var lists = new [] {l1, l2, l3};

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test2()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);

            ListNode l2 = new ListNode(6);
            l2.next = new ListNode(7);
            l2.next.next = new ListNode(8);
            l2.next.next.next = new ListNode(9);

            ListNode l3 = new ListNode(10);
            l3.next = new ListNode(11);

            var lists = new[] { l1, l2, l3 };

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test3()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(1);
            l1.next.next = new ListNode(1);

            ListNode l2 = new ListNode(2);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(2);

            ListNode l3 = new ListNode(3);
            l3.next = new ListNode(3);
            l3.next.next = new ListNode(3);

            var lists = new[] { l1, l2, l3 };

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        [Test]
        public void Test4()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(3);

            ListNode l3 = new ListNode(1);
            l3.next = new ListNode(2);
            l3.next.next = new ListNode(3);

            ListNode l4 = new ListNode(1);
            l4.next = new ListNode(2);
            l4.next.next = new ListNode(3);

            var lists = new[] { l1, l2, l3, l4 };

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }


        [Test]
        public void Test5()
        {
            //var lists = new ListNode[] { null, null };
            //var lists = new ListNode[] { null };
            ListNode[] lists = null;

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }


        [Test]
        public void Test6()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(4);
            l2.next = new ListNode(5);
            l2.next.next = new ListNode(6);

            //var lists = new ListNode[] { null, l1, null, l2, null };
            var lists = new ListNode[] { null, l1, null, null, null, l2, null };

            var result = MergeKLists(lists);

            LinkedListHelper.PrintList(result);
            LinkedListHelper.CheckSorted(result);
        }

        // O (k * N) where k == count of the lists
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
            {
                return null;
            }
            
            // edge case - remove null lists
            int listsCount = lists.Length;
            for (int i = 0; i < listsCount;)
            {
                if (lists[i] == null)
                {
                    lists[i] = lists[listsCount - 1];
                    listsCount--;
                    continue;
                }
                i++;
            }
            
            if (listsCount == 0)
            {
                return null;
            }

            ListNode resultList = new ListNode(-1);
            ListNode start = resultList;

            while (listsCount > 1)
            {
                int listToConsider = 0; // start with first list
                // go through the lists
                for (int i = 1; i < listsCount; ++i)
                {
                    // find the smallest element among the first elements of each list
                    if (lists[i].val < lists[listToConsider].val)
                    {
                        listToConsider = i;
                    }
                }

                // add found element to the result list
                resultList.next = lists[listToConsider];
                // delete the element from the list
                if (lists[listToConsider].next == null)
                {
                    // it was the last element in the list
                    // assign the last list form the lists to that position
                    lists[listToConsider] = lists[listsCount - 1];
                    listsCount--;
                }
                else
                {
                    lists[listToConsider] = lists[listToConsider].next;
                }

                // move the pointer step forward
                resultList = resultList.next;
            }

            resultList.next = lists[0]; // add the tail

            return start.next;
        }
    }
}