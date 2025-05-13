using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

/// <summary>
/// Represents the view model for the Listboard, providing data and functionality for the UI.
/// </summary>
public partial record ListboardModel
{
    #region Services
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
    /// <param name="stringLocalizer">The string localizer service.</param>
    /// <param name="galleryImageService">The gallery image service.</param>
    /// <param name="serviceProvider">The serviceProvider, to fetch the code sample service as NamedService from with correct configuration.</param>
    public ListboardModel(
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        IServiceProvider serviceProvider)
    {
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        this._codeSampleService = serviceProvider.GetRequiredNamedService<ICodeSampleService>("ListboardSampleService");
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
                                                      .Selection(SelectedOption);

    /// <summary>
    /// Represents the selected code sample option.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="string.Empty"/> as the default value to avoid null checks in the XAML.
    /// </remarks>
    public IState<string> SelectedOption => State<string>
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
    /// <param name="choice">The selected code sample option.</param>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <example>
    /// <code>
    /// public async ValueTask SwitchCodeSampleAsync(string? selectedSampleOption, CancellationToken ct = default)
    /// {
    ///     string sample = await _codeSampleService.GetCodeSampleAsync(selectedSampleOption ?? string.Empty);
    ///     await CurrentCodeSample.SetAsync(sample, ct);
    /// }
    /// </code>
    /// </example>
    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedSampleOption))] string? choice, CancellationToken ct = default)
    {
        string sample = await _codeSampleService.GetCodeSampleAsync(choice ?? string.Empty);
        await CurrentCodeSample.SetAsync(sample, ct);
    }
    #endregion

    #region ViewHeaderContent
    /// <summary>
    /// Gets the header content for the view, including an image and caption.
    /// </summary>
    /// <example>
    /// <code>
    /// public IState<HeaderContent> ViewHeaderContent =>
    /// State<HeaderContent>
    ///        .Value(owner: this,
    ///               valueProvider: () =>
    ///                 new HeaderContent(
    ///                     ImageLocation: "Assets/Images/styled_logo.png",
    ///                     Caption: _stringLocalizer["ListViewTitle"]));
    /// </code>
    /// </example>
    public IState<HeaderContent> ViewHeaderContent =>
        State<HeaderContent>
            .Value(owner: this,
                   valueProvider: () =>
                        new HeaderContent(
                            ImageLocation: "Assets/Images/styled_logo.png",
                            Caption: _stringLocalizer["ListViewTitle"]));
    #endregion
}



