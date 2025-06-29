---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-CreateApp
---

# [⚙️ App-Konfiguration mit dem Visual Studio-Wizard](#tab/vs-wizard)

1. Erstelle eine neue Uno Platform App:

   1. Wähle die Vorlage **`recommended`**
   1. Ziel-Framework: **`net9.0`**
   1. Markup: **`Xaml`**
   1. Präsentation: **`MVUX`**
   1. Erweiterungen: **`Regions`**, **`DependencyInjection`**
   1. *Optional: `Toolkit`, `Localization`, `Configuration`*

2. Klicke auf **`Create`**, um die App zu generieren.

## 📺 Video Tutorial zur Konfiguration

[!Video [How To: Konfigurieren unserer Uno App Visual Studio Wizard](https://youtu.be/UGKidrvdKpQ)]

---

# [🖥️ App-Konfiguration über die CLI](#tab/cli)

1. Öffne ein Terminal und navigiere in das gewünschte Verzeichnis.
2. Führe folgenden Befehl aus, um eine neue App zu erstellen:

  ```bash
  dotnet new unoapp -o UnoApp2 -preset "recommended" -platforms "desktop" -config False -http "none" -loc False -dsp False -theme-service False
  ```

# Nächste Schritte

- [Registrierung der Routen](HowTo-RegisterRoutes.md)
