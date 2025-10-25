---
uid: DevTKSS.Uno.ResourcesLookup.en
---

# Resource Collection for Getting Started with Uno App Development

Welcome to the Uno Platform Developer Community!

Here you will learn how to get started with development in your Uno app: https://aka.platform.uno/get-started

Get an overview of all the great features Uno offers: https://platform.uno/docs/articles/intro.html

For more information on using Uno.Sdk or updating Uno Platform packages in your solution, see: https://aka.platform.uno/using-uno-sdk

## Table of Contents

- [Uno Platform Documentation Resource Collection](#uno-platform-documentation-resource-collection)
  - [General Links](#general-links)
  - [WinUI as Base](#winui-as-base)
- [Discover Uno Studio Options for Your Application](#discover-uno-studio-options-for-your-application-development)
  - [Hot Design](#hot-design)
  - [Hot Reload](#hot-reload)
  - [Design to Code](#design-to-code)
- [Learn More About `Uno.Extensions`](#learn-more-about-unoextensions)
- [Uno.Resizetizer](#unoresizetizer)
- [Get Help](#get-help)
- [Contribute to Uno Platform](#contribute-to-uno-platform)

## Uno Platform Documentation Resource Collection

### General Links

- [Best Practices for Development with Uno Platform](https://platform.uno/docs/articles/best-practices-uno.html)
- [Development with Uno Platform](https://platform.uno/docs/articles/using-uno-ui.html)
  - [Uno Platform Features](https://platform.uno/docs/articles/supported-features.html)
    - [List of Controls Implemented in Uno](https://platform.uno/docs/articles/implemented-views.html)
  - [Special Notes on WinAppSDK](https://platform.uno/docs/articles/features/winapp-sdk-specifics.html)
- [Updating Uno Platform NuGet Packages](https://platform.uno/docs/articles/upgrading-nuget-packages.html) – here you will also find the current stable version of **Uno.Sdk**!
- [Tutorials](https://platform.uno/docs/articles/samples-tutorials-overview.html)
- [Samples](https://platform.uno/docs/articles/external/uno.samples/doc/samples.html)
- [Additional Resources](https://platform.uno/docs/articles/get-started-next-steps.html)
- [Publishing an Uno App](https://platform.uno/docs/articles/uno-publishing-overview.html)

### WinUI as Base

If you are not only new to Uno Platform, but have also never worked with WinUI-based XAML (if you develop with C# Markup, note that the properties still have the same structure as with XAML Markup), you will find a collection of links here to get you started:

- [Links to WinUI Documentation](https://platform.uno/docs/articles/winui-doc-links.html)
- [WinUI 3 and Uno Platform](https://platform.uno/docs/articles/uwp-vs-winui3.html)

## Discover Uno Studio Options for Your Application Development

**Uno Platform Studio** revolutionizes how developers design, build, and iterate on their applications.

It includes three main tools specifically developed to simplify your workflow:

### [Hot Design®](https://platform.uno/docs/articles/studio/Hot%20Design/hot-design-overview.html)

The first runtime visual designer for cross-platform .NET applications. Hot Design transforms your running app into a designer – from any IDE, on any operating system – allowing you to effortlessly create high-quality user interfaces.

[➜ Learn More About Hot Design®](https://platform.uno/docs/articles/studio/Hot%20Design/hot-design-getstarted-guide.html)

### [Hot Reload](https://platform.uno/docs/articles/studio/Hot%20Reload/hot-reload-overview.html)

Reliably update any code in your app and get instant feedback that your changes have been applied – with a new Hot Reload indicator to monitor your changes during development.

[➜ Get Started with Hot Reload](https://platform.uno/docs/articles/studio/Hot%20Reload/get-started-with-hot-reload.html)

### [Design-to-Code](https://platform.uno/docs/articles/external/figma-docs/download.html)

Generate production-ready, well-structured XAML or C# Markup directly from your Figma designs with a single click – and save yourself the manual design handoff.

[➜ Learn More About Design-to-Code](https://platform.uno/docs/articles/external/figma-docs/get-started.html)

## Learn More About `Uno.Extensions`

- [Authentication](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Authentication/AuthenticationOverview.html)
- [Configuration](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Configuration/ConfigurationOverview.html)
- [Hosting](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Hosting/HostingOverview.html)
- [HTTP](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Http/HttpOverview.html)
- [Localization](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Localization/LocalizationOverview.html)
- [Logging](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Logging/LoggingOverview.html)
- [Navigation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/NavigationOverview.html)
- [Serialization](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Serialization/SerializationOverview.html)
- [Storage](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Storage/StorageOverview.html)
- [Validation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Validation/ValidationOverview.html)
- [C# Markup](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Markup/Overview.html)
- [.NET MAUI Embedding](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Maui/MauiOverview.html)
- [Theme Service](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/ThemeService/HowTo-UseThemeService.html)

## Uno.Resizetizer

> [!NOTE]
> When working with Visual Studio, you can insert `*.png` and `*.svg` files into your app without having to convert them with Uno.Resizetizer – it is already included in every Uno app.

Here's how it works (short version):

1. Insert the image file into the **Assets** folder in **Solution Explorer** – e.g. under **Images**, **Icons** or **Splash** (create these if they don't exist).
2. Open the file's **Properties Window** and make sure the **Build Action** is set to **`UnoImage`**.

> [!NOTE]
> Alternatively, you can also configure this directly in your Uno app's `*.csproj` file:
>
> ```xml
> <ItemGroup>
>    <UnoImage Include="Assets\Images\*" />
> </ItemGroup>
> ```

For more information, see: [Get Started with Uno.Resizetizer](https://platform.uno/docs/articles/external/uno.resizetizer/doc/using-uno-resizetizer.html).

## Get Help

If you encounter problems while developing your Uno app, you can connect with the core team and community via Discord or GitHub.

Depending on the difficulty of your problem, you may be asked to provide a reproduction project (also called a "repro") so that others can understand your problem and help you specifically.

You can learn how to create such a repro project here: https://platform.uno/docs/articles/uno-howto-create-a-repro.html

## Contribute to Uno Platform

Everyone is invited to contribute to Uno Platform. Here you will find helpful information for new and returning contributors.

To begin, it's best to read the [Code of Conduct](https://github.com/unoplatform/uno/blob/master/CODE_OF_CONDUCT.md), which establishes the commitment to an open, friendly, and harassment-free Uno Platform community.

If you don't know where to start: [Read more about ways to contribute](https://github.com/unoplatform/uno/blob/master/doc/articles/contributing/ways-to-contribute.md) or check out the list of [beginner-friendly open issues](https://github.com/unoplatform/Uno/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22).

For more information, see the official documentation: https://platform.uno/docs/articles/uno-development/contributing-intro.html
