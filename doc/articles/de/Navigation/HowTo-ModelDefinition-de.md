---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.de
---

# Anleitung: Navigation im Model oder ViewModel

Nun wollen wir uns einmal anschauen, wie wir passend zur Uno Extensions Navigation unser Model bzw. ViewModel aufbauen müssen.

## Voraussetzungen

1. Erstelle hierfür zu aller erst ein Model bzw. ViewModel Element.

   > [!TIP]
   > Wenn du noch nicht weißt, wie das geht, habe ich hier eine [Anleitung zur Erstellung eines grundlegenden Model bzw. ViewModels](xref:DevTKSS.Uno.Setup.HowTo-AddingNewVmClass.de) vorbereitet.

2. Füge nun noch den `INavigator` als **DependencyInjection** Konstruktor Parameter hinzu.

   > [!TIP]
   > Hierfür kannst du diese [Anleitung: Nutze Konstruktor Parameter für DependencyInjection](xref:DevTKSS.Uno.Setup.AddingNewClass.de) verwenden.

## Navigation im Xaml

Grundsätzlich benötigst du tatsächlich nicht unbedingt einen Navigations-Code im ViewModel / Model, wenn du wie in der [Anleitung: Definieren des UI mit NavigationView für ExtensionsNavigation](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de) die `Attached Properties` nutzt!

In diesem Fall wären es klassischerweise nur dann die Title Eigenschaften oder andere, die du von View zu ViewModel bindest und du wärst fertig. Und genau das ist auch ein großer Vorteil dieser Extension meiner Meinung nach.

### Binden der View UI Steuerelemente an Eigenschaften im ViewModel bzw. Model

### [Mvvm](#tab/mvvm)

```csharp
public partial class DashboardViewModel : ObservableObject
{
    private readonly INavigator _navigator;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NavigateSecondAsyncCommand))]
    private string? name;

    public DashboardViewModel(INavigator navigator)
    {
        _navigator = navigator;
        NavigateSecondAsyncCommand = new AsyncRelayCommand(NavigateSecondAsync);
    }

    public IAsyncRelayCommand NavigateSecondAsyncCommand { get; }

    [RelayCommand(CanExecute = nameof(CanExecuteNavigateSecondAsync))]
    private async Task NavigateSecondAsync()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }

    private bool CanExecuteNavigateSecondAsync()
    {
        return !string.IsNullOrWhiteSpace(Name);
    }
}
```

### [Mvux](#tab/mvux)

```csharp
namespace Mvux.XamlNavigationApp.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public DashboardModel(INavigator navigator)
    {
        _navigator = navigator;
        Title = "Dashboard";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task NavigateSecondAsync()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
```

Mit diesem Code ist es dir möglich, die `Name` Eigenschaft in der View zu binden und den `NavigateSecondAsyncCommand` zu verwenden, um zur `SecondViewModel` zu navigieren.

Hierbei kannst du einen Button oder ein anderes Steuerelement in der View verwenden, um die Navigation auszulösen, aber indem du die `IsEnabled` Eigenschaft des Steuerelements an den `CanExecute` Status des Befehls bindest, kannst du die Navigation nur dann ausführen, wenn der Name nicht leer ist.

---
