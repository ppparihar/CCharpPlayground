using CCharpPlayground.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test
{

    [TestClass]
    public class MinHeapTest
    {
        [TestMethod]
        public void MinValue()
        {
            var minHeap = new MinHeap(10);

            minHeap.Add(10);
            Assert.AreEqual(10, minHeap.Peak());

            minHeap.Add(9);
            Assert.AreEqual(9, minHeap.Peak());

            minHeap.Add(5);
            Assert.AreEqual(5, minHeap.Peak());

            minHeap.Add(20);
            Assert.AreEqual(5, minHeap.Peak());

            minHeap.Add(15);
            Assert.AreEqual(5, minHeap.Peak());
        }

        [TestMethod]
        public void PopMin()
        {
            var minheap = new MinHeap(20);

            minheap.Add(1);
            minheap.Add(10);
            minheap.Add(9);
            minheap.Add(5);
            minheap.Add(2);

            Assert.AreEqual(1, minheap.Peak());
            Assert.AreEqual(1, minheap.Pop());
            Assert.AreEqual(2, minheap.Peak());

            minheap.Add(20);
            minheap.Add(10);
            minheap.Add(30);
            Assert.AreEqual(2, minheap.Peak());
            Assert.AreEqual(2, minheap.Pop());
            Assert.AreEqual(5, minheap.Peak());
            Assert.AreEqual(5, minheap.Pop());
            Assert.AreEqual(9, minheap.Pop());
            Assert.AreEqual(10, minheap.Pop());
            Assert.AreEqual(10, minheap.Pop());
            Assert.AreEqual(20, minheap.Pop());
            Assert.AreEqual(30, minheap.Pop());


            Assert.AreEqual(0, minheap.Count);
        }
    }
}
