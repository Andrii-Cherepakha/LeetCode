
namespace LeetCode.Dropbox
{
    public class SeatReservationManager3
    {
        // keep unreserved seats separately in a separate container
        //  if any element is present in this separate container, then it contains the minimum-numbered seat,
        // otherwise, if this separate container is empty then the marker points to the minimum-numbered unreserved seat.
        private readonly PriorityQueue<int, int> unreserved = new PriorityQueue<int, int>();
        private int marker = 1;

        public SeatReservationManager3(int n)
        {
        }

        public int Reserve()
        {
            // Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
            if (unreserved.Count != 0)
            {
                return unreserved.Dequeue();
            }
            int seat = marker;
            marker++;
            return seat;
        }

        public void Unreserve(int seatNumber)
        {
            // Unreserves the seat with the given seatNumber.
            unreserved.Enqueue(seatNumber, seatNumber); // O(log(N))
        }
    }
}
