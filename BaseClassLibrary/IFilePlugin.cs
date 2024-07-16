namespace BaseClassLibrary;

public interface IFilePlugin
{
    Stream GetInputStream(Stream initStream, string param);
    Stream GetOutputStream(Stream initStream, string param);
    string PluginName { get; }
}