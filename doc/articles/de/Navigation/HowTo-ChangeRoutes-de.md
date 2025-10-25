---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-ChangeRoutes.de
---

# Anleitung: Reagieren auf Routen Änderungen

Wenn wir nun Routen in unserer Anwendung registriert haben, möchten wir vielleicht auch auf Änderungen der Route reagieren, um beispielsweise bestimmte Aktionen auszuführen oder Daten zu laden.

Dafür können wir den `IRouteNotifier` nutzen, um uns über Änderungen der aktuellen Route zu informieren. Dieser enthält das Ereignis `RouteChanged`, das ausgelöst wird, wenn sich die Route ändert. Im folgenden Beispiel werde ich dir zeigen, wie du dies in deiner Anwendung implementieren kannst.

## Voraussetzungen

Bevor du mit der Implementierung beginnst, benötigst du zum einen natürlich das Uno Feature "Navigation" in deiner Anwendung, also die `Uno.Extensions.Navigation` Bibliothek, zum anderen aber auch eine oder mehrere [Routen registriert](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de) haben und eine ViewModel oder Model Klasse mit zugehöriger Seite, also View erzeugt haben und dort navigieren können. Der Einfachheit halber werde ich davon ausgehen, dass du hierfür die folgenden drei Tutorials bereits erfolgreich absolviert hast:

- [Tutorial: Erstellen des UI mit einer `NavigationView` in Xaml](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de)
- [Tutorial: Routen in der App registrieren](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de)
- [Tutorial: Anleitung: Navigation im Model oder ViewModel](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.de)

## Tutorial Video: Reagieren auf Routen Änderungen

In diesem Video werden wir uns zusammen anschauen, wie du auf Routen Änderungen in deiner Anwendung reagieren kannst, indem du den `IRouteNotifier` verwendest. Wir werden sehen, wie du das Ereignis `RouteChanged` abonnierst und darauf reagierst. Den Code kannst du dabei direkt aus dem Code hierunter kopieren und in deine Anwendung einfügen, wenn du möchtest, aber aus eigener Erfahrung heraus hilft es dir mehr, den Code selber zu schreiben und dabei zuzuschauen, wie es funktioniert. So kannst du auch besser verstehen, was du tust und warum.

