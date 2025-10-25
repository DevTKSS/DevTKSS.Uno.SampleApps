---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de
---

# Anleitung: Registrieren und Verwalten von Routen

Mit der `Uno.Extensions.Navigation` verwenden wir eine zentrale Definition der **Routen Registrierung** in der App Klasse [`App.xaml.cs`(source link)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.XamlNavigationApp-1/App.xaml.cs) gehandhabt, was man sich vereinfacht schlichtweg wie eine Landkarte vorstellen kann.

## Voraussetzungen

Bevor du mit der Routen Registrierung beginnst, brauchst du noch zwei Dinge:

1. Eine oder mehrere Seiten (`View`), die du in deiner App verwenden möchtest.

   - [Neue Seiten Elemente zu deiner Anwendung hinzufügen](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.de)

2. Ein oder mehrere zugehörige `ViewModel` oder `Model`, die du für die Seiten verwenden möchtest. (optional, aber empfohlen)

   - [Neue Klasse oder Record Definitionen für ein ViewModel oder Model hinzufügen](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.de)

## RegisterRoutes Methode

Füge die dafür benötigte Methode wie folgt in deine App Klasse unterhalb der `OnLaunched` Methode ein:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/App.xaml.cs#L82)]

## Definieren der `ViewMap`'s

Hiermit teilen wir dem Navigator mit, welche Seite (`View`) mit welchem (`View`-)`Model` zusammengehört, worin wir Eigenschaften und Funktionen definieren, die die View dort aufrufen kann. Hierfür findest du den Abschnitt `views.Register` bisher in deiner Anwendung, bzw. kannst ihn noch hinzufügen, wenn deine Anwendung ge-upgraded wird.

```csharp
{
    views.Register(
        new ViewMap(ViewModel: typeof(ShellModel)),
        new ViewMap<MainPage, MainModel>(),
        new DataViewMap<SecondPage, SecondViewModel, Entity>()
```

Wenn zusätzliche Daten Objekte bei der Navigation dieser Route erforderlich sind, dann konvertierst du diese als `DataViewMap` beispielsweise so wie in der letzten Zeile.

So sieht das zum Beispiel dann in der XamlNavigationApp aus, wo ich `Entity` nicht mehr benötigt habe und diese Route entsprechend zurück konvertiert habe:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/App.xaml.cs#L83-L89)]

## Hierarchisch aufgebaute `RoutesMap`'s

Nun schauen wir uns an, welche Routen von welchem übergeordneten Element erreichbar sind:

In diesem Beispiel aus einer Mvux nutzenden vom Template erstellten Anwendung, siehst du anhand des `Nested:` Parameter Namen, aber auch anhand der Struktur des Abschnitts, wie eine solche Hierarchie der Routen aussehen kann.

```csharp
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

Nun wollen wir aber auf der `MainPage` vielleicht eine TabBar, NavigationBar, einen Frame innerhalb eines Grid oder auch eine NavigationView mit navigierbarer Inhalt (Content) Eigenschaft verwenden. Dieser Inhalt würde aber vielleicht keinen Sinn auf der `SecondPage` machen. In diesem Fall sollten wir also sicherstellen, dass diese Routen nur dort Verfügbar sein werden.

**Das machen wir beispielsweise so:**

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/App.xaml.cs#L96-L101)]

Hier siehst du, dass ich eine weitere Seite hinzugefügt habe, die `DashboardPage` und ein Model dazu erstellt habe namens `DashboardModel`. Außerdem habe ich die Route `Second` in die `RouteMap` der `Main`-Route verschachtelt.

## Nützliche Informationen

Bei der Benennung macht es immer Sinn, die Routen- und Seiten Element-Namen gleich zu halten. Eine `DashboardPage` würde somit klassisch `Dashboard` als Routen-Namen erhalten.

Wenn du anstelle von **MVVM** das **MVUX** verwendest, solltest du darauf achten, das zur Seite oder `View` zugehörige **Model** nicht fälschlicherweise `DashboardViewModel` für die `DashboardPage` zu nennen, sondern `DashboardModel`, da der Mvux Source Code Generator das für dich erstellte `DashboardViewModel` genau so nennen wird und es sonst zu unerwarteten Problemen kommen kann.

## Anwendung starten

Nun sind wir auch schon fertig mit der Routen Registrierung und können die Anwendung starten. Wenn du nun die App startest, solltest du in der Lage sein, die `MainPage` zu sehen und von dort aus zu den anderen Seiten zu navigieren.
