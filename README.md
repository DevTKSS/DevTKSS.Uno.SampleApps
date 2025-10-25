# DevTKSS Uno Samples

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-online-green.svg)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/)
[![Uno.Sdk](https://img.shields.io/badge/Uno.Sdk-6.3.28+-purple.svg)](https://platform.uno/)

## Welcome to this Samples and Tutorials Library! ❤️

This is a collection of Sample Apps and Tutorials for the [Uno Platform](https://platform.uno/), created to fill the gap of missing **German-localized** learning content. Most tutorials are available in both **German** (primary) and **English**.

**Quick Links:** [Get Started](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/HowTo-Setup-DevelopmentEnvironment-en.html) | [Documentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/) | [Video Tutorials (German)](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX) | [Discussions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions)

---

## About This Repository

This repository aims to help developers, regardless of their prior knowledge, learn:

- How to get started with the [Uno Platform](https://platform.uno/)
- How to use featured controls and patterns in real applications
- Best practices for MVUX, Navigation, and other Uno.Extensions

### Prerequisites

Before diving into the samples, make sure you have:

- **.NET 9.0 SDK** or later
- **Visual Studio 2022** (17.8+) with Uno Platform extension, **Rider**, or **VS Code**
- **Uno.Check** tool installed and verified (run `uno-check`)

> [!TIP]
> For detailed setup instructions, see our [Development Environment Setup Guide](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/HowTo-Setup-DevelopmentEnvironment-en.html).

---

## Sample Applications

### Mvux Gallery

![Mvux Gallery Showcase Thumbnail](./docs/articles/.attachments/DevTKSS%20Uno%20Mvux%20Samples%20Gallery%20App-Thumbnail.png)

**Want to see a quick showcase of what you can explore?**

![Mvux Gallery ShowCase](./docs/articles/.attachments/MvuxGallery-ShowCase.gif)

The [Mvux Gallery](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.Samples.MvuxGallery/) demonstrates modern Uno Platform development patterns with a comprehensive example application.

**[View Detailed Mvux Gallery Overview](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/MvuxGallery-Overview-en.html)**

#### Featured Controls

- **FeedView** combined with GridView and ListView
- **DataTemplate** centralized resource definitions
- **Card**, **Grid**, **NavigationView**
- **ItemOverlayTemplate** (replicated from WinUI 3 Gallery)
- **TabBar & TabBarItem**

#### Demonstrated Uno.Extensions

- **[MVUX](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)** - Model-View-Update-eXtended pattern
- **Navigation**
  - [Navigation via XAML](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/Navigation/HowTo-Defining-UI-NavigationView-en.html)
  - [React to Route Changes with IRouteNotifier](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/Navigation/HowTo-ChangeRoutes-en.html)
- **Hosting** - App Host Builder pattern
- **Dependency Injection** - Constructor injection
- **Serialization** - JSON data handling
- **Configuration** - Data loaded from `appsettings.json`
- **Storage** - Local data persistence
- **Localization** - Multi-language support

#### Known Issues

- ThemeResource styles are not listening to theme changes ([Issue #13](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues/13))
- DocFX fails to resolve source code links for included code snippets

---

### Xaml Navigation App

![Image of final Xaml Navigation App](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/doc/articles/.attachments/DevTKSS.Uno.XamlNavigationApp.png)

A complete tutorial application demonstrating navigation patterns with MVUX and XAML.

#### Tutorial Content

- [Uno.Extensions.Reactive (MVUX)](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)
- [Uno.Extensions.Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
- [XAML Markup Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)

**Available Resources:**

- **[Tutorial Documentation](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/Navigation/Extensions-Navigation-en.html)** - Step-by-step guide (🇩🇪 German | 🇬🇧 English)
- **[Video Tutorial Series](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX)** - Complete walkthrough (🇩🇪 German with English subtitles)
- **[Source Code](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/tree/master/src/DevTKSS.Uno.XamlNavigationApp-1/)** - Browse the implementation

---

## Documentation & Tutorials

You can access all tutorials and guides in both English and German. Use the table below to quickly jump to the documentation in your preferred language:

| Section                  | English                                                                 | German                                                                  |
|--------------------------|------------------------------------------------------------------------|-------------------------------------------------------------------------|
| Getting Started          | [Guide (EN)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/HowTo-Setup-DevelopmentEnvironment-en.html) | [Anleitung (DE)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/de/HowTo-Setup-DevelopmentEnvironment-de.html) |
| Mvux Gallery Overview    | [Overview (EN)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/MvuxGallery-Overview-en.html) | [Übersicht (DE)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/de/MvuxGallery-Overview-de.html) |
| Navigation Tutorials     | [Navigation (EN)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/en/Navigation/Extensions-Navigation-en.html) | [Navigation (DE)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/articles/de/Navigation/Extensions-Navigation-de.html) |
| All Docs Index           | [Docs Home (EN)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/) | [Docs Home (DE)](https://devtkss.github.io/DevTKSS.Uno.SampleApps/docs/index.html?lang=de) |

Most content is available in both German (original) and English (translated).

---

## Feedback, Issues and Contributing

We welcome your feedback and contributions!

- **Questions?** Start a [Discussion](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions)
- **Found a bug?** Open an [Issue](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues)
- **Want to contribute?** Check out our [Contributing Guidelines](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/CONTRIBUTING.md)
- **Have an idea?** Share it in [Discussions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions/new)

---

### Helpful Resources

- [Uno Platform Homepage](https://platform.uno/)
- [Uno Platform Documentation](https://platform.uno/docs/articles/intro.html)
- [Uno Platform Discord Community](https://discord.gg/eBHZSKG)
- [Uno Platform on GitHub](https://github.com/unoplatform/uno)
