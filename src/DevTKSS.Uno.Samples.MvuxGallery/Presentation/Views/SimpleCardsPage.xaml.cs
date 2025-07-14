namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SimpleCardsPage : Page
{
    public SimpleCardsPage()
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
}
