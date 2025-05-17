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

Solltet ihr schon eine existierende Uno Anwendung haben, prüft einfach mal in der .csproj Datei, ob ihr in der `UnoFeatures` Sammlung die Elemente `Hosting` und `Navigation` habt und fügt diese hinzu, wenn das nicht bereits der Fall sein sollte.

Des weiteren benötigt eure App.xaml.cs Datei folgende Elemente:

![code-csharp[](../../../src/DevTKSS.Uno.Samples.MvuxGallery/App.xaml.cs?highlight=L19-L23,L96,L110,L113-L115,L124-L130)]

Den Namespace, den wir in einer Xaml-basierten Navigation in einer Uno Anwendung benötigen, ist `Uno.Extensions.Navigation.UI`, meist mit dem xmlns Namespace Identifikator `xmlns:uen=` eurer Seite dann vorzufinden.
<!-- ## Navigation mittels NavigationView und Seiten
[!Video [How-To-Uno-XamlNavigation](../images/How-To-Uno-XamlNavigation.mp4)] -->
