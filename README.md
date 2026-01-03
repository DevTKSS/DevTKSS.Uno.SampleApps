# DevTKSS Uno Samples

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-online-green.svg)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/)
[![Uno.Sdk](https://img.shields.io/badge/Uno.Sdk-6.3.28+-purple.svg)](https://platform.uno/)

| **Über dieses Repository** | **About This Repository** |
| --- | --- |
| Diese Sammlung von Beispiel-Apps und Tutorials für die [Uno Platform](https://platform.uno/) richtet sich an Entwickler jeder Erfahrungsstufe. Sie ergänzt die offizielle Dokumentation mit zusätzlichen Erklärungsschritten und präziseren Details – besonders für deutschsprachige Anfänger. Als aktiver Contributor zu Uno Platform erstelle ich diese Tutorials als ergänzende Perspektive zur kontinuierlich verbesserten offiziellen Dokumentation. | This collection of sample apps and tutorials for the [Uno Platform](https://platform.uno/) is designed for developers of all skill levels. It complements the official documentation with additional explanations and precise details – particularly for German-speaking beginners. As an active contributor to Uno Platform, I create these tutorials as a complementary perspective to the continuously improving official documentation. |
| **Schnellzugriffe** | **Quick Links** |
| - [Einrichten der Entwicklungs Umgebung](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/de/HowTo-Setup-DevelopmentEnvironment-de.html) | - [Setup the Development Environment](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/en/HowTo-Setup-DevelopmentEnvironment-en.html) |
| - [Dokumentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/index.html?lang=de) | - [Documentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/) |
| - [Diskussionen](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions) | - [Discussions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions) |
<!--markdownlint-disable MD028 -->
> [!NOTE]
> **Deutsch:** Dieses Repository wird nach bestem Wissen und Gewissen gepflegt, ist aber nicht garantiert zu 100% aktuell und kann wie alle Projekte natürlich Fehler enthalten. Die offizielle [Uno Platform Dokumentation](https://platform.uno/docs/) ist immer einen Blick wert, da dort ein größeres Team die Inhalte kontinuierlich aktualisiert. Ich trage selbst zu Uno Platform als Open Source Projekt bei und schätze die kontinuierliche Verbesserung der Features und der offiziellen Dokumentation sehr.

> [!NOTE]
> **English:** This repository is maintained to the best of my knowledge and effort, but it is not guaranteed to be fully up to date and may contain errors like any project. The official [Uno Platform documentation](https://platform.uno/docs/) is always worth checking—there is a larger team keeping it continuously updated. I contribute to Uno Platform as an open source project and appreciate the ongoing improvements to the features and the official documentation.

## Video Tutorials

[YouTube Playlist](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX)

> [!NOTE]
> Video tutorials are currently available in German only. You can enable auto-generated English subtitles on YouTube.

## Beispiel-Apps / Sample Applications

### Mvux Gallery

![Mvux Gallery Showcase Thumbnail](https://raw.githubusercontent.com/DevTKSS/DevTKSS.Uno.SampleApps/master/docs/articles/.attachments/DevTKSS%20Uno%20Mvux%20Samples%20Gallery%20App-Thumbnail.png)

![Mvux Gallery ShowCase](https://raw.githubusercontent.com/DevTKSS/DevTKSS.Uno.SampleApps/master/docs/articles/.attachments/MvuxGallery-ShowCase.gif)

*Erlebe die Mvux Gallery in Aktion* / *Experience the Mvux Gallery in Action*

| Übersicht | Overview |
| --- | --- |
| Die [Mvux Gallery](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.Samples.MvuxGallery/) demonstriert moderne Uno Platform Entwicklungsmuster mit einer umfassenden Beispielanwendung. | The [Mvux Gallery](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.Samples.MvuxGallery/) demonstrates modern Uno Platform development patterns with a comprehensive example application. |
| [Übersicht Mvux Gallery in der Dokumentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/de/MvuxGallery-Overview-de.html) | [Overview Mvux Gallery in the Documentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/en/MvuxGallery-Overview-en.html) |

## Controls / Steuerelemente

| Control/Steuerelement | Beschreibung | Description |
| --- | --- | --- |
| **FeedView** | Mit GridView und ListView für reaktive Datenbindung | Combined with GridView and ListView for reactive data binding |
| **DataTemplate** | Zentrale Ressourcendefinitionen für wiederverwendbare UI-Strukturen | Centralized resource definitions for reusable UI structures |
| **Card, Grid, NavigationView** | Layout und Container Controls für strukturierte Oberflächen | Layout and container controls for structured interfaces |
| **ItemOverlayTemplate** | Repliziert aus WinUI 3 Gallery für Overlay-Effekte | Replicated from WinUI 3 Gallery for overlay effects |
| **TabBar & TabBarItem** | Tab-basierte Navigation mit Uno.Toolkit | Tab-based navigation with Uno.Toolkit |

## Verwendete Uno Extensions / Used Uno Extensions

| Uno.Extensions ID | |
| --- | --- |
| [MVUX](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html) | - Reactive pattern<br>- `IState`, `IFeed`, `ListFeed`<br>- Automatic UI updates |
| [Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html) | - Declarative routing via C#/XAML<br>- `INavigator` with DI and UI-Codebehind integration<br> - Regions, Dialogs, Flyouts<br>- `IRouteNotifier` |
| [Hosting](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Hosting/HostingOverview.html) | - `IHostBuilder` pattern<br>- Dependency Injection<br>- App lifecycle management |
| [Dependency Injection (In UnoFeature "Hosting")](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/DependencyInjection/DependencyInjectionOverview.html) | - Constructor injection<br>- Service registration<br>- `IServiceProvider` |
| [Configuration](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Configuration/ConfigurationOverview.html) | - `IOptions<T>` pattern<br>- `IWriteableOptions`<br>- `appsettings.json` support |
| [Serialization](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Serialization/SerializationOverview.html) | - Source-generated JSON serialization<br>- `JsonSerializerContext`<br>- High performance |
| [Storage](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Storage/StorageOverview.html) | - Key-value storage<br>- File-based persistence<br>- Cross-platform |
| [Localization](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Localization/LocalizationOverview.html) | - Resource-based<br>- `UseLocalization()`<br>- Culture-specific formatting |

---

### Xaml Navigation App

![Image of final Xaml Navigation App](https://raw.githubusercontent.com/DevTKSS/DevTKSS.Uno.SampleApps/master/docs/articles/.attachments/DevTKSS.Uno.XamlNavigationApp.png)

| | |
| --- | --- |
| Die `XamlNavigationApp` ist die erste Tutorial-Anwendung, die du während der YouTube Tutorial Serie kennen lernen kannst.<br>Hierin erkläre ich, wie du eine minimalistische Xaml Markup basierte Navigation mit einer [NavigationView](https://learn.microsoft.com/en-us/windows/apps/develop/ui/controls/navigationview) als Navigations Steuerelement, welches in seiner `Content`-Eigenschaft die verschiedenen Seiten anzeigt.<br>Hierfür werden wir als Navigations Framework [Uno.Extensions.Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html) in einer [MVUX](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html) Uno App verwenden. | The `XamlNavigationApp` is the first tutorial application you'll learn about in the YouTube tutorial series.<br>I explain how to set up minimalist XAML markup-based navigation using a [NavigationView](https://learn.microsoft.com/en-us/windows/apps/develop/ui/controls/navigationview) as the navigation control, which displays different pages in its `Content` property.<br>The Navigation Framework we will choose for this, is [Uno.Extensions.Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html) used in a [MVUX](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html) Uno app. |

#### Tutorial-Inhalte / Tutorial Content

| Ressource / Resource | Deutsch | English |
| --- | --- | --- |
| **Tutorial Serie** | [Uno.Extensions Navigation via Xaml – Schritt-für-Schritt](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/de/Navigation/Extensions-Navigation-de.html) | [Uno.Extensions Navigation via Xaml – Step-by-step](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/en/Navigation/Extensions-Navigation-en.html) |
| **Fortgeschrittene Navigation** | [Auf Route-Änderungen mit IRouteNotifier reagieren](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/de/Navigation/HowTo-ChangeRoutes-de.html) | [Listen to Route Changes with IRouteNotifier](https://devtkss.github.io/DevTKSS.Uno.SampleApps/articles/en/Navigation/HowTo-ChangeRoutes-en.html) |
| **Video-Tutorials** | [Komplette Anleitung 🇩🇪 (Deutsch mit englischen Untertiteln)](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX) | [Complete Walkthrough 🇩🇪 (German with English Subtitles)](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX) |
| **Quellcode** | [Implementierung durchsuchen](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.XamlNavigationApp/) | [Browse the Implementation](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.XamlNavigationApp/) |

#### Beispiel: Auf Routen-Änderungen mit IRouteNotifier reagieren / Example: Listen to Route Changes with IRouteNotifier

![Listen to Route Changes with IRouteNotifier](https://raw.githubusercontent.com/DevTKSS/DevTKSS.Uno.SampleApps/master/docs/articles/.attachments/IRouteNotifier.gif)

| | |
| --- | --- |
| In diesem Beispiel zeige ich dir, wie man den `IRouteNotifier`-Dienst im Mvux Model erhält und sich für das `RouteChanged`-Ereignis registriert. Hierbei gehe ich u.a. auch auf die (zum Zeitpunkt der Erstellung dieses Tutorials) leider fehlerhafte Dokumentation im Uno Platform Docs ein, und zeige dir wie du trotzdem den korrekten Namen der aktuellen Route erhalten kannst, sowie diesen live in deiner App anzeigen lassen kannst. | In this example, I show how to obtain the `IRouteNotifier` service inside the Mvux model and subscribe to the `RouteChanged` event. I also call out the (at the time of writing) incorrect Uno Platform docs and show how you can still retrieve the correct current route name and display it live inside your app. |

### Simple Member Selection App

![Image of final Simple Member Selection App](https://raw.githubusercontent.com/DevTKSS/DevTKSS.Uno.SampleApps/master/docs/articles/.attachments/SimpleMemberSelectionApp.png)

| | |
| --- | --- |
| Die Simple Member Selection Anwendung demonstriert die Auswahl und Anzeige von Mitgliedernamen in einer `ListView`, gebunden an einen `ListState<string>` im Modell mittels MVUX. | The Simple Member Selection application demonstrates selection and display of member names in a `ListView` bound to a `ListState<string>` in the Model using MVUX. |

#### Tutorial-Inhalte / Tutorial Content

| Resource | Link |
| --- | --- |
| **Video-Tutorial:** | [How To: Binden von ListState und ImmutableList zu FeedView & ListView im UI](https://youtu.be/wOsSlv1YFic) |
| **Quellcode/Source Code** | [Simple Member Selection App](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.SimpleMemberSelectionApp/) |

---

## Feedback & Beitragen / Feedback & Contributing

| | | | |
| --- | --- | --- | --- |
| | Wir freuen uns auf dein Feedback und deine Beiträge! | | We welcome your feedback and contributions! |
| **Du hast Fragen?** | [Diskussion starten](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions) | **Do you have questions?** | [Start a Discussion](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions) |
| **Du hast einen Fehler gefunden?** | [Issue öffnen](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues) | **Did you found a bug?** | [Open an Issue](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues) |
| **Du möchtest Beitragen?** | [Hier geht's zu den Guidelines](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/CONTRIBUTING.md) | **You want to contribute?** | [Here you can find the Guidelines](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/CONTRIBUTING.md) |
| **Hast du eine Idee?** | [Diskussionen](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions/new) | **Do you have an idea?** | [Discussions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions/new) |

## Externe Ressourcen & Lernmaterial / External Resources

### Uno Platform Ressourcen / Uno Platform Resources

| Ressource / Resource | Link |
| --- | --- |
| Homepage | [Uno Platform Homepage](https://platform.uno/) |
| Dokumentation / Documentation | [Uno Platform Documentation](https://platform.uno/docs/articles/intro.html) |
| Discord Community | [Uno Platform Discord](https://discord.gg/eBHZSKG) |
| GitHub | [Uno Platform on GitHub](https://github.com/unoplatform/uno) |

---

### Für neu anfangende deutschsprachige C# Entwickler

Falls du gerade erst mit **C#** anfangen möchtest zu lernen, empfehle ich die Kurse von **Coding mit Jannick** (IT Leismann):

| Kurs | Beschreibung | Link |
| --- | --- | --- |
| C# Grundlagen (kostenlos) | Der perfekte Einstieg in die Softwareentwicklung – Ideal für absolute Anfänger | [Zum Kurs](https://codingmitjannick.de/s/coding-mit-jannick/csharp-grundlagenkurs) |
| .NET Guide (kostenlos) | Produktionsreife .NET Anwendungen – Umgang mit professionellen .NET Anwendungen | [Zum Kurs](https://codingmitjannick.de/s/coding-mit-jannick/leitfaden) |
| C# Bootcamp 2024 | Vom Anfänger bis zum Profi – Umfassendes Trainingsprogramm | [Zum Kurs](https://codingmitjannick.de/s/coding-mit-jannick/csharp-bootcamp) |
| C# Expertise | Design Patterns und Clean Code – Fortgeschrittene Konzepte für professionelle Entwicklung | [Zum Kurs](https://codingmitjannick.de/s/coding-mit-jannick/csharp-expertise) |
| Alle Kurse | Komplette Kursübersicht | [Alle Kurse ansehen](https://codingmitjannick.de/s/coding-mit-jannick/kurse) |

> [!NOTE]
> **Transparenzhinweis:** Ich habe selbst an diesen Kursen teilgenommen und empfehle sie aus Überzeugung. Ich erhalte für diese Weiterempfehlung kein Geld oder andere Vergütung.
> Die Preise und Verfügbarkeit der Kurse können sich ändern. Bitte überprüfe die Kursseiten für die aktuellsten Informationen.
