---
uid: DevTKSS.Uno.MvuxStateManagement.ListState.Selection.de
---
# Anleitung: Binding von ListState mit Selection

## Überblick

In diesem Beispiel zeigen wir dir, wie du ein `ListState` aus deinem Model an eine `ListView` bindest und wie du die Auswahl eines Elements verfolgst. Wir erstellen eine einfache Mitgliederlisten-Anzeige, bei der du:

- Eine Liste von Mitgliedern in einer `ListView` anzeigen kannst
- Ein Mitglied aus der `ListView` auswählen kannst
- Das ausgewählte Mitglied oben auf der Seite angezeigt bekommst

Dieses Beispiel zeigt die Grundlagen des `.Selection(...)`-Operators, der sowohl mit `IListState<T>` als auch mit `IListFeed<T>` funktioniert.

## Voraussetzungen

Bevor du mit diesem Tutorial beginnst, stelle sicher, dass du:

- [Anleitung: Erstellen einer Uno Platform App](xref:DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.de) abgeschlossen hast
- [Anleitung: Hinzufügen neuer Pages](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.de) abgeschlossen hast
- [Anleitung: Hinzufügen neuer MVUX Model-Klassen](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.de) abgeschlossen hast
- Grundlegendes Verständnis von Dependency Injection aus [Anleitung: Verwendung von DI im Constructor](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.de) hast

## Visuelle Referenz

![Mitgliederlisten UI mit Selection](../../.attachments/Binding-ListState-FeedView.png)

## Das Model Setup

Zunächst definieren wir die States, die für die Anzeige und Auswahl benötigt werden.

### Initialisierung von ListState

Es gibt zwei gängige Möglichkeiten, den `ListState<T>` zu initialisieren:

#### [Verwendung von `ListState.Async(...)`](#tab/Async)

Mit der `ListState<string>.Async(...)`-Methode kannst du eine asynchrone Methode bereitstellen, die einmal aufgerufen wird, um die anfängliche Liste der Mitglieder zu erhalten. Dies ist nützlich, wenn du Daten asynchron aus einer API oder Datenbank laden musst.

```csharp
private readonly IImmutableList<string> _listMembers = ImmutableList.Create(
    [
        "Hans",
        "Lisa",
        "Anke",
        "Tom"
    ]);

private async ValueTask<IImmutableList<string>> GetMembersAsync(CancellationToken ct)
    => _listMembers;

public IListState<string> Members => ListState<string>.Async(this, GetMembersAsync)
                                                      .Selection(SelectedMember);

public IState<string> SelectedMember => State<string>.Value(this, () => string.Empty);
```

Die Schlüsselelemente in diesem Code:

- `_listMembers` - Eine statische unveränderliche Liste, die unsere Mitgliedernamen enthält
- `GetMembersAsync(...)` - Asynchrone Methode, die die Liste zurückgibt (obwohl es sich um statische Daten handelt)
- `Members` - `IListState<string>` initialisiert über `Async(...)` mit `.Selection(...)`-Operator
- `SelectedMember` - `IState<string>`, das das aktuell ausgewählte Mitglied verfolgt

**Hinweis:** Obwohl dieser Ansatz funktioniert, erfordert er erheblichen Boilerplate-Code (Feld + asynchrone Methode + ListState-Property), selbst für statische Daten, die eigentlich kein asynchrones Laden benötigen.

#### [Verwendung von `ListState.Value(...)`](#tab/Value)

Mit der `ListState<string>.Value(...)`-Methode kannst du eine statische Liste von Mitgliedern direkt in einer einzigen Zeile bereitstellen. Dieser Ansatz reduziert den Boilerplate drastisch und eignet sich perfekt für Demonstrationszwecke oder beim Umgang mit statischen Daten.

```csharp
public IListState<string> Members => ListState<string>.Value(this,
     () => ImmutableList.Create(
        [
            "Hans",
            "Lisa",
            "Anke",
            "Tom"
        ])
    ).Selection(SelectedMember);

public IState<string> SelectedMember => State<string>.Value(this, () => string.Empty);
```

**Vorteile gegenüber dem Async-Ansatz:**

- **90% weniger Code** - Kein separates Feld oder asynchrone Methode erforderlich
- **Mehrzeilige Definition** - Klarer, lesbarer Property-Ausdruck mit ordnungsgemäßer Formatierung
- **Sofortige Klarheit** - Du kannst die Daten direkt dort sehen, wo sie definiert sind
- **Gleiche Funktionalität** - Erhält trotzdem den `.Selection(...)`-Operator und alle ListState-Features
- **Ideal für statische Daten** - Kein unnötiger asynchroner Overhead für bereits verfügbare Daten

> [!TIP]
> **Wann Value vs Async verwenden:**
>
> - **Verwende `.Value(...)`**, wenn deine Daten statisch sind, aus Konstanten stammen oder synchron berechnet werden
> - **Verwende `.Async(...)`**, wenn du tatsächlich Daten aus einer API, Datenbank abrufen oder asynchrone Operationen durchführen musst

***

## Die View (XAML)

Nachdem wir nun unser Model mit den erforderlichen States eingerichtet haben, erstellen wir die UI. Unsere UI besteht aus einem `TextBlock`, der das ausgewählte Mitglied anzeigt, und einer `ListView` zur Anzeige aller Mitglieder:

```xaml
<StackPanel Spacing="16">
    <!-- Display selected member -->
    <TextBlock
        Text="{Binding Path=SelectedMember, Mode=OneWay}"
        FontSize="24"
        FontWeight="Bold"/>

    <!-- List of all members -->
    <ListView
        ItemsSource="{Binding Path=Members}"
        SelectionMode="Single"
        Height="300"/>
</StackPanel>
```

> [!WARNING]
> Wenn du das `ListView`-Control verwendest, stelle sicher, dass du die `ItemClickCommand`-Eigenschaft der `ListView` **nicht** gleichzeitig mit dem `.Selection(...)`-Operator des `ListState` setzt, da dies das Auswahlverhalten beeinträchtigt und den State, den du zur Widerspiegelung der aktuellen Auswahl verwendest, nicht wie erwartet aktualisiert. Du musst dich für eine der beiden Optionen entscheiden.

Beachte die wichtigsten Bindings:

- `ItemsSource="{Binding Path=Members}"` - bindet an unser `IListState<string>`
- `Text="{Binding Path=SelectedMember, Mode=OneWay}"` - zeigt das ausgewählte Mitglied an

## Zusammenfassung

Dieses Beispiel demonstriert:

1. Binding von `IListState<T>` an eine `ListView` mit `.Selection(...)`-Operator (funktioniert auch mit `IListFeed<T>`)
2. Verwendung eines separaten `IState<string>` zur Verfolgung der Auswahl
3. Anzeige des ausgewählten Elements in der UI
4. Zwei Initialisierungsmethoden: `.Async(...)` für echte asynchrone Daten vs `.Value(...)` für statische Daten

Im nächsten Tutorial lernst du, wie du die ausgewählten Elemente bearbeiten und aktualisieren kannst.

- [Nächstes Tutorial: Aktualisierung von ListState Items](xref:DevTKSS.Uno.MvuxStateManagement.ListState.UpdateItems.de)
