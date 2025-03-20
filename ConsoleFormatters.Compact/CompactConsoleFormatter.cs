using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace ConsoleFormatters.Compact;

public class CompactConsoleFormatter(IOptions<CompactConsoleConfiguration> configuration) : ConsoleFormatter(Name) {
    public new const string Name = "compact";
    
    private readonly string _nl          = Environment.NewLine; // shortcut
    private readonly string _normal      = Console.IsOutputRedirected ? "" : "\x1b[39m";
    private readonly string _red         = Console.IsOutputRedirected ? "" : "\x1b[91m";
    private readonly string _green       = Console.IsOutputRedirected ? "" : "\x1b[92m";
    private readonly string _yellow      = Console.IsOutputRedirected ? "" : "\x1b[93m";
    private readonly string _blue        = Console.IsOutputRedirected ? "" : "\x1b[94m";
    private readonly string _magenta     = Console.IsOutputRedirected ? "" : "\x1b[95m";
    private readonly string _cyan        = Console.IsOutputRedirected ? "" : "\x1b[96m";
    private readonly string _grey        = Console.IsOutputRedirected ? "" : "\x1b[97m";
    private readonly string _bold        = Console.IsOutputRedirected ? "" : "\x1b[1m";
    private readonly string _nobold      = Console.IsOutputRedirected ? "" : "\x1b[22m";
    private readonly string _underline   = Console.IsOutputRedirected ? "" : "\x1b[4m";
    private readonly string _noUnderline = Console.IsOutputRedirected ? "" : "\x1b[24m";
    private readonly string _reverse     = Console.IsOutputRedirected ? "" : "\x1b[7m";
    private readonly string _noreverse   = Console.IsOutputRedirected ? "" : "\x1b[27m";
     public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter) {
        var logLevel = configuration.Value.UseEmoji ? FormatLogLevelEmoji(logEntry) : FormatLogLevel(logEntry);
        var message = logEntry.Formatter(logEntry.State, logEntry.Exception);
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        var category = configuration.Value.EnableCategory ? $" {_bold}[{logEntry.Category}]{_nobold}" : "";
         var exception = logEntry.Exception != null ? $"{_nl}{_red}{logEntry.Exception}{_normal}" : "";
         textWriter.WriteLine($"{timestamp} {logLevel}{category} {message}{exception}");
    }
     
    private string FormatLogLevel<TState>(LogEntry<TState> logEntry) {
        return logEntry.LogLevel switch {
            LogLevel.Trace => $"| {_grey}TRC{_normal} |",
            LogLevel.Debug => $"| {_cyan}DBG{_normal} |",
            LogLevel.Information => $"| {_green}INF{_normal} |",
            LogLevel.Warning => $"| {_yellow}WRN{_normal} |",
            LogLevel.Error => $"| {_red}ERR{_normal} |",
            LogLevel.Critical => $"| {_magenta}CRT{_normal} |",
            LogLevel.None => $"| {_normal}---{_normal} |",
            _ => $"| {_normal}{logEntry.LogLevel}{_normal} |"
        };
    }
    
    private string FormatLogLevelEmoji<TState>(LogEntry<TState> logEntry) {
        return logEntry.LogLevel switch {
            LogLevel.Trace => "📄 |",
            LogLevel.Debug => "🪲 |",
            LogLevel.Information => "ℹ️ |",
            LogLevel.Warning => "⚠️ |",
            LogLevel.Error => "❌  |",
            LogLevel.Critical => "💀 |",
            LogLevel.None => "❔ |",
            _ => $"{_normal}{logEntry.LogLevel}{_normal}"
        };
    }
}
