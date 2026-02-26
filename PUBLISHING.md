# Publishing the exe to GitHub Releases

Instructions for maintainers: how to build a single-file exe and publish it as a GitHub Release.

## 1. Build the single-file exe

From the repo root:

```powershell
dotnet publish YinYangMode\YinYangMode.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## 2. Locate the exe

Path: `YinYangMode\bin\Release\net8.0-windows\win-x64\publish\YinYangMode.exe`

## 3. Create a GitHub Release and attach the exe

- Open: https://github.com/polskiemedia/yinyangmode/releases
- Click **"Draft a new release"** (or **"Create a new release"**)
- **Choose a tag** (e.g. `v1.0.0`) and optionally a title like `v1.0.0`
- In **"Attach binaries"**, drag and drop `YinYangMode.exe` (or click and select it)
- Add release notes (see example below), then click **"Publish release"**

## Example release notes

Paste into the release description:

```text
YinYangMode – tray app to switch Windows light/dark theme.

**What's in this release**
- Single-file executable (Windows x64, self-contained, no install).
- Tray icon: left-click toggles theme, right-click opens menu (Options, Exit).
- Configurable hotkey (default Ctrl+Alt+Y) and "Run at Windows startup" in Options.

**Requirements:** Windows 10/11 (x64) only. No .NET install needed (self-contained build).

**Usage:** Download `YinYangMode.exe`, run it. The window hides to the tray; use the tray icon or Options to configure.
```
