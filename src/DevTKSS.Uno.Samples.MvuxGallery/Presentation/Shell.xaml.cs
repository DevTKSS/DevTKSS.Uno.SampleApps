using Microsoft.UI.Xaml.Data;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation;
[Bindable]
public sealed partial class Shell : UserControl, IContentControlProvider
{
    public Shell()
    {
        this.InitializeComponent();
    }
    public ContentControl ContentControl => Splash;
}
