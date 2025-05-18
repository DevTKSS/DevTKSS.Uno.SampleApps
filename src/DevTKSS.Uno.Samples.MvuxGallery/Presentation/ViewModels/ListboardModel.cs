namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

/// <summary>
/// Represents the view model for the Listboard, providing data and functionality for the UI.
/// </summary>
public partial record ListboardModel
{

    #region Services
    private readonly ILogger _logger;
    /// <summary>
    /// Service for retrieving localized strings.
    /// </summary>
    private readonly IStringLocalizer _stringLocalizer;

    /// <summary>
    /// Service for managing code samples.
    /// </summary>
    private readonly ICodeSampleService<ListboardSampleOptions> _sampleService;

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
    /// <param name="logger">The logger instance for logging diagnostic and trace information.</param>
    /// <param name="sampleService">The service responsible for providing code sample options and content.</param>
    public ListboardModel(
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        ILogger<ListboardModel> logger,
        ICodeSampleService<ListboardSampleOptions> sampleService)
    {
        _logger = logger;
        _stringLocalizer = stringLocalizer;
        _galleryImageService = galleryImageService;
        _sampleService = sampleService;
    }

    /// <summary>
    /// Gets a feed of gallery images to be displayed.
    /// </summary>
    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(_galleryImageService.GetGalleryImagesWithoutReswAsync);

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
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(_sampleService.GetCodeSampleOptionsAsync)
                                                          .Selection(SelectedOption);

    /// <summary>
    /// Represents the selected code sample option.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="string.Empty"/> as the default value to avoid null checks in the XAML.
    /// </remarks>
    public IState<string> SelectedOption => State<string>.Value(this, () => string.Empty)
                                                         .ForEach(SwitchCodeSampleAsync);

    /// <summary>
    /// Represents the content of the currently selected code sample.
    /// </summary>
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);

    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedOption))] string? selectedOption, CancellationToken ct = default)
    {
        _logger.LogTrace("{methodName} called with selectedOption: '{SelectedOption}'",nameof(SwitchCodeSampleAsync), selectedOption);

        if (string.IsNullOrWhiteSpace(selectedOption))
        {
            _logger.LogTrace("selectedOption is null or whitespace. Attempting to get default from CodeSampleOptions.");
            var options = await CodeSampleOptions;
            selectedOption = options.FirstOrDefault(string.Empty);
            _logger.LogTrace("selectedOption updated to: '{SelectedOption}' after fetching options.", selectedOption);
        }
        string codeSample = await _sampleService.GetCodeSampleAsync(selectedOption, ct);
        _logger.LogTrace("Loaded code sample for option '{SelectedOption}': {CodeSample}", selectedOption, codeSample);
        await CurrentCodeSample.SetAsync(codeSample, ct);
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
                              Caption: _stringLocalizer["ListViewTitle"]);
           });
    #endregion
}



