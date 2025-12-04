---
uid: DevTKSS.Uno.ExtensionsNavigation.Overview.en
---

# How To: Navigation with Uno Extensions

![Mvux XamlNavigationApp](../../.attachments/DevTKSS.Uno.XamlNavigationApp.png)

## Content of this Tutorial

- A `NavigationView` control for navigation.
- Routes defined in the `App.xaml` file.
- A `MainPage.xaml` that serves as the entry point for navigation.
- `DashboardPage` and `SecondPage` as example pages for navigation.
- Each page binds to an `IState<string>` property in the associated Model to demonstrate state management according to MVUX.

Since this sample app was created as part of a community tutorial video series on YouTube, you can follow the videos and understand the app's structure step by step.

> [!NOTE]
> The tutorial videos are currently only available in German, but transcriptions have been added to the video descriptions, which should be usable through YouTube's auto-translate feature. You can also enable auto-translated subtitles in YouTube to follow along in your preferred language.

- [Go to the Playlist on YouTube](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX&si=qHkpAUMSW9s8GZCO)

## Showcase of Possibilities

Let's first take a look at what you can create in a Xaml-based Uno application, using the MvuxGallery as an example.

![MvuxGallery Showcase](https://youtu.be/vVvnK02r2ug)

---

## Prerequisites

This tutorial series builds on the assumption that your development environment is already fully set up and the command `uno-check --tfm net9.0-desktop` executed in your terminal gives you a green light. Here you can also check these again:

- [Tutorial: Setting up the Development Environment](xref:DevTKSS.Uno.Setup.DevelopmentEnvironment.en)

## Next Steps

In the next steps, you will find guides with which you can learn how to implement navigation in an Uno Platform application using the Uno feature `Navigation`, i.e. the `Uno.Extensions.Navigation` NuGet. For this, you can simply use the footer navigation to go through the individual steps.

**I start with...**

[**A new Uno Platform App**](xref:DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.en) | [**An existing Uno Platform App**](xref:DevTKSS.Uno.ExtensionsNavigation.UpgradeExistingApp.en)

Once you have completed this step, we will continue with the implementation of navigation using the `NavigationView` control.

[**Implementation of Navigation via NavigationView**](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en)

---

- [Here you can find the source code of the sample application XamlNavigationApp used](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.XamlNavigationApp)

### Uno Documentation Links

- [How-To: Navigate in Xaml](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html)
- [How-To: Define Routes](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-DefineRoutes.html)
- [How-To: Regions](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-Regions.html)
- [How-To: Use NavigationView to Switch Views](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-UseNavigationView.html)
- [How-To: IRouteNotifier](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-IRouteNotifier.html)
