namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.Views;

public sealed partial class ListboardPage : Page
{
    public ListboardPage()
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
