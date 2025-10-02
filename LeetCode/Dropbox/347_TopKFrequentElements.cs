namespace LeetCode.Dropbox
{
    public class TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums == null)
            {
                return nums;
            }

            var dict = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                var f = dict.ContainsKey(n) ? dict[n] : 0;
                dict[n] = f + 1;
            }

            var q = new PriorityQueue<int, int>(); // element, priority
            foreach (var key in dict.Keys)
            {
                q.Enqueue(key, dict[key]);
            }

            while (q.Count > k)
            {
                q.Dequeue();
            }

            List<int> l = new List<int>();
            while (q.Count > 0)
            {
                l.Add(q.Dequeue());

            }
            return l.ToArray();
        }
    }
}
