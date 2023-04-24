using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;

namespace ColectiiDeDate
{
    public class StreamClass
    {
        const int bufferSize = 1024;
        public static void Write(Stream stream, string text)
        {
            byte[] key = Encoding.UTF8.GetBytes("mysecretkey12345");
            byte[] iv = Encoding.UTF8.GetBytes("mysecretiv678900");
            byte[] encoded = (EncryptString(text, key, iv));
            foreach (byte b in encoded)
            {
                stream.WriteByte(b);
            }
        }

        public static string Read(Stream stream)
        {
            byte[] key = Encoding.UTF8.GetBytes("mysecretkey12345");
            byte[] iv = Encoding.UTF8.GetBytes("mysecretiv678900");

            byte[] buffer = new byte[bufferSize];
            List<byte> byteList = new List<byte> { };
            int bytesRead = 0;

            while ((bytesRead = stream.Read(buffer, 0, bufferSize)) != 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    byteList.Add(buffer[i]);
                }
            }

            return DecryptBytes(byteList.ToArray(), key, iv);
        }

        static byte[] EncryptString(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        static string DecryptBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
