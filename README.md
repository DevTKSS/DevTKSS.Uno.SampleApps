# DevTKSS Uno Samples

## Welcome to this Samples and Tutorials Library! ❤️

The here contained samples and Tutorials are meant to help Developers, independent to their pre-knowledge, to get an Idea of:

- How to get started with the [Uno Platform](https://platform.uno/)
- How the Sampled Features and Controls can be used inside of our Applications

 Because of the Uno Platform own provided Samples and guides are only English localized, I created this Sample Apps and Tutorials to help German speaking Developers, like myself, to get started with the Uno Platform in their native language.

**Table of Contents** *(of this ReadMe)**

- Samples in this Repository:
  - [Mvux Gallery](#mvux-gallery)
    - [Sampled Controls](#sampled-controls)
    - [Uno.Extensions](#sampled-unoextensions)
    - [Known Issues](#known-issues)
  - [Mvux.XamlNavigationApp](./src/DevTKSS.Uno.XamlNavigationApp-1/)
  - [Tutorials](#tutorial-videos-and-used-samples)
    - [Mvux XamlNavigation App](#mvuxxamlnavigationapp)

Last but not least:

- [Contributions Welcome!](#help-welcome)
- [See also](#see-also)

Let me know if you have any questions or feedback!

In case you want to contribute, please feel free to open an [issue](./issues), [PR](./pulls) or [discussion](./discussions)!

If you would like the samples to be available in your language and you are willing to help out with the translation, please let me know as well!

> [!TIP]
> Check out the [Documentation & Tutorials](/doc/articles/de/Introduction-de.md), for more a more detailed List and future coming Guides and Explanations.

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
- [Navigation](./doc/articles/en/Navigation-Intro.md)
  - [via Xaml](./doc/articles/en/Navigation/Extensions-Navigation.md)
- Hosting (App Host Builder)
- Dependency Injection
- Serialization
- Configuration
  - Data for Serialization load from separate [`appsettings.sampledata.json`](./src/DevTKSS.Uno.Samples.MvuxGallery/appsettings.sampledata.json) file.
- Storage
- Localization

### Known Issues

- [ ] [ThemeResource Styled are not listening to Theme changes](./issues/13)
- [ ] Getting `IOptions` with JsonTypeInfo Typed to Dictionary or Tuples does not work as expected and only returns null values. (see [#6](./issues/6))
- [ ] Missing Information about how to use `NamedOptions` at the point they should get returned by the IConfiguration to Configure the Service because Uno did remove the Microsoft own `.Configure<...>` which would be known, but is missing a documentation about those Changes applied. So in amiss of that, we need to create a derived Record for each of them to get the correct JsonSerializable Type and makes us need to define the CodeSampleService Generic. Following this up on [#9](./issues/9)

## Tutorial Videos and used Samples

To show you how to get to the end result of the Mvux Gallery App, I created a Tutorial Video that will guide you through the process of building this App with the following Sample Apps and added Documentation.

### Mvux.XamlNavigationApp

![Image of final XamlNavigationApp](./doc/articles/.attachments/DevTKSS.Uno.XamlNavigationApp.png)

#### Content of the Tutorial

- [Uno.Extensions.Reactive also known as `Mvux`](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)
- [Uno.Extensions.Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
- [Xaml Markup Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)

[Discover the Source Code of the DevTKSS.Uno.XamlNavigationApp](./src/DevTKSS.Uno.XamlNavigationApp-1/)

#### Select your preferred Language

- [German Language](./doc/articles/de/Navigation/HowTo-Navigation-with-NavigationView-in-Mvux-and-Xaml.md)
- [English Language](./doc/articles/Mvux.XamlNavigation/HowTo-Navigation-with-NavigationView-in-Mvux-and-Xaml.md)

> [!NOTE]
> The Tutorial Video is available in German Language only, but there are subtitles available, which should work using auto translation to your preferred language.

<!--markdownlint-disable MD026 -->
## Help Welcome!

If you want to help out, please feel free to open an [issue](./issues) or [PR](./pulls).

Every helping hand is welcome and I will try to review and merge it as soon as possible.

**Current Documentation State:**

Currently, the Docs deployment is needed to be served with `docfx serve doc/_site/` and then navigate manually to the start page: `articles/de/Introduction-de.html` because there is no option to set the default language or startup page, if its in a localized documentation not one right on the doc root path, in the `docfx.json` file, so as the Uno docs themselves are only available in english, so making the default language to german enables new learning developers to get started with the Uno Platform and Mvux in their native language.

As this is no show able result if the Page breaks, this will have to get fixed before getting published.

> [!IMPORTANT]
> As DocFx currently also loads explicitly excluded files from the `**/obj/**` folder, the Uno Platform provided and generated files from Uno.Resizetizer are shown as part of the API, when deploying the API documentation also, therefore the API documentation will be excluded from deployment after this Commit, so this can get investigated, from the appropriate Developer Team, but will not get included until then into the published documentation.

## See also

- [Uno Platform](https://platform.uno/)
  - [Documentation Intro](https://platform.uno/docs/articles/intro.html)
  - [Uno Navigation Extensions](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
  - [Mvux Documentation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)
  - [FeedView Control](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/FeedView.html)
