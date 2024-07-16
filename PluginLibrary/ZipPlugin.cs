using System.IO.Compression;
using BaseClassLibrary;

namespace PluginLibrary;

public class ZipPlugin: IFilePlugin
{
    public Stream GetInputStream(Stream initStream, string param)
    {
        return new GZipStream(initStream, CompressionMode.Decompress);
    }

    public Stream GetOutputStream(Stream initStream, string param)
    {
        return new GZipStream(initStream, CompressionMode.Compress);
    }

    public string PluginName { get; } = "gzip плагин";
}