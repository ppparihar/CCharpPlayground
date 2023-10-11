namespace Playground.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CCharpPlayground.Hashing;

    public class ConsistentHashingTest
    {
        [Fact]
        public void Test1()
        {
            var consistentHashing = new ConsistentHashing<string>(3);
            consistentHashing.AddNode("A");
            consistentHashing.AddNode("B");
            consistentHashing.AddNode("C");

            Assert.NotNull(consistentHashing.GetNode("1"));
            Assert.NotNull(consistentHashing.GetNode("2"));
            Assert.NotNull(consistentHashing.GetNode("3"));
        }
    }
}
