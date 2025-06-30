---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI
---

# Tutorial: Erstellen des UI mit einer `NavigationView` in Xaml

In diesem Teil des Tutorials, wollen wir uns anschauen, wie man eine einfache Seitennavigation mittels einer `NavigationView` erstellen kann.

## Voraussetzungen

Dieses Tutorial geht davon aus, dass du bereits erfolgreich deine Anwendung für Uno Extensions Navigation mithilfe bspw. der [Anleitung: Erstellen einer Uno Platform Anwendung für Extensions Navigation](./HowTo-CreateApp.md) erstellt hast oder der [Anleitung: Erweitern einer bestehenden Anwendung mit Extensions Navigation](./HowTo-UpgradeExistingApp.md) gefolgt bist.

## Basis Implementierung der NavigationView

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
   + <Grid uen:Region.Attached="True"
           utu:SafeArea.Insets="VisibleBounds">
     <Grid.RowDefinitions>
         <RowDefinition Height="*" />
         <RowDefinition Height="Auto"/>
     </Grid.RowDefinitions>
   + <NavigationView uen:Region.Attached="True"
                     Header="{Binding Title}"
                     IsPaneToggleButtonVisible="True"
                     PaneDisplayMode="Auto">
       <NavigationView.MenuItems>
         <NavigationViewItem Content="Home"
                             Icon="Home" />
         <NavigationViewItem Content="Some View"
                             Icon="AddFriend" />
       </NavigationView.MenuItems>
             <NavigationView.Content>
   +             <Grid uen:Region.Attached="True" />
             </NavigationView.Content>
         </NavigationView>
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
   +                         uen:Region.Name="Dashboard"
                             Icon="Home" />
         <NavigationViewItem Content="Some View"
   +                         uen:Region.Name="Second"
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
   +          uen:Region.Navigator="Visibility"
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

- [Füge Neue Seiten Elemente zu deiner Anwendung hinzu](../HowTo-Adding-New-Pages.md)
- [Das **Model** oder **ViewModel** Definieren](./HowTo-ModelDefinition.md)
