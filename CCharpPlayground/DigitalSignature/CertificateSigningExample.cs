namespace CCharpPlayground.DigitalSignature
{
    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;

    public class CertificateSigningExample
    {
        public static void Run()
        {
            try
            {
                // Load the certificate from a file or a certificate store
                X509Certificate2 certificate = new X509Certificate2("path_to_certificate.pfx", "certificate_password");

                // Data to be sent via API
                string data = "Hello, API!";
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                // Sign the data with the certificate's private key
                byte[] signature = SignData(dataBytes, certificate);

                // Verify the signature using the certificate's public key
                bool isVerified = VerifyData(dataBytes, signature, certificate);

                Console.WriteLine("Data: " + data);
                Console.WriteLine("Is Signature Verified: " + isVerified);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        // Method to sign data with a certificate's private key
        static byte[] SignData(byte[] data, X509Certificate2 certificate)
        {
            using (RSA rsa = certificate.GetRSAPrivateKey())
            {
                return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }

        // Method to verify data with a certificate's public key and signature
        static bool VerifyData(byte[] data, byte[] signature, X509Certificate2 certificate)
        {
            using (RSA rsa = certificate.GetRSAPublicKey())
            {
                return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
    }

}
