namespace DevTKSS.Extensions.Uno.Storage.Tests;
public class StorageExtensionsTests
{
    private static readonly string[] SampleContent = new[] { "a", "b", "c", "d" };

#pragma warning disable IDE0090 // Use 'new(...)'
    public static MatrixTheoryDataOneBased<string> SampleData
     => new MatrixTheoryDataOneBased<string>(SampleContent);
#pragma warning restore IDE0090 // Use 'new(...)'

    [Fact]
    public async Task ReadLinesFromPackageFile_NoRanges_ReturnsFullFile()
    {
        // Arrange
        var content = SampleFileHelper.GetSampleFile(SampleFileDefaults.CSharpPath);
        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);

        // Act
        var result = await storageMock.Object.ReadLinesFromPackageFile("any", Array.Empty<Lines>());

        // Assert
        Assert.Equal(content, result);
    }

    [Fact]
    public async Task ReadLinesFromPackageFile_EmptyContent_ReturnsEmptyString()
    {
        // Arrange
        var content = string.Empty;
        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);

        // Act
        var result = await storageMock.Object.ReadLinesFromPackageFile("any", Array.Empty<Lines>());

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public async Task ReadLinesFromPackageFile_SingleRange_ReturnsSelectedLines()
    {
        var content = string.Join(Environment.NewLine, SampleContent);
        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);
        var expected = string.Join(Environment.NewLine, new[] { "b", "c", "d" });

        // Extension uses isNullBased = false (1-based)
        // Current implementation returns End-inclusive; Start=2, End=4 yields 'b','c' as second and third lines
        var ranges = new[] { new Lines { Start = 2, End = 4 } };

        // Act
        var result = await storageMock.Object.ReadLinesFromPackageFile("any", ranges);

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [MemberData(nameof(SampleData))]
    public async Task ReadLinesFromPackageFile_RandomRanges_ReturnsExpected(string[] allData, IEnumerable<List<string>> expectedLines, IEnumerable<Lines> ranges, int _)
    {
        var content = string.Join(Environment.NewLine, allData);
        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);
        var expected = string.Join(Environment.NewLine, expectedLines.SelectMany(e => e));

        // Act
        var result = await storageMock.Object.ReadLinesFromPackageFile("any", ranges);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public async Task ReadPackageFile_WithEmbeddedCSharpSample_ReturnsContent()
    {
        // Arrange
        var fileContent = SampleFileHelper.GetSampleFile(SampleFileDefaults.CSharpPath);
        Contract.Assert(!string.IsNullOrEmpty(fileContent), "Sample CSharp fileContent must be available as file or embedded resource for this test.");

        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(fileContent);

        // Act
        var result = await storageMock.Object.ReadPackageFileAsync(SampleFileDefaults.CSharpPath);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldContain("CodeSampleOption");
    }

    [Fact]
    public async Task ReadPackageFile_WithEmbeddedXamlSample_ContainsDataTemplate()
    {
        // Arrange
        var content = SampleFileHelper.GetSampleFile(SampleFileDefaults.XamlPath);
        Contract.Assert(!string.IsNullOrEmpty(content), "Sample XAML fileContent must be available as file or embedded resource for this test.");

        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);

        // Act
        var result = await storageMock.Object.ReadPackageFileAsync(SampleFileDefaults.XamlPath);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldContain("DataTemplate");
    }

    [Fact]
    public async Task ReadPackageFile_WithEmbeddedJsonSample_ContainsListboardSampleOptions()
    {
        // Arrange
        var content = SampleFileHelper.GetSampleFile(SampleFileDefaults.JsonPath);
        Contract.Assert(!string.IsNullOrEmpty(content), "Sample JSON fileContent must be available as file or embedded resource for this test.");

        var storageMock = new Mock<IStorage>();
        storageMock.Setup(s => s.ReadPackageFileAsync(It.IsAny<string>())).ReturnsAsync(content);

        // Act
        var result = await storageMock.Object.ReadPackageFileAsync(SampleFileDefaults.JsonPath);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldContain("ListboardSampleOptions");
    }
}
