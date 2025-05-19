---
uid: DevTKSS.Uno.SamplesApps.MvuxGallery.XamlNavigation
---
# Navigieren via Xaml in Uno Apps

Jede Anwendung, die mehr als eine einzige Seite umfasst oder eben nicht vollkommen überladen ist, braucht eine vernünftige "Navigation".

Grundlegend enthält es die gleichen Bausteine wie man es von einer Navigation mittels Landkarte und Co kennt:

- **Eine Sammlung von `ViewMap`'s**, mit der wir dem Navigator mitteilen, welche Seite mit welchen Daten zusammengehört. Das kann ein ViewModel oder auch spezifischen Daten sein, wobei es dann ein `DataViewMap` element zusätzlich wird.
- **Eine hierarchisch aufgebaute `Routes` Sammlung**, mit der wir dem Navigator mitteilen, in welcher Relation die verschiedenen Routen zueinander stehen. Wenn wir keine Relation in dem Sinne haben, dann wäre es eine schlichte flache Liste, aber sagen wir mal, wir wollen eine seitliche Navigationsleiste (hierzu können wir bspw. TabBar oder NavigationView nutzen) haben, dann wird das oberste Element in dem eben diese Navigationssteuerelemente UI technisch definiert sind, zum hierarchisch übergeordneten Element auch in unseren Routes:

    ```plaintext
    - MainPage mit NavigationView
        - SecondPage
        - ThirdPage
    ```

## Voraussetzungen erfüllen

Bevor es los geht, prüft bitte mit `Uno.Check` ob eure Entwicklungs-Umgebung startklar ist. Hierzu habe ich euch eine kurze Link Sammlung zu allen dahingehenden Dokumentations-Seiten im Bereich [Getting Started](../getting-started.md) erstellt.

Solltet ihr schon eine existierende Uno Anwendung haben, prüft einfach mal in der .csproj Datei, ob ihr in der `UnoFeatures` Sammlung die Elemente `Hosting` und `Navigation` habt und fügt diese hinzu, wenn das nicht bereits der Fall sein sollte.

Des weiteren benötigt eure App.xaml.cs Datei folgende Elemente:

<!--![code-csharp[](../../../src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs?highlight=L19-L23,L96,L110,L113-L115,L124-L130)] TODO: uncomment as soon as the docs are DocFx generated-->
```diff
using Uno.Resizetizer;

namespace DevTKSS.Uno.Samples.MvuxGallery;
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

+    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

+    protected async override void OnLaunched(LaunchActivatedEventArgs args)
+    {
+        var builder = this.CreateBuilder(args)
+            // Add navigation support for toolkit controls such as TabBar and NavigationView
+            .UseToolkitNavigation()
+            .Configure(host => host
+                .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
+            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

+        Host = await builder.NavigateAsync<Shell>();
    }
+
+       private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
+       {
+           views.Register(
+               new ViewMap(ViewModel: typeof(ShellModel)),
+               new ViewMap<MainPage, MainModel>(),
+               new ViewMap<SecondPage, SecondModel>()
+           );
+
+           routes.Register(
+               new RouteMap("", View: views.FindByViewModel<ShellModel>(),
+                Nested:
+                   [
+                       new ("Main", View: views.FindByViewModel<MainModel>(), IsDefault:true),
+                       new ("Second", View: views.FindByViewModel<SecondModel>()),
+                   ]
+               )
+           );
+       }
+   }

```

Den Namespace, den wir in einer Xaml-basierten Navigation in einer Uno Anwendung benötigen, ist `Uno.Extensions.Navigation.UI`, meist mit dem xmlns Namespace Identifikator `xmlns:uen=` eurer Seite dann vorzufinden.

## Navigation mittels NavigationView und Seiten

*Coming soon...*
<!-- [!Video [How-To-Uno-XamlNavigation](../images/How-To-Uno-XamlNavigation.mp4)] -->
