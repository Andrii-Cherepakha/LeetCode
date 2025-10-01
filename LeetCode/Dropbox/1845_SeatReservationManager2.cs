using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Dropbox
{
    public class SeatReservationManager2
    {
        // private readonly HashSet<int> reserved = new HashSet<int>();
        private readonly PriorityQueue<int, int> available = new PriorityQueue<int, int>();

        public SeatReservationManager2(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                available.Enqueue(i, i); // O(n * log(N))
            }
        }

        public int Reserve()
        {
            // Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
            /*
            int seat = available.Dequeue(); // O(1)
            reserved.Add(seat); // O(1)
            return seat;
            */
            return available.Dequeue(); // O(1)
        }

        public void Unreserve(int seatNumber)
        {
            // Unreserves the seat with the given seatNumber.
            /*
            if (reserved.Contains(seatNumber))
            {
                reserved.Remove(seatNumber); // O(1)
                available.Enqueue(seatNumber, seatNumber); // O(log(N))
            }
            */
            available.Enqueue(seatNumber, seatNumber); // O(log(N))
        }
    }
}
