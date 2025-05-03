# DevTKSS Uno Samples

Example projects to see how different things can be done in a Uno Platform App.

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

At the [Mvux Gallery](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery) you can find:  

### Controls to be explored in this App

- FeedView + GridView
- FeedView + ListView
- DataTemplate centralized Recource definition
- Card
- `ItemOverlayTemplate` DataTemplate layout replicated from WinUI 3 Gallery

### Uno.Extensions to be explored here

- Mvux
  - Feed
  - ListFeed
  - State
  - ListState

  --> Almost every Model, detailed overview will follow.

- Navigation
  - via Xaml
    - NavigationView
      - [MainPage.xaml](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/MainPage.xaml#L1-L50))
  - Via Model
    - (planned)

- Hosting  
  - [App.xaml.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs#L21-L91)

- DependencyInjection
  - Service Registration
    - [App.xaml.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs#L69-L74)
  - Service Definition
    - [CodeSampleService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
    - [ICodeSampleService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/ICodeSampleService.cs)
  - Data Model Definition
    - [SampleCode.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/SampleCode.cs)
    - [CodeSampleOption.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Serialization
  - JsonSerializerContext of each DataModel
    - [SampleCodeContext](SampleCode.cs#L8-L11)
    - [CodeSampleOptionsContext](CodeSampleOptions.cs#L8-L11)
    - [CodeSampleOptionsConfigurationContext](CodeSampleOptionsConfiguration.cs#L6-L9)

- Configuration
  - Data for Serialization  
    - [appsettings.json](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/appsettings.json)

- Storage
  - Via Model
    - [DashboardModel.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs#L55-L141)
  - Via Service
    - [CodeSampleService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
  - Via StorageExtension
    - Currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)

- Localization
  - **IStringLocalizer**
    - Resources Dictionarys
      - [en](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/Resources.resw)
      - [de](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/Resources.resw)
    - Binding current value in `IState<string>` and to corresponding View  
      - [DashboardModel.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs#L31)
      - [ListboardModel.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs#L33)
      - [MainModel.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/MainModel.cs#L21)
      - CounterModel.cs  
    - Requesting localized Items via FeedView  
      - Service Definition  
        - [GalleryImageService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs#L34-L66)
        - [IGalleryImageService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/IGalleryImageService.cs#L6)
      - Data Model Definition  
        - [GalleryImageModel.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageModel.cs)
  - **ILocalizationService**
    - Requesing current culture  
      - [GalleryImageService.cs](./src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs#L19-L30)
    - Switching culture  
      - (planned)  

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
