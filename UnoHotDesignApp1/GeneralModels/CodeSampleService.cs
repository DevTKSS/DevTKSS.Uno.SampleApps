using System.ComponentModel.DataAnnotations;

public class CodeSampleService
{
    private readonly IStorage _storage;
    private readonly ILogger? _logger;
    public CodeSampleService(
        IStorage storage,
        ILogger<CodeSampleService>? logger)
    {
        _storage = storage;
        _logger = logger;
    }

    public async ValueTask<string> GetCodeSampleAsync(
        [MinLength(1)]
        [RegularExpression(@"^(?![a-zA-Z]:|/|\\)[a-zA-Z0-9_\-./\\]+$", ErrorMessage = "Invalid file path format. Only relative nested paths are allowed.")]
        string filePath)
    {
        var fileContent = await _storage.ReadPackageFileAsync(filePath);
        return string.IsNullOrEmpty(fileContent) ? string.Empty : fileContent;
    }
    public async ValueTask<string> GetSampleCodeAsync(
        [MinLength(1)]
        [RegularExpression(@"^(?![a-zA-Z]:|/|\\)[a-zA-Z0-9_\-./\\]+$", ErrorMessage = "Invalid file path format. Only relative nested paths are allowed.")]
        string filePath,
        List<(int Start, int End)>? lineRanges = null)
    {
        lineRanges ??= new List<(int Start, int End)>();
        string fileContent = await GetCodeSampleAsync(filePath);

        if (lineRanges == null || lineRanges.Count == 0)
        {
            return fileContent;
        }

        var lines = fileContent.Split(Environment.NewLine);
        var selectedLines = new List<string>();

        foreach (var range in lineRanges)
        {
            if (range.Start <= 0 || range.End <= 0 || range.Start > range.End || range.Start > lines.Length)
            {
                _logger?.LogWarning("Skipping invalid line range: {StartRange} - {EndRange}. ", range.Start, range.End);
                continue;
            }

            var start = range.Start - 1;
            var end = Math.Min(range.End, lines.Length); // Ensure 'End' does not exceed available lines
            selectedLines.AddRange(lines[start..end]);
        }

        return string.Join(Environment.NewLine, selectedLines);
    }

}
