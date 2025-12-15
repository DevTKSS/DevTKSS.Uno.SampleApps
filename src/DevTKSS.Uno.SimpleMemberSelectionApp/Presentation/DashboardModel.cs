namespace DevTKSS.Uno.SimpleMemberSelectionApp.Presentation;
public partial record DashboardModel
{
    public DashboardModel()
    {

    }
    private async ValueTask<IImmutableList<string>> GetMembers(CancellationToken ct) => _listMembers;
    
    private readonly IImmutableList<string> _listMembers = ImmutableList.Create(
        [
            "Hans",
            "Lisa",
            "Anke",
            "Tom"
        ]);

    public IState<string> DashboardTitle => State<string>.Value(this, () => "Hallo vom Dashboard");

    public IListState<string> DashboardList => ListState.Value(this, () => _listMembers)
                                                        .Selection(SelectedMember);

    public IState<string> SelectedMember => State<string>.Empty(this);
}
