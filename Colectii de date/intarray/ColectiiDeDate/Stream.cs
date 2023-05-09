using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.IO.Compression;

namespace ColectiiDeDate
{
    public class StreamClass
    {
        private Aes MyAes;
        public StreamClass()
        {
            MyAes = Aes.Create();
            MyAes.Key = Encoding.UTF8.GetBytes("mysecretkey12345");
            MyAes.IV = Encoding.UTF8.GetBytes("mysecretiv678900");
        }
        public void Write(Stream stream, string text, bool gzipped = false, bool encrypt = false)
        {
            if (encrypt)
            {
                var encryptedBytes = EncryptString(text, MyAes.Key, MyAes.IV);
                text = Convert.ToBase64String(encryptedBytes);
            }

            if (gzipped)
            {
                text = Compress(text);
            }

            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Close();
        }

        public string Read(Stream stream, bool gzipped = false, bool encrypt = false)
        {
            StreamReader reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            reader.Close();

            if (gzipped)
            {
                text = Decompress(text);
            }

            if (encrypt)
            {
                byte[] encoded = Convert.FromBase64String(text);
                text = DecryptBytes(encoded, MyAes.Key, MyAes.IV);
            }

            return text;
        }

        private byte[] EncryptString(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            ICryptoTransform encryptor = MyAes.CreateEncryptor(MyAes.Key, MyAes.IV);

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


            return encrypted;
        }

        private string DecryptBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            ICryptoTransform decryptor = MyAes.CreateDecryptor(MyAes.Key, MyAes.IV);

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

            return plaintext;
        }

        private string Compress(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            using (var compressedStream = new MemoryStream())
            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                gzipStream.Write(bytes, 0, bytes.Length);
                gzipStream.Close();
                return Convert.ToBase64String(compressedStream.ToArray());
            }
        }

        private string Decompress(string compressedText)
        {
            var compressedBytes = Convert.FromBase64String(compressedText);

            using (var compressedStream = new MemoryStream(compressedBytes))
            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzipStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
