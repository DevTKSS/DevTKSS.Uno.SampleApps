using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Uno.Extensions.Reactive;

namespace UnoHotDesignApp1.Presentation.Models;

public partial record DashboardModel
{
    #region Services
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IGalleryImageService _galleryImageService;
    private readonly IStorage _storage;
    private readonly ILogger _logger;
    #endregion

    public DashboardModel(
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService,
        IStorage storage,
        ILogger<DashboardModel> logger)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
        this._storage = storage;
        this._logger = logger;
    }

    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(_galleryImageService.GetGalleryImagesWithoutReswAsync);
    public IListFeed<GalleryImageModel> GalleryImagesWithResw => ListFeed.Async(_galleryImageService.GetGalleryImagesWithReswAsync);
    

    public IState<string> DashboardTitle => State<string>.Value(this, () => _stringLocalizer["DashboardTitle"]);

    #region CodeSample import
    private readonly IImmutableList<string> _sampleOptions =
                        new string[]
                        {
                            "FeedView + GridView XAML",
                            "C# in Model",
                            "DI Service Resw",
                            "DI Service without Resw",
                            "C# Record",
                            "XAML DataTemplate"
                        }
                        .ToImmutableArray();
    public IListFeed<string> CodeSampleOptions => ListFeed.Async(
        static async (ct) =>
        {
            await Task.Delay(1, ct);
            return ImmutableList<string>.Empty.AddRange(new[]
            {
                "FeedView + GridView XAML",
                "C# in Model",
                "DI Service Resw",
                "DI Service without Resw",
                "C# Record",
                "XAML DataTemplate"
            });
        })
        .Selection(SelectedOption);
    public IState<string> SelectedOption => State<string>.Value(this, () => "FeedView + GridView XAML")
                                                         .ForEach(SwitchCodeSampleAsync);
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);
                                                           // .ForEach(SwitchCodeSampleAsync);

    public async ValueTask SwitchCodeSampleAsync(string? choice, CancellationToken ct = default)
        {
        //  var choice = await CodeSampleOptions.GetSelectedItem(ct);
        Console.WriteLine("SwitchCodeSampleAsync called with parameter: {0}", choice);
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
            },ct);
        }

  //public async ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ctk)
    //{
    //    await Task.Delay(TimeSpan.FromMilliseconds(1), ctk);
    //    return new List<string>
    //            {
    //                "C# in Model",
    //                "DI Service Resw",
    //                "DI Service without Resw",
    //                "C# Record",
    //                "XAML DataTemplate",
    //                "FeedView + GridView XAML"
    //            }.ToImmutableList();
    //}
  
    #endregion

 
    #region ViewHeaderContent
    public IFeed<HeaderContent> ViewHeaderContent => Feed.Async(GetGridViewHeaderAsync);
    public async ValueTask<HeaderContent> GetGridViewHeaderAsync(CancellationToken ctk)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1), ctk);
        var headerContent = new HeaderContent("Assets/Images/styled_logo.png", _stringLocalizer["GridViewTitle"]);
        return headerContent;
    }
    #endregion
}



