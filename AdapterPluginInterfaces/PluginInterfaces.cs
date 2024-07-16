namespace Interfaces
{
    public enum PluginType
    {
        ptShape,
        ptTransformFiles,
        ptTransformFilesBorrowed,
        ptUnknown
    }

    // Атрибут годен использоватся только с определениями класов - не методов или полей
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PluginAttribute : Attribute
    {
        private PluginType _Type;
        public PluginAttribute(PluginType T) { _Type = T; }
        public PluginType Type { get { return _Type; } }
    };

    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        string Author { get; }
    }

    // /// <summary>
    // /// Интерфейс плагина для добавления нового класса фигур.
    // /// </summary>
    // public interface IShapeClassPlugin : IPlugin
    // {
    //     string ShapeName { get; }
    //     IShapeFactory CreateShapeFactory();
    //     IShapeEditDialogFactory CreateShapeEditDialogFactory();
    // }


    /// <summary>
    /// Интерфейс плагина для трансформации созраняемых файлов.
    /// </summary>
    public interface ITransformFilePlugin : IPlugin
    {
        Stream GetTransformStream(Stream stream);
        Stream GetDetransformStream(Stream stream);
        string GetExtension();
    }
}
