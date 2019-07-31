using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Arrays
{
    class MergeIntervals
    {
        [Test]
        public void Example1()
        {
            var array = new int[4][];
            array[0] = new int[] { 1, 2 };
            array[1] = new int[] { 2, 6 };
            array[2] = new int[] { 8, 10 };
            array[3] = new int[] { 15, 18 };
            var a = Merge(array);
        }

        [Test]
        public void Example2()
        {
            var array = new int[2][];
            array[0] = new int[] { 1, 4 };
            array[1] = new int[] { 4, 5 };
            var a = Merge(array);
        }

        [Test]
        public void Test1()
        {
            var array = new int[11][];
            array[4] = new int[] { 1, 4 };
            array[3] = new int[] { 4, 6 }; // 1 - 6
            array[0] = new int[] { 1, 6 }; // 1 - 6
            array[5] = new int[] { 1, 7 }; // 1 - 7
            array[1] = new int[] { 7, 7 }; // 1 - 7
            array[10] = new int[] { 2, 5 }; // 1 - 7
            array[6] = new int[] { 1, 1 }; // 1 - 7
            array[2] = new int[] { 1, 1 }; // 1 - 7
            array[7] = new int[] { 3, 7 }; // 1 - 7
            array[9] = new int[] { 2, 6 }; // 1 - 7
            array[8] = new int[] { 1, 2 }; // 1 - 7
            var a = Merge(array);
        }

        [Test]
        public void Test2()
        {
            var array = new int[1][];
            array[0] = new int[] { 1, 4 };
            var a = Merge(array);
        }

        [Test]
        public void Test3()
        {
            var array = new int[2][];
            array[0] = new int[] { 1, 4 };
            array[1] = new int[] { 4,12 };
            var a = Merge(array);
        }

        [Test]
        public void Test4()
        {
            var array = new int[2][];
            array[0] = new int[] { 1, 4 };
            array[1] = new int[] { 5, 12 };
            var a = Merge(array);
        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0 || intervals.Length == 1)
            {
                return intervals;
            }
            
            // TODO implement sorting
            Array.Sort(intervals, new Comparison<int[]>( (x, y) => { return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0); } ));

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);
            int r = 0;
            int i = 1;
            while (i < intervals.Length)
            {
                if (result[r][0] <= intervals[i][1] && result[r][1] >= intervals[i][0])
                {
                    // overlap
                    result[r][1] = Math.Max(intervals[i][1], result[r][1]);
                    i++;
                }
                else // no overlap
                {
                    result.Add(intervals[i]);
                    r++;
                    i++;
                }
            }
            
            return result.ToArray();
        }
    }
}
