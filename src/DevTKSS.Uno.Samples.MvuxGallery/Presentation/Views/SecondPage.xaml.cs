using Microsoft.UI.Xaml.Data;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.Views;
[Bindable]
public sealed partial class SecondPage : Page
{
    public SecondPage()
    {
        this.InitializeComponent();
        this.DataContext = (SecondViewModel)DataContext;
    }
}

