namespace ConsoleFormatters.Compact;

/// <summary>
/// Configuration settings for the Compact Console Formatter.
/// </summary>
public class CompactConsoleConfiguration {
    /// <summary>
    /// The name of the console formatter.
    /// </summary>
    public const string Name = "CompactConsole";

    /// <summary>
    /// Gets or sets a value indicating whether to use emoji in the console output.
    /// </summary>
    public bool UseEmoji { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to enable category display in the console output.
    /// </summary>
    public bool EnableCategory { get; set; } = true;
}
