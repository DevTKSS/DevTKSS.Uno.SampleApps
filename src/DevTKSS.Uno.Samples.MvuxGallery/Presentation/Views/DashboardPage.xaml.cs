namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.Views;
public sealed partial class DashboardPage : Page
{
    public DashboardPage()
    {
        this.InitializeComponent();
        this.CodeSampleTabBar.SelectionChanged += (s, e) =>
        {
            if (this.CodeSampleTabBar.SelectedIndex > -1)
            {
                this.CodeSampleExpander.IsExpanded = true;
            }
        };
    }

    private double DevideByTwo(double value)
    {
        return value / 2;
    }
}
