# DevTKSS Uno Samples

Welcome to this Samples Repository! ❤️

The samples in this Repository are meant to help other Developers, independent to their pre-knowledge, get an Idea of how to use the shown things.

> [!TIP]
> Check out the [Documentation](./doc/articles/introduction.md), for more a more detailed List and future coming Guides and Explanations.

## Table of Contents

- [DevTKSS Uno Samples](#devtkss-uno-samples)
  - [Table of Contents](#table-of-contents)
  - [Mvux Gallery](#mvux-gallery)
    - [Controls to be explored in this App](#controls-to-be-explored-in-this-app)
    - [Uno.Extensions to be explored here](#unoextensions-to-be-explored-here)
    - [Fist Recording of Making-Of](#fist-recording-of-making-of)
    - [Current state](#current-state)
  - [Help Welcome!](#help-welcome)
  - [See also](#see-also)

## Mvux Gallery

![Mvux Gallery ShowCase](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/doc/articles/images/MvuxGallery-ShowCase.gif)

Following list provides you a quick Overview, what you can find in the [Mvux Gallery](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery) App.
The depending Documentation you can find [here](./doc/articles/MvuxGallery/Overview.md)

### Controls to be explored in this App

- FeedView combined with:
  - GridView
  - ListView
- DataTemplate centralized Resource definition
- Card
- Grid
- NavigationView
- `ItemOverlayTemplate` DataTemplate layout replicated from WinUI 3 Gallery
- TabBar & TabBarItem

### Uno.Extensions to be explored here

- Mvux
  - ListFeed
  - State
- Navigation
  - via Xaml
- Hosting
- DependencyInjection
- Serialization
  - JsonSerializerContext of each DataModel
  - Using multiple `JsonSerializable(typeof...)` Attributes to extend the `CodeSampleOptionsContext.Default.<...>` Items
- Configuration
  - Data for Serialization load from separate `appsettings.sampledata.json`
- Storage
  - Directly in the Model Definition
  - Via Service
  - Via StorageExtension
    - Referenced currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)
- Localization
  - **IStringLocalizer**
    - Resources Dictionaries
    - Binding current value in `IState<string>` and to corresponding View
    - Requesting localized Items via FeedView
  - **ILocalizationService**
    - Requesting current culture

### Fist Recording of Making-Of

> [!NOTE]
> uncut, without sound, will be edited and re-recorded in the future, src at [this commit](https://github.com/DevTKSS/DevTKSS.MvuxSampleApps/commit/8d13dcee8107324e747d828700cfd8fcf780ca37)
>
> This is showing the initial making of from this project at the first commits

<iframe src="https://technischekonstruktion.sharepoint.com/_layouts/15/embed.aspx?UniqueId=8e4c435c-50fd-4d69-82ef-a9f5bc571dd7&embed=%7B%22ust%22%3Atrue%2C%22hv%22%3A%22CopyEmbedCode%22%7D&referrer=StreamWebApp&referrerScenario=EmbedDialog.Create" width="640" height="360" frameborder="0" scrolling="no" allowfullscreen title="Uno HotDesign App Making-Off.mp4"></iframe>

### Current state

- [x] Created a [first `working` state](https://github.com/DevTKSS/UnoHotDesignApp1/commit/9f6479fa37901a0478bbc9e1c3e92221223ce4d0)
- [x] Restructuring, Refactoring applying SOC
- [x] Implement SampleCode Presenting like Gallery to have the src code side by side in the running app
  - [x] [Working State of DashboardPage](https://github.com/DevTKSS/UnoHotDesignApp1/commit/98fa25af8f23bb27c2dccac39d9248f3fc7254dd)
  - [ ] Fixing ThemeResource Styled that are not seeming to listen to Theme changes
  - [x] Updating the Code Samples in Assets
- [ ] Record video guides in English and German Language to provide a step by step Guide for Beginners like me and simplify the start with uno.extensions with Mvux.
  - [x] Video Tutorial Xaml Navigation with NavigationView --> pending release (German Language)
    - [Documentation in German Language](./doc/articles/MvuxGallery/How-To-XamlNavigation.md)

<!--markdownlint-disable MD026 -->
## Help Welcome!

If you want to help out, please feel free to open an [issue](./issues) or PR.

Every helping hand is welcome and I will try to review and merge it as soon as possible.

## See also

- [Uno Platform](https://platform.uno/)
  - [Documentation Intro](https://platform.uno/docs/articles/intro.html)
  - [Uno Navigation Extensions](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
  - [Mvux Documentation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)
  - [FeedView Control](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/FeedView.html)
