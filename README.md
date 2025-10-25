# DevTKSS Uno Samples

## Welcome to this Samples and Tutorials Library! ❤️

The here contained samples and Tutorials are meant to help Developers, independent to their pre-knowledge, to get an Idea of:

- How to get started with the [Uno Platform](https://platform.uno/)
- How the Sampled Features and Controls can be used inside of our Applications

This is a collection of Sample Apps and Tutorials for the [Uno Platform](https://platform.uno/), aiming to fill the gap of missing ***German Localized*** learning Content.

### Page - Table of Contents

- **Samples in this Repository:**
  - [Mvux Gallery](#mvux-gallery)
  - [XamlNavigationApp](#xaml-navigation-app)- Localized Tutorial available in German!

- [**Tutorials**](#tutorial-videos-and-used-samples)

- [Feedback, Issues and Contributing](#feedback-issues-and-contributing)

> [!TIP]
> Check out the [Documentation & Tutorials](https://devtkss.github.io/DevTKSS.Uno.SampleApps/doc/), for more a more detailed List and future coming Guides and Explanations.

## Mvux Gallery

![Mvux Gallery Showcase Thumbnail](./doc/articles/.attachments/DevTKSS%20Uno%20Mvux%20Samples%20Gallery%20App-Thumbnail.png)

**Wanna see a quick showcase, what to explore there?**

![Mvux Gallery ShowCase](./doc/articles/.attachments/MvuxGallery-ShowCase.gif)

Following list provides you a quick Overview, what you can find in the [Mvux Gallery](./src/DevTKSS.Uno.Samples.MvuxGallery/) App.
[Detailed and linked Overview about the Mvux Gallery Contents](./doc/articles/de/MvuxGallery-Overview.md)

### Sampled Controls

- FeedView combined with:
  - GridView
  - ListView
- DataTemplate centralized Resource definition
- Card
- Grid
- NavigationView
- `ItemOverlayTemplate` DataTemplate layout replicated from WinUI 3 Gallery
- TabBar & TabBarItem

### Sampled Uno.Extensions

- [Mvux](./src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
- Navigation
  - [via Xaml](./src/DevTKSS.Uno.Samples.MvuxGallery/doc/articles/en/Navigation/HowTo-Defining-UI-NavigationView-en.md)
- Hosting (App Host Builder)
- Dependency Injection
- Serialization
- Configuration
  - Data for Serialization load from separate [`appsettings.sampledata.json`](./src/DevTKSS.Uno.Samples.MvuxGallery/master/appsettings.sampledata.json) file.
- Storage
- Localization

### Known Issues on the Mvux Gallery

- [ ] [ThemeResource Styled are not listening to Theme changes](https://github.com/DevTKSS/DevTKSS.Uno.Samples.MvuxGallery/issues/13)
- [ ] docfx fails to resolve source code links for e.g. included code snippets

## Tutorial Videos and used Samples

To show you how to get to the end result of the Mvux Gallery App, I created a Tutorial Video that will guide you through the process of building this App with the following Sample Apps and added Documentation.

### Xaml Navigation App

![Image of final Xaml Navigation App](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/doc/articles/.attachments/DevTKSS.Uno.XamlNavigationApp.png)

#### Content of the Tutorial

- [Uno.Extensions.Reactive also known as `Mvux`](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)
- [Uno.Extensions.Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
- [Xaml Markup Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)

[Discover the Source Code of the DevTKSS.Uno.XamlNavigationApp](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.XamlNavigationApp-1/)

## Feedback, Issues and Contributing

Let me know if you have any questions or feedback!

If you find any issues or have suggestions for improvements, please open an [issue](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues) or [discussion](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions).

In case you want to contribute, check out the [Contributing Guidelines](CONTRIBUTING.md) for more information on how to get started.

You are missing a feature or have an idea for a new Sample App? Please open a [discussion](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/discussions/new) to share your thoughts!
