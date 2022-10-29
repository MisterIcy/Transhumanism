namespace Transhumanism.Engine.Logger;

/// <summary>
/// Describes a log entry
/// </summary>
public sealed class LogEntry
{
    /// <summary>
    /// Gets the entry's message
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the entry's timestamp
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Gets the entry's level
    /// </summary>
    public Level Level { get; }

    /// <summary>
    /// Gets the entry's category
    /// </summary>
    public Category Category { get; }

    /// <summary>
    /// Gets the entry's exception, if one occurred.
    /// </summary>
    public Exception? Exception { get; }


    /// <summary>
    /// Create a new log entry
    /// </summary>
    /// <param name="message">The message to be logged</param>
    /// <param name="timestamp">The timestamp the event was created. Leave null to use the date the entry is created</param>
    /// <param name="level">The level of the entry</param>
    /// <param name="category">The category of the entry</param>
    /// <param name="exception">An optional exception that led to the creation of the entry, used for debugging purposes</param>
    public LogEntry(
        string message,
        DateTime? timestamp = null,
        Level level = Level.Info,
        Category category = Category.Application,
        Exception? exception = null
    )
    {
        Message = message;
        Timestamp = timestamp ?? DateTime.Now;
        Level = level;
        Category = category;
        Exception = exception;
    }
}