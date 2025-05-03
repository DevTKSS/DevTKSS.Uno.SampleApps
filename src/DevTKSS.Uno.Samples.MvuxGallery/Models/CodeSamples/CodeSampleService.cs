
using System.Runtime.CompilerServices;
using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public class CodeSampleService
{    
    public CodeSampleService(
    IOptions<CodeSampleOptionsConfiguration>? options,
    ILogger<CodeSampleService> logger,
    IStorage storage)
    {
        _codeSampleDict = options?.Value.Items ?? [];
        _logger = logger;
        _storage = storage;
    }

    private readonly IStorage _storage;
    private readonly ILogger<CodeSampleService> _logger;
    private readonly Dictionary<string, CodeSampleOption[]> _codeSampleDict;
    
    public async ValueTask<ImmutableList<string>> GetCodeSampleOptions(string callerID, CancellationToken ct = default)
    {
        await Task.Delay(1, ct);
        return _codeSampleDict.UnoGetValueOrDefault(callerID)
            .SelectToList(sampleOptions => sampleOptions.Identifyer)
            .ToImmutableList();
    }
    
    public async Task<string> GetCodeSampleAsync(string callerID, string sampleID)
    {
        if(_codeSampleDict.TryGetValue(callerID, out var sampleOptions))
        {
            var sampleOption = sampleOptions.FirstOrDefault(item => item.Identifyer == sampleID);
            return sampleOption == null
                ? throw new ArgumentException($"Sample option {sampleID} not found for {callerID}")
                : await _storage.ReadLinesFromPackageFile(sampleOption.FilePath, sampleOption.LineRanges);
        }
        else return string.Empty;
    }

    /// <summary>
    /// Get a static Collection of Values for <see cref="CodeSampleOptions"/>
    /// </summary>
    /// <param name="ct">
    /// A CancellationToken to make it compileable
    /// <remarks>
    /// since `ListFeed.Async` requires a CancellationToken even if Uno Documentation remarks this parameter to be optional.<br/>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0411?f1url=%3FappId%3Droslyn%26k%3Dk(CS0411)">CS0411</see><br/>
    /// <br/>
    /// adding then the type string or IImmutableList<string> to the ListFeed like `ListFeed<string>.Async(...)`,
    /// or to the Async Extension itself like `ListFeed.Async<IImutableList<string>` results in a type mismatch.<br/>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)">CS1503</see>
    /// </remarks>
    /// </param>
    /// <returns>The available Values to select from.</returns>
    /// <remarks>
    /// This uses the explicit `ImmutableList.Create` function (non generic!)<br/>
    /// overload:<br/>
    /// `params ReadOnlySpan<string> items` this takes in an (e.g.) array of generic typed values
    /// </remarks>
    public static async ValueTask<IImmutableList<string>?> GetCodeSampleOptionsAsync<TOwner>(TOwner owner, CancellationToken ct = default)
        where TOwner : class
    {
        await Task.Delay(1, ct);

        if (owner is MainModel)
        {
            return ImmutableList.Create(
                items:
            [
                "NavigationView XAML",
                "C# in Model"
            ]);
        }
        else if (owner is DashboardModel)
        {
            return ImmutableList.Create(
            items:
            [
                "FeedView + GridView XAML",
                "C# in DashboardModel",
                "DI GalleryImageService Resw",
                "DI GalleryImageService without Resw",
                "C# GalleryImageModel Record",
                "XAML DataTemplate"
            ]);
        }
        else if (owner is ListboardModel)
        {
            return ImmutableList.Create(
                items:
            [
                "FeedView + ListView XAML",
                "C# in ListboardModel",
                "DI Service Resw",
                "DI Service without Resw",
                "C# Record",
                "XAML DataTemplate"
            ]);
        }
        else if (owner is SimpleCardsModel)
        {
            return ImmutableList.Create(
                items:
            [
                "Card Control XAML",
                "C# in SimpleCardsModel",
                "C# Record",
                "XAML DataTemplate"
            ]);
        }
        else if (owner is CounterModel)
        {
            return ImmutableList.Create(
                items:
            [
                "View XAML",
                "C# in CounterModel"
            ]);
        }
        else return default;

    }

    /// <summary>
    /// Get the content of the selected item
    /// </summary>
    /// <param name="choice">The selected item</param>
    /// <param name="ct">A cancellation token for the operation to update the <see cref="CurrentCodeSample"/></param>
    /// <returns>A ValueTask to be awaited</returns>
    /// <remarks>
    /// Uses switch expression to select the correct code sample which provides better performance and less boilerplate code.
    /// </remarks>
    public async ValueTask SwitchCodeSampleAsync(string? choice, CancellationToken ct = default)
    {
        _logger.LogTrace("SwitchCodeSampleAsync called with parameter: {choice}", choice);
        return choice switch
        {
            "C# in Model" => await _storage.ReadPackageFileAsync("Assets/Samples/ModelBinding-Sample.cs.txt"),
            "DI Service Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-resw.cs.txt"),
            "DI Service without Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-noResw.cs.txt"),
            "C# Record" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageModel.cs.txt"),
            "XAML DataTemplate" => await _storage.ReadPackageFileAsync("Assets/Samples/Card-GalleryImage.DataTemplate.xaml.txt"),
            "FeedView + GridView XAML" => await _storage.ReadPackageFileAsync("Assets/Samples/FeedView-GridView-Sample.xaml.txt"),
            _ => string.Empty
        };
    }
}
