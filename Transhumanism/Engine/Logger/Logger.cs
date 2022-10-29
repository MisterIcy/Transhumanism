namespace Transhumanism.Engine.Logger;

public class Logger
{
    private ILogWriter Writer { get; }
    public string LogFile { get; }

    private string generateLogFileName()
    {
        string version = Version.GetVersion();
#if DEBUG
        string build = "dev";
#else
        string build = "prod";
#endif
        string ts = DateTime.Now.ToString("yyyyMMddHHmmss");

        string fileName = $"transhumanism-{version}-{build}-{ts}.log";
        return Path.Combine(Directory.GetCurrentDirectory(), fileName);
    }

    public Logger(ILogWriter? writer = null)
    {
        LogFile = generateLogFileName();
        Writer = writer ?? new TextLogWriter(LogFile);
        ;
    }

    public void Log(LogEntry entry)
    {
        Writer.Write(entry);
    }

    public void Log(string message, Level level, Category category, Exception? exception = null)
    {
        Log(new LogEntry(message, null, level, category, exception));
    }

    public void Fatal(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Fatal, category, exception);
    }

    public void Error(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Error, category, exception);
    }

    public void Warning(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Warning, category, exception);
    }

    public void Info(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Info, category, exception);
    }

    public void Debug(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Debug, category, exception);
    }

    public void Trace(string message, Category category, Exception? exception = null)
    {
        Log(message, Level.Trace, category, exception);
    }

    public void Close()
    {
        Writer.Close();
    }

    public void Flush()
    {
        Writer.Flush();
    }

    public void StartSection(string name)
    {
        Writer.StartSection(name);
    }

    public void EndSection()
    {
        Writer.EndSection();
    }
    
    
}