using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class CryptDecorator : StreamDecorator
    {
        private Aes MyAes;
        public CryptDecorator(IStream stream) : base(stream)
        {
            MyAes = Aes.Create();
            MyAes.Key = Encoding.UTF8.GetBytes("mysecretkey12345");
            MyAes.IV = Encoding.UTF8.GetBytes("mysecretiv678900");
        }

        public override void Write(Stream stream, string text)
        {
            var encryptedBytes = EncryptString(text, MyAes.Key, MyAes.IV);
            var encryptedText = Convert.ToBase64String(encryptedBytes);
            base.Write(stream, encryptedText);
        }

        public override string Read(Stream stream)
        {
            string encodedString = base.Read(stream);
            byte[] encoded = Convert.FromBase64String(encodedString);
            return DecryptBytes(encoded, MyAes.Key, MyAes.IV);
        }

        byte[] EncryptString(string plainText, byte[] Key, byte[] IV)
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

        string DecryptBytes(byte[] cipherText, byte[] Key, byte[] IV)
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
    }
}
