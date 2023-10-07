using System;
using System.Collections.Generic;
using System.Text;

namespace CCharpPlayground.Heap
{
    public class MinHeapGeneric<T> where T : IComparable<T>
    {
        T[] heap;

        public int Count { get; private set; }

        IComparer<T> Comparer;
        public MinHeapGeneric(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("The size can not be negative");
            }
            heap = new T[size];
        }
        public MinHeapGeneric(int size, IComparer<T> comparer) : this(size)
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
            ParentChildHeapify(0);
            return temp;
        }

        public void Add(T item)
        {
            if (Count == heap.Length)
            {
                throw new ArgumentOutOfRangeException("Max limit of heap has reached, Can't add new item");
            }
            heap[Count] = item;
            Count++;
            ChildParentHeapify(Count - 1);
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;

        private void ParentChildHeapify(int index)
        {
            var left = LeftChild(index);
            var right = RightChild(index);
            var smallerIndex = index;
            if (left >= Count)
            {
                return;
            }

            smallerIndex = DoCompare(left, smallerIndex) < 0 ? left : smallerIndex;

            if (right < Count)
            {
                smallerIndex = DoCompare(right, smallerIndex) < 0 ? right : smallerIndex;
            }
            if (smallerIndex != index)
            {
                Swap(index, smallerIndex);
                ParentChildHeapify(smallerIndex);
            }
        }

        private void ChildParentHeapify(int index)
        {
            if (index <= 0 || index >= Count)
            {
                return;
            }
            var parent = Parent(index);
            if (DoCompare(index, parent) < 0)
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
