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
        public virtual void Write(Stream stream, string text, bool gzipped = false, bool encrypt = false)
        {
            if (encrypt)
            {
                ICryptoTransform encryptor = MyAes.CreateEncryptor(MyAes.Key, MyAes.IV);
                stream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
            }

            if (gzipped)
            {
                stream = new GZipStream(stream, CompressionMode.Compress);
            }

            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Close();
        }

        public virtual string Read(Stream stream, bool gzipped = false, bool encrypt = false)
        {
            if (encrypt)
            {
                ICryptoTransform decryptor = MyAes.CreateDecryptor(MyAes.Key, MyAes.IV);
                stream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read);
            }

            if (gzipped)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            StreamReader reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            reader.Close();
            return text;
        }
    }
}
