---
uid: DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.de
---

## Tutorial: Eine neue Uno Anwendung erstellen

In dieser Anleitung lernst du, wie du eine Uno Platform Anwendung mittels des Wizard oder dotnet CLI erstellen kannst um beispielsweise das [Xaml Navigation App Tutorial](./Navigation/Extensions-Navigation-de.md) zu verfolgen.

Um dem folgen zu können, solltest du zuvor die [Anleitung Entwicklungsumgebung einrichten](xref:DevTKSS.Uno.Setup.DevelopmentEnvironment.de) durchlaufen haben.

## Video Tutorial zur Konfiguration

![How To: Konfigurieren unserer Uno App Visual Studio Wizard](https://youtu.be/UGKidrvdKpQ)

## Eine Uno App via Template erstellen und konfigurieren

Im folgenden wirst du lernen, wie du eine Uno App konfigurieren kannst, indem du die gewünschten Optionen auswählst. Du kannst entweder den Visual Studio Wizard verwenden oder das dotnet CLI Tool nutzen. Bei letzterem empfiehlt es sich, den [Web Wizard](https://new.platform.uno/) zu besuchen, um die Konfiguration zu erleichtern und den passenden `dotnet new` Command zu erhalten!

### [Visual Studio 2022](#tab/vs-wizard)

#### Template auswählen

1. Öffne Visual Studio 2022 und wähle im Startfenster **"Neues Projekt erstellen"** aus.
2. Suche nach dem Template **"Uno App"** und wähle es aus. Klicke auf **"Weiter"**.

   ![select-template](../.attachments/select-template-de.png)

3. Gib deinem Projekt einen Namen und aktiviere die Option **"Projekt im selben Verzeichnis wie die Lösung erstellen"**. Anschließend klicke auf **"Erstellen"**.

   ![place-project-in-sln](../.attachments/place-project-in-sln-de.png)

#### Der Template Wizard

**Wähle die folgenden Optionen im Visual Studio Wizard aus, um deine App zu konfigurieren:** *(am beispiel des Xaml Navigation App Tutorials)*

1. Verwende das Preset **`recommended`**
1. Ziel-Framework: **`net9.0`**

1. Als `Platform` wähle mindestens **Desktop** bzw. **Skia Desktop** aus.

1. Markup: **`Xaml`**

   ![select-Xaml](../.attachments/select-xaml.png)

1. Präsentation: **`MVUX`**

   ![select-MVUX](../.attachments/select-presentation-mvux.png)

1. Wähle das **Material Design Theme** unter **Themes** aus.

    ![select-theme-optional-themeservice](../.attachments/select-theme-optional-themeservice.png)

    > [!TIP]
    > Hier ist standardmäßig auch **ThemeService** angewählt, damit könntest du später dann auch zwischen hell und dunklem UI wechseln, der wird hier nicht direkt benötigt, kannst du aber wenn du möchtest drin lassen.

1. Erweiterungen: **`Regions`**, **`DependencyInjection`**

   ![select-extensions](../.attachments/select-regions-di-optional-localization.png)

1. *(Optional)* wähle das **Uno Toolkit** aus.

    ![select-toolkit-optional-vscode-debugging](../.attachments/select-toolkit-optional-vscode-debugging.png)

    > [!TIP]
    > Wenn du dir offen lassen möchtest, später in Visual Studio Code zu entwickeln, solltest du hier auch `Visual Studio Code Debugging` auswählen.

1. Klicke nun zum Schluss auf **`Create`**, um die App zu generieren.

### [Das dotnet CLI Tool](#tab/dotnet-cli)

1. Öffne optional in deinem Browser den [Uno Platform Web Wizard](https://new.platform.uno/), um die Konfiguration zu erleichtern und den passenden `dotnet new` Command zu erhalten. Alternativ kannst du alle möglichen Optionen jederzeit mittels `dotnet new unoapp --help` im Terminal einsehen!
1. Öffne ein Terminal und navigiere in das gewünschte Verzeichnis.
1. Mit dem nachfolgenden Befehl, erhältst du die Mindestkonfiguration um eine neue App für das [**Xaml Navigation App Tutorial**](./Navigation/Extensions-Navigation-de.md) zu erstellen:

   ```bash
   dotnet new unoapp -o XamlNavigationApp -preset "recommended" -platforms "desktop" -config False -http "none" -loc False -dsp False -theme-service False
   ```

   Alternativ, wenn du alle im Video gezeigten Optionen nutzen möchtest, kannst du folgenden Befehl verwenden:

   ```bash
   dotnet new unoapp -o XamlNavigationApp -preset "recommended" -platforms "desktop" -http "none"
   ```

---

