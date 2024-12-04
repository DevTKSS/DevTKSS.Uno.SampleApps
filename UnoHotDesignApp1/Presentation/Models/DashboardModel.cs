namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
public partial record DashboardModel
{
    public DashboardModel()
    {
        Title = "Welcome to your Dashboard!";
    }
    public string? Title { get; }
}
