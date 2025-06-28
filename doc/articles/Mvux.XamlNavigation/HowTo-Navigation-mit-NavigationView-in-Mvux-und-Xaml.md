---
uid: DevTKSS.Mvux.XamlNavigation.HowTo-Navigation-mit-NavigationView-in-Mvux-und-Xaml
---

# How To: Navigation mit einer `NavigationView` in einer XAML-Markup + MVUX Präsentation Uno Platform App

Dieses Beispiel zeigt, wie man das `NavigationView`-Steuerelement verwendet, um zwischen Seiten in einer XAML-Markup- + MVUX-Präsentations-App zu navigieren. Die App ist so strukturiert, dass sie eine einfache Navigation ermöglicht und das MVUX-Muster demonstriert – mit Fokus auf Kürze und Einfachheit.

**Das Beispiel enthält:**

- Ein `NavigationView`-Steuerelement zur Navigation.  
- Routen, die in der Datei `App.xaml` definiert sind.  
- Eine `MainPage.xaml`, die als Einstiegspunkt für die Navigation dient.  
- `DashboardPage` und `SecondPage` als Beispielseiten für die Navigation.  
- Jede Seite bindet an einen `IState<string>`-Eigenschaft im zugehörigen Model, um die Zustandsverwaltung gemäß MVUX zu demonstrieren.

Da diese Beispiel-App im Rahmen eines Community-Tutorial-Videos auf YouTube erstellt wurde, kannst du dem Video folgen und den Aufbau der App Schritt für Schritt nachvollziehen.

🔗 [Zur Playlist auf YouTube](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX&si=qHkpAUMSW9s8GZCO)

Showcase-Video: [!Video [Navigation in Xaml und Mvux mit Navigation View (Showcase)](https://youtu.be/vVvnK02r2ug)]

---

## 🧰 Voraussetzungen

- Visual Studio 2022 oder neuer mit installierter Uno Platform-Erweiterung  
- Der Befehl `uno-check --tfm net9.0-desktop` im Terminal muss alle relevanten Prüfungen bestehen

- 📚 Weitere Informationen: [Uno Platform Dokumentation](https://platform.uno/docs/articles/external/uno.check/doc/using-uno-check.html)

### 📺 Videoanleitung

[!Video [How To: Einrichten unserer Uno Platform Entwicklungsumgebung](https://youtu.be/oI6IZVOeQBI)]

---

## [⚙️ App-Konfiguration mit dem Visual Studio-Wizard](#tab/vs-wizard)

1. Erstelle eine neue Uno Platform App:

   1. Wähle die Vorlage **`recommended`**
   1. Ziel-Framework: **`net9.0`**
   1. Markup: **`Xaml`**
   1. Präsentation: **`MVUX`**
   1. Erweiterungen: **`Regions`**, **`Dependency Injection`**
   1. *Optional: `Toolkit`, `Localization`, `Configuration`*

2. Klicke auf **`Create`**, um die App zu generieren.

### 📺 Video Tutorial zur Konfiguration

[!Video [How To: Konfigurieren unserer Uno App Visual Studio Wizard](https://youtu.be/UGKidrvdKpQ)]

---

## [🖥️ App-Konfiguration über die CLI](#tab/cli)

1. Öffne ein Terminal und navigiere in das gewünschte Verzeichnis.  
2. Führe folgenden Befehl aus, um eine neue App zu erstellen:

  ```bash
  dotnet new unoapp -o UnoApp2 -preset "recommended" -platforms "desktop" -config False -http "none" -loc False -dsp False -theme-service False
  ```

---

## 📺 Tutorial Video: Navigation mit `NavigationView` in MVUX und XAML

Jetzt kann es auch schon loslegen mit der Navigation in deiner App! In diesem Video zeige ich dir, wie du das `NavigationView`-Steuerelement in einer XAML-Markup + MVUX-App einrichtest und verwendest. Wir werden die Navigation zwischen verschiedenen Seiten implementieren und dabei die MVUX-Prinzipien anwenden.

[!Video [Navigation in Xaml und Mvux mit Navigation View](https://youtu.be/knt2oOjHH30)]

[Hier geht's zum Source Code](../../../src/DevTKSS.Uno.XamlNavigationApp-1/)

## Weitere interessante Informationen

### Uno Documentation links

- [How-To: Navigate in Xaml](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)
- [How-To: Define Routes](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-DefineRoutes.html)
- [How-To: Regions](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-Regions.html)
- [How-To: Use NavigationView to Switch Views](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-UseNavigationView.html)
- [How-To: IRouteNotifier](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-IRouteNotifier.html) (*möglicherweise fehlerhaft aktuell*)
