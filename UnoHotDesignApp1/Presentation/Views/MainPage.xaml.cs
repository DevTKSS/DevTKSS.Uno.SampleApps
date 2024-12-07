

namespace UnoHotDesignApp1.Presentation.Views;

[Bindable]
public sealed partial class MainPage : Page
{
    
    //MainViewModel? ViewModel;
    public MainPage()
    {
        this.InitializeComponent();
        this.DataContext = (MainViewModel)DataContext;
    }

}
