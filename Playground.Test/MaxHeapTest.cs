using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CCharpPlayground;

namespace Playground.Test
{

    [TestClass]
    public class MaxHeapTest
    {
        [TestMethod]
        public void MaxValue()
        {
            var maxHeap = new MaxHeap(10);

            maxHeap.Add(1);
            Assert.AreEqual(1, maxHeap.Peak());

            maxHeap.Add(10);
            Assert.AreEqual(10, maxHeap.Peak());

            maxHeap.Add(5);
            Assert.AreEqual(10, maxHeap.Peak());

            maxHeap.Add(2);
            Assert.AreEqual(10, maxHeap.Peak());

            maxHeap.Add(20);
            Assert.AreEqual(20, maxHeap.Peak());
        }

        [TestMethod]
        public void PopMax()
        {
            var maxHeap = new MaxHeap(10);

            maxHeap.Add(1);
            maxHeap.Add(10);
            maxHeap.Add(9);
            maxHeap.Add(5);
            maxHeap.Add(2);

            Assert.AreEqual(10, maxHeap.Peak());
            Assert.AreEqual(10, maxHeap.Pop());
            Assert.AreEqual(9, maxHeap.Peak());

            maxHeap.Add(20);
            maxHeap.Add(10);
            maxHeap.Add(30);
            Assert.AreEqual(30, maxHeap.Peak());
            Assert.AreEqual(30, maxHeap.Pop());
            Assert.AreEqual(20, maxHeap.Peak());
            Assert.AreEqual(20, maxHeap.Pop());
            Assert.AreEqual(10, maxHeap.Pop());
            Assert.AreEqual(9, maxHeap.Pop());
            Assert.AreEqual(5, maxHeap.Pop());
            Assert.AreEqual(2, maxHeap.Pop());
            Assert.AreEqual(1, maxHeap.Pop());

            Assert.AreEqual(0, maxHeap.Count);
        }
    }
}
