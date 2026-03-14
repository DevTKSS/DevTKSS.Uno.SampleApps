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

    /// <summary>
    /// Prefer using Statefull Properties, if your really expect changes to happen, which you want the UI/View Layer to become updated with.<br/>
    /// This Example without us expecting any changes, would not make sense in real-world Applications,<br/>
    /// instead you could connect the lamda function to be fed by a <see cref="IStringLocalizer" /> and rely on always current Title for your Dashboard.
    /// </summary>
    public IState<string> DashboardTitle => State<string>.Value(this, () => "Hallo vom Dashboard");

    /// <summary>
    /// Use the <c>.Async</c>-Operator, whenever you need asyncronous initialization, like if your App needs to request its Value from an external API.<br/>
    /// The <c>.Selection(ListState<T>)</c>-Operator will get called everytime, either the User selects a displayed Item in the View or if you call the <c>ListState<T>.TrySelectAsync(T,CancellationToken)</c> in the Model itself and provide the value to the given recipient <see cref="State<T>" />.
    /// </summary>
    public IListState<string> Members => ListState.Async(this, GetMembers)
                                                   .Selection(AsyncSelectedMember);

    /// <summary>
    /// Use the <c>.Value</c>-Operator, whenever you load data from <see cref="IOptions<{T}>" /> or a static Collection like we do here, for synchronous Initialization of the Value.
    /// The <c>.Selection(ListState<T>)</c>-Operator will get called everytime, either the User selects a displayed Item in the View or if you call the <c>ListState<T>.TrySelectAsync(T,CancellationToken)</c> in the Model itself and provide the value to the given recipient <see cref="State<T>" />.
    /// </summary>
    public IListState<string> AsyncMembers => ListState.Value(this, () => _listMembers)
                                                        .Selection(SelectedMember);


    public IState<string> SelectedMember => State<string>.Empty(this);
    
    public IState<string> AsyncSelectedMember => State<string>.Empty(this);
}
