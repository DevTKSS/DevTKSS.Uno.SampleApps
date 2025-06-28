---
uid: DevTKSS.Setup.DevelopmentEnvironment.de
---

# 🛠️ Anleitung: Entwicklungsumgebung für Uno Platform Apps einrichten

Um mit der Entwicklung von Uno Platform Apps zu starten, prüfe bitte ob du folgende Schritte erledigt hast.

> [!TIP]
> Ab dem 6.0 Release des Uno.Sdk bzw. der zugehörigen Visual Studio Extension kann das nachfolgend genutzte Tool `Uno.Check` (CLI Name `uno-check`) hieraus in den meisten Fällen deine Entwicklungsumgebung für alle Endgeräte prüfen. Dennoch ist immer sinnvoll sich einmal die zugehörige Dokumentation durchzulesen um auf etwaige Fehlermeldungen adäquat reagieren zu können.

## Videoanleitung

[!Video [How To: Einrichten unserer Uno Platform Entwicklungsumgebung](https://youtu.be/oI6IZVOeQBI)]

> [!NOTE]
> Die aktuellste Anleitung hierfür findest du immer im offiziellen [Quick Start Guide](https://platform.uno/docs/articles/get-started.html) von Uno Platform.

---

## Checkliste zur Einrichtung

- **Installiere das neueste .NET SDK**\
  Download unter [dotnet.microsoft.com](https://dotnet.microsoft.com/)

- **Wähle und installiere deine bevorzugte IDE**

> [!NOTE]
> In diesem Guide wird Visual Studio 2022 Community Edition verwendet. Solltest du mit Rider oder Visual Studio Code arbeiten, informiere dich bitte im zuvor verlinkten Quick Start Guide über etwaige Abweichungen!

- **Installiere die Uno Platform-Erweiterung**\
  Erhältlich im [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=nventive.unoplatform)

<!-- - **Installiere **``** über die Kommandozeile**

  ```bash
  dotnet tool install -g Uno.Check
  ```

- **Starte **``**, um deine Umgebung zu prüfen**

  ```bash
  uno-check
  ```

  > ℹ️ *Dieses Tool hilft dir, fehlende Workloads zu installieren oder Probleme zu beheben, damit du sofort loslegen kannst.* -->

- **Optionen zur Konfiguration entdecken**

  - Mehr Infos in der [Uno.Check Dokumentation](https://platform.uno/docs/articles/external/uno.check/doc/configuring-uno-check.html)\

  - Oder gib `uno-check -h` im Terminal ein, um alle Optionen zu sehen.

- **Probleme bei der Einrichtung?**\
  Sieh dir den [Troubleshooting Guide](https://platform.uno/docs/articles/external/uno.check/doc/troubleshooting-uno-check.html) an.

---

## 🧪 Was du als Nächstes tun solltest

Sobald deine Umgebung eingerichtet ist, empfehlen wir dir, mindestens den [Counter Workshop](https://platform.uno/docs/articles/getting-started/counterapp/get-started-counter.html) durchzuführen. Dabei lernst du unter anderem:

- 📁 Die Struktur einer Uno-App
- 🖼️ Den Umgang mit Assets (Bilder/Icons) über **Uno.Resizetizer**
- 🔗 Die Verwendung von Commands und Bindings

> [!TIPP]
> Abhängig vom Tutorial, das du anschließend machen möchtest, solltest du im Workshop die passende Variante auswählen:
>
> - Wähle zwischen **XAML** oder **C#** als Markup
> - Und zwischen **MVVM** oder **MVUX** als `Presentation` deiner Anwendung.

---

Viel Spaß bei den nachfolgenden Tutorials! 🚀
