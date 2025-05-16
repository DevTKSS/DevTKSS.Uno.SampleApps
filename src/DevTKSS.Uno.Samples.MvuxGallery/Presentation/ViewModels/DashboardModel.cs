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

    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(_galleryImageService.GetGalleryImagesWithoutReswAsync);
    public IListFeed<GalleryImageModel> GalleryImagesWithResw => ListFeed.Async(_galleryImageService.GetGalleryImagesWithReswAsync);


    public IState<string> DashboardTitle => State<string>.Value(this, () => _stringLocalizer["DashboardTitle"]);

    #region ViewHeaderContent
    /// <value>
    /// Represents the header content of the view
    /// </value>
    /// <remarks>
    /// uses <see cref="IStringLocalizer"/> to dynamically localize the caption
    /// </remarks>
    public IState<HeaderContent> ViewHeaderContent =>
        State<HeaderContent>.Value(
            owner: this,
            valueProvider: () =>
                new HeaderContent(
                    ImageLocation: "Assets/Images/styled_logo.png",
                    Caption: _stringLocalizer["GridViewTitle"]));
    #endregion

    #region CodeSample import directly in the Model
    /// <value>
    /// Holds a static Collection of <see langword="string"/> to bind to
    /// </value>
    /// <remarks>
    /// Projects the selected item to <see cref="SelectedOption"/>
    /// </remarks>
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(GetCodeSampleOptionsAsync)
                                                          .Selection(SelectedOption);

    /// <value>
    /// Represents the selected item in the <see cref="CodeSampleOptions"/>
    /// </value>
    /// <remarks>
    /// Executes <see cref="SwitchCodeSampleAsync"/> when the selected item changes
    /// </remarks>
    public IState<string> SelectedOption => State<string>.Value(this, () => "FeedView + GridView XAML")
                                                         .ForEach(SwitchCodeSampleAsync);

    /// <value>
    /// Represents the currently selected code sample to bind to and default to an empty string
    /// </value>
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);

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
    public static async ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ct = default)
    {

        await Task.Delay(1, ct);

        return ImmutableList.Create(
            items:
            [
                "FeedView + GridView XAML",
                "C# in Model",
                "DI Service Resw",
                "DI Service without Resw",
                "C# Record",
                "XAML DataTemplate"
            ]);
    }

    /// <summary>
    /// Switches the <see cref="CurrentCodeSample"/> to the selected item in <see cref="CodeSampleOptions"/>
    /// </summary>
    /// <param name="choice">The selected item, provide-able via CommandParameter, prefer to let it get it via the <see cref="FeedParameterAttribute"/></param>
    /// <param name="ct">A cancellation token for the operation to update the <see cref="CurrentCodeSample"/></param>
    /// <returns>A ValueTask to be awaited</returns>
    /// <remarks>
    /// Uses switch expression to select the correct code sample which provides better performance and less boilerplate code.
    /// </remarks>
    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedOption))] string? choice, CancellationToken ct = default)
    {
        _logger.LogTrace("SwitchCodeSampleAsync called with parameter: {choice}", choice);
        await CurrentCodeSample.SetAsync(choice switch
        {
            "C# in Model" => await _storage.ReadPackageFileAsync("Assets/Samples/ModelBinding-Sample.cs.txt"),
            "DI Service Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-resw.cs.txt"),
            "DI Service without Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-noResw.cs.txt"),
            "C# Record" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageModel.cs.txt"),
            "XAML DataTemplate" => await _storage.ReadPackageFileAsync("Assets/Samples/Card-GalleryImage.DataTemplate.xaml.txt"),
            "FeedView + GridView XAML" => await _storage.ReadPackageFileAsync("Assets/Samples/FeedView-GridView-Sample.xaml.txt"),
            _ => string.Empty
        }, ct);
    }

    #endregion



}



