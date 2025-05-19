namespace DevTKSS.Uno.XamlNavigationApp.Presentation;
public partial record DashboardModel
{
    public DashboardModel()
    {
        
    }
    public IState<string> DashboardTitle => State<string>.Value(this, () => "Hallo vom Dashboard");
}
