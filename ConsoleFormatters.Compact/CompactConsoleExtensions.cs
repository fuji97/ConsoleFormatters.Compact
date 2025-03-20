using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ConsoleFormatters.Compact;

/// <summary>
/// Provides extension methods for adding the CompactConsoleFormatter to the logging builder.
/// </summary>
public static class CompactConsoleExtensions {
    
    /// <summary>
    /// Adds the CompactConsoleFormatter to the logging builder.
    /// </summary>
    /// <param name="builder">The logging builder.</param>
    private static void AddCompactFormatter(ILoggingBuilder builder) {
        builder.Services.AddSingleton<ConsoleFormatter, CompactConsoleFormatter>();
        builder.AddConsole(options => {
            options.FormatterName = CompactConsoleFormatter.Name;
        });
    }
    
    /// <summary>
    /// Adds the CompactConsoleFormatter to the logging builder using the specified configuration.
    /// </summary>
    /// <param name="builder">The logging builder.</param>
    /// <param name="configuration">The configuration to use.</param>
    /// <returns>The logging builder.</returns>
    public static ILoggingBuilder AddCompactConsoleFormatter(this ILoggingBuilder builder, IConfiguration configuration) {
        builder.Services.Configure<CompactConsoleConfiguration>(configuration);
        AddCompactFormatter(builder);
        return builder;
    }
    
    /// <summary>
    /// Adds the CompactConsoleFormatter to the logging builder using the specified configuration.
    /// </summary>
    /// <param name="builder">The logging builder.</param>
    /// <param name="configuration">The configuration to use.</param>
    /// <returns>The logging builder.</returns>
    public static ILoggingBuilder AddCompactConsoleFormatter(this ILoggingBuilder builder, CompactConsoleConfiguration configuration) {
        builder.Services.Configure<CompactConsoleConfiguration>(conf => {
            conf.UseEmoji = configuration.UseEmoji;
            conf.EnableCategory = configuration.EnableCategory;
        });
        AddCompactFormatter(builder);
        return builder;
    }
    
    /// <summary>
    /// Adds the CompactConsoleFormatter to the logging builder using the specified configuration action.
    /// </summary>
    /// <param name="builder">The logging builder.</param>
    /// <param name="configure">The configuration action to use.</param>
    /// <returns>The logging builder.</returns>
    public static ILoggingBuilder AddCompactConsoleFormatter(this ILoggingBuilder builder, Action<CompactConsoleConfiguration> configure) {
        builder.Services.Configure(configure);
        AddCompactFormatter(builder);
        return builder;
    }
}