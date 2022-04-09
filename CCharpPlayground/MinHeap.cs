using System;
using System.Collections.Generic;
using System.Text;

namespace CCharpPlayground
{
    public class MinHeap
    {
        int[] heap;

        public int Count { get; private set; }
        public MinHeap(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("The size can not be negative");
            }
            heap = new int[size];
        }
        public int Peak()
        {
            if (Count <= 0)
            {
                throw new ArgumentOutOfRangeException("There are not item in the heap");
            }
            return heap[0];
        }

        public int Pop()
        {
            if (Count <= 0)
            {
                throw new ArgumentOutOfRangeException("There are not item in the heap");
            }
            var temp = heap[0];
            heap[0] = heap[Count - 1];
            Count--;
            MinHeapify(0);
            return temp;
        }

        public void Add(int item)
        {
            heap[Count] = item;
            Count++;
            ChildParentHeapify(Count - 1);
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;

        private void MinHeapify(int index)
        {
            var left = LeftChild(index);
            var right = RightChild(index);
            var smallest = index;
            if (left >= Count)
            {
                return;
            }

            smallest = heap[smallest] > heap[left] ? left : smallest;

            if (right < Count)
            {
                smallest = heap[smallest] > heap[right] ? right : smallest;
            }
            if (smallest != index)
            {
                Swap(index, smallest);
                MinHeapify(smallest);
            }
        }
        private void ChildParentHeapify(int index)
        {
            if (index <= 0 || index >= Count)
            {
                return;
            }
            var parent = Parent(index);
            if (heap[parent] > heap[index])
            {
                Swap(index, parent);
                ChildParentHeapify(parent);
            }
        }

        private void Swap(int a, int b)
        {
            var temp = heap[b];
            heap[b] = heap[a];
            heap[a] = temp;
        }
    }
}
