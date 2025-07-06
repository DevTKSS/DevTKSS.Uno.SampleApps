---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-CreateApp.de
---

# Tutorial: Eine Uno Extensions Navigation Anwendung erstellen

In dieser Anleitung lernst du, wie du eine Uno Platform Anwendung mittels des Wizard oder dotnet CLI erstellen kannst.

Um dem folgen zu können, solltest du zuvor die [Anleitung Entwicklungsumgebung einrichten](xref:DevTKSS.Uno.Setup.DevelopmentEnvironment.de) durchlaufen haben.

## [⚙️ App-Konfiguration mit dem Visual Studio-Wizard](#tab/vs-wizard)

1. Öffne Visual Studio 2022
2. Erstelle ein neues Projekt und wähle die Vorlage Uno App aus
   1. Wähle das Preset **`recommended`** aus
   2. Ziel-Framework: **`net9.0`**
   3. Markup: **`Xaml`**
   4. Präsentation: **`MVUX`**
   5. Erweiterungen: **`Regions`**, **`DependencyInjection`**
   6. *Optional: `Toolkit`, `Localization`, `Configuration`*
3. Klicke auf **`Create`**, um die App zu generieren.

## [🖥️ App-Konfiguration über die CLI](#tab/cli)

1. Öffne ein Terminal und navigiere in das gewünschte Verzeichnis.
2. Führe folgenden Befehl aus, um eine neue App zu erstellen:

  ```bash
  dotnet new unoapp -o UnoApp2 -preset "recommended" -platforms "desktop" -config False -http "none" -loc False -dsp False -theme-service False
  ```

> [!TIP]
> Für mehr Konfigurationsmöglichkeiten für die Nutzung von `dotnet new`, kannst du am besten den [Web Wizard](https://new.platform.uno/) besuchen, welcher dir mit dem selben UI des Visual Studio Wizards während der Konfiguration, anschließend den passenden `dotnet new` Command gibt.

---

## 📺 Video Tutorial zur Konfiguration

[!Video [How To: Konfigurieren unserer Uno App Visual Studio Wizard](https://youtu.be/UGKidrvdKpQ)]

## Nächste Schritte

- [Registrierung der Routen](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.de)
