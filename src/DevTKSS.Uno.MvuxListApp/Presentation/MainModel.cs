using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.MvuxListApp.Presentation;

public partial record MainModel
{
    private readonly ILogger _logger;
    private readonly INavigator _navigator;
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
    private async void Main_OnRouteChanged(object? sender, RouteChangedEventArgs e)
    {
        await Title.SetAsync(e.Navigator?.Route?.ToString());
    }

    #region MembersView-Value
    private readonly IImmutableList<string> _listMembers = ImmutableList.Create(
        [
            "Hans",
            "Lisa",
            "Anke",
            "Tom"
        ]);

    private async ValueTask<IImmutableList<string>> GetMembersAsync(CancellationToken ct)
        => _listMembers;

    public IListState<string> Members => ListState<string>.Async(this, GetMembersAsync)
                                                          .Selection(SelectedMember);

    public IState<string> SelectedMember => State<string>.Value(this, () => string.Empty);
    #endregion
    #region MembersView-Update
    public IState<string> ModifiedMemberName => State<string>.Empty(this);

    public async ValueTask RenameMemberAsync(
        [FeedParameter(nameof(ModifiedMemberName))] string? modName,
        [FeedParameter(nameof(SelectedMember))] string? replaceMember,
        CancellationToken ct)
    {

        _logger.LogInformation("Modified MemberName ist: {modifiedName}", modName);
        _logger.LogInformation("SelectedMember ist: {selectedMember}", replaceMember);
        if (string.IsNullOrWhiteSpace(modName))
            return;

        await Members.UpdateAllAsync(
            match: item => item == replaceMember,
            updater: _ => modName,
            ct: ct
        );

       // await Members.TrySelectAsync(modName, ct);
    }
    #endregion
}
