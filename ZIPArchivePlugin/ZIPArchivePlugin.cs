using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ZIPArchivePlugin
{
    [Plugin(PluginType.ptTransformFiles)]
    public class ZIPArchivePlugin : ITransformFilePlugin
    {
        public string Name
        {
            get { return "ZIP Archive Stream creation Plugin"; }
        }

        public string Version
        {
            get { return "1.3.0"; }
        }

        public string Author
        {
            get { return "Maria Dorova"; }
        }

        public Stream GetTransformStream(Stream stream)
        {
            return new GZipStream(stream, CompressionMode.Compress);
        }

        public Stream GetDetransformStream(Stream stream)
        {
            return new GZipStream(stream, CompressionMode.Decompress);
        }

        public string GetExtension()
        {
            return ".gz";
        }
    }
}
