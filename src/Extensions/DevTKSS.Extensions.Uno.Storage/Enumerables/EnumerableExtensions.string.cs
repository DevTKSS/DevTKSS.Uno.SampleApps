using System.Diagnostics.CodeAnalysis;

namespace DevTKSS.Extensions.Uno.Storage.Enumerables;

/// <summary>
/// Provides <see cref="IEnumerable{TResult}"/> extension methods for working with <see cref="IStorage"/>.
/// </summary>
internal static class EnumerableExtensions
{

    /// <summary>
    /// Returns the string segments from  <paramref name="source"/> for each range provided in <paramref name="ranges"/>, joined by <see cref="Environment.NewLine"/>.
    /// <list type="bullet">
    /// <listheader>Behavior details:</listheader>
    /// <item>If <paramref name="source"/> is <see langword="null"/>, the method will yield return an empty string once and stop the iteration</item>
    /// <item>If <paramref name="ranges"/> is empty, the method will yield back once, containing all items from <paramref name="source"/></item>
    /// <item>Otherwise the method iterates <paramref name="ranges"/> and yields for each range the concatenated specified lines returned by <see cref="GetLinesWithinRange(IEnumerable{string}?, Lines?, bool)"/>.</item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// This is specifically useful when working with typical text editor or IDE files, that are showing 1-based line numbering.
    /// </remarks>
    /// <param name="source">
    /// The source <see cref="IEnumerable{T}"/> of <see langword="string"/> items to select the specified Ranges from.</param>
    /// <param name="ranges">
    /// A collection of <see cref="Lines"/> ranges. Each range provides <see cref="Lines.Start"/> and <see cref="Lines.End"/>.
    /// <see cref="Lines.End"/> may be <c>0</c> when using 1-based indexing (<paramref name="isNullBased"/> = <see langword="false"/>), which serves as a sentinel meaning "until end".
    /// For 0-based indexing, <c>0</c> is a valid end value representing the first item.
    /// </param>
    /// <param name="isNullBased">
    /// Defines whether the provided indices in <paramref name="ranges"/> are treated as 0-based or 1-based.<br/>
    /// Specifically useful when working with typical text editor or IDE files, that are showing 1-based line numbering.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{string}"/> where each yielded string represents the items within one specified range from <paramref name="ranges"/>, with items joined by <see cref="Environment.NewLine"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when any range in <paramref name="ranges"/> contains invalid index values relative to <paramref name="source"/>.<br/>
    /// <b>Examples:</b><br/>
    /// <see cref="Lines.Start"/> or <see cref="Lines.End"/> that are negative or greater than the number of items in <paramref name="source"/>
    /// will cause <see cref="GetItemsWithinRange(IEnumerable{string}, Lines, bool)"/> to throw <see cref="ArgumentOutOfRangeException"/>.
    /// </exception>
    [return: NotNullIfNotNull(nameof(source))]
    public static IEnumerable<string> GetLinesWithinRanges(this IEnumerable<string>? source, IEnumerable<Lines> ranges, bool isNullBased = true)
    {

        if (source is null)
        {
            yield return string.Empty;
            yield break;
        }

        if (!ranges.Any())
        {
            yield return source.JoinBy(Environment.NewLine);
            yield break;
        }

        foreach (var range in ranges)
        {
            yield return source.GetLinesWithinRange(range, isNullBased);
        }

    }

