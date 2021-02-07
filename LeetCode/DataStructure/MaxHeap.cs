using System;

namespace LeetCode.DataStructure
{
    public class MaxHeap
    {
        private HeapNode[] _arr;
        private int _tail = -1;

        public MaxHeap(int size)
        {
            _arr = new HeapNode[size];
        }

        public void Push(HeapNode node)
        {
            if (++_tail >= _arr.Length)
            {
                throw new IndexOutOfRangeException($"Cannot insert value. Array capacity: {_arr.Length} Index: {_tail}");
            }

            _arr[_tail] = node;

            // walk up the tree and swap current value with parent if current value is greater than parent
            int currentIndex = _tail;
            int parentIndex = GetParent(_tail);

            while (parentIndex >=0 && _arr[currentIndex].Key > _arr[parentIndex].Key)
            {
                _arr[currentIndex] = _arr[parentIndex];
                _arr[parentIndex] = node; // do not need to use tmp

                currentIndex = parentIndex;
                parentIndex = GetParent(currentIndex);
            }
        }

        public HeapNode Pop()
        {
            if (_tail == -1)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }

            HeapNode top = _arr[0];

            _arr[0] = _arr[_tail];
            _arr[_tail] = null;
            _tail--;

            int currentIndex = 0;
            while (LeftLeafExists(currentIndex))
            {
                int biggestIndex = GetLeftLeafIndex(currentIndex);

                if (RightLeafExists(currentIndex) && _arr[GetRightLeafIndex(currentIndex)].Key > _arr[biggestIndex].Key)
                {
                    biggestIndex = GetRightLeafIndex(currentIndex);
                }

                if (_arr[currentIndex].Key > _arr[biggestIndex].Key)
                {
                    break;
                }

                // swap
                var tmp = _arr[currentIndex];
                _arr[currentIndex] = _arr[biggestIndex];
                _arr[biggestIndex] = tmp;

                // go further
                currentIndex = biggestIndex;
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

        private int GetParent(int i) { return (i - 1) / 2; }
        private int GetLeftLeafIndex(int i) { return i * 2 + 1; }
        private int GetRightLeafIndex(int i) { return i * 2 + 2; }
        private bool LeftLeafExists(int i) { return GetLeftLeafIndex(i) <= _tail; }
        private bool RightLeafExists(int i) { return GetRightLeafIndex(i) <= _tail; }
    }
}