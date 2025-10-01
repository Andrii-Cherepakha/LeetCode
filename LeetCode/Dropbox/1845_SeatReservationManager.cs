
namespace LeetCode.Dropbox
{
    public class SeatReservationManager // Time Limit Exceeded
    {
        private readonly int[] _seats;

        public SeatReservationManager(int n)
        {
            _seats = new int[n];
            for (int i = 0; i < _seats.Length; i++)
            {
                _seats[i] = 0;
            }
        }

        public int Reserve()
        {
            // Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
            for (int i = 0; i < _seats.Length; i++)
            {
                if (_seats[i] == 0)
                {
                    _seats[i] = 1;
                    return i + 1;
                }
            }
            return 0;
        }

        public void Unreserve(int seatNumber)
        {
            _seats[seatNumber - 1] = 0;
        }
    }
}
