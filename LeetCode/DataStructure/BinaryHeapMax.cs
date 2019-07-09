using System;

namespace LeetCode.DataStructure
{
    public class BinaryHeapMax
    {
        private int[] _arr;
        private int _tail = -1;

        public BinaryHeapMax(int size)
        {
            _arr = new int[size];
        }
        
        public bool IsEmpty => _tail == -1;

        public int[] Array => _arr;

        // log(N)
        public void Push(int value)
        {
            if (++_tail >= _arr.Length)
            {
                throw new IndexOutOfRangeException($"Cannot insert value. Array capacity: {_arr.Length} Index: {_tail}");
            }

            // put new value at the end
            _arr[_tail] = value;

            // walk up the tree and swap current value with parent if current value is greater than parent
            int currentIndex = _tail;
            int parentIndex = GetParent(_tail);
            while (parentIndex >= 0 && _arr[currentIndex] > _arr[parentIndex])
            {
                // swap values
                _arr[currentIndex] = _arr[parentIndex];
                _arr[parentIndex] = value;
                // update indexes
                currentIndex = parentIndex;
                parentIndex = GetParent(currentIndex);
            }
        }

        public int Pop()
        {
            if (_tail == -1)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }

            int top = _arr[0];

            _arr[0] = _arr[_tail];
            _arr[_tail] = 0; // clean up the value for debug purpose
            _tail--;

            int currentIndex = 0;
            while (LeftLeafExists(currentIndex))
            {
                int biggestValueIndex = GetLeftLeafIndex(currentIndex);

                if (RightLeafExists(currentIndex) &&
                    _arr[GetRightLeafIndex(currentIndex)] > _arr[GetLeftLeafIndex(currentIndex)])
                {
                    biggestValueIndex = GetRightLeafIndex(currentIndex);
                }

                if (_arr[currentIndex] >= _arr[biggestValueIndex])
                {
                    break;
                }
                
                // swap
                int tmp = _arr[currentIndex];
                _arr[currentIndex] = _arr[biggestValueIndex];
                _arr[biggestValueIndex] = tmp;
                // walk down
                currentIndex = biggestValueIndex;
            }

            return top;
        }

        private int GetParent(int i) { return (i - 1) / 2; }

        private int GetLeftLeafIndex(int i) { return i * 2 + 1; }
        private int GetRightLeafIndex(int i) { return i * 2 + 2; }

        private bool LeftLeafExists(int i) { return GetLeftLeafIndex(i) <= _tail; }
        private bool RightLeafExists(int i) { return GetRightLeafIndex(i) <= _tail; }
    }
}