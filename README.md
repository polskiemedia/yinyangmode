# YinYangMode

A small Windows tray app that toggles system light/dark theme with one click or a keyboard shortcut.

## Features

- **Tray icon** – click to switch theme; right-click for menu (Toggle theme, Options, Exit)
- **Keyboard shortcut** – configurable hotkey (default: Ctrl+Alt+Y)
- **Run at startup** – optional launch with Windows
- **Options** – set hotkey and startup preference in the settings window

## Download and run

1. Go to [Releases](https://github.com/polskiemedia/yinyangmode/releases).
2. Download the latest `YinYangMode.exe` (or a zip containing it).
3. Run `YinYangMode.exe` locally (no install needed).

Requires **Windows 10/11** and **.NET 8 Desktop Runtime** if you don’t have it: [Download .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).

## Build from source

- **.NET 8 SDK** and **Windows** are required.

```bash
git clone git@github.com:polskiemedia/yinyangmode.git
cd YinYangMode
dotnet build -c Release
```

The executable will be in:

`YinYangMode\bin\Release\net8.0-windows\YinYangMode.exe`

Open the solution in Visual Studio and run or publish from there if you prefer.

## Publishing an exe for others

To put a single `.exe` in a release (so others can download and run it without building):

```bash
dotnet publish YinYangMode\YinYangMode.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The output will be under `YinYangMode\bin\Release\net8.0-windows\win-x64\publish\YinYangMode.exe`. Upload this file as an asset when you create a new release on GitHub.

## License

MIT – see [LICENSE](LICENSE).

## Icon

Yinyang icons by [Park Jisun - Flaticon](https://www.flaticon.com/free-icons/yinyang).
