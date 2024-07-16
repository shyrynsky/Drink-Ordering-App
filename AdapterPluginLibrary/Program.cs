using BaseClassLibrary;

namespace AdapterPluginLibrary;

public class Program
{
    public static IFilePlugin[] Load()
    {
        return
        [
            new Adapter("./ZIPArchivePlugin.dll"),
            new Adapter("./SimpleXOREncryptPlugin.dll")
        ];
    }
}