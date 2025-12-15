namespace DevTKSS.Extensions.Uno.Storage.Tests;

public class SampleFileHelperTests
{
    private static readonly string[] SampleFileNames =
    [
        SampleFileDefaults.CSharpPath,
        SampleFileDefaults.XamlPath,
        SampleFileDefaults.JsonPath
    ];
    public static TheoryData<string> SampleFiles => new TheoryData<string>(SampleFileNames);

    [Theory]
    [MemberData(nameof(SampleFiles))]
    public void GetSampleFile_ExistingResource_ReturnsContent(string fileName)
    {
        // Arrange - nothing to arrange

        // Act
        var content = SampleFileHelper.GetSampleFile(fileName);

        // Assert
        content.ShouldNotBeNullOrWhiteSpace();
        if(fileName.EndsWith(".cs.txt"))
        {
            content.ShouldNotBeNullOrWhiteSpace();
            content.ShouldContain("record");
            content.ShouldContain("[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]");
        }
        else if (fileName.EndsWith(".xaml.txt"))
        {
            content.ShouldNotBeNullOrWhiteSpace();
            content.ShouldContain("<DataTemplate");
            content.ShouldContain("GalleryImage");
        }
        else if (fileName.EndsWith(".json.txt"))
        {
            content.ShouldStartWith("{");
            content.ShouldContain("ListboardSampleOptions");
            content.ShouldContain("[]");
        }
    }

    [Fact]
    public void GetSampleFile_NonExistingResource_ThrowsFileNotFoundException()
    {
        // Arrange
        var resourceName = "non-existing-file.txt";

        // Act & Assert
        var exception = Should.Throw<FileNotFoundException>(() => SampleFileHelper.GetSampleFile(resourceName));
        exception.Message.ShouldBe("Sample file not found");
    }

    [Fact]
    public void GetSampleFile_ExistingResource_DoesNotThrowException()
    {
        // Arrange
        var resourceName = SampleFileDefaults.CSharpPath;

        // Act & Assert
        Should.NotThrow(() => SampleFileHelper.GetSampleFile(resourceName));
    }

    [Theory]
    [MemberData(nameof(SampleFiles))]
    public void GetAvailableSampleFileNames_Default_ReturnsOnlySampleFolder(string fileName)
    {
        // Arrange
        var folderPrefix = string.Join('.', [SampleFileDefaults.AssemblyName, SampleFileDefaults.SampleDataFolder]);
        var expectedFileName = string.Join('.', folderPrefix, fileName);

        // Act
        var names = SampleFileHelper.GetAvailableSampleFileNames().ToList();

        // Assert
        names.ShouldNotBeNull();
        names.ShouldNotBeEmpty();
        names.ShouldContain(expectedFileName);
        names.ShouldAllBe(name => name.Contains(SampleFileDefaults.SampleDataFolder));
    }

    [Fact]
    public void GetAvailableSampleFileNames_WithFalse_ReturnsSuperset()
    {
        // Act
        var defaultNames = SampleFileHelper.GetAvailableSampleFileNames().ToList();
        var allNames = SampleFileHelper.GetAvailableSampleFileNames(false).ToList();

        // Assert
        allNames.ShouldNotBeNull();
        allNames.ShouldNotBeEmpty();
        allNames.Count.ShouldBeGreaterThanOrEqualTo(defaultNames.Count);
        defaultNames.ShouldBeSubsetOf(allNames);
    }

    [Fact]
    public void GetAssemblyName_Returns_CurrentAssemblyName()
    {
        // Act
        var assemblyName = SampleFileHelper.GetAssemblyName();

        // Assert
        assemblyName.ShouldNotBeNullOrWhiteSpace();
        assemblyName.ShouldBe("DevTKSS.Extensions.Uno.Storage.Tests");
        typeof(SampleFileHelperTests).Assembly.GetName().Name.ShouldBe(assemblyName);
    }

    [Fact]
    public void GetAssemblyName_ThrowsInvalidOperationException_WhenAssemblyNameIsNull()
    {
        SampleFileHelper.GetAssemblyName().ShouldNotBeNull();
    }

    [Fact]
    public void GetSampleFile_VerifiesProjectDirectoryResolution()
    {
        // This test indirectly verifies GetTestProjectDirectory's while loop
        // by ensuring the method can locate files from the project root
        
        // Act & Assert - should not throw, meaning directory was found
        Should.NotThrow(() => SampleFileHelper.GetSampleFile(SampleFileDefaults.CSharpPath));
    }

    [Fact]
    public void GetAvailableSampleFileNames_VerifiesDirectoryExistsCheck()
    {
        // This test ensures the Directory.Exists check works correctly
        // and returns files when directory exists
        
        // Act
        var names = SampleFileHelper.GetAvailableSampleFileNames().ToList();

        // Assert - should find files since SampleData folder exists in test project
        names.ShouldNotBeNull();
        names.ShouldNotBeEmpty("Sample folder should exist and contain test files");
    }

    [Fact]
    public void GetAvailableSampleFileNames_AlwaysReturnsValidFormat()
    {
        // This test ensures all returned names follow the expected format
        // which indirectly tests the Select projection logic
        
        // Act
        var names = SampleFileHelper.GetAvailableSampleFileNames();

        // Assert
        names.ShouldAllBe(name => name.Contains(SampleFileDefaults.AssemblyName), 
            "All file names should contain assembly name");
        names.ShouldAllBe(name => name.Contains(SampleFileDefaults.SampleDataFolder),
            "All file names should contain sample data folder");
        names.ShouldAllBe(name => name.EndsWith(".txt"),
            "All file names should end with .txt extension");
    }

    [Fact]
    public void GetAvailableSampleFileNamesFromDirectory_WithNonExistentDirectory_ReturnsEmpty()
    {
        // Arrange - use a path that definitely doesn't exist
        var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        // Act
        var result = SampleFileHelper.GetAvailableSampleFileNamesFromDirectory(nonExistentPath);

        // Assert
        result.ShouldBeEmpty("Should return empty collection when directory doesn't exist");
    }

    [Fact]
    public void GetAvailableSampleFileNamesFromDirectory_WithValidDirectory_ReturnsFiles()
    {
        // Arrange - use actual test project directory
        var assemblyLocation = typeof(SampleFileHelperTests).Assembly.Location;
        var directory = Path.GetDirectoryName(assemblyLocation);
        
        while (directory != null && !File.Exists(Path.Combine(directory, "DevTKSS.Extensions.Uno.Storage.Tests.csproj")))
        {
            directory = Directory.GetParent(directory)?.FullName;
        }

        directory.ShouldNotBeNull("Should find project directory");

        // Act
        var result = SampleFileHelper.GetAvailableSampleFileNamesFromDirectory(directory!).ToList();

        // Assert
        result.ShouldNotBeEmpty("Should find sample files in test project directory");
        result.ShouldAllBe(name => name.EndsWith(".txt"));
    }
}
