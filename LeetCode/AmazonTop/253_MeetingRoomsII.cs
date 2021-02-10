using System;

namespace LeetCode.AmazonTop
{
    class _253_MeetingRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {

            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            Array.Sort(start);
            Array.Sort(end);

            int rooms = 0;
            int s = 0;
            int e = 0;

            while (s < start.Length)
            {
                if (start[s] >= end[e]) // one of occupied romm is free
                {
                    e++;
                }
                else
                {
                    rooms++; // have to book one more room
                }
                s++;
            }

            return rooms;
        }
    }
}
