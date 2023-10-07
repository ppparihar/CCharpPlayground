namespace CCharpPlayground.Hashing
{
    using System;
    using BCrypt.Net;
    public class PasswordHashing
    {
        public static void Run()
        {


            string password = "my_secure_password";
            string hashedPassword = BCrypt.HashPassword(password);
            VerifyPassword(password, hashedPassword);

        }
        private static void VerifyPassword(string password, string hashedPassword)
        {
            bool isValid = BCrypt.Verify(password, hashedPassword);
            Console.WriteLine("Password is valid: " + isValid);
        }
    }
}
