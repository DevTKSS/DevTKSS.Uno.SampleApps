# DevTKSS Uno Samples

The samples in this Repository are meant to help other Developers, independent to their pre-knowledge, get an Idea of how to use the shown things.

> [!TIP]
> Check out the [Documentation](./doc/), for more a more detailed List and future coming Guides and Explanations.

## Table of Contents
1. [DevTKSS Uno Samples](#devtkss-uno-samples)
2. [Mvux Gallery](#mvux-gallery)
  - [Controls to be explored in this App](#controls-to-be-explored-in-this-app)
  - [Uno.Extensions to be explored here](#unoextensions-to-be-explored-here)
3. [First Recording of Making-Of](#first-recording-of-making-of)
4. [Current state](#current-state)
5. [Help Welcome!](#help-welcome)
6. [See also](#see-also)

## Mvux Gallery

Following list provides you a quick Overview, what you can find in the [Mvux Gallery](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery) App.

### Controls to be explored in this App

- FeedView comined with:
  - GridView
  - ListView
- DataTemplate centralized Recource definition
- Card
- Grid
- NavigationView
- `ItemOverlayTemplate` DataTemplate layout replicated from WinUI 3 Gallery

### Uno.Extensions to be explored here

- Mvux
- Navigation
  - via Xaml
- Hosting
- DependencyInjection
- Serialization
  - JsonSerializerContext of each DataModel
- Configuration
  - Data for Serialization load from `appsettings.json`
- Storage
  - Directly in the Model Definition
  - Via Service
  - Via StorageExtension
    - Referenced currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)
- Localization
  - **IStringLocalizer**
    - Resources Dictionarys
    - Binding current value in `IState<string>` and to corresponding View
    - Requesting localized Items via FeedView
  - **ILocalizationService**
    - Requesing current culture

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
 - [ ] Updating the Code Samples in Assets  
- [ ] (Re)record the video to show a final step by step Guide to Beginners like me and simplify the start with uno.extensions with Mvux.  

## Help Welcome!  

If you want to help out, please feel free to open an issue or PR.  

Every helping hand is welcom and I will try to merge it as soon as possible.  

## See also  

- [Uno Platform](https://platform.uno/)  
   - [Documentation Intro](https://platform.uno/docs/articles/intro.html)  
   - [Mvux Documentation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/Overview.html)  
   - [FeedView Control](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Mvux/FeedView.html)
