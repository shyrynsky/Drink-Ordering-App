using BaseClassLibrary;

namespace PluginLibrary;

public class Program
{
    public static IFilePlugin[] Load()
    {
        return [new ZipPlugin(), new AesPlugin()];
    }
}