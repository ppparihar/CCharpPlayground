using CCharpPlayground.Heap;
using Xunit;

namespace Playground.Test
{
    public class MaxHeapGenericGenericTest
    {
        [Fact]
        public void MaxValue()
        {
            var MaxHeapGeneric = new MaxHeapGeneric<int>(10);

            MaxHeapGeneric.Add(1);
            Assert.Equal(1, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(10);
            Assert.Equal(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(5);
            Assert.Equal(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(2);
            Assert.Equal(10, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(20);
            Assert.Equal(20, MaxHeapGeneric.Peak());
        }

        [Fact]
        public void PopMax()
        {
            var MaxHeapGeneric = new MaxHeapGeneric<int>(10);

            MaxHeapGeneric.Add(1);
            MaxHeapGeneric.Add(10);
            MaxHeapGeneric.Add(9);
            MaxHeapGeneric.Add(5);
            MaxHeapGeneric.Add(2);

            Assert.Equal(10, MaxHeapGeneric.Peak());
            Assert.Equal(10, MaxHeapGeneric.Pop());
            Assert.Equal(9, MaxHeapGeneric.Peak());

            MaxHeapGeneric.Add(20);
            MaxHeapGeneric.Add(10);
            MaxHeapGeneric.Add(30);
            Assert.Equal(30, MaxHeapGeneric.Peak());
            Assert.Equal(30, MaxHeapGeneric.Pop());
            Assert.Equal(20, MaxHeapGeneric.Peak());
            Assert.Equal(20, MaxHeapGeneric.Pop());
            Assert.Equal(10, MaxHeapGeneric.Pop());
            Assert.Equal(9, MaxHeapGeneric.Pop());
            Assert.Equal(5, MaxHeapGeneric.Pop());
            Assert.Equal(2, MaxHeapGeneric.Pop());
            Assert.Equal(1, MaxHeapGeneric.Pop());

            Assert.Equal(0, MaxHeapGeneric.Count);
        }
    }
}
