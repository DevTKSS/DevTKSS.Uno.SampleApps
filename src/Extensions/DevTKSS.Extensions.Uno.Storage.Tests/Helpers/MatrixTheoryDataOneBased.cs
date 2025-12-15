using System.Diagnostics.Contracts;

namespace DevTKSS.Extensions.Uno.Storage.Tests.Helpers;

public class MatrixTheoryDataOneBased<T1> : TheoryData<T1[], IEnumerable<List<T1>>, IEnumerable<Lines>, int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixTheoryDataOneBased{T1}"/> class.<br/>
    /// Generates random 1-based <see cref="Lines"/> ranges and expected elements based on the provided <paramref name="data"/> array.
    /// </summary>
    /// <param name="data">The array of data elements to generate <see cref="Lines"/> ranges and expected elements from.</param>
    /// <remarks>
    /// The generated <see cref="Lines"/> ranges and expected elements are added to the theory data.
    /// </remarks>
    public MatrixTheoryDataOneBased(T1[] data)
    {
        // Ensure we got valid data
        Contract.Assert(data is not null && data.Length > 0);

        // Determine number of line ranges to generate
        var numberOfLines = Random.Shared.Next(1, data.Length + 1);

        var lines = new List<Lines>(numberOfLines);
        var expectedLines = new List<List<T1>>();

        for (int i = 0; i < numberOfLines; i++)
        {
            // Generate random 1-based line ranges (End is inclusive in current implementation)
            var firstLine = Random.Shared.Next(1, data.Length); // 1 .. (N-1)
            var lastLine = Random.Shared.Next(firstLine + 1, data.Length + 1); // (first+1) .. N

            // Extract expected elements based on the line ranges (convert to 0-based for array indexing)
            var expectedElements = new List<T1>(data[(firstLine - 1)..lastLine]);

            // And add to collections
            lines.Add(new Lines(firstLine, lastLine));
            expectedLines.Add(expectedElements);
        }

        Add(data, expectedLines, lines, numberOfLines);

    }
}
