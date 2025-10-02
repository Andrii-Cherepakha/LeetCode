
namespace LeetCode.Dropbox
{
    public class DesignHitCounter
    {
        private LinkedList<int> list = new LinkedList<int>();

        // All the calls are being made to the system in chronological order (i.e., timestamp is monotonically increasing) !!!!!
        public DesignHitCounter()
        {

        }

        public void Hit(int timestamp)
        {
            // Records a hit that happened at timestamp (in seconds). Several hits may happen at the same timestamp.
            list.AddFirst(timestamp);
        }

        public int GetHits(int timestamp)
        {
            // Returns the number of hits in the past 5 minutes from timestamp (i.e., the past 300 seconds).
            LinkedListNode<int> prev = list.Last;
            while (prev != null && prev.Value < timestamp - 300 + 1)
            {
                prev = prev.Previous;
                list.RemoveLast();
            }
            return list.Count;
        }
    }
}
