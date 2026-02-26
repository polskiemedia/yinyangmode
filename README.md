# YinYangMode

A small Windows tray app that toggles system light/dark theme with one click or a keyboard shortcut.

## What it does

- **Tray icon** – click to switch theme; right-click for menu (Toggle theme, Options, Exit)
- **Keyboard shortcut** – configurable hotkey (default: Ctrl+Alt+Y)
- **Run at startup** – optional launch with Windows
- **Options** – set hotkey and startup preference in the settings window

## Download ready-made exe

1. Go to [Releases](https://github.com/polskiemedia/yinyangmode/releases).
2. Download the latest `YinYangMode.exe` (or a zip containing it).
3. Run `YinYangMode.exe` (no install needed).

The release is **self-contained** – no .NET runtime required. **Windows 10/11** (x64) only.

## Build from source

**.NET 8 SDK** and **Windows** are required.

```bash
git clone git@github.com:polskiemedia/yinyangmode.git
cd YinYangMode
dotnet build -c Release
```

The executable will be in: `YinYangMode\bin\Release\net8.0-windows\YinYangMode.exe`

You can also open the solution in Visual Studio and run or build from there.

## License

MIT – see [LICENSE](LICENSE).

## Icon

Yinyang icons by [Park Jisun - Flaticon](https://www.flaticon.com/free-icons/yinyang).
