using BaseClassLibrary;

namespace lab2.Plugins;

public class CacheProxyPlugin : IFilePlugin
{
    private class CombinedStream : Stream
    {
        private readonly Stream _initStream;
        private readonly MemoryStream _cache;

        public override void Flush()
        {
            _initStream.Flush();
            _cache.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _initStream.Seek(count, SeekOrigin.Current);
            return _cache.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            _cache.Seek(offset, origin);
            return _initStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _initStream.SetLength(value);
            _cache.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _initStream.Write(buffer, offset, count);
            _cache.Write(buffer, offset, count);
        }

        public override bool CanRead => _initStream.CanRead;
        public override bool CanSeek => _initStream.CanSeek;
        public override bool CanWrite => _initStream.CanWrite;
        public override long Length => _initStream.Length;

        public override long Position
        {
            get => _initStream.Position;
            set
            {
                _initStream.Position = value;
                _cache.Position = value;
            }
        }

        public CombinedStream(Stream initStream, MemoryStream cache)
        {
            _initStream = initStream;
            _cache = cache;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _initStream.Dispose();
        }
    }

    private readonly IFilePlugin _basePlugin;

    private MemoryStream? _cache;

    public Stream GetInputStream(Stream initStream, string param)
    {
        if (_cache is { CanRead: true } && initStream.Length == _cache?.Length)
        {
            _cache.Seek(0, SeekOrigin.Begin);
            initStream.Dispose();
            initStream = _cache;
        }
        return _basePlugin.GetInputStream(initStream, param);
    }

    public Stream GetOutputStream(Stream initStream, string param)
    {
        _cache?.Dispose();
        _cache = new MemoryStream();
        return _basePlugin.GetOutputStream(new CombinedStream(initStream, _cache), param);
    }

    public string PluginName { get; }

    public CacheProxyPlugin(IFilePlugin basePlugin)
    {
        _basePlugin = basePlugin;
        PluginName = basePlugin.PluginName + " с кэшированием";
    }
}