namespace DevTKSS.Extensions.Uno.Storage.Tests;

public class EnumerableExtensionsTests
{
    [Fact]
    public void GetItemsWithinRange_ReturnsEmptyString_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<string>? source = null;
        var range = new Lines { Start = 0, End = 1 };

        // Act
        var result = source.GetLinesWithinRange(range);

        // Assert
        result.ShouldBe(string.Empty);
        result.ShouldNotBeNull();
    }

    [Fact]
    public void GetItemsWithinRange_ReturnsEmptyString_WhenSourceIsEmpty()
    {
        // Arrange
        var source = Array.Empty<string>();
        var range = new Lines { Start = 0, End = 1 };

        // Act
        var result = source.GetLinesWithinRange(range);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Theory]
    [InlineData(new[] { "a", "b", "c", "d" }, new[] { "b", "c", "d" }, 1, 3, true )]
    [InlineData(new[] { "one", "two", "three" }, new[] { "one", "two" }, 1, 2, false )]
    [InlineData(new[] { "a", "b", "c", "d" }, new[] { "b", "c", "d" }, 2, 0, false )]
    // 0-based single-item selection: start=0,end=0 should return the first item only
    [InlineData(new[] { "x", "y", "z" }, new[] { "x" }, 0, 0, true )]
    public void GetItemsWithinRange_ReturnsExpectedItems(string[] source, string[] expectedData, int start, int end, bool isNullBased)
    {
        // Arrange
        var range = new Lines(start, end);
        var expected = expectedData.JoinBy(Environment.NewLine);

        // Act
        var result = source.GetLinesWithinRange(range, isNullBased: isNullBased);

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData(new[] { "a", "b", "c" }, 4, 1, true)]
    [InlineData(new[] { "a", "b", "c" }, 1, 5, true)]
    [InlineData(new[] { "a", "b", "c" }, -1, 1, true)]
    [InlineData(new[] { "a", "b", "c" }, 1, -1, true)]
    [InlineData(new[] { "a", "b", "c" }, 0, -1, true)]
    [InlineData(new[] { "a", "b", "c" }, 1, 0, true)]
    [InlineData(new[] { "a", "b", "c" }, 3, 3, true)] // 0-based: Start == Count is invalid
    [InlineData(new[] { "a", "b", "c" }, 0, 3, true)] // 0-based: End == Count is invalid
    public void GetItemsWithinRange_InvalidIndices_Throw(string[] source, int start, int end, bool isNullBased)
    {
        var range = new Lines(start, end);
        Should.Throw<ArgumentOutOfRangeException>(() => source.GetLinesWithinRange(range, isNullBased));
    }

    [Fact]
    public void GetItemsWithinRange_WithIEnumerableNotIList_MaterializesSource()
    {
        // Test the materialization branch: source as IEnumerable (not IList)
        // Using Select() creates an IEnumerable that is NOT IList
        IEnumerable<string> source = new[] { "a", "b", "c", "d" }.Select(x => x);
        var range = new Lines(1, 2);

        var result = source.GetLinesWithinRange(range, isNullBased: true);

        result.ShouldBe(new[] { "b", "c" }.JoinBy(Environment.NewLine));
    }

    [Fact]
    public void GetItemsWithinRange_WithIList_UsesDirectCast()
    {
        // Test the IList cast branch
        IList<string> source = new List<string> { "a", "b", "c", "d" };
        var range = new Lines(2, 0);

        var result = source.GetLinesWithinRange(range, isNullBased: false);

        result.ShouldBe(new[] { "b", "c", "d" }.JoinBy(Environment.NewLine));
    }

    [Fact]
    public void SelectItemsByRanges_WithNullSource_ReturnsEmptyString()
    {
        // Arrange
        IEnumerable<string>? source = null;
        var ranges = new List<Lines> { new(0, 0) };

        // Act
        var result = source.GetLinesWithinRanges(ranges).ToArray();

        // Assert
        result.ShouldBe([string.Empty]);
    }

    [Fact]
    public void SelectItemsByRanges_WithSingleItemAndEmptyRanges_ReturnsSingleItem()
    {
        // Arrange
        var source = new[] { "x" };
        var ranges = Array.Empty<Lines>();

        // Act
        var result = source.GetLinesWithinRanges(ranges).ToArray();

        // Assert
        result.ShouldBe(["x"]);
    }

    [Theory]
    [InlineData(new[] { "a", "b", "c", "d" }, 0, 1, 2, 3, new[] { "a\r\nb", "c\r\nd" })] // Two ranges, 0-based
    [InlineData(new[] { "one", "two", "three" }, 1, 2, 2, 3, new[] { "one\r\ntwo", "two\r\nthree" })] // Overlapping ranges, 1-based
    [InlineData(new[] { "x", "y", "z" }, 0, 0, 1, 1, new[] { "x", "y" })] // Single items, 0-based
    public void SelectItemsByRanges_WithMultipleRanges_ReturnsExpectedSegments(string[] source, int start1, int end1, int start2, int end2, string[] expected)
    {
        // Arrange
        var ranges = new List<Lines> { new(start1, end1), new(start2, end2) };
        bool isNullBased = start1 == 0; // Infer from first start value

        // Act
        var result = source.GetLinesWithinRanges(ranges, isNullBased).ToArray();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void SelectItemsByRanges_WithEmptyRanges_ReturnsFullContent()
    {
        // Arrange
        var source = new[] { "a", "b", "c", "d" };
        var content = string.Join(Environment.NewLine, source);
        var ranges = Array.Empty<Lines>();

        // Act
        var result = source.GetLinesWithinRanges(ranges);

        // Assert
        result.ShouldHaveSingleItem();
        result.First().ShouldBe(content);
    }

    [Fact]
    public void SelectItemsByRanges_WithMultipleRanges_ReturnsEachRangeContent()
    {
        // Arrange
        var source = new[] { "a", "b", "c", "d" };
        IEnumerable<Lines> rangesList = [ new(0, 1), new(2, 3) ];
        var firstExpected = new[] { "a", "b" }.JoinBy(Environment.NewLine);
        var secondExpected = new[] { "c", "d" }.JoinBy(Environment.NewLine);

        // Act: default isNullBased = true
        var result = source.GetLinesWithinRanges(rangesList).ToArray();

        // Assert: length and each item
        result.Length.ShouldBe(2);
        result.First().ShouldBe(firstExpected);
        result.Last().ShouldBe(secondExpected);
    }

}
