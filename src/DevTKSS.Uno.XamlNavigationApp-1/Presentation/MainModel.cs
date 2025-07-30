namespace DevTKSS.Uno.XamlNavigationApp.Presentation;

public partial record MainModel
{
    private readonly INavigator _navigator;
    private readonly IRouteNotifier _routeNotifier;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        IRouteNotifier routeNotifier)
    {
        _navigator = navigator;
        _routeNotifier = routeNotifier;
        _routeNotifier.RouteChanged += Main_OnRouteChanged;
    }

    private async void Main_OnRouteChanged(object? sender, RouteChangedEventArgs e)
    {
        await Title.SetAsync(e.Navigator?.Route?.ToString());
    }

    public IState<string> Title => State<string>.Value(this, () => _navigator.Route?.ToString() ?? string.Empty);

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
