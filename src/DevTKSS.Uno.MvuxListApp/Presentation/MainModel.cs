using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.MvuxListApp.Presentation;

public partial record MainModel
{
    private readonly ILogger _logger;
    private INavigator _navigator;
    private readonly IRouteNotifier _routeNotifier;
    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        IRouteNotifier routeNotifier,
        ILogger<MainModel> logger)
    {
        _navigator = navigator;
        _routeNotifier = routeNotifier;
        _routeNotifier.RouteChanged += Main_OnRouteChanged;
        _logger = logger;
    }



    public IState<string> Title => State<string>.Value(this, () => _navigator.Route?.ToString() ?? string.Empty);

    private async ValueTask<IImmutableList<string>> GetMembersAsync(CancellationToken ct)
        => _listMembers;

    private readonly IImmutableList<string> _listMembers = ImmutableList.Create(
        [
            "Hans",
            "Lisa",
            "Anke",
            "Tom"
        ]);
    private async void Main_OnRouteChanged(object? sender, RouteChangedEventArgs e)
    {
        await Title.SetAsync(e.Navigator?.Route?.ToString());
    }

    public IListState<string> DashboardList => ListState<string>.Async(this,GetMembersAsync)
                                                      .Selection(SelectedMember);

    public IState<string> SelectedMember => State<string>.Value(this,() => string.Empty);

    public IState<string> ModifiedMemberName => State<string>.Empty(this)
                                                             .ForEach(RenameMemberAsync);
    
    public async ValueTask RenameMemberAsync([FeedParameter(nameof(ModifiedMemberName))]string? modifiedName, CancellationToken ct)
    {
        
        string replaceMeItem = await SelectedMember ?? string.Empty;
        string modifiedItem = await ModifiedMemberName ?? string.Empty;
        _logger.LogInformation("Modified MemberName ist: {modifiedItem}", modifiedItem);
        _logger.LogInformation("SelectedMemeber ist: {selectedMember}", replaceMeItem);

        await DashboardList.RemoveAllAsync(item => item == replaceMeItem);

        await DashboardList.AddAsync(modifiedItem,ct);

        await DashboardList.TrySelectAsync(modifiedItem,ct);
    }
}
