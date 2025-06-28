---
uid: Mvux.XamlNavigationApp.HowTo-Navigation-with-NavigationView-in-Mvux-and-Xaml
---

## How-To: Navigating with a NavigationView in a XAML Markup + MVUX Presentation App

This sample demonstrates how to use a `NavigationView` control to navigate between pages in a XAML Markup + MVUX Presentation App. The app is structured to allow for easy navigation and showcases the MVUX pattern, with focus on brevity and simplicity.

**The sample includes:**

- A `NavigationView` control for navigation.
- Routes defined in the `App.xaml` file.
- A `MainPage.xaml` that serves as the entry point for navigation.
- `DashboardPage` and `SecondPage` as example pages to navigate to.
- Each of the pages binds to a string statefull property to demonstrate state management gatered by the MVUX.

As this SampleApp is produces alongside a Community Tutorial Video on YouTube, you can follow along with the video to see how the app is built step-by-step.

- [Link to the Playlist](https://youtube.com/playlist?list=PLEL6kb4Bivm_g81iKBl-f0eYPNr5h2dFX&si=qHkpAUMSW9s8GZCO)

> [!NOTE]
> Currently, the Videos are only available in German Language, but there are Transcriptions added to the Video Description, which should be useable through YouTube's Auto-Translate feature. There are also plans to create English Videos for this SampleApp in the future.

### Prerequisites

- Visual Studio 2022 or later with the Uno Platform extension installed.
- `uno-check --tfm net9.0-desktop` command executed in the Terminal gives you green light for all applyable checks.

For more information on how to set up your development environment, refer to the [Uno Platform documentation](https://platform.uno/docs/articles/external/uno.check/doc/using-uno-check.html).

### [Configuring the App using the VS Wizard](#tab/vs-wizard)

To configure the app using the Visual Studio Wizard, follow these steps:

1. Create a new Uno Platform App:

  1. Select the `recommended` Template.
  1. Select the `net9.0` target framework.
  1. Select `Xaml` as Markup.
  1. Select `MVUX` as Presentation.
  1. Select `Regions`, `Dependency Injection`,   as Extensions.
  1. *Optional: `Toolkit` `Localization`, `Configuration`*

1. Click `Create` to generate the app.

### [Configuring the App using the CLI](#tab/cli)

To configure the app using the CLI, follow these steps:

1. Open a terminal and navigate to the directory where you want to create the app.
1. Run the following command to create a new Uno Platform App:

  ```bash
  dotnet new unoapp -o UnoApp2 -preset "recommended" -platforms "desktop" -config False -http "none" -loc False -dsp False -theme-service False
  ```

---
<!--
Here is a Video so you can follow along with the steps:

[!Video [Navigation in Xaml und Mvux mit Navigation View]()] // add link to the english localized video here, when available
-->

### Tutorial Video: Navigation with `NavigationView` in MVUX and XAML

Now you can get started with the navigation in your app! In this video, I will show you how to set up and use the `NavigationView` control in a XAML Markup + MVUX Presentation App. We will implement navigation between different pages while applying the MVUX principles.

[!Video [Navigation in Xaml und Mvux mit Navigation View](https://youtu.be/knt2oOjHH30?si=PNgis0v9ZTR4LRsF)]

[Discover the Source Code](./)
