namespace DevTKSS.Extensions.Uno.Storage;
public static class StorageExtensions
{
    /// <summary>
    /// Reads specific lines from a file asynchronously based on the provided line ranges.
    /// </summary>
    /// <param name="storage">The storage interface used to access the file.</param>
    /// <param name="filePath">The path of the file to read from.</param>
    /// <param name="lineRanges">
    /// A collection of <see cref="Lines"/> representing the line ranges to extract.
    /// Each range contains a start line (inclusive) and an end line (inclusive).
    /// </param>
    /// <param name="isNullBased">
    /// When <see langword="true"/>, indices are treated as 0-based; when <see langword="false"/>, they are treated as 1-based.<br/>
    /// Defaults to <see langword="false"/> (1-based indexing), matching typical text editor line numbering.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask{string}"/> representing the asynchronous operation.
    /// The result contains the extracted lines joined by <see cref="Environment.NewLine"/>,
    /// or the entire file content if no line ranges are specified.
    /// </returns>
    public static async ValueTask<string> ReadLinesFromPackageFile(this IStorage storage, string filePath, IEnumerable<Lines> lineRanges, bool isNullBased = false)
    {
        var fileContent = await storage.ReadPackageFileAsync(filePath) ?? string.Empty;

        if (fileContent.IsNullOrEmpty() || !lineRanges.Any())
        {
            return fileContent;
        }

        return fileContent.Split(Environment.NewLine)
                          .GetLinesWithinRanges(lineRanges, isNullBased)
                          .JoinBy(Environment.NewLine);
    }
}
