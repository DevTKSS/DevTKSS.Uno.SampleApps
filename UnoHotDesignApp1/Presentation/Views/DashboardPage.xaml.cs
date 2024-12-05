namespace UnoHotDesignApp1.Presentation.Views;

[Bindable]
public sealed partial class DashboardPage : Page
{
    public DashboardPage()
    {
        this.InitializeComponent();
        DataContext = (DashboardViewModel)DataContext;
    }
}
