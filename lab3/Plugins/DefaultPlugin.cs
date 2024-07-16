using BaseClassLibrary;

namespace lab2.Plugins;

public class DefaultPlugin: IFilePlugin
{
    public Stream GetInputStream(Stream initStream, string param)
    {
        return initStream;
    }

    public Stream GetOutputStream(Stream initStream, string param)
    {
        return initStream;
    }

    public string PluginName { get; } = "плагин по умолчанию";
}