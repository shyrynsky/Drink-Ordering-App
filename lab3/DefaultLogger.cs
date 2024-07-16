namespace lab2;

public class DefaultLogger : ILogger
{
    private StreamWriter _stream = new(File.Open("loggerFile.log", FileMode.Append));

    public void Add(string information)
    {
        _stream.Write(DateTime.Now + "    " + information + "\n");
    }

    public void Close()
    {
        _stream.Dispose();
    }
}