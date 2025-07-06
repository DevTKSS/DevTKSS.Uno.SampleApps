---
uid: DevTKSS.Uno.ExtensionsNavigation.Overview.de
---

# Navigation mit Uno Extensions Navigation

![Mvux XamlNavigationApp](../.attachments/DevTKSS.Uno.XamlNavigationApp.png)

## Inhalt dieses Tutorials

- Ein `NavigationView`-Steuerelement zur Navigation.
- Routen, die in der Datei `App.xaml` definiert sind.
- Eine `MainPage.xaml`, die als Einstiegspunkt für die Navigation dient.
- `DashboardPage` und `SecondPage` als Beispielseiten für die Navigation.
- Jede Seite bindet an einen `IState<string>`-Eigenschaft im zugehörigen Model, um die Zustandsverwaltung gemäß MVUX zu demonstrieren.

Da diese Beispiel-App im Rahmen eines Community-Tutorial-Videos auf YouTube erstellt wurde, kannst du dem Video folgen und den Aufbau der App Schritt für Schritt nachvollziehen. Dort sind auch Transkripte hinzugefügt, da es in Deutscher Sprache aufgenommen wurde.

🔗 [Zur Playlist auf YouTube](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX&si=qHkpAUMSW9s8GZCO)

## Kurzer Showcase

Lass uns zuerst einmal schauen, was man beispielsweise in einer Xaml-basierten Uno Anwendung damit erstellen kann, am beispiel der MvuxGallery.

**Showcase-Video:**

[!Video[Navigation in Xaml und Mvux mit Navigation View (Showcase)](https://youtu.be/vVvnK02r2ug)]

---

## Links zu den Tutorial-Teilen

Im folgenden findest du Schritt für Schritt Anleitungen, mit welchen du lernen kannst, wie man in einer Uno Platform Anwendung eine Navigation mithilfe des Uno Feature `Navigation`, also des `Uno.Extensions.Navigation` NuGet implementieren kann.

## Einrichten der Entwicklungsumgebung

Dieses Tutorial baut darauf auf, dass deine Entwicklungsumgebung bereits vollständig eingerichtet ist und der Befehl `uno-check --tfm net9.0-desktop` ausgeführt in deinem Terminal grünes Licht gibt.

Eine Anleitung und weitere nützliche Links hierzu findest du im [Tutorial: Einrichten der Entwicklungsumgebung](xref:DevTKSS.Uno.Setup.DevelopmentEnvironment.de)

## App erstellt oder konfiguriert

Des hier lernst du, wie man Anwendung erstellt oder passend konfiguriert:

- [Erstellen einer Uno App mit Extensions Navigation](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-CreateApp.de)
- [Upgrade einer existierenden Uno App](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-UpgradeExistingApp.de)

## Die Routen registrieren

- [Tutorial Routen Registrieren](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de)

## Das User Interface mit einer NavigationView erstellen

- [Tutorial: Erstellen des UI mit einer NavigationView in Xaml](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI-NavigationView.de)

## Das Model bzw. ViewModel erstellen

- [Anleitung: Erstellen eines ViewModel oder Model](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.de)

---

## 📺 Tutorial Video: Navigation mit `NavigationView` in MVUX und XAML

In diesem Video zeige ich dir, wie du das `NavigationView`-Steuerelement in einer XAML-Markup-App einrichtest und verwendest. Wir werden die Navigation zwischen verschiedenen Seiten implementieren und dabei die MVUX-Prinzipien anwenden.

[!Video[Navigation in Xaml und Mvux mit Navigation View](https://youtu.be/knt2oOjHH30)]

---

[Hier geht's zum Source Code der verwendeten Beispiel Anwendung XamlNavigationApp](../../../../src/DevTKSS.Uno.XamlNavigationApp-1/)

### Uno Documentation links

- [How-To: Navigate in Xaml](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)
- [How-To: Define Routes](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-DefineRoutes.html)
- [How-To: Regions](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-Regions.html)
- [How-To: Use NavigationView to Switch Views](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-UseNavigationView.html)
- [How-To: IRouteNotifier](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-IRouteNotifier.html)
