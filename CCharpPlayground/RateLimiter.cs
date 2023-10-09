namespace CCharpPlayground
{
    using System;

    public class RateLimiter
    {
        private readonly int capacity;
        private readonly int fillRate;
        private int availableTokens;
        private DateTime lastRefillTime;
        public RateLimiter(int capacity, int fillRate)
        {
            this.capacity = capacity;
            this.fillRate = fillRate;
            lastRefillTime = DateTime.Now;
            availableTokens = capacity;
        }

        public bool Consume(int tokens)
        {
            Refill();
            if (availableTokens < tokens)
            {
                return false;
            }
            availableTokens -= tokens;
            return true;

        }

        private void Refill()
        {
            var time = lastRefillTime.Subtract(DateTime.Now);
            var tokensToAdd = Math.Max(time.Seconds, 0) * fillRate;
            availableTokens = Math.Min(capacity, availableTokens + tokensToAdd);
            lastRefillTime = DateTime.Now;
        }
    }
}
