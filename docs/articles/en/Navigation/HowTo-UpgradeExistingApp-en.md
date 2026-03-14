---
uid: DevTKSS.Uno.ExtensionsNavigation.UpgradeExistingApp.en
---

# How To: Add Uno Extensions Navigation to an Existing Application

If you already have an existing Uno application, you can of course add Extensions Navigation.

## Adding UnoFeatures

In the project file, recognizable by the `.csproj` extension, you need the following `UnoFeatures` elements in addition to the `Uno.Sdk`:

### [Mvux](#tab/mvux)

```xml
<UnoFeatures>
    Hosting;
    Mvux;
    Navigation;
    Toolkit;
</UnoFeatures>
```

### [Mvvm](#tab/mvvm)

```xml
<UnoFeatures>
    Hosting;
    Mvvm;
    Navigation;
    Toolkit;
</UnoFeatures>
```

***

> [!TIP]
> The `Toolkit` feature is only required to use navigation controls like `TabBar` or `DrawerControl`.
> [!NOTE]
> In general we need the `Hosting` feature to use `DependencyInjection` in our app.
> I say "in general" because, for example, in the included `MvuxGallery` and `SimpleMemberSelectionApp` I removed the `Hosting` feature, created the app, and contrary to the official documentation I couldn't find any problems.
> All DI parameters were resolved correctly and I was still able to use `ConfigureServices` with `KeyedService` Registration in the corresponding `App.xaml.cs` file with the [![Uno.Sdk 6.3.28](https://img.shields.io/badge/Uno.Sdk-6.3.28-blue)](https://www.nuget.org/packages/Uno.Sdk/6.3.28).

## App.xaml.cs Configuration

Add the following content to your `App.xaml.cs` file if not already included:

### [Mvux](#tab/mvux-on-launched)

```diff
+    protected async override void OnLaunched(LaunchActivatedEventArgs args)
+    {
+        var builder = this.CreateBuilder(args)
+            // Adds support for additional navigation controls like TabBar and NavigationView
+            .UseToolkitNavigation()
+            .Configure(host => host
+                // Add the callback to the RegisterRoutes method, which will define the routes in the application.
+                .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
+            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

+        Host = await builder.NavigateAsync<Shell>();
    }
```

### [Mvvm](#tab/mvvm-on-launched)

```diff
+    protected async override void OnLaunched(LaunchActivatedEventArgs args)
+    {
+        var builder = this.CreateBuilder(args)
+            // Adds support for additional navigation controls like TabBar and NavigationView
+            .UseToolkitNavigation()
+            .Configure(host => host
+                // Add the callback to the RegisterRoutes method, which will define the routes in the application.
+                .UseNavigation(RegisterRoutes)
+            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

+        Host = await builder.NavigateAsync<Shell>();
    }
```

***

## Next Steps

- [Register the routes in your app](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en)
