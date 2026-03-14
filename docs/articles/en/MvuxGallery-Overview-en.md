---
uid: DevTKSS.Uno.SampleApps.MvuxGallery.Overview.en
---

# Mvux Gallery Overview

![MvuxGallery](../.attachments/DevTKSS%20Uno%20Mvux%20Samples%20Gallery%20App-Thumbnail.png)

The [Mvux Gallery (source link)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/) should give you a impression of whats possible to achieve with the Mvux and Uno.Extensions packages in your Uno Platform App.

As it contains already a lot of Controls and Features, I decided to create some Tutorials to guide you through the process of building this App with some Sample Apps and added Tutorials. Take a look at the Table of Contents and NavigationBar in these Docs to see what is already available.

## Sampled Controls

Here is a list of Controls and Features you can explore in the MvuxGallery App with links to their Source code in the MvuxGallery App:

- [Card](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SimpleCardsPage.xaml)
- [Counter](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/CounterPage.xaml) and [CounterModel](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/CounterModel.cs)
- [FeedView + GridView](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml) and [Model](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
- [FeedView + ListView](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/ListboardPage.xaml) and [Model](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
- [DataTemplate centralized Style Resource Definition](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml)
- [`ItemOverlayTemplate` DataTemplate](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml) (*Layout replicated from WinUI 3 Gallery*)
- [TabBar and TabBarItem](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml) and [Model for Binding Items to ListFeed](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)

## Sampled Uno.Extensions

- Mvux
  - ListFeed
  - State

  --> Almost every Model, detailed overview will follow.

- Navigation
  - via Xaml
    - NavigationView
      - [MainPage.xaml](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/MainPage.xaml) see [DE Tutorial](xref:DevTKSS.Uno.ExtensionsNavigation.Overview.de)
  - Via Model
    - (planned)

- Hosting
  - [App.xaml.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)

- DependencyInjection
  - Service Registration
    - [App.xaml.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)
  - Service Definition
    - [CodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
    - [ICodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/ICodeSampleService.cs)
  - Data Model Definition
    - [SampleCode.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/SampleCode.cs)
    - [CodeSampleOption.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Serialization
  - JsonSerializerContext of each DataModel
    - [CodeSampleOptionsContext](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

    > [!NOTE]
    > Currently `ValueTuple<int,int>` and `Dictionary<string, CodeSampleOption>` Definitions of IOptions loaded Settings could'nt get successfully loaded, therefore this is defined as Array for Workaround.

- Configuration
  - Data for Serialization
    - [appsettings.sampledata.json](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/appsettings.sampledata.json)
    - [`IOptions<CodeSampleOptionsConfiguration>` in Service](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Storage
  - Via Model
    - [DashboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
  - Via Service
    - [CodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
  - Via [own StorageExtensions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Extensions.Uno/StorageExtensions.cs) and [IEnumerableExtensions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Extensions.Uno/Storage/Enumerable/EnumerableExtensions.string.cs) (*temporary imported until PR might get merged or Package gets published*)
  - Via Uno.Extensions.Storage.StorageExtensions
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)

- Localization
  - **IStringLocalizer**
    - Resources Dictionaries (*I recommend to lookup those links using Visual Studio 2022/2026*)
      - [en](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/)
      - [de](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Strings/de/)
    - Binding current value in `IState<string>` and to corresponding View
      - [DashboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
      - [ListboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
      - [MainModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/MainModel.cs)
      - [CounterModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/CounterModel.cs)
    - Requesting localized Items via FeedView
      - Service Definition
        - [GalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
        - [IGalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/IGalleryImageService.cs)
      - Data Model Definition
        - [GalleryImageModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageModel.cs)
  - **ILocalizationService**
    - Requesting current culture
      - [GalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
    - Switching culture
      - (planned)
