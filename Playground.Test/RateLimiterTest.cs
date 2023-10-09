namespace Playground.Test
{
    using CCharpPlayground;
    using Xunit;

    public class RateLimiterTest
    {
        [Fact]
        public void Fact1()
        {
            var rateLimiter = new RateLimiter(10, 2);
            Assert.True(rateLimiter.Consume(3));
            Assert.True(rateLimiter.Consume(6));
            Assert.False(rateLimiter.Consume(3));
        }

        [Fact]
        public void TestWithDeay()
        {
            var rateLimiter = new RateLimiter(10, 2);
            Assert.True(rateLimiter.Consume(3));
            Assert.True(rateLimiter.Consume(6));
            //delay
            Thread.Sleep(1000);

            Assert.False(rateLimiter.Consume(3));
        }
    }
}
