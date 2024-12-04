using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation.Views;

[Bindable]
public sealed partial class CounterPage : Page
{
    public CounterPage()
    {
        this.InitializeComponent();
        DataContext = new CounterViewModel();
    }
}
