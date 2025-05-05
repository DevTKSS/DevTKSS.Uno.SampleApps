---
uid: DevTKSS.Uno.SampleApps.MvuxGallery.Overview
---

## Mvux Gallery

At the [Mvux Gallery](../../../src/DevTKSS.Uno.Samples.MvuxGallery/) you can explore the following features:

### Controls

- [FeedView + ListView](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/ListboardPage.xaml)
- [DataTemplate centralized Resource Definition](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml)
- [Card](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SimpleCardsPage.xaml)
- [`ItemOverlayTemplate` DataTemplate](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml) (*Layout replicated from WinUI 3 Gallery*)
- [Counter](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/CounterPage.xaml)
- [Settings](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SettingsPage.xaml)
- [FeedView + GridView](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml)
- [FeedView + ListView](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/ListboardPage.xaml)
- [DataTemplate centralized Resource Definition](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml)
- [Card](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SimpleCardsPage.xaml)
- [`ItemOverlayTemplate` DataTemplate](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml) (*Layout replicated from WinUI 3 Gallery*)

### Uno.Extensions

- Mvux
  - Feed
  - ListFeed
  - State
  - ListState

  --> Almost every Model, detailed overview will follow.

- Navigation
  - via Xaml
    - NavigationView
      - [MainPage.xaml](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/MainPage.xaml)
  - Via Model
    - (planned)

- Hosting  
  - [App.xaml.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)

- DependencyInjection
  - Service Registration
    - [App.xaml.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)
  - Service Definition
    - [CodeSampleService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
    - [ICodeSampleService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/ICodeSampleService.cs)
  - Data Model Definition
    - [SampleCode.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/SampleCode.cs)
    - [CodeSampleOption.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Serialization
  - JsonSerializerContext of each DataModel
    - [CodeSampleOptionsContext](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptions.cs)
    - [CodeSampleOptionsConfigurationContext](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Configuration
  - Data for Serialization  
    - [appsettings.json](../../../src/DevTKSS.Uno.Samples.MvuxGallery/appsettings.json)

- Storage
  - Via Model
    - [DashboardModel.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
  - Via Service
    - [CodeSampleService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
  - Via StorageExtension
    - Currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)

- Localization
  - **IStringLocalizer**
    - Resources Dictionaries
      - [en](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/)
      - [de](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Strings/de/)
    - Binding current value in `IState<string>` and to corresponding View  
      - [DashboardModel.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
      - [ListboardModel.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
      - [MainModel.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/MainModel.cs)
      - CounterModel.cs  
    - Requesting localized Items via FeedView  
      - Service Definition  
        - [GalleryImageService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
        - [IGalleryImageService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/IGalleryImageService.cs)
      - Data Model Definition  
        - [GalleryImageModel.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageModel.cs)
  - **ILocalizationService**
    - Requesting current culture
      - [GalleryImageService.cs](../../../src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
    - Switching culture
      - (planned)
