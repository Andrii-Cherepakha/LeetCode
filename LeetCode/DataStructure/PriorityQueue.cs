using System;

namespace LeetCode.DataStructure
{
    // heap (self-balanced BST)
    class PriorityQueue
    {
        // for i node 
        // left child is i*2
        // right child is i*2+1
        // root is i/2
        private int[] _arr;
        private int end; // current position to insert, tail
        private const int StartIndex = 1;

        public PriorityQueue(int size)
        {
            _arr = new int[size + 1]; // will start to store data in the array with index 1
            end = 0;         // start index == 1, see Push (++end)
        }

        public bool IsEmpty => end < StartIndex;

        // log(N)
        public void Push(int value)
        {
            if (++end >= _arr.Length)
            {
                throw new IndexOutOfRangeException($"Cannot insert value. Array capacity: {_arr.Length} Index: {end}");
            }

            _arr[end] = value;

            int parentIndex = end / 2;
            int newValueIndex = end;
            // walk up the tree
            while (parentIndex >= StartIndex && _arr[parentIndex] < _arr[newValueIndex]) // while parent is smaller and the root is not reached
            {
                // swap
                _arr[newValueIndex] = _arr[parentIndex];
                _arr[parentIndex] = value; // no need tmp storage since we have value passed as a parameter
                newValueIndex = parentIndex;
                parentIndex = parentIndex / 2;
            }
        }

        // log(N)
        public int Pop()
        {
            int largest = _arr[1];
            
            // replace the value in the root with the value at the end (rightmost leaf)
            _arr[1] = _arr[end];
            _arr[end] = 0; // just for debug purpose
            end--;

            // walk down the tree
            int root = 1;
            int left = root * 2;
            int right = root * 2 + 1;
            while (!(left > end && right > end))
            {
                // if the value in the root is not smaller than each childen - OK, nothing to do
                //if ((right <= end && _arr[root] >= _arr[left] && _arr[root] >= _arr[right]) ||
                //    (right > end && _arr[root] >= _arr[left]))

                // if the value in the root is not smaller than each childen - OK, nothing to do
                if (_arr[root] >= _arr[left] && ((right <= end && _arr[root] >= _arr[right]) || (right > end) ))
                {
                    break;
                }

                // if the value in the root (current) is less than one of its children - swap the value with the largets child
                int tmp = _arr[root];
                if (right > end) // there is no right leaf, only left
                {
                    // swap with left leaf
                    _arr[root] = _arr[left];
                    _arr[left] = tmp;
                    // change root
                    root = left;
                }
                else // both left and right leaves
                {
                    if (_arr[left] > _arr[right])
                    {
                        // swap with left leaf
                        _arr[root] = _arr[left];
                        _arr[left] = tmp;
                        // change root
                        root = left;
                    }
                    else
                    {
                        // swap with right leaf
                        _arr[root] = _arr[right];
                        _arr[right] = tmp;
                        root = right;
                    }
                }
                               
                left = root * 2;
                right = root * 2 + 1;
            }

            return largest;
        }

        public int[] Array => _arr;
    }
}
