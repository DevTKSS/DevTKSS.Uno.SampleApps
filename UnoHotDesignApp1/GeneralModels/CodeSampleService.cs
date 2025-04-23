using System.ComponentModel.DataAnnotations;

public class CodeSampleService(ILogger<CodeSampleService>? Logger, IStorage Storage)
{

    public async ValueTask<string> GetCodeSampleAsync(string filePath)
    {
        Logger?.LogTrace("GetCodeSampleAsync called with filePath: {filePath}", filePath);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));
        Logger?.LogTrace("Trying to read file from path: {filePath}", filePath);
        var fileContent = await Storage.ReadPackageFileAsync(filePath);
        Logger?.LogTrace("File content successfully read from path: {filePath}", filePath);
        Logger?.LogDebug("File content successfully read from {filePath}: {fileContent}", filePath, fileContent);
        return string.IsNullOrEmpty(fileContent) ? string.Empty : fileContent;
    }
    public async ValueTask<ImmutableList<string>> GetSampleCodeAsync(string filePath, List<(int Start, int End)>? lineRanges = null)
    {
        Logger?.LogTrace("GetSampleCodeAsync called with filePath: {filePath} and lineRanges {lineRanges}", filePath, lineRanges);
        lineRanges ??= new List<(int Start, int End)>();
        string fileContent = await GetCodeSampleAsync(filePath);
        string[] lines = fileContent.Split(Environment.NewLine);

        if (!(lineRanges.Count > 0)) return lines.ToImmutableList();

        var selectedLines = new List<string>();

        foreach (var (Start, End) in lineRanges)
        {
            var start = Math.Clamp(Start - 1, 0, lines.Length);
            var end = Math.Clamp(End,start, lines.Length); // Ensure 'End' does not exceed available lines
            selectedLines.AddRange(lines[start..end]);
        }

        return selectedLines.ToImmutableList();
    }

}
