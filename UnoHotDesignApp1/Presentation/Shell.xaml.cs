using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation;
[Bindable]
public sealed partial class Shell : UserControl, IContentControlProvider
{
    public Shell()
    {
        this.InitializeComponent();
    }
    public ContentControl ContentControl => Splash;
}
