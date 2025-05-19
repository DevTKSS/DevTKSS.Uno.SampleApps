namespace DevTKSS.Extensions.Uno.Storage;
public static class StorageExtensions
{
    /// <summary>
    /// Reads specific lines from a file asynchronously based on the provided line ranges.
    /// </summary>
    /// <param name="storage">The storage interface used to access the file.</param>
    /// <param name="filePath">The path of the file to read from.</param>
    /// <param name="lineRanges">
    /// A collection of tuples representing the line ranges to extract. 
    /// Each tuple contains a start line (inclusive) and an end line (inclusive).
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous operation. 
    /// The result contains the extracted lines joined by the system's newline character, 
    /// or the entire file content if no line ranges are specified.
    /// </returns>
    public static async ValueTask<string> ReadLinesFromPackageFile(this IStorage storage, string filePath, IEnumerable<(int, int)> lineRanges)
    {
        string fileContent = await storage.ReadPackageFileAsync(filePath) ?? string.Empty;
        if (!(lineRanges.Any()))
        {
            return fileContent;
        }

        return fileContent.Split(Environment.NewLine)
                          .SelectItemsByRanges(lineRanges,false)
                          .JoinBy(Environment.NewLine);
    }
}
