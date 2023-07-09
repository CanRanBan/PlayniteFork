using System.Reflection;

namespace Playnite;

public interface IPlayniteApplication
{
    ApplicationMode Mode { get; }
    void Quit(bool saveSettings);
    void Restart(bool saveSettings);
    void QuitAndStart(string path, string arguments, bool saveSettings = true);
}

public class PlayniteApplication
{
    public static Version CurrentVersion { get; }

    static PlayniteApplication()
    {
        CurrentVersion = Assembly.GetExecutingAssembly()!.GetName()!.Version!;
    }
}