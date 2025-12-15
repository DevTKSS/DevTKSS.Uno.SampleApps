# DevTKSS.Extensions.Uno.Storage

Lightweight helpers for reading and selecting line ranges from text content in Uno Platform projects. Designed for MVUX sample apps and unit-tested with comprehensive coverage.

## Installation

Install via NuGet:

```bash
dotnet add package DevTKSS.Extensions.Uno.Storage
```

Target frameworks: .NET 9+, Uno SDK-based projects.

## Features

- Read package files via `IStorage.ReadPackageFileAsync`
- Select line ranges with 0-based and 1-based indexing
- Robust validation and sentinel behavior for editor-like 1-based indices

## Usage

```csharp
var ranges = new[] { new Lines(1, 3) }; // 1-based
var content = await storage.ReadLinesFromPackageFile("path/to/file.txt", ranges, isNullBased: false);
```

For 0-based indexing:

```csharp
var ranges = new[] { new Lines(0, 2) }; // 0-based
var content = await storage.ReadLinesFromPackageFile("path/to/file.txt", ranges, isNullBased: true);
```

## Documentation

This package is used within the Uno Sample Apps repository to demonstrate MVUX patterns. See the `Extensions` folder README for CI and coverage status.

## License

Apache-2.0. See root `LICENSE.md`.
