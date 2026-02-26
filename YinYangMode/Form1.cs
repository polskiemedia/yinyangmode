using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace YinYangMode;

public partial class Form1 : Form
{
    private const int WM_HOTKEY = 0x0312;
    private const int HOTKEY_ID = 1;

    [Flags]
    private enum HotkeyModifiers : uint
    {
        None = 0,
        Alt = 0x1,
        Control = 0x2,
        Shift = 0x4,
        Win = 0x8
    }

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    private static readonly IntPtr HWND_BROADCAST = new(0xFFFF);
    private const uint WM_SETTINGCHANGE = 0x001A;
    private const uint SMTO_ABORTIFHUNG = 0x0002;

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, UIntPtr wParam, string lParam, uint fuFlags, uint uTimeout, out UIntPtr lpdwResult);

    public Form1()
    {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        Hide();
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        InitializeHotkeyControls();
        LoadSettings();
        RegisterGlobalHotkey();
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
        {
            ToggleTheme();
        }

        base.WndProc(ref m);
    }

    private void notifyIcon_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ToggleTheme();
        }
    }

    private void trayMenuToggleItem_Click(object? sender, EventArgs e)
    {
        ToggleTheme();
    }

    private void trayMenuOptionsItem_Click(object? sender, EventArgs e)
    {
        if (Visible)
        {
            Activate();
        }
        else
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }

    private void trayMenuExitItem_Click(object? sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        UnregisterHotKey(Handle, HOTKEY_ID);
        Environment.Exit(0);
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        SaveSettings();
        RegisterGlobalHotkey();
        Hide();
    }

    private void buttonCancel_Click(object? sender, EventArgs e)
    {
        LoadSettings();
        Hide();
    }

    private void InitializeHotkeyControls()
    {
        comboModifiers.Items.Clear();
        comboModifiers.Items.Add(new ComboItem("Ctrl + Alt", HotkeyModifiers.Control | HotkeyModifiers.Alt));
        comboModifiers.Items.Add(new ComboItem("Ctrl + Shift", HotkeyModifiers.Control | HotkeyModifiers.Shift));
        comboModifiers.Items.Add(new ComboItem("Alt + Shift", HotkeyModifiers.Alt | HotkeyModifiers.Shift));
        comboModifiers.Items.Add(new ComboItem("Ctrl + Alt + Shift", HotkeyModifiers.Control | HotkeyModifiers.Alt | HotkeyModifiers.Shift));

        comboKey.Items.Clear();
        for (var c = 'A'; c <= 'Z'; c++)
        {
            comboKey.Items.Add(c.ToString());
        }

        if (comboModifiers.Items.Count > 0)
        {
            comboModifiers.SelectedIndex = 0;
        }

        if (comboKey.Items.Count > 0)
        {
            comboKey.SelectedItem = "Y";
        }
    }

    private void LoadSettings()
    {
        using var key = Registry.CurrentUser.CreateSubKey(@"Software\YinYangMode");
        var modifiersValue = (int?)key?.GetValue("HotkeyModifiers") ?? (int)(HotkeyModifiers.Control | HotkeyModifiers.Alt);
        var keyValue = (int?)key?.GetValue("HotkeyKey") ?? (int)Keys.Y;
        var runAtStartup = ((int?)key?.GetValue("RunAtStartup") ?? 0) == 1;

        var modifiers = (HotkeyModifiers)modifiersValue;
        SelectModifiers(modifiers);
        SelectKey((Keys)keyValue);

        checkRunAtStartup.Checked = runAtStartup;
        UpdateRunAtStartup(runAtStartup);
    }

    private void SaveSettings()
    {
        var modifiers = GetSelectedModifiers();
        var key = GetSelectedKey();
        var runAtStartup = checkRunAtStartup.Checked;

        using var keyReg = Registry.CurrentUser.CreateSubKey(@"Software\YinYangMode");
        keyReg?.SetValue("HotkeyModifiers", (int)modifiers, RegistryValueKind.DWord);
        keyReg?.SetValue("HotkeyKey", (int)key, RegistryValueKind.DWord);
        keyReg?.SetValue("RunAtStartup", runAtStartup ? 1 : 0, RegistryValueKind.DWord);

        UpdateRunAtStartup(runAtStartup);
    }

    private void UpdateRunAtStartup(bool enabled)
    {
        using var runKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

        if (enabled)
        {
            runKey?.SetValue("YinYangMode", Application.ExecutablePath);
        }
        else
        {
            if (runKey?.GetValue("YinYangMode") != null)
            {
                runKey.DeleteValue("YinYangMode");
            }
        }
    }

    private void RegisterGlobalHotkey()
    {
        UnregisterHotKey(Handle, HOTKEY_ID);

        var modifiers = GetSelectedModifiers();
        var key = GetSelectedKey();

        if (modifiers == HotkeyModifiers.None || key == Keys.None)
        {
            return;
        }

        RegisterHotKey(Handle, HOTKEY_ID, (uint)modifiers, (uint)key);
    }

    private HotkeyModifiers GetSelectedModifiers()
    {
        if (comboModifiers.SelectedItem is ComboItem item)
        {
            return item.Modifiers;
        }

        return HotkeyModifiers.Control | HotkeyModifiers.Alt;
    }

    private Keys GetSelectedKey()
    {
        if (comboKey.SelectedItem is string s && Enum.TryParse<Keys>(s, out var key))
        {
            return key;
        }

        return Keys.Y;
    }

    private void SelectModifiers(HotkeyModifiers modifiers)
    {
        for (var i = 0; i < comboModifiers.Items.Count; i++)
        {
            if (comboModifiers.Items[i] is ComboItem item && item.Modifiers == modifiers)
            {
                comboModifiers.SelectedIndex = i;
                return;
            }
        }
    }

    private void SelectKey(Keys key)
    {
        var keyString = key.ToString();
        if (comboKey.Items.Contains(keyString))
        {
            comboKey.SelectedItem = keyString;
        }
    }

    private void ToggleTheme()
    {
        const string personalizePath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        using var key = Registry.CurrentUser.CreateSubKey(personalizePath);
        if (key == null)
        {
            return;
        }

        var current = (int?)key.GetValue("AppsUseLightTheme") ?? 1;
        var newValue = current == 1 ? 0 : 1;

        key.SetValue("AppsUseLightTheme", newValue, RegistryValueKind.DWord);
        key.SetValue("SystemUsesLightTheme", newValue, RegistryValueKind.DWord);

        NotifyThemeChange();
    }

    private static void NotifyThemeChange()
    {
        _ = SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, UIntPtr.Zero, "ImmersiveColorSet", SMTO_ABORTIFHUNG, 2000, out _);
    }

    private sealed class ComboItem
    {
        public string Text { get; }
        public HotkeyModifiers Modifiers { get; }

        public ComboItem(string text, HotkeyModifiers modifiers)
        {
            Text = text;
            Modifiers = modifiers;
        }

        public override string ToString() => Text;
    }
}
