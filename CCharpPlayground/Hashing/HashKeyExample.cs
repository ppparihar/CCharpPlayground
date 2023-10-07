namespace CCharpPlayground.Hashing
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;

    public class HashKeyExample
    {
        public static void Run()
        {
            var hash = ComputeMD5Hash("Hello, API!");
            // GetNumericValueFromHashCode();
        }

        private static void GetNumericValueFromHashCode()
        {
            var hash = CalculateSHA256Hash("if you have a specific use case where you need to convert a hash to a numeri");
            Console.WriteLine("Hash: " + hash);
            byte[] hashBytes = Encoding.UTF8.GetBytes(hash);
            long numericValue = BitConverter.ToInt64(hashBytes);
            Console.WriteLine("Numeric value: " + numericValue);
        }

        public static void HashKey(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var hashBytes = SHA256.HashData(keyBytes);
            Console.WriteLine("Hashed key: " + Convert.ToBase64String(hashBytes));
        }

        private static void HashCode(string key)
        {
            // int hashCode = Comparer.GetHashCode(key) & 0x7FFFFFFF;
        }

        static string CalculateSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Convert to hexadecimal representation
                }

                return builder.ToString();
            }
        }

        static string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Convert to hexadecimal representation
                }

                return builder.ToString();
            }
        }
    }
}
