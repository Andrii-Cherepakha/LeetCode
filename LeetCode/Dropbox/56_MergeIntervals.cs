
namespace LeetCode.Dropbox
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0 || intervals[0].Length == 0)
            {
                return intervals;
            }

            Array.Sort(intervals, (i1, i2) => i1[0] - i2[0]);
            var result = new LinkedList<int[]>();

            result.AddLast(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                var last = result.Last.Value;
                if (intervals[i][0] <= last[1]) // start2 <= end1
                {
                    last[1] = Math.Max(last[1], intervals[i][1]);
                }
                else
                {
                    result.AddLast(intervals[i]);
                }
            }

            return result.ToArray();
        }
    }
}
