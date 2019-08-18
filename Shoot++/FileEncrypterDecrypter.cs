using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shoot
{
    public static class FileEncrypterDecrypter
    {
        private static string password = @"HLYSHT!!";

        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            for (int i = 0; i < 10; i++)
                rng.GetBytes(data);

            return data;
        }

        public static void FileEncrypt(string input, string userFile)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            byte[] salt = GenerateRandomSalt();

            FileStream fsCrypt = new FileStream(userFile, FileMode.Create);
            fsCrypt.Write(salt, 0, salt.Length);

            RijndaelManaged RMCrypto = new RijndaelManaged();
            RMCrypto.Padding = PaddingMode.ISO10126;
            RMCrypto.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, salt), CryptoStreamMode.Write);

            StringReader sr = new StringReader(input);

            int data;
            while ((data = sr.Read()) != -1)
                cs.WriteByte((byte)data);

            sr.Close();
            cs.Close();
            fsCrypt.Close();
        }

        public static string FileDecrypt(string userFile)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            byte[] salt = new byte[16];

            FileStream fsCrypt = new FileStream(userFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged RMCrypto = new RijndaelManaged();
            RMCrypto.Padding = PaddingMode.ISO10126;
            RMCrypto.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, salt), CryptoStreamMode.Read);

            StringWriter sw = new StringWriter();

            int data;
            while ((data = cs.ReadByte()) != -1)
                sw.Write((char)data);

            sw.Close();
            cs.Close();
            fsCrypt.Close();

            return sw.ToString();
        }
    }
}