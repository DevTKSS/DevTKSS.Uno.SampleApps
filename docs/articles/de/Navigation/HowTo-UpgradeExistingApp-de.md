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
> [!NOTE]
> Wir benötigen grundsätzlich das `Hosting` Feature und die `DependencyInjection` Funktionalität in unserer Anwendung zu verwenden.
> Ich sage hier absichtlich "grundsätzlich", da ich bspw. in der hier enthaltenen `MvuxGallery` und `SimpleMemberSelectionApp` Anwendungen das `Hosting` Feature entfernt habe, die App erstellt habe und entgegen der offiziellen Dokumentation ich keine Probleme feststellen konnte.
> Alle DI Parameter wurden korrekt aufgelöst und ich war weiterhin im stande `ConfigureServices` für die Registrierung von bspw. `KeyedService` in der zugehörigen `App.xaml.cs` Datei mit dem [![Uno.Sdk 6.3.28](https://img.shields.io/badge/Uno.Sdk-6.3.28-blue)](https://www.nuget.org/packages/Uno.Sdk/6.3.28) zu verwenden.

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
