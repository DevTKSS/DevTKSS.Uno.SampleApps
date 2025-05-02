# Mvux meets HotDesign(TM) Sample App

Example project which should show how different mvux ui controls and model binding can be done

## Current state

- [x] Created a [first `working` state](https://github.com/DevTKSS/UnoHotDesignApp1/commit/9f6479fa37901a0478bbc9e1c3e92221223ce4d0)

  Not acceptable for me as final result since it had very poor performance and not relyable functionality

- [x] Restructuring, Refactoring applying SOC
- [x] Implement SampleCode Presenting like Gallery to have the src code side by side in the running app
  - [x] [Working State of DashboardPage](https://github.com/DevTKSS/UnoHotDesignApp1/commit/98fa25af8f23bb27c2dccac39d9248f3fc7254dd)
- [ ] (Re)record the video to show a final step by step Guide to Beginners like me and simplify the start with uno.extensions with Mvux.

## Controls to be explored in this App

- FeedView + GridView
- FeedView + ListView
- DataTemplate centralized Recource definition
- Card
- `ItemOverlayTemplate` DataTemplate layout replicated from WinUI 3 Gallery

## Uno.Extensions to be explored here

- Mvux
  - Feed
  - ListFeed
  - State
  - ListState

  --> Almost every Model, detailed overview will follow.

- Navigation
  - via Xaml
    - NavigationView
      - MainPage.xaml
  - Via Model
    - (planned)

- Hosting
  - App.xaml.cs

- DependencyInjection
  - Service Registration
      - App.xaml.cs
  - Service Definition
    - CodeSampleService.cs
    - (ICodeSampleService.cs) => to be extracted and added
  - Data Model Definition
    - SampleCode.cs#SampleCode
    - CodeSampleOptions.cs
    - CodeSampleOptionsConfiguration.cs

- Serialization
  - JsonSerializerContext of each DataModel
    - [SampleCodeContext](SampleCode.cs#SampleCodeContext)
    - [CodeSampleOptionsContext](CodeSampleOptions.cs#SampleCodeContext)
    - [CodeSampleOptionsConfigurationContext] (CodeSampleOptionsConfiguration.cs#CodeSampleOptionsConfigurationContext)

- Configuration
  - Data for Serialization
    - appsettings.json

- Storage
  - Via Model
    - DashboardModel.cs
  - Via Service
    - CodeSampleService.cs
  - Via StorageExtension
    - Currently in private preview package
  - Via Uno.Extensions.Storage.IStorage Interface extension
    - added as PR to Uno.Extensions

- Localization
  - **IStringLocalizer**
    - Resources Dictionarys
      - en/.resw
      - de/.resw
    - Binding current value in`IState<string>` and to corresponding View
      - DashboardModel.cs
      - ListboardModel.cs
      - MainModel.cs
      - CounterModel.cs
    - Requesting localized Items via FeedView
      - Service Definition
        - GalleryImageService.cs
      - Data Model Definition
        - GalleryImageModel.cs
  - **ILocalizationService**
    - Requesing current culture
      - GalleryImageModel.cs
    - Switching culture
      - (planned)

## Fist Recording (uncut, without sound)

[This Video](https://technischekonstruktion-my.sharepoint.com/:v:/g/personal/info_technische-konstruktion_com/EQyOpS6sImZJmLd83Nn_q6IBb1dfIqudJHjEMebV5PCYqA?e=0EIBcw) is showing the initial making of from this project at the first commits

