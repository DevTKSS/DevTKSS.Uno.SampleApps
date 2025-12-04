namespace DevTKSS.Uno.XamlNavigationApp.Presentation;

public partial record SecondModel
{
    public SecondModel()
    {
     
    }
    public IState<string> SecondTitle => State<string>.Value(this, () => "Hallo vom Second");
}
