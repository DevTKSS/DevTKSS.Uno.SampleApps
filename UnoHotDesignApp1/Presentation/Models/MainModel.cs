using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
public partial record MainModel
{
    private INavigator _navigator;
    private ILocalizationService _localizer;
    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        ILocalizationService localizer)
    {
        _navigator = navigator;
        _localizer = localizer;
        Title = $"Welcome to my Uno Platform Hot Design Application! \n You are running in {appInfo?.Value?.Environment} Environment";
    }

    public string? Title { get; }
    public IState<string> Name => State<string>.Value(this, () => string.Empty);
    //public IState<Page> CurrentPage;
    public async Task GoBack()
    {
        await _navigator.NavigateRouteAsync(this,"Dashboard", qualifier: Qualifiers.Separator);
    }
   // public async Task ChangeCulture(string culture)
   // {
        //await _localizer.SetCurrentCultureAsync(newCulture: );
   // }
}

