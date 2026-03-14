---
uid: DevTKSS.Uno.Mvux-StateManagement.Overview.de
---
# Übersicht: Mvux State Management

## Einführung

In dieser Tutorial-Serie lernst du, wie du `ListState` und `ListFeed` in deinen Uno Platform MVUX-Apps verwendest. Diese Komponenten ermöglichen dir die reaktive Verwaltung von Listen-Daten mit automatischer UI-Aktualisierung.

## Was ist der Unterschied zwischen ListFeed und ListState?

- **`IListFeed<T>`** - Schreibgeschützte read-only Daten-Sammlungen (z.B. Server-Antworten)
  - Unterstützt `RequestRefreshAsync` oder `RefreshAsync` und den `.Selection(...)` Operator
  - Kein Support für `ForEach`-Callbacks oder direkte Item-Updates via bspw. `UpdateAllAsync(...)`

- **`IListState<T>`** - read-write Daten-Sammlungen
  - Ermöglicht direkte Aktualisierung und Key-matching Updates von Elementen mit `UpdateAllAsync(...)` oder `UpdateItemAsync(...)`
  - Unterstützt `ForEach`-Callbacks für die Verarbeitung von Elementen
  - Unterstützt `AddAsync`/`RemoveAsync`-Operationen
  - Ebenfalls kompatibel mit dem `.Selection(...)` Operator

## Tutorial-Serie

Diese Serie besteht aus zwei aufeinander aufbauenden Tutorials:

### 1. [Binding von ListState mit Selection](xref:DevTKSS.Uno.MvuxStateManagement.ListState-Selection.de)

In diesem ersten Tutorial lernst du die Grundlagen:

- Wie du ein `ListState` an eine `ListView` bindest
- Wie du den `.Selection(...)` Operator verwendest
- Wie du das ausgewählte Element in der UI anzeigst
- Unterschiede zwischen `.Async(...)` und `.Value(...)` Initialisierung

### 2. [Aktualisierung von ListState Items](xref:DevTKSS.Uno.MvuxStateManagement.Update-ListStateItems.de)

Im zweiten Tutorial erweitern wir die Funktionalität:

- Wie du Elemente in einem `ListState` bearbeitest
- Verwendung von `UpdateAllAsync(...)` mit Filterkriterien
- Einsatz von `[FeedParameter]` für saubereres State-Handling
- Warum `IListState<T>` für Aktualisierungen erforderlich ist

## Voraussetzungen

Bevor du mit diesen Tutorials beginnst, stelle sicher, dass du:

- [Anleitung: Erstellen einer Uno Platform App](xref:DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.de) abgeschlossen hast
- [Anleitung: Hinzufügen neuer Pages](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.de) abgeschlossen hast
- [Anleitung: Hinzufügen neuer MVUX Model-Klassen](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.de) abgeschlossen hast
- Grundlegendes Verständnis von Dependency Injection aus [Anleitung: Verwendung von DI im Constructor](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.de) hast

## Los geht's

Beginne mit dem ersten Tutorial: [Binding von ListState mit Selection](xref:DevTKSS.Uno.MvuxStateManagement.ListState-Selection.de)
