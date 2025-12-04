---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.de
---

# Anleitung: Navigation im Model oder ViewModel

Nun wollen wir uns einmal anschauen, wie wir passend zur Uno Extensions Navigation unsere Verbindung zwischen der `View` und dem `ViewModel`  aufbauen müssen.

Hierfür wollen wir uns natürlich ersteinmal die Frage stellen: **Navigation nur im Xaml - Geht das eigentlich?**

*Ja und Nein.*

Also, dann lass uns das doch mal genauer betrachten. Was bedeutet das denn nun?

- **Ja:**

  Tatsächlich brauchst du grundsätzlich weder Codebehind noch Code im ViewModel / Model für die Navigation, wenn du die `Attached Properties` in dem Xaml deiner Seite nutzt.

  **Wie das geht, erfährst du bei Interesse direkt hier:**

  [Anleitung: Definieren des UI mit NavigationView für ExtensionsNavigation](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de)

  In diesem Fall wären es dann nur zum beispiel die anzuzeigende Eigenschaft, wie die `string`-Property `Title`, die du entsprechend in deiner `Page`, also deiner `View` zum `ViewModel` bzw. `Model` bindest und schon bist du fertig damit!

  > [!TIP]
  > Mit der Attached Property `uen:Navi` kannst du den Titel der Seite in der NavigationView setzen.

- **Nein:**

  1. Du musst weiterhin die Routen, die du Navigieren möchtest in der `App.xaml.cs` Klasse in der `RegisterRoutes` Methode registrieren, damit der `INavigator` auch weiß, was zusammen gehört und von wo du mit welchen "Qualifizierern" welche Routen erlauben möchtest zu navigieren.
  2. Wenn du in deinem Model bzw. ViewModel eine Navigation auslösen möchtest, dann brauchst du den `INavigator` dort natürlich, um die Navigation zu starten.

## Vorraussetzungen schaffen

Gut, also lass uns doch mal davon ausgehen, dass wir genannten zweiten Fall haben und folgendes Tun wollen:

1. Unser Anwender soll mit einem Klick auf einen `Button` eine Funktion in unserem `ViewModel` bzw. `Model` auslösen können
2. Diese Funktion soll ihn zur `SecondPage` navigieren, die wir in der Uno App Vorlage inkludiert hatten, aber es könnte auch jede andere Seite sein, die du selbst erstellt und registriert hast.

    Angenommen das hier ist unsere `App.xaml.cs` mit der `RegisterRoutes` Methode:

    ```csharp
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellModel)),
            new ViewMap<MainPage, MainModel>(),
            new DataViewMap<SecondPage, SecondViewModel, Entity>()
        );

    routes.Register(
        new RouteMap("", View: views.FindByViewModel<ShellModel>(),
        Nested:
            [
                new RouteMap("Main", View: views.FindByViewModel<MainModel>(), IsDefault:true),
                new RouteMap("Second", View: views.FindByViewModel<SecondModel>())
            ]
        )
    );
    }
    ```

Aber wie muss dafür unser `ViewModel` bzw. `Model` aussehen, damit wir das umsetzen können?

Hierfür brauchen wir erstmal folgendes Schritte:

1. [Erstelle ein Model bzw. ViewModel](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.de)

2. [Und hole dir dort den `INavigator` als **`DependencyInjection` Konstruktor Parameter**](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.de)

## Binden der View UI Steuerelemente an Eigenschaften im ViewModel bzw. Model

Nun haben wir zuvor den `Title` der NavigationView manuell festgelegt, aber wie sieht es mit anderen Eigenschaften aus, die wir in der View binden wollen? Und du hast in der Template App vielleicht auch den `Name` gesehen, der in der `Dashboard(View)Model` definiert ist.

Wenn du nicht vom Template startest, füge diese Eigenschaft hinzu, um sie in der View zu binden.

```csharp
public string? Name { get; set; }
```

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

Mit diesem Code ist es dir möglich, die `Name` Eigenschaft in der View zu binden und den `NavigateSecondAsyncCommand` zu verwenden, um zur `SecondViewModel` zu navigieren.

Hierbei kannst du einen Button oder ein anderes Steuerelement in der View verwenden, um die Navigation auszulösen, aber indem du die `IsEnabled` Eigenschaft des Steuerelements an den `CanExecute` Status des Befehls bindest, kannst du die Navigation nur dann ausführen, wenn der Name nicht leer ist.

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

Hier könntest du dann in der View einen Button definieren, der die `NavigateSecondAsync` Methode aufruft, um zur `SecondModel` zu navigieren, sich den `Name` Wert holt und diesen als Daten an die nächste Seite übergibt.
Wenn du jetzt einmal vergleichst, wie das in Mvvm und Mvux aussieht, wirst du feststellen, dass es im Grunde genommen sehr ähnlich ist, aber in Mvux das ganze doch irgendwie übersichtlicher und du weniger "boilerplate" Code benötigt um das selbe zu erreichen.

Und um zum beispiel direkt an den `IState<string> Name` eine TwoWay Bindung in der View zu erstellen, brauchst du nicht einmal eine `PropertyChanged` Benachrichtigung, wie du es in Mvvm tun müsstest, sondern hängst einfach an das `.Value(...)` ein `.ForEach(...)` daran, erstellst eine Methode, die den neuen Wert empfängt und kannst dort direkt damit arbeiten. Kein lästiges Implementieren von `INotifyPropertyChanged` mehr.

Mehr zu diesem Thema findest du hier im [Tutorial: Auf Routen Änderungen reagieren](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-ChangeRoutes.de)

---
