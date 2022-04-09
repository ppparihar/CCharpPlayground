﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCharpPlayground
{
    public class MaxHeap
    {
        int[] heap;

        public int Count { get; private set; }
        public MaxHeap(int size)
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
            MaxHeapify(0);
            return temp;
        }

        public void Add(int item)
        {
            heap[Count] = item;
            Count++;
            ChildParentHeapify(Count - 1);
        }

        private void MaxHeapify(int index)
        {
            var left = 2 * index + 1;
            var right = left + 1;
            var largest = index;
            if (left >= Count)
            {
                return;
            }

            largest = heap[largest] < heap[left] ? left : largest;

            if (right < Count)
            {
                largest = heap[largest] < heap[right] ? right : largest;
            }
            if (largest != index)
            {
                Swap(index, largest);
                MaxHeapify(largest);
            }
        }
        private void ChildParentHeapify(int index)
        {
            if (index <= 0 || index >= Count)
            {
                return;
            }
            var parent = index / 2;
            if (heap[parent] < heap[index])
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
