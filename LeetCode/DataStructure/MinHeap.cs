using System;

namespace LeetCode.DataStructure
{
    public class MinHeap
    {
        public MinHeap(int size)
        {
            _arr = new HeapNode[size];
        }

        private HeapNode[] _arr;
        private int _tail = -1;

        public void Push(HeapNode node)
        {
            if (++_tail >= _arr.Length)
                throw new IndexOutOfRangeException($"Cannot insert value. Array capacity: {_arr.Length} Index: {_tail}");

            _arr[_tail] = node;

            int currentIndex = _tail;
            int parentIndex = GetParetnIndex(_tail);

            while (parentIndex >= 0 && _arr[currentIndex].Key < _arr[parentIndex].Key)
            {
                _arr[currentIndex] = _arr[parentIndex];
                _arr[parentIndex] = node;

                currentIndex = parentIndex;
                parentIndex = GetParetnIndex(currentIndex);
            }
        }

        public HeapNode Pop()
        {
            if (_tail == -1)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }

            var top = _arr[0];

            _arr[0] = _arr[_tail];
            _arr[_tail] = null;
            _tail--;

            int currentIndex = 0;
            while (LeftLeafExists(currentIndex))
            {
                int smallestIndex = GetLeftLeafIndex(currentIndex);

                if (RightLeafExists(currentIndex) && _arr[GetRightLeafIndex(currentIndex)].Key < _arr[smallestIndex].Key)
                {
                    smallestIndex = GetRightLeafIndex(currentIndex);
                }

                if (_arr[currentIndex].Key < _arr[smallestIndex].Key)
                {
                    break;
                }

                var tmp = _arr[currentIndex];
                _arr[currentIndex] = _arr[smallestIndex];
                _arr[smallestIndex] = tmp;

                currentIndex = smallestIndex;
            }

            return top;
        }

        public HeapNode Peek()
        {
            if (_tail == -1)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }

            return _arr[0];
        }

        public bool IsEmpty => _tail == -1;

        private int GetParetnIndex(int i) => (i - 1) / 2;
        private int GetLeftLeafIndex(int i) => i * 2 + 1;
        private int GetRightLeafIndex(int i) => i * 2 + 2;
        private bool LeftLeafExists(int i) => GetLeftLeafIndex(i) <= _tail;
        private bool RightLeafExists(int i) => GetRightLeafIndex(i) <= _tail;
    }
}
