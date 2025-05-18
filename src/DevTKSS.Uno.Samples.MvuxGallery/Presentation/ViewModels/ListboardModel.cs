using System.Runtime.CompilerServices;

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
    private readonly ICodeSampleService<ListboardCodeSampleOptions> _codeSampleService;

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
        IServiceProvider serviceProvider,
        ILogger<ListboardModel> logger,
        ICodeSampleService<ListboardCodeSampleOptions> sampleService)
    {
        _logger = logger;
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        _codeSampleService = sampleService;
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
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(_codeSampleService.GetCodeSampleOptionsAsync)
                                                      .Selection(SelectedOption);

    /// <summary>
    /// Represents the selected code sample option.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="string.Empty"/> as the default value to avoid null checks in the XAML.
    /// </remarks>
    public IState<string> SelectedOption => State<string>.Value(this, () => string.Empty);

    /// <summary>
    /// Represents the content of the currently selected code sample.
    /// </summary>
    public IFeed<string> CurrentCodeSample => SelectedOption.SelectAsync((sample, ct)=> _codeSampleService.GetCodeSampleAsync(sample, ct));

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



