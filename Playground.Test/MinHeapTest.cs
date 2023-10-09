using CCharpPlayground.Heap;

namespace Playground.Test
{

    public class MinHeapTest
    {
        [Fact]
        public void MinValue()
        {
            var minHeap = new MinHeap(10);

            minHeap.Add(10);
            Assert.Equal(10, minHeap.Peak());

            minHeap.Add(9);
            Assert.Equal(9, minHeap.Peak());

            minHeap.Add(5);
            Assert.Equal(5, minHeap.Peak());

            minHeap.Add(20);
            Assert.Equal(5, minHeap.Peak());

            minHeap.Add(15);
            Assert.Equal(5, minHeap.Peak());
        }

        [Fact]
        public void PopMin()
        {
            var minheap = new MinHeap(20);

            minheap.Add(1);
            minheap.Add(10);
            minheap.Add(9);
            minheap.Add(5);
            minheap.Add(2);

            Assert.Equal(1, minheap.Peak());
            Assert.Equal(1, minheap.Pop());
            Assert.Equal(2, minheap.Peak());

            minheap.Add(20);
            minheap.Add(10);
            minheap.Add(30);
            Assert.Equal(2, minheap.Peak());
            Assert.Equal(2, minheap.Pop());
            Assert.Equal(5, minheap.Peak());
            Assert.Equal(5, minheap.Pop());
            Assert.Equal(9, minheap.Pop());
            Assert.Equal(10, minheap.Pop());
            Assert.Equal(10, minheap.Pop());
            Assert.Equal(20, minheap.Pop());
            Assert.Equal(30, minheap.Pop());


            Assert.Equal(0, minheap.Count);
        }
    }
}
