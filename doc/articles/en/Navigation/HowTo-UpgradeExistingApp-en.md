---
uid: DevTKSS.Uno.ExtensionsNavigation.UpgradeExistingApp.en
---

# How To: Add Uno Extensions Navigation to an Existing Application

If you already have an existing Uno application, you can of course add Extensions Navigation.

In the project file, recognizable by the `.csproj` extension, you need the following `UnoFeatures` elements in addition to the `Uno.Sdk`:

# [Mvux](#tab/mvux)

```xml
<UnoFeatures>
    Hosting;
    Mvux;
    Navigation;
</UnoFeatures>
```

# [Mvvm](#tab/mvvm)

```xml
<UnoFeatures>
    Hosting;
    Mvvm;
    Navigation;
    Toolkit;
</UnoFeatures>
```

# [On Launched](#tab/mvux/on-launched)

Add the following content to your `App.xaml.cs` file if not already included:

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

# [On Launched](#tab/mvvm/on-launched)

Add the following content to your `App.xaml.cs` file if not already included:

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

---

## Next Steps

- [Register the routes in your app](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en)
