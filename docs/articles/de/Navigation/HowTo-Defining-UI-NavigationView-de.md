---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.de
---

# Tutorial: Erstellen des UI mit einer `NavigationView` in Xaml

In diesem Teil des Tutorials, wollen wir uns anschauen, wie man eine einfache Seitennavigation mittels einer `NavigationView` erstellen kann.

**Was zuvor geschah...**

Wir haben uns nun zuvor im Intro angeschaut, was wir mit der `Uno.Extensions.Navigation` und der `NavigationView` alles machen können und im anschluss das Setup der Anwendung angepasst oder diese erstellt. Nun wollen wir uns anschauen wie man dann dann auch umsetzen kann!

## Tutorial Video: Navigation mit `NavigationView` in MVUX und XAML

In diesem Video werden wir uns zusammen anschauen, wie du ein `NavigationView`-Steuerelement in einer XAML-Markup-App einrichtest und verwendest. Wir werden die Navigation zwischen verschiedenen Seiten implementieren und dabei die MVUX-Prinzipien anwenden. Den Code kannst du dabei direkt aus dem Code hierunter kopieren und in deine Anwendung einfügen, wenn du möchtest, aber aus eigener Erfahrung heraus hilft es dir mehr, den Code selber zu schreiben und dabei zuzuschauen, wie es funktioniert. So kannst du auch besser verstehen, was du tust und warum.

![Navigation-in-Xaml-und-Mvux-mit-Navigation-View](https://youtube.com/embed/knt2oOjHH30)

## Implementierung der NavigationView

Wir werden zuerst einmal eine einfache `NavigationView` hierfür auf der `MainPage` der Anwendung hinzufügen. Dort sollte bisher bereits ein `Grid` mit einem `StackPanel` sein, wenn du eine Anwendung vom Template erstellt hast.

Von diesem Ausgangspunkt, entferne zunächst das `StackPanel` inklusive der darin enthaltenen Steuerelemente und füge anstelle dessen diese einfache Definition der `NavigationView` ein:

```xml
<Grid utu:SafeArea.Insets="VisibleBounds">
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <NavigationView Header="{Binding Title}"
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
        <NavigationView.MenuItems>
            <NavigationViewItem Content="Home"
                                Icon="Home" />
            <NavigationViewItem Content="Some View"
                                Icon="AddFriend" />
        </NavigationView.MenuItems>
        <NavigationView.Content>
            <Grid />
        </NavigationView.Content>
    </NavigationView>
</Grid>
```

> [!NOTE]
> Wenn deine Anwendung nicht das Uno Toolkit Feature enthält, kannst du das `utu:SafeArea.Insets="VisibleBounds">` in der ersten Zeile einfach entfernen bzw. weg lassen.

## Namespaces und erweiterte Eigenschaften

Nun wollen wir die von der Extension ermöglichten Eigenschaften, sogenannte `Attached Properties` hinzufügen.

1. Hierzu füge zuerst im oberen Bereich deiner Seite `xmlns:uen="using:Uno.Extensions.Navigation.UI` der Sammlung hinzu.
1. Anschließend füge sowohl in den Eigenschaften des `Grid`, als auch in denen der `NavigationView` selber, aber auch in dem `Grid` im `Content`-Bereich der `NavigationView`, die Eigenschaft `uen:Region.Attached="True"` hinzu. Hiermit teilen wir dem Navigator mit, dass innerhalb dieses Steuerelements eine Navigationsroute bzw. verschachtelte Navigationsdarstellung erwartet und verwendet werden soll.

    Das sollte dann so aussehen:

    ```diff
    +<Grid uen:Region.Attached="True"
        utu:SafeArea.Insets="VisibleBounds">
        <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
    + <NavigationView uen:Region.Attached="True"
                    Header="{Binding Title}" <-- Optionale Bindung an die Title Eigenschaft im ViewModel
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Home"
                            Icon="Home" />
        <NavigationViewItem Content="Some View"
                            Icon="AddFriend" />
    </NavigationView.MenuItems>
        <NavigationView.Content>
    +     <Grid uen:Region.Attached="True" />
        </NavigationView.Content>
    </NavigationView>
    </Grid>
    ```

1. Nun fügen wir mittels `uen:Region.Name="..."` ein paar Routen Bezeichner Namen ein.

    ```diff
    <Grid uen:Region.Attached="True"
        utu:SafeArea.Insets="VisibleBounds">
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <NavigationView uen:Region.Attached="True"
                    Header="{Binding Title}"
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Home"
    +                       uen:Region.Name="Dashboard"
                            Icon="Home" />
        <NavigationViewItem Content="Some View"
    +                       uen:Region.Name="Second"
                            Icon="AddFriend" />
    </NavigationView.MenuItems>
            <NavigationView.Content>
                <Grid uen:Region.Attached="True" />
            </NavigationView.Content>
        </NavigationView>
    ```

1. Zu guter Letzt benötigt das `Grid`, welches wir für die Navigation des Content der `NavigationView` verwenden wollen nun noch zwei letzte weitere und sehr wichtige Eigenschaften setzen, ohne welche es gut möglich ist, dass unser Vorhaben misslingt.

   Wir müssen:

   1. `uen:Region.Navigator="Visibility"` anhängen
   2. die Eigenschaft `Visibility` auf sichtbar setzen

   Und das geht so:

    ```diff
    <NavigationView.Content>
    <Grid uen:Region.Attached="True"
    +      uen:Region.Navigator="Visibility"
            Visibility="Visible" />
    </NavigationView.Content>
    ```

   **Als kurze Erklärung zu den hinzugefügten Eigenschaften dort:**

   - **Die `Visibility`-Eigenschaft:**

     Mit setzen der  sorgen wir dafür, dass der Inhalt dieser Route zu Beginn erst einmal Sichtbar ist.

   - **Der Navigator Bezeichner Name:**

     Hiermit sagen wir den Funktionen, welche uns die Extension zur Verfügung stellt, dass wir die Elemente, welche hiermit gekennzeichnet werden Sichtbar und Unsichtbar machen wollen, wenn wir die zugehörige Navigationsroute aufrufen.

     *Die Namensgebung ist also keineswegs Zufall!*

     >[!NOTE]
     > Der "Visibility"-Navigator ist gemäß der Dokumentation verfügbare Bezeichner für diese Eigenschaft.

## Nächste Schritte

Nun haben wir die `NavigationView` eingerichtet und können diese nun auch verwenden, um zwischen den Seiten zu navigieren. Im nächsten Schritt werden wir uns anschauen, wie wir die Routen definieren und die Navigation zwischen den Seiten implementieren können.

[**Routen definieren und Navigation implementieren**](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de)
