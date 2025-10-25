---
uid: DevTKSS.Uno.ExtensionsNavigation.UpgradeExistingApp.de
---

# Hinzufügen von Uno Extensions Navigation in eine bestehende Anwendung

Solltest du schon eine existierende Uno Anwendung haben, kannst du die Extensions Navigation natürlich hinzufügen.

## Hinzufügen der UnoFeatures

In der Projektdatei, zu erkennen an der Endung `.csproj`, brauchst du dafür neben dem `Uno.Sdk` folgende `UnoFeatures` Elemente:

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
> Das `Toolkit` Feature wird nur benötigt, wenn Navigations-Steuerelemente wie `TabBar` oder `DrawerControl` verwendet werden sollen.

## App.xaml.cs Konfiguration

Füge deiner Datei `App.xaml.cs` folgenden Inhalt hinzu, wenn nicht bereits enthalten:

### [Mvux](#tab/mvux-on-launched)

```diff
+    protected async override void OnLaunched(LaunchActivatedEventArgs args)
+    {
+        var builder = this.CreateBuilder(args)
+            // Fügt Unterstützung für weitere Navigations-Steuerelemente wie TabBar and NavigationView hinzu
+            .UseToolkitNavigation()
+            .Configure(host => host
+                // Füge den Callback zur Methode RegisterRoutes hinzu, diese wird die Routen in der Anwendung definieren.
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
+            // Fügt Unterstützung für weitere Navigations-Steuerelemente wie TabBar and NavigationView hinzu
+            .UseToolkitNavigation()
+            .Configure(host => host
+                // Füge den Callback zur Methode RegisterRoutes hinzu, diese wird die Routen in der Anwendung definieren.
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

## Nächste Schritte

- [Registriere die Routen in deiner App](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de)
