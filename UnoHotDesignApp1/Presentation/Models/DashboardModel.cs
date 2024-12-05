namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
public partial record DashboardModel
{
    #region "Services"
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;
    #endregion
    public DashboardModel(
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer)
    {
        this._navigator = navigator;
        this._localizationService = localizationService;
        this._stringLocalizer = stringLocalizer;
    }
    
    public IState<string> Title => State<string>.Value(this, () => _stringLocalizer["DashboardTitle"]);

    

}
