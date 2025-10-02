

namespace LeetCode.Dropbox
{
    public class DesignHitCounter2
    {
        private LinkedList<KeyValuePair<int, int>> list = new LinkedList<KeyValuePair<int, int>>();
        private int count = 0;

        // All the calls are being made to the system in chronological order (i.e., timestamp is monotonically increasing) !!!!!
        public DesignHitCounter2()
        {

        }

        public void Hit(int timestamp)
        {
            // Records a hit that happened at timestamp (in seconds). Several hits may happen at the same timestamp.
            if (list.First == null || list.First.Value.Key != timestamp)
            {

                list.AddFirst(KeyValuePair.Create(timestamp, 1));
            }
            else
            {
                var kvp = KeyValuePair.Create(list.First.Value.Key, list.First.Value.Value + 1);
                list.RemoveFirst();
                list.AddFirst(kvp);
            }

            count++;
        }

        public int GetHits(int timestamp)
        {
            // Returns the number of hits in the past 5 minutes from timestamp (i.e., the past 300 seconds).
            // LinkedListNode<int> prev = list.Last;
            while (list.Last != null && list.Last.Value.Key < timestamp - 300 + 1)
            {
                count -= list.Last.Value.Value;
                list.RemoveLast();
            }
            return count;
        }
    }
}
