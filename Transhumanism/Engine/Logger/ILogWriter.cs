namespace Transhumanism.Engine.Logger;

/// <summary>
/// Interface for Log Writers
/// </summary>
public interface ILogWriter
{
    /// <summary>
    /// Writes a log entry
    /// </summary>
    /// <param name="entry">The entry to be written</param>
    public void Write(LogEntry entry);

    /// <summary>
    /// Starts a new section in the log file (to group things together)
    /// </summary>
    /// <param name="name">The name of the section</param>
    public void StartSection(string name);

    /// <summary>
    /// Ends a section in the log file (if a section exists)
    /// </summary>
    public void EndSection();

    /// <summary>
    /// Flushes the writer
    /// </summary>
    public void Flush();

    /// <summary>
    /// Closes the writer
    /// </summary>
    public void Close();
}
