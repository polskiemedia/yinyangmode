namespace YinYangMode;

internal static class Program
{
    // Application icon: Yinyang icons by Park Jisun - Flaticon (https://www.flaticon.com/free-icons/yinyang)
    private const string SingleInstanceMutexName = "Global\\YinYangMode_SingleInstance";

    [STAThread]
    static void Main()
    {
        using var mutex = new Mutex(false, SingleInstanceMutexName, out var createdNew);
        if (!createdNew || !mutex.WaitOne(TimeSpan.Zero))
        {
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}