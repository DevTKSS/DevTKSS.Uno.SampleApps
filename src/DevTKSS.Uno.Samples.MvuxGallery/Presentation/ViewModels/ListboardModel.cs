using Uno.Extensions.Storage;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

/// <summary>
/// Represents the view model for the Listboard, providing data and functionality for the UI.
/// </summary>
public partial record ListboardModel
{
    #region Services
    /// <summary>
    /// Service for navigation between views.
    /// </summary>
    private readonly INavigator _navigator;

    /// <summary>
    /// Service for localization-related operations.
    /// </summary>
    private readonly ILocalizationService _localizationService;

    /// <summary>
    /// Service for retrieving localized strings.
    /// </summary>
    private readonly IStringLocalizer _stringLocalizer;

    /// <summary>
    /// Service for managing code samples.
    /// </summary>
    private readonly ICodeSampleService _codeSampleService;

    /// <summary>
    /// Service for retrieving gallery images.
    /// </summary>
    private readonly IGalleryImageService _galleryImageService;
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="ListboardModel"/> class.
    /// </summary>
    /// <param name="navigator">The navigation service.</param>
    /// <param name="localizationService">The localization service.</param>
    /// <param name="stringLocalizer">The string localizer service.</param>
    /// <param name="galleryImageService">The gallery image service.</param>
    /// <param name="codeSampleService">The code sample service.</param>
    public ListboardModel(
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        ICodeSampleService codeSampleService)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        this._codeSampleService = codeSampleService;
    }

    /// <summary>
    /// Gets a feed of gallery images to be displayed.
    /// </summary>
    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(this._galleryImageService.GetGalleryImagesWithoutReswAsync);

    /// <summary>
    /// Gets the title of the Listboard.
    /// </summary>
    public IState<string> ListboardTitle => State<string>.Value(this, () => _stringLocalizer["ListboardTitle"]);

    #region CodeSample import
    /// <summary>
    /// Represents a static collection of code sample options to bind to.
    /// </summary>
    /// <remarks>
    /// The ListFeed is generic (`ListFeed<string>.Async`) and the service function returns a collection of strings.
    /// </remarks>
    public IListFeed<string> CodeSampleOptions => ListFeed<string>
                                                      .Async(_codeSampleService.GetCodeSampleOptionsAsync)
                                                      .Selection(SelectedSampleOption);

    /// <summary>
    /// Represents the selected code sample option.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="string.Empty"/> as the default value to avoid null checks in the XAML.
    /// </remarks>
    public IState<string> SelectedSampleOption => State<string>
                                                    .Value(this, () => string.Empty)
                                                    .ForEach(SwitchCodeSampleAsync);

    /// <summary>
    /// Represents the content of the currently selected code sample.
    /// </summary>
    public IState<string> CurrentCodeSample => State<string>
                                                    .Value(this, () => string.Empty);

    /// <summary>
    /// Switches the current code sample based on the selected option.
    /// </summary>
    /// <param name="selectedSampleOption">The selected code sample option.</param>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async ValueTask SwitchCodeSampleAsync(string? selectedSampleOption, CancellationToken ct = default)
    {
        string sample = await _codeSampleService.SwitchCodeSampleAsync(selectedSampleOption);
        await CurrentCodeSample.SetAsync(sample, ct);
    }
    #endregion

    #region ViewHeaderContent
    /// <summary>
    /// Gets the header content for the view, including an image and caption.
    /// </summary>
    public IState<HeaderContent> ViewHeaderContent =>
        State<HeaderContent>
            .Value(owner: this,
                   valueProvider: () =>
                        new HeaderContent(
                            ImageLocation: "Assets/Images/styled_logo.png",
                            Caption: _stringLocalizer["ListViewTitle"]));
    #endregion
}



