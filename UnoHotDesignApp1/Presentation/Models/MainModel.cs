using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
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
        //this.Title.SetAsync($"{stringLocalizer["ApplicationName"]}");
    }

    public IState<string> AppTitle => State<string>.Value(this, () => _stringLocalizer["ApplicationName"]);
   // public IState<string> Name => State<string>.Value(this, () => string.Empty);
    public IState<bool> MenuPaneOpen => State<bool>.Value(this, () => false);
    public async Task GoBack()
    {
        await _navigator.NavigateRouteAsync(this,"Dashboard", qualifier: Qualifiers.Separator);
    }
   

    public async Task ToggleMenuVisibility()
    {
        await MenuPaneOpen.SetAsync(await MenuPaneOpen == false ? true : false);
    }
    
}

