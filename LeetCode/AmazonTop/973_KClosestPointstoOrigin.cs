using System;

namespace LeetCode.AmazonTop
{
    public class _973_KClosestPointstoOrigin
    {
        public int[][] KClosest(int[][] points, int K)
        {

            var heap = new MaxHeap(K);

            int i = 1;
            foreach (var point in points)
            {
                int distance = point[0] * point[0] + point[1] * point[1]; // SQRT
                var node = new HeapNode();
                node.distance = distance;
                node.point = point;

                if (i <= K)
                {
                    heap.Push(node);
                }
                else
                {
                    var max = heap.Peek().distance;
                    if (distance < max)
                    {
                        heap.Pop();
                        heap.Push(node);
                    }
                }
                i++;
            }

            int[][] res = new int[heap.Count][];

            i = 0;
            while (heap.Count > 0)
            {
                var node = heap.Pop();
                res[i] = node.point;
                i++;
            }

            return res;
        }
    }

    public class MaxHeap
    {
        public MaxHeap(int size)
        {
            arr = new HeapNode[size];
        }

        public void Push(HeapNode node)
        {
            if (++tail >= arr.Length)
                throw new Exception("Heap is full");

            arr[tail] = node;

            // 
            int currentIndex = tail;
            int parentIndex = GetParent(currentIndex);

            while (parentIndex >= 0 && arr[parentIndex].distance < arr[currentIndex].distance)
            {
                arr[currentIndex] = arr[parentIndex];
                arr[parentIndex] = node;

                currentIndex = parentIndex;
                parentIndex = GetParent(currentIndex);
            }
        }

        public HeapNode Pop()
        {
            if (Count == 0)
                throw new Exception("There are no elements in the heap");

            var nodeToReturn = arr[0];

            arr[0] = arr[tail];
            arr[tail] = null;
            tail--;

            int currentIndex = 0;
            while (LeftLeafExists(currentIndex))
            {
                int biggest = GetLeftLeafIndex(currentIndex);

                if (RigthLeafExists(currentIndex) && arr[GetRigthLeafIndex(currentIndex)].distance > arr[biggest].distance)
                {
                    biggest = GetRigthLeafIndex(currentIndex);
                }

                if (arr[currentIndex].distance > arr[biggest].distance)
                {
                    break;
                }

                // swap
                HeapNode tmp = arr[biggest];
                arr[biggest] = arr[currentIndex];
                arr[currentIndex] = tmp;

                currentIndex = biggest;
            }


            return nodeToReturn;
        }

        public HeapNode Peek()
        {
            if (Count == 0)
                throw new Exception("There are no elements in the heap");

            return arr[0];
        }

        //public bool IsEmpty => tail == -1;
        public int Count => tail + 1;

        private HeapNode[] arr;
        private int tail = -1;

        private int GetParent(int i) => (i - 1) / 2;
        private int GetLeftLeafIndex(int i) => i * 2 + 1;
        private int GetRigthLeafIndex(int i) => i * 2 + 2;
        private bool LeftLeafExists(int i) => GetLeftLeafIndex(i) <= tail;
        private bool RigthLeafExists(int i) => GetRigthLeafIndex(i) <= tail;
    }

    public class HeapNode
    {
        public int distance;
        public int[] point;
    }
}

