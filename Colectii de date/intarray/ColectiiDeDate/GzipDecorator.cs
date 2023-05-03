using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class GzipDecorator : StreamDecorator
    {
        public GzipDecorator(IStream stream) : base(stream)
        {
        }

        public override void Write(Stream stream, string text)
        {
            var compressedText = Compress(text);
            base.Write(stream, compressedText);
        }

        public override string Read(Stream stream)
        {
            var compressedText = base.Read(stream);
            var decompressedText = Decompress(compressedText);
            return decompressedText;
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