    /// <summary>
    /// Retrieves and returns the concatenated items from <paramref name="source"/> that fall within the specified <paramref name="range"/>.<br/>
    /// Specifically usefull when working with typical text editor or IDE files, that are showing 1-based line numbering.<br/>
    /// Simply use the showed line numbers from there to get the appropriate items at Runtime.
    /// </summary>
    /// <param name="source">The sequence of strings to select from.</param>
    /// <param name="range">
    /// When provided, <see cref="Lines"/> specifies the desired start and end indices (both treated as inclusive)<br/>
    /// For 1-based indexing (<paramref name="isNullBased"/> = <see langword="false"/>), providing <see cref="Lines.End"/> with the value <c>0</c> will return <b>all</b> joined lines until the end of <paramref name="source"/>, starting by <see cref="Lines.Start"/>.<br/>
    /// For 0-based indexing (<paramref name="isNullBased"/> = <see langword="true"/>), <c>0</c> is a valid end value representing the first item.<br/>
    /// If <paramref name="range"/> is <see langword="null"/>, all items from <paramref name="source"/> are returned, joined by <see cref="Environment.NewLine"/>.
    /// </param>
    /// <param name="isNullBased">
    /// When <see langword="true"/> the provided indices are interpreted as 0-based; when <see langword="false"/> they are interpreted as 1-based.<br/>
    /// <list type="bullet">
    /// <item>If <paramref name="isNullBased"/> is <see langword="true"/>, <paramref name="range"/> values are treated as 0-based indices.<br/>
    /// <b>Example:</b><br/>
    /// <see cref="Lines.Start"/><c>=0</c> and  <see cref="Lines.End"/><c>=2</c> will return items at indices 0, 1 and 2.</item>
    /// <item>If <paramref name="isNullBased"/> is <see langword="false"/>, <paramref name="range"/> values are treated as 1-based indices.<br/>
    /// <b>Example:</b><br/>
    /// <see cref="Lines.Start"/><c>=0</c> and  <see cref="Lines.End"/><c>=2</c> will instead return the items at indices 0 and 1.</item>
    /// </list>
    /// </param>
    /// <returns>
    /// A <see cref="string"/> consisting of the items from <paramref name="source"/> that are within the computed range specified by <paramref name="range"/>, joined by <see cref="Environment.NewLine"/>.<br/>
    /// If <paramref name="source"/> is <see langword="null"/> or empty, <see cref="string.Empty"> will be returned (no exception).
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <see cref="Lines.Start"/> or <see cref="Lines.End"/> are negative, or when either value is greater than the number of items in <paramref name="source"/>.
    /// </exception>
    [return: NotNullIfNotNull(nameof(source))]
    public static string GetLinesWithinRange(this IEnumerable<string>? source, Lines range, bool isNullBased = true)
    {
        // sourceItems null -> return empty string (no exception)
        if (source is null)
        {
            return string.Empty;
        }

        // materialize
        IList<string> sourceList = source as IList<string> ?? [.. source];

        // empty source -> empty string
        if (sourceList.Count == 0)
        {
            return string.Empty;
        }

        // Validate non-negative using ThrowIfNegative
        ArgumentOutOfRangeException.ThrowIfNegative(range.Start, nameof(range.Start));
        ArgumentOutOfRangeException.ThrowIfNegative(range.End, nameof(range.End));

        var resultBase = isNullBased ? 0 : 1;

        // Context-aware validation:
        // - For 0-based: indices must be < Count (valid indices are 0 to Count-1)
        // - For 1-based: line numbers must be <= Count (valid lines are 1 to Count)
        if (isNullBased)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(range.Start, sourceList.Count, nameof(range.Start));
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(range.End, sourceList.Count, nameof(range.End));
        }
        else
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(range.Start, sourceList.Count, nameof(range.Start));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(range.End, sourceList.Count, nameof(range.End));
        }

        var startIndex = Math.Clamp(
            value: range.Start - resultBase,
            min: 0,
            max: sourceList.Count);

        // Interpret End == 0 as 'until end' sentinel only for 1-based indexing
        // (where line 0 doesn't exist, making it unambiguous)
        // For 0-based indexing, End == 0 is a valid index (the first item)
        int endIndex;
        if (range.End == 0 && !isNullBased)
        {
           return sourceList.Skip(startIndex)
                            .JoinBy(Environment.NewLine);
        }

        // Validate range direction: for 0-based, End cannot be less than Start (backward range)
        if (isNullBased && range.End < range.Start)
        {
            throw new ArgumentOutOfRangeException(nameof(range.End), $"End ({range.End}) cannot be less than Start ({range.Start}) for 0-based indexing.");
        }

        if (isNullBased)
        {
            endIndex = Math.Clamp(
                value: range.End + 1,
                min: startIndex,
                max: sourceList.Count ); // Ensure 'End' does not exceed available lines
        }
        else
        {
            endIndex = Math.Clamp(
                    value: range.End,
                    min: startIndex,
                    max: sourceList.Count); // Ensure 'End' does not exceed available lines
        }

        return sourceList.Skip(startIndex)
                   .Take(endIndex - startIndex)
                   .JoinBy(Environment.NewLine);
    }
}
