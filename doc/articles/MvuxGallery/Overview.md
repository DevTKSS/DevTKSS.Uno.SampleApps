---
uid: DevTKSS.Uno.SampleApps.MvuxGallery.Overview
_lang: en
---

## Mvux Gallery

At the [Mvux Gallery](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery) you can explore the following features:

### Controls

- [FeedView + GridView](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml)
- [FeedView + ListView](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/ListboardPage.xaml)
- [DataTemplate centralized Recource Definition](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml)
- [Card](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SimpleCardsPage.xaml))
- [`ItemOverlayTemplate` DataTemplate](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml#L92-L123) (*Layout replicated from WinUI 3 Gallery*)

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
      - [MainPage.xaml](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/MainPage.xaml#L1-L50))
  - Via Model
    - (planned)

- Hosting  
  - [App.xaml.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs#L21-L91)

- DependencyInjection
  - Service Registration
    - [App.xaml.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs#L69-L74)
  - Service Definition
    - [CodeSampleService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
    - [ICodeSampleService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/ICodeSampleService.cs)
  - Data Model Definition
    - [SampleCode.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/SampleCode.cs)
    - [CodeSampleOption.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Serialization
  - JsonSerializerContext of each DataModel
    - [CodeSampleOptionsContext](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptions.cs#L8-L11)
    - [CodeSampleOptionsConfigurationContext](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs#L6-L9)

- Configuration
  - Data for Serialization  
    - [appsettings.json](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/appsettings.json)

- Storage
  - Via Model
    - [DashboardModel.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs#L55-L141)
  - Via Service
    - [CodeSampleService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
  - Via StorageExtension
    - Currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)

- Localization
  - **IStringLocalizer**
    - Resources Dictionarys
      - [en](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/Resources.resw)
      - [de](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/Resources.resw)
    - Binding current value in `IState<string>` and to corresponding View  
      - [DashboardModel.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs#L31)
      - [ListboardModel.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs#L33)
      - [MainModel.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/MainModel.cs#L21)
      - CounterModel.cs  
    - Requesting localized Items via FeedView  
      - Service Definition  
        - [GalleryImageService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs#L34-L66)
        - [IGalleryImageService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/IGalleryImageService.cs#L6)
      - Data Model Definition  
        - [GalleryImageModel.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageModel.cs)
  - **ILocalizationService**
    - Requesing current culture  
      - [GalleryImageService.cs](~/../src/DevTKSS.Uno.Samples/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs#L19-L30)
    - Switching culture  
      - (planned)  
