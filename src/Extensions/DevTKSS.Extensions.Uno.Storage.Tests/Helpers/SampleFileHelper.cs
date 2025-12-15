using System.Diagnostics;
using System.Reflection;

namespace DevTKSS.Extensions.Uno.Storage.Tests.Helpers;

internal static class SampleFileHelper
{

    internal static string GetSampleFile(string sampleFileName)
    {
        // Use file system instead of embedded resources for reliability
        var testProjectDir = GetTestProjectDirectory();
        var filePath = Path.Combine(testProjectDir, SampleFileDefaults.SampleDataFolder, sampleFileName);
        
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        
        throw new FileNotFoundException("Sample file not found", filePath);
    }
    
    private static string GetTestProjectDirectory()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var directory = Path.GetDirectoryName(assemblyLocation);
        
        // Navigate up from bin/Debug/net10.0 to project root
        while (directory != null && !File.Exists(Path.Combine(directory, "DevTKSS.Extensions.Uno.Storage.Tests.csproj")))
        {
            directory = Directory.GetParent(directory)?.FullName;
        }
        
        return directory ?? throw new InvalidOperationException("Could not find test project directory");
    }

    internal static IEnumerable<string> GetAvailableSampleFileNames(bool sampleFolderOnly = true)
    {
        var testProjectDir = GetTestProjectDirectory();
        return GetAvailableSampleFileNamesFromDirectory(testProjectDir, sampleFolderOnly);
    }

    internal static IEnumerable<string> GetAvailableSampleFileNamesFromDirectory(string testProjectDir, bool sampleFolderOnly = true)
    {
        var sampleFolder = Path.Combine(testProjectDir, SampleFileDefaults.SampleDataFolder);
        
        if (!Directory.Exists(sampleFolder))
        {
            return [];
        }
        
        var files = Directory.GetFiles(sampleFolder, "*.txt", SearchOption.AllDirectories);
        var prefix = string.Join('.', SampleFileDefaults.AssemblyName, SampleFileDefaults.SampleDataFolder);
        
        return files.Select(f =>
        {
            var fileName = Path.GetFileName(f);
            return string.Join('.', prefix, fileName);
        });
    }

    internal static string? GetAssemblyName()
    {
        var asm = Assembly.GetExecutingAssembly().GetName().Name;
        return asm;
    }

}
