namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
public partial record DashboardModel
{
    #region Services
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly ICardService _cardService;
    private readonly IGalleryImageService _galleryImageService;
    #endregion

    public DashboardModel(
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer,
        ICardService cardService,
        IGalleryImageService galleryImageService)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
        this._cardService = cardService;
        this._galleryImageService = galleryImageService;

    }
    
    public IListFeed<GalleryImageModel> GalleryImages => ListFeed.Async(this._galleryImageService.GetGalleryImagesAsync);
    public IListFeed<CardModel> Cards => ListFeed<CardModel>.Async(this._cardService.GetCardsAsync);
    public IState<string> DashboardTitle => State<string>.Value(this, () => _stringLocalizer["DashboardTitle"]);

    public async Task ReloadDashboardTitle()
    {
        await DashboardTitle.SetAsync(_stringLocalizer["DashboardTitle"]);
    }

}



