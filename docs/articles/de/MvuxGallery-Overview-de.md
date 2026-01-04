---
uid: DevTKSS.Uno.SampleApps.MvuxGallery.Overview.de
---

# Mvux Galerie Übersicht

![MvuxGallery](../.attachments/DevTKSS%20Uno%20Mvux%20Samples%20Gallery%20App-Thumbnail.png)

Die [Mvux Galerie (Quelllink)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery) soll Ihnen einen Eindruck davon vermitteln, was mit den Mvux- und Uno.Extensions-Paketen in Ihrer Uno Platform App möglich ist.

Da sie bereits viele Steuerelemente und Funktionen enthält, habe ich mich entschieden, einige Tutorials zu erstellen, um Sie durch den Prozess des Erstellens dieser App mit einigen Beispiel-Apps und hinzugefügten Tutorials zu führen. Werfen Sie einen Blick auf das Inhaltsverzeichnis und die Navigationsleiste in diesen Dokumenten, um zu sehen, was bereits verfügbar ist.

## Beispiel-Steuerelemente

Hier ist eine Liste von Steuerelementen und Funktionen, die Sie in der MvuxGallery App erkunden können, mit Links zu ihrem Quellcode in der MvuxGallery App:

- [Card](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/SimpleCardsPage.xaml)
- [Counter](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/CounterPage.xaml) und [CounterModel](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/CounterModel.cs)
- [FeedView + GridView](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml) und [Model](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
- [FeedView + ListView](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/ListboardPage.xaml) und [Model](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
- [DataTemplate zentrale Style Ressourcendefinition](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml)
- [`ItemOverlayTemplate` DataTemplate](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Styles/Generic.xaml) (*Layout repliziert aus WinUI 3 Galerie*)
- [TabBar und TabBarItem](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/DashboardPage.xaml) und [Model für das Binden von Elementen an ListFeed](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)

## Beispielhafte Uno.Extensions

- Mvux
  - ListFeed
  - State

  --> Fast jedes Model, detaillierte Übersicht folgt.

- Navigation
  - über Xaml
    - NavigationView
      - [MainPage.xaml](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/Views/MainPage.xaml) siehe [hier geht's zum Tutorial!](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de)
  - Über Model
    - (geplant)

- Hosting
  - [App.xaml.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)

- DependencyInjection
  - Service Registrierung
    - [App.xaml.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs)
  - Service Definition
    - [CodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
    - [ICodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery//Models/CodeSamples/ICodeSampleService.cs)
  - Datenmodell Definition
    - [SampleCode.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/SampleCode.cs)
    - [CodeSampleOption.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOption.cs)
    - [CodeSampleOptionsConfiguration.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Serialization
  - JsonSerializerContext jedes Datenmodells
    - [CodeSampleOptionsContext](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptions.cs)
    - [CodeSampleOptionsConfiguration](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleOptionsConfiguration.cs)

- Konfiguration
  - Daten für Serialization
    - [appsettings.sampledata.json](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/appsettings.sampledata.json)
    - [`IOptions<CodeSampleOptionsConfiguration>` im Service](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)

- Storage
  - Über Model
    - [DashboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
  - Über Service
    - [CodeSampleService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/CodeSamples/CodeSampleService.cs)
  - Über [eigene StorageExtensions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Extensions.Uno/StorageExtensions.cs) und [IEnumerableExtensions](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Extensions.Uno/EnumerableExtensions.string.cs) (*vorübergehend importiert, bis PR möglicherweise gemergt wird oder anstelle ein eigenständiges Paket veröffentlicht wird*)
  - Über Uno.Extensions.Storage.StorageExtensions
    - hinzugefügt als PR zu Uno.Extensions [#2734](https://github.com/unoplatform/uno.extensions/pull/2734)

- Lokalisierung
  - **IStringLocalizer**
    - Ressourcenwörterbücher (*Ich empfehle, diese Links mit Visual Studio 2022/2026 zu durchsuchen*)
      - [en](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Strings/en/Resources.resw)
      - [de](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Strings/de/Resources.resw)
    - Bindung des aktuellen Werts in `IState<string>` und zur entsprechenden Ansicht
      - [DashboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/DashboardModel.cs)
      - [ListboardModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/ListboardModel.cs)
      - [MainModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/MainModel.cs)
      - [CounterModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Presentation/ViewModels/CounterModel.cs)
    - Anforderung lokalisierter Elemente über FeedView
      - Service Definition
        - [GalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
        - [IGalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/IGalleryImageService.cs)
      - Datenmodell Definition
        - [GalleryImageModel.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageModel.cs)
  - **ILocalizationService**
    - Anforderung der aktuellen Kultur
      - [GalleryImageService.cs](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.Samples.MvuxGallery/Models/GalleryImages/GalleryImageService.cs)
    - Wechsel der Kultur
      - (geplant)
