using System.Reflection;
using System.Text;
using BaseClassLibrary;
using Interfaces;

namespace AdapterPluginLibrary;

public class Adapter : IFilePlugin
{
    public Stream GetInputStream(Stream initStream, string param)
    {
        return _transformPlugin.GetDetransformStream(initStream);
    }

    public Stream GetOutputStream(Stream initStream, string param)
    {
        return _transformPlugin.GetTransformStream(initStream);
    }

    public string PluginName { get; }

    private ITransformFilePlugin _transformPlugin;

    public Adapter(string pluginPath)
    {
        SetPlugin(pluginPath);
        PluginName = _transformPlugin!.GetExtension();
    }

    private bool SetPlugin(string pluginFile)
    {
        Assembly asm;
        PluginType pt = PluginType.ptUnknown;
        Type pluginClass = null;

        if (!File.Exists(pluginFile))
        {
            return false;
        }

        asm = Assembly.LoadFile(Path.GetFullPath(pluginFile));

        if (asm != null)
        {
            foreach (Type type in asm.GetTypes())
            {
                if (type.IsAbstract) continue;


                object[] attrs = type.GetCustomAttributes(typeof(PluginAttribute), true);
                if (attrs.Length > 0)
                {
                    foreach (PluginAttribute pa in attrs)
                    {
                        pt = pa.Type;
                    }

                    pluginClass = type;
                }
            }

            if (pt == PluginType.ptUnknown)
            {
                return false;
            }

            if (pt == PluginType.ptTransformFilesBorrowed)
            {
                return false;
            }

            _transformPlugin = Activator.CreateInstance(pluginClass) as ITransformFilePlugin;

            return true;
        }

        return false;
    }
}