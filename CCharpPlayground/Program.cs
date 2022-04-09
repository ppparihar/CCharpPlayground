using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;

namespace CCharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            // var heap = new PriorityQueue<int>
            // var heap = new SortedList<int>();
            var KthLargest = new KthLargest(3, new int[] { 3, 2, -1, 40 });
            var result = KthLargest.Add(10);
        }
    }

    public class KthLargest
    {
        MinHeap minHeap;
        int k;
        public KthLargest(int k, int[] nums)
        {
            minHeap = new MinHeap(100001);
            this.k = k;
            foreach (var num in nums)
            {
                minHeap.Add(num);
            }
            while (minHeap.Count > k)
            {
                var item = minHeap.Pop();
            }
        }

        public int Add(int val)
        {
            minHeap.Add(val);
            while (minHeap.Count > k)
            {
                var item = minHeap.Pop();
            }
            return minHeap.Peak();
        }
    }

}
