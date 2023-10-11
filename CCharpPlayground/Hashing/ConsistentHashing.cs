namespace CCharpPlayground.Hashing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class ConsistentHashing<T>
    {
        private readonly SortedDictionary<uint, T> circle = new SortedDictionary<uint, T>();
        private readonly int virtualNodeCount;

        public ConsistentHashing(int virtualNodeCount)
        {
            this.virtualNodeCount = virtualNodeCount;
        }

        public void AddNode(T node)
        {
            for (int i = 0; i < virtualNodeCount; i++)
            {
                uint hash = GetHash(node.ToString() + i);
                circle[hash] = node;
            }
        }

        public void RemoveNode(T node)
        {
            for (int i = 0; i < virtualNodeCount; i++)
            {
                uint hash = GetHash(node.ToString() + i);
                circle.Remove(hash);
            }
        }

        public T GetNode(string key)
        {
            if (circle.Count == 0)
            {
                throw new InvalidOperationException("No nodes available in the circle.");
            }

            uint hash = GetHash(key);

            // Find the first node with a hash greater than or equal to the hash of the key.
            foreach (var nodeHash in circle.Keys)
            {
                if (nodeHash >= hash)
                {
                    return circle[nodeHash];
                }
            }

            // If no node with a hash greater than or equal to the key's hash is found,
            // wrap around to the first node in the circle.
            return circle.First().Value;
        }

        private uint GetHash(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] data = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha.ComputeHash(data);
                return BitConverter.ToUInt32(hashBytes, 0);
            }
        }
    }

}
