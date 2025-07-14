using Microsoft.UI.Xaml.Data;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.Views;

public sealed partial class CounterPage : Page
{
    public CounterPage()
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
