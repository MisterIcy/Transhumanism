using System.Text;

namespace Transhumanism.Engine.Logger;

public sealed class TextLogWriter : ILogWriter
{

    private Queue<LogEntry> _entries;
    private string SectionName { get; set; }
    private DateTime Started { get; }
    private DateTime LastWritten { get; set; }
    private StreamWriter Writer { get; }

    public TextLogWriter(string logFile)
    {
        SectionName = string.Empty;
        Started = DateTime.Now;
        LastWritten = DateTime.Now;
        _entries = new Queue<LogEntry>();

        if (File.Exists(logFile))
        {
            File.Delete(logFile);
        }

        var fsOpts = new FileStreamOptions
        {
            Access = FileAccess.Write,
            Mode = FileMode.Create,
            Options = FileOptions.SequentialScan,
            Share = FileShare.Read,
            BufferSize = 4096,
            PreallocationSize = 4096
        };

        Writer = new StreamWriter(logFile, Encoding.UTF8, fsOpts);
        Writer.WriteLine($"Transhumanism v{Version.GetVersion()} - {DateTime.Now:O}");
        Writer.WriteLine(new string('=', 120));
        Writer.WriteLine("");
    }

    public void Write(LogEntry entry)
    {
        _entries.Enqueue(entry);
        
        if (_entries.Count > 100 || (DateTime.Now - LastWritten).TotalSeconds > 60.0)
        {
            WriteInternal();
        }
    }

    public void WriteInternal()
    {
        if (_entries.Count == 0)
        {
            return;
        }

        while (_entries.Count > 0)
        {
            var entry = _entries.Dequeue();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"[{(entry.Timestamp - Started):G}] ")
                         .Append($"[{entry.Level.ToString().ToUpper()} / {entry.Category}] ")
                         .Append($" - {entry.Message}");

            if (entry.Exception != null)
            {
                stringBuilder.Append(Environment.NewLine)
                             .Append(entry.Exception.StackTrace)
                             .Append(Environment.NewLine);
            }

            Writer.WriteLine(stringBuilder.ToString());
        }
        LastWritten = DateTime.Now;
        Writer.Flush();
    }

    public void StartSection(string name)
    {
        if (!string.IsNullOrEmpty(SectionName))
        {
            EndSection();
        }

        WriteInternal();
        SectionName = name;
        CalculateSectionMargins(SectionName, out int left, out int right);
        Writer.WriteLine($"{new string('/', left)} {SectionName} {new string('\\', right)}");
    }

    public void EndSection()
    {
        if (string.IsNullOrEmpty(SectionName))
        {
            return;
        }

        WriteInternal();
        CalculateSectionMargins(SectionName, out int left, out int right);
        Writer.WriteLine($"{new string('\\', left)} {SectionName} {new string('/', right)}");
        SectionName = string.Empty;
    }

    private void CalculateSectionMargins(string section, out int left, out int right)
    {
        bool isOdd = false;
        int sectionLen = section.Length + 2;
        if (sectionLen % 2 == 1)
        {
            sectionLen++;
            isOdd = true;
        }

        left = (int)Math.Floor((decimal)((120 - sectionLen) / 2));
        right = left + ((isOdd) ? 1 : 0);
    }

    public void Flush()
    {
        WriteInternal();
        Writer.Flush();
    }

    public void Close()
    {
        Flush();
        Writer.Close();
    }
}