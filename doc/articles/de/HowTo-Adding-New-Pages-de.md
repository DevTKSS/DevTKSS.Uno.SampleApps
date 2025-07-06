---
uid: DevTKSS.Uno.Setup.HowTo-AddingNewPages.de
---

# Anleitung: Hinzufügen einer Seite

In dieser Anleitung werden wir zusammen eine neue Seite mit Beispielinhalt zu unserer Uno App hinzufügen.

1. **Neues Element hinzufügen:**
   1. Klicke hierzu mit der rechten Maustaste auf den Ordner **Presentation** rechts im Projektmappen-Browser
   2. Wähle **Hinzufügen** aus
   3. Und klicke dann auf **Neues Element**

   ![Hinzufügen-neues-Element-zu-Projektmappe](../.attachments/Adding-new-Item-to-sln-de.png)

2. **Seiten  Element erstellen:**
   1. Wähle oben in der Liste das Element **`Page (Uno Platform)`** aus und gebe diesem einen Namen mit der Endung Page. Beispielsweise: `SamplePage.xaml`. Diese Endung ist zwingend erforderlich für Uno Anwendungen.
   2. Klicke nun noch auf **Hinzufüge**.

   ![Hinzufügen-neues-Element-Seite](../.attachments/Adding-new-Item-Page-de.png)

## Hinzufügen von Beispiel Inhalt

Um nun auf der Seite, auch zu sehen, dass wir uns auch auf der gewünschten Seite befinden, fügen wir nun noch einen einfachen Beispiel Inhalt hinzu:

```xml
<Page x:Class="UnoApp2.Presentation.HelloWorldPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:UnoApp2.Presentation"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      mc:Ignorable="d"
      Background="{ThemeResource BackgroundBrush}">
    <Grid>
        <TextBlock Text="Hello World"
                    HorizontalTextAlignment="Center"
                    VerticalAlignment="Center" />
    </Grid>
</Page>
```

Somit wird diese Seite im Endeffekt der Text `Hello World` in diesem Fall angezeigt werden. Dir steht es natürlich frei, jeden beliebigen Inhalt zu verwenden.

---
