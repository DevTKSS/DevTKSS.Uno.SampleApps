using Uno.Extensions.Storage;

namespace UnoHotDesignApp1.Presentation.Models;

public partial record ListboardModel
{
    #region Services
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IStorage _storage;
    private readonly IGalleryImageService _galleryImageService;
    #endregion

    public ListboardModel(
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        IStorage storage)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        this._storage = storage;
    }

    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(this._galleryImageService.GetGalleryImagesWithoutReswAsync);
    public IState<string> ListboardTitle => State<string>.Value(this, () => _stringLocalizer["ListboardTitle"]);

    #region CodeSample import
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(GetCodeSampleOptionsAsync);

    public async ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ctk)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1), ctk);
        return new List<string>
                {
                    "C# in Model",
                    "DI Service Resw",
                    "DI Service without Resw",
                    "C# Record",
                    "XAML DataTemplate",
                    "FeedView + ListView XAML"
                }.ToImmutableList();
    }
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);
    public async Task SwitchCodeSampleAsync(object? parameter)
    {
        string? codeSample = parameter?.ToString() switch
        {
            "C# in Model" => await _storage.ReadPackageFileAsync("Assets/Samples/ModelBinding-Sample.cs.txt"),
            "DI Service Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-resw.cs.txt"),
            "DI Service without Resw" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageService-noResw.cs.txt"),
            "C# Record" => await _storage.ReadPackageFileAsync("Assets/Samples/GalleryImageModel.cs.txt"),
            "XAML DataTemplate" => await _storage.ReadPackageFileAsync("Assets/Samples/Card-GalleryImage.DataTemplate.xaml.txt"),
            "FeedView + ListView XAML" => await _storage.ReadPackageFileAsync("Assets/Samples/FeedView-ListView-Sample.xaml.txt"),
            _ => string.Empty
        };

        await CurrentCodeSample.SetAsync(codeSample);
    }
    #endregion

    #region ViewHeaderContent
    public IFeed<HeaderContent> ViewHeaderContent => Feed<HeaderContent>
        .Async(async (ct) =>
        {
            await Task.Delay(1, ct);
            return new HeaderContent("Assets/Images/styled_logo.png", _stringLocalizer["ListViewTitle"]);
        });
    #endregion
}



