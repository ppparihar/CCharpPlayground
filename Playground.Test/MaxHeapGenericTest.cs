using CCharpPlayground.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test
{

    [TestClass]
    public class MaxHeapGenericGenericTest
    {
        [TestMethod]
        public void MaxValue()
        {
            var MaxHeapGeneric = new MaxHeapGeneric<int>(10);

            MaxHeapGeneric.Add(1);
            Assert.AreEqual(1, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(10);
            Assert.AreEqual(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(5);
            Assert.AreEqual(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(2);
            Assert.AreEqual(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(20);
            Assert.AreEqual(20, MaxHeapGeneric.Peak());
        }

        [TestMethod]
        public void PopMax()
        {
            var MaxHeapGeneric = new MaxHeapGeneric<int>(10);

            MaxHeapGeneric.Add(1);
            MaxHeapGeneric.Add(10);
            MaxHeapGeneric.Add(9);
            MaxHeapGeneric.Add(5);
            MaxHeapGeneric.Add(2);

            Assert.AreEqual(10, MaxHeapGeneric.Peak());
            Assert.AreEqual(10, MaxHeapGeneric.Pop());
            Assert.AreEqual(9, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(20);
            MaxHeapGeneric.Add(10);
            MaxHeapGeneric.Add(30);
            Assert.AreEqual(30, MaxHeapGeneric.Peak());
            Assert.AreEqual(30, MaxHeapGeneric.Pop());
            Assert.AreEqual(20, MaxHeapGeneric.Peak());
            Assert.AreEqual(20, MaxHeapGeneric.Pop());
            Assert.AreEqual(10, MaxHeapGeneric.Pop());
            Assert.AreEqual(9, MaxHeapGeneric.Pop());
            Assert.AreEqual(5, MaxHeapGeneric.Pop());
            Assert.AreEqual(2, MaxHeapGeneric.Pop());
            Assert.AreEqual(1, MaxHeapGeneric.Pop());

            Assert.AreEqual(0, MaxHeapGeneric.Count);
        }
    }
}
