using CCharpPlayground.Heap;
using Xunit;

namespace Playground.Test
{


    public class MaxHeapTest
    {
        [Fact]
        public void MaxValue()
        {
            var maxHeap = new MaxHeap(10);

            maxHeap.Add(1);
            Assert.Equal(1, maxHeap.Peak());

            maxHeap.Add(10);
            Assert.Equal(10, maxHeap.Peak());

            maxHeap.Add(5);
            Assert.Equal(10, maxHeap.Peak());

            maxHeap.Add(2);
            Assert.Equal(10, maxHeap.Peak());

            maxHeap.Add(20);
            Assert.Equal(20, maxHeap.Peak());
        }

        [Fact]
        public void PopMax()
        {
            var maxHeap = new MaxHeap(10);

            maxHeap.Add(1);
            maxHeap.Add(10);
            maxHeap.Add(9);
            maxHeap.Add(5);
            maxHeap.Add(2);

            Assert.Equal(10, maxHeap.Peak());
            Assert.Equal(10, maxHeap.Pop());
            Assert.Equal(9, maxHeap.Peak());

            maxHeap.Add(20);
            maxHeap.Add(10);
            maxHeap.Add(30);
            Assert.Equal(30, maxHeap.Peak());
            Assert.Equal(30, maxHeap.Pop());
            Assert.Equal(20, maxHeap.Peak());
            Assert.Equal(20, maxHeap.Pop());
            Assert.Equal(10, maxHeap.Pop());
            Assert.Equal(9, maxHeap.Pop());
            Assert.Equal(5, maxHeap.Pop());
            Assert.Equal(2, maxHeap.Pop());
            Assert.Equal(1, maxHeap.Pop());

            Assert.Equal(0, maxHeap.Count);
        }
    }
}
