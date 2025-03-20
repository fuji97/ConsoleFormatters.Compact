# <div align="center">ConsoleFormatters.Compact</div>
<div align="center">

A compact console formatting library for .NET applications

[![NuGet](https://img.shields.io/nuget/v/ConsoleFormatters.Compact.svg)](https://www.nuget.org/packages/ConsoleFormatters.Compact)
[![License](https://img.shields.io/github/license/fuji97/ConsoleFormatters.Compact)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/fuji97/ConsoleFormatters.Compact/nuget-release.yml)](https://github.com/fuji97/ConsoleFormatters.Compact/actions/workflows/nuget-release.yml)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download)

</div>

## Description

ConsoleFormatters.Compact provides compact and customizable formatters for console output in .NET applications. It helps you create clean, readable console logs with minimal configuration.

## Getting Started

### Installation

Install the package from NuGet:

```bash
dotnet add package ConsoleFormatters.Compact
```

### Basic Usage

#### ASP.NET Core
```csharp
using ConsoleFormatters.Compact;

// Configure logger
builder.Logging.AddCompactConsoleFormatter(options => {
    options.UseEmoji = true;        // Log level as emoji
    options.EnableCategory = true;  // Show source category between brackets
});
```

## License

This project is licensed under the MIT License.