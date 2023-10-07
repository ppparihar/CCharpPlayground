using System;
using System.Collections.Generic;
using System.Text;

namespace CCharpPlayground.Heap
{
    public class MaxHeapGeneric<T> where T : IComparable<T>
    {
        T[] heap;

        public int Count { get; private set; }

        IComparer<T> Comparer;
        public MaxHeapGeneric(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("The size can not be negative");
            }
            heap = new T[size];
        }
        public MaxHeapGeneric(int size, IComparer<T> comparer) : this(size)
        {
            Comparer = comparer;
        }
        public T Peak()
        {
            if (Count <= 0)
            {
                throw new ArgumentOutOfRangeException("There are not item in the heap");
            }
            return heap[0];
        }

        public T Pop()
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

        public void Add(T item)
        {
            heap[Count] = item;
            Count++;
            ChildParentHeapify(Count - 1);
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;

        private void MaxHeapify(int index)
        {
            var left = LeftChild(index);
            var right = RightChild(index);
            var largest = index;
            if (left >= Count)
            {
                return;
            }

            largest = DoCompare(left, largest) > 0 ? left : largest;

            if (right < Count)
            {
                largest = DoCompare(right, largest) > 0 ? right : largest;
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
            var parent = Parent(index);
            if (DoCompare(index, parent) > 0)
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

        private int DoCompare(int firstIndex, int secondIndex)
        {
            T initial = heap[firstIndex];
            T contender = heap[secondIndex];
            return Comparer != null ? Comparer.Compare(initial, contender) : initial.CompareTo(contender);
        }
    }
}
