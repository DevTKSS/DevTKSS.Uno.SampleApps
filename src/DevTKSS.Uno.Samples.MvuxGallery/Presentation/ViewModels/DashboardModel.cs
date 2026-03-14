using System.Reflection.Metadata;
using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

public partial record DashboardModel
{
    #region Services
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IGalleryImageService _galleryImageService;
    private readonly IStorage _storage;
    private readonly ILogger _logger;
    #endregion
    public DashboardModel(
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        IStorage storage,
        ILogger<DashboardModel> logger)
    {
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        this._storage = storage;
        this._logger = logger;
    }

    public IListFeed<GalleryImage> GalleryImages => ListFeed.Async(_galleryImageService.GetGalleryImagesWithoutReswAsync);
    public IListFeed<GalleryImage> GalleryImagesWithResw => ListFeed.Async(_galleryImageService.GetGalleryImagesWithReswAsync);

    #region CodeSample import directly in the Model
    /// <summary>
    /// Holds a static Collection of <see langword="string"/> to bind to
    /// </summary>
    /// <remarks>
    /// Projects the selected item to <see cref="SelectedOption"/>
    /// </remarks>
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(GetCodeSampleOptionsAsync)
                                                          .Selection(SelectedOption);

    /// <summary>
    /// Represents the selected item in the <see cref="CodeSampleOptions"/>
    /// </summary>
    /// <remarks>
    /// Executes <see cref="SwitchCodeSampleAsync"/> when the selected item changes
    /// </remarks>
    public IState<string> SelectedOption => State<string>.Value(this, () => "FeedView + GridView XAML")
                                                         .ForEach(SwitchCodeSampleAsync);

    /// <summary>
    /// Represents the currently selected code sample to bind to and default to an empty string
    /// </summary>
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);


    /// <summary>
    /// Retrieves a static collection of values for <see cref="CodeSampleOptions"/>.
    /// </summary>
    /// <param name="ct">A <see cref="CancellationToken"/> to make the method compileable.</param>
    /// <returns>An awaitable <see cref="ValueTask{TResult}"/> providing an <see cref="ImmutableList{T}"/> of <see langword="string"/> with the sample names to select from.</returns>
    public static async ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ct = default)
    {
        // since `ListFeed.Async` requires a CancellationToken even if Uno Documentation remarks this parameter to be optional.< br />
        // <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0411?f1url=%3FappId%3Droslyn%26k%3Dk(CS0411)">CS0411</see><br/>
        // 
        // adding then the type string or IImmutableList<string> to the ListFeed like `ListFeed<string>.Async(...)`,
        // or to the Async Extension itself like `ListFeed.Async<IImutableList<string>` results in a type mismatch.<br/>
        // <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)">CS1503</see>

        await Task.Delay(1, ct);

        return ImmutableList.Create(
            items:
            [
                "FeedView + GridView XAML",
                "Get GalleryImages via \n FeedList in Model",
                "DI Service Resw",
                "DI Service without Resw",
                "GalleryImage Record",
                "XAML DataTemplate"
            ]);
    }

    /// <summary>
    /// Switches the <see cref="CurrentCodeSample"/> to the selected item in <see cref="CodeSampleOptions"/>
    /// </summary>
    /// <param name="selectedOption">The selected item, provide-able via CommandParameter, prefer to let it get it via the <see cref="FeedParameterAttribute"/></param>
    /// <param name="ct">A cancellation token for the operation to update the <see cref="CurrentCodeSample"/></param>
    /// <returns>A ValueTask to be awaited</returns>
    /// <remarks>
    /// Uses switch expression to select the correct code sample which provides better performance and less boilerplate code.
    /// <para>
    /// The switch expression maps the selected option to the corresponding code sample file path. If the selected option does not match any predefined cases, it defaults to an empty string.
    /// </para>
    /// </remarks>
    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedOption))] string? selectedOption, CancellationToken ct = default)
    {
        _logger.LogTrace("SwitchCodeSampleAsync called with parameter: {selectedOption}", selectedOption);
        await CurrentCodeSample.SetAsync(selectedOption switch
        {
            "Get GalleryImages via \n FeedList in Model" => await _storage.ReadPackageFileAsync("Assets/Samples/ModelBinding-Sample.cs.txt"),
            "DI Service Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-resw.cs.txt"),
            "DI Service without Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-noResw.cs.txt"),
            "GalleryImage Record" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageModel.cs.txt"),
            "XAML DataTemplate" => await _storage.ReadPackageFileAsync("Assets/Samples/Card-GalleryImage.DataTemplate.xaml.txt"),
            "FeedView + GridView XAML" => await _storage.ReadPackageFileAsync("Assets/Samples/FeedView-GridView-Sample.xaml.txt"),
            _ => string.Empty
        }, ct);
    }

    #endregion

    #region ViewHeaderContent
    /// <summary>
    /// Gets the header content for the view, including an image and caption.
    /// </summary>
    /// <remarks>
    /// A Feed always needs a Async or Create function wich takes the cancellation token as parameter.<br/>
    /// So this is using a Task.Delay to simulate a delay in the async function.
    /// </remarks>
    public IFeed<HeaderContent> ViewHeaderContent => Feed<HeaderContent>.Async(
           valueProvider: async (ct) =>
           {
               await Task.Delay(1, ct);
               return new HeaderContent(ImageLocation: "Assets/Images/styled_logo.png",
                              Caption: _stringLocalizer["GridViewTitle"]);
           });
    #endregion

}



