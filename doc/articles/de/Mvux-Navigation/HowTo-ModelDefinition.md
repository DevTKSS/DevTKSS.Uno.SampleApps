---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel
---

# Anleitung: Navigation im Model oder ViewModel

Nun wollen wir uns einmal anschauen, wie wir passend zur Uno Extensions Navigation unser Model bzw. ViewModel aufbauen müssen.

## Voraussetzungen

1. Erstelle hierfür zu aller erst ein Model bzw. ViewModel Element.

   > [!TIP]
   > Wenn du noch nicht weißt, wie das geht, habe ich hier eine [Anleitung zur Erstellung eines grundlegenden Model bzw. ViewModels](../HowTo-Adding-New-VM-Class.md) vorbereitet.

2. Füge nun noch den `INavigator` als **DependencyInjection** Konstruktor Parameter hinzu.

   > [!TIP]
   > Hierfür kannst du diese [Anleitung: Nutze Konstruktor Parameter für DependencyInjection](../HowTo-Using-DI-in-ctor.md) verwenden.

## Navigation im Xaml

Grundsätzlich benötigst du tatsächlich nicht unbedingt einen Navigations-Code im ViewModel / Model, wenn du wie in der [Anleitung: Definieren des UI mit NavigationView für ExtensionsNavigation](./HowTo-Defining-UI-NavigationView.md) die `Attached Properties` nutzt!

In diesem Fall wären es klassischerweise nur dann die Title Eigenschaften oder andere, die du von View zu ViewModel bindest und du wärest fertig. Und genau das ist auch ein großer Vorteil dieser Extension meiner Meinung nach.

### Szenarien für komplexe Navigation mittels ViewModel oder Model

Werden die Navigations-Anfragen jedoch komplexer, macht es durchaus Sinn, das ViewModel bzw. Model mit `INavigator` Instanz zu nutzen.

Szenarien wären bzw. wenn im xaml `uen:Navigation.Request` oder `uen:Navigation.Data` verwendet werden und oder es weiterer Logik bedarf um vom ausgewählten Element, ggf. noch Daten zu sammeln und dann erst die finale Navigation anzustoßen.

## Navigation zwischen (View-)Models

Um dir einmal einen Vergleich zu geben, was die Verwendung von **Mvux** im Gegensatz zu **Mvvm** im Thema Boilerplate Code ausmacht, findest du im folgenden Beispiel eine Navigationsroutine, welche so durchaus realistisch implementiert wäre:

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

---
