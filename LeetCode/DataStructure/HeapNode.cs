namespace LeetCode.DataStructure
{
    public class HeapNode
    {
        public int Key { get; private set; }
        public int Value { get; private set; }

        public HeapNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}