![Reagieren-auf-Routen-aenderungen-mit-IRouteNotifier](https://www.youtube.com/embed/RZ3RirA7jhk)

## IRouteNotifier im Model Konstruktor anfordern

Um den `IRouteNotifier` in deinem Model oder ViewModel zu verwenden, musst du ihn als Abhängigkeit im Konstruktor anfordern. Hier ist ein Beispiel, wie du dies in einem ViewModel machen kannst:

```csharp
public partial record MainModel
{
    private readonly IRouteNotifier _routeNotifier;

    public MainModel(IRouteNotifier routeNotifier)
    {
        _routeNotifier = routeNotifier;
        _routeNotifier.RouteChanged += OnRouteChanged;
    }

    private void OnRouteChanged(object sender, RouteChangedEventArgs e)
    {
        // Hier kannst du später auf die Routenänderung reagieren
    }
}
```

> [!IMPORTANT]
> Am verlässlichsten aus meiner Erfahrung funktioniert es, wenn wir das Ereignis in eine eigene Methode auslagern, also nicht als Lambda Ausdruck im Konstruktor registrieren. Eigentlich sollte zwar das selbe passieren, aber ich hatte öfters das Problem, dass die Methode nicht aufgerufen wurde, wenn ich es als Lambda Ausdruck geschrieben habe.

## Verknüpfen des Routen Namens mit einem `IState<string>` im Model

Um den aktuellen Routen Namen in deinem Model oder ViewModel zu speichern und darauf zuzugreifen, kannst du ein `IState<string>` verwenden. Hier ist ein Beispiel, wie du dies implementieren kannst:

```csharp
public IState<string> Title => State<string>.Value(this, () => "Dashboard");
```

Nun ist der aktuelle Inhalt natürlich hardcoded. Was wenn wir uns aber zwischendurch doch mal umentscheiden und die Seite umbenennen? Und wollen wir denn überhaupt dass der Titel, in dem Fall unser Routen Name gerade, abhängig davon ist, wie unser Model heißt? Gehen wir mal davon aus, dass dem nicht so ist.

1. Wollen wir also nun als initialen Wert erstmal den aktuellen Routen Namen verwenden ohne den Namen hart zu codieren, brauchen wir erstmal einen `INavigator`, falls wir den noch nicht zuvor angefordert haben:

    ```diff
    public partial record MainModel
    {
        private readonly IRouteNotifier _routeNotifier;
    +   private readonly INavigator _navigator;

        public MainModel(
            IRouteNotifier routeNotifier,
    +       INavigator navigator)
        {
            _routeNotifier = routeNotifier;
            _routeNotifier.RouteChanged += Main_OnRouteChanged;
    +       _navigator = navigator;
        }
    }
    ```

2. Und danach können wir dann hiermit auch direkt unsere aktuelle Route abfragen, auf der wir uns befinden:

    ```csharp
    public IState<string> Title => State<string>.Value(this, () => _navigator.Route?.ToString() ?? string.Empty);
    ```

    **Was passiert hier?**
    Was wir effektiv nun geändert haben, ist dass wir nun:
    1. Von unserem Navigator die Eigenschaft `Route` abfragen, die uns das aktuelle `Route`-Objekt oder (laut Compiler) möglicherweise auch `null` zurückgibt.
    2. Der `Route`-Type hat eine Überschreibung der `ToString()` Methode, welche uns bei Abfrage dann den Routen-Namen als `string` zurückgibt.
    3. Falls dieser Wert selber oder eben infolge von einem `null` Wert der `Route` Eigenschaft `null` sein sollte, geben wir stattdessen einen leeren String zurück mittels des Null-Koaleszenz Operators `??`.

Und somit haben wir auch schon unseren aktuellen Routen Namen griffbereit hinterlegt in unserem Model im `Title`.

Dort im Model selber bringt unserem User das aber natürlich erstmal nichts, also müssen wir das Ganze ja auch noch irgendwie in der UI anzeigen. Erinnerst du dich noch daran, dass ich im [Tutorial: Erstellen des UI mit einer `NavigationView` in Xaml](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de) gezeigt habe, wie du den Header der `NavigationView` an eine Eigenschaft im Model binden kannst? Zufälligerweise hieß diese Eigenschaft genau `Title`. Perfekt!

Solltest du das noch nicht gemacht haben, dann geht das jetzt ganz einfach auch noch nachträglich:

```diff
<NavigationView uen:Region.Attached="True"
+               Header="{Binding Title}"
                IsPaneToggleButtonVisible="True"
                PaneDisplayMode="Auto">
<NavigationView.MenuItems>
    <NavigationViewItem Content="Home"
                        uen:Region.Name="Dashboard"
                        Icon="Home" />
    <NavigationViewItem Content="Some View"
                        uen:Region.Name="Second"
                        Icon="AddFriend" />
</NavigationView.MenuItems>
        <NavigationView.Content>
            <Grid uen:Region.Attached="True" />
        </NavigationView.Content>
</NavigationView>
```

## Reagieren auf Routen Änderungen

Nun fehlt nur noch die eigentliche Reaktion auf die Routen Änderung. Das machen wir in der Methode `OnRouteChanged`, die wir zuvor im Konstruktor registriert haben. Hier ist ein Beispiel, wie du dies implementieren kannst:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/Presentation/MainModel.cs#L19-L22)]

**Was passiert hier?**

1. Ein `IState<T>` hat die Methode `SetAsync`, mit der wir den Wert des States ändern können. Diese ist asynchron, daher verwenden wir das `await` Schlüsselwort davor.
2. In den RouteChangedEventArgs `e` erhalten wir den `Navigator`, der wie schon zuvor beim [Verknüpfen des Routen Namens](#verknüpfen-des-routen-namens-mit-einem-istatestring-im-model) in der Überladung der `Route.ToString()` Methode den aktuellen Routen Namen als `string` zurückgibt.
3. Diesen übergeben wir dann direkt an die `SetAsync` Methode und lassen das Mvux für uns die Aktualisierung des States und somit auch der UI übernehmen.

> [!TIP]
> Ist dir aufgefallen, dass wir hier beim EventHandler `OnRouteChanged` `async void` verwenden mussten? Das liegt daran, dass EventHandler immer `void` zurückgeben müssen. In solchen Fällen ist es üblich, `async void` zu verwenden, um asynchrone Operationen durchzuführen. Allerdings solltest du `async void` nur in solchen Fällen mit EventHandlern verwenden und sonst immer `async Task` oder `ValueTask` bevorzugen, um eine bessere Fehlerbehandlung und Kontrolle über asynchrone Operationen zu haben. Ohne das `async` Schlüsselwort könnten wir das `await` nicht verwenden, was uns hier aber zwingend notwendig ist, um die asynchrone Methode `SetAsync` aufzurufen ohne vom Compiler wiederum die Meldung zu bekommen, dass wir `await` nutzen sollten.

## Anwendung starten

Nun sind wir auch schon fertig mit dem erstellen unseres Codes und können die Anwendung einfach mal starten.

Wenn du nun in der NavigationView auf einen anderen Menüpunkt klickst und korrekt zuvor die Routen registriert hast, solltest du sehen, dass sich der Text im Header der NavigationView entsprechend ändert und den aktuellen Routen Namen anzeigt.

Glückwunsch! Du hast erfolgreich gelernt, wie du auf Routen Änderungen in deiner Anwendung reagieren kannst, indem du den `IRouteNotifier` verwendest und den aktuellen Routen Namen in deinem Model speicherst.

**Hier nochmal der komplette Code, den du in deinem Model von diesem Tutorial haben solltest:**

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/Presentation/MainModel.cs#L3-L25)]

## Links zur Uno Documentation

- [IRouteNotifier Documentation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-IRouteNotifier.html)
