using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation.Views;

[Bindable]
public sealed partial class CounterPage : Page
{
    // MainViewModel ViewModel => (MainViewModel)DataContext;
    public CounterPage()
    {
        this.InitializeComponent();
        this.DataContext = (CounterViewModel)DataContext;
    }
}
