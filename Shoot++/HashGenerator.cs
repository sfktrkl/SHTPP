using System;
using System.Security.Cryptography;
using System.Text;

namespace Shoot
{
    public static class HashGenerator
    {
        private static Byte[] keyByte = Encoding.UTF8.GetBytes("ORLY??");
        private static HMACSHA256 hmac = new HMACSHA256(keyByte);

        public static string GetHash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyHash(string input, string source)
        {
            string hash = GetHash(source);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(input, hash) == 0;
        }
    }
}