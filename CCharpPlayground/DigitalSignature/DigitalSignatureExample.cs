namespace CCharpPlayground.DigitalSignature
{
    using System;
    using System.Text;
    using System.Security.Cryptography;

    class DigitalSignatureExample
    {
        public static void Run()
        {
            try
            {
                // Create a new RSA key pair (public and private key)
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    // Data to be sent via API
                    string data = "Hello, API!";
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                    // Sign the data with the private key
                    byte[] signature = SignData(dataBytes, rsa);

                    byte[] dataBytes1 = Encoding.UTF8.GetBytes("Hello, API");

                    // Verify the signature with the public key
                    bool isVerified = VerifyData(dataBytes1, signature, rsa);

                    Console.WriteLine("Data: " + data);
                    Console.WriteLine("Is Signature Verified: " + isVerified);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        // Method to sign data with a private key
        static byte[] SignData(byte[] data, RSACryptoServiceProvider rsa)
        {
            return rsa.SignData(data, new SHA256CryptoServiceProvider());
        }

        // Method to verify data with a public key and signature
        static bool VerifyData(byte[] data, byte[] signature, RSACryptoServiceProvider rsa)
        {
            return rsa.VerifyData(data, new SHA256CryptoServiceProvider(), signature);
        }
    }

}
