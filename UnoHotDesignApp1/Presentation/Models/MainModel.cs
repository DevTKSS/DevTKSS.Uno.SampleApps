namespace UnoHotDesignApp1.Presentation.Models;
public partial record MainModel
{
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;

    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
    }

    public IState<string> AppTitle => State<string>.Value(this, () => _stringLocalizer["ApplicationName"]);
   
    public IState<bool> MenuPaneOpen => State<bool>.Value(this, () => false);

    //public async Task DoMainNavigation(string RegionName)
    //{
    //    await _navigator.NavigateRouteAsync(this, RegionName, qualifier: Qualifiers.Nested);
    //}
   
    public async Task ToggleMenuVisibility()
    {
        await MenuPaneOpen.SetAsync(await MenuPaneOpen == false ? true : false);
    }
    public async Task ReloadTitle()
    {
        await AppTitle.SetAsync(_stringLocalizer["ApplicationName"]);
    }
}

