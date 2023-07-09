using System.IO;

namespace Playnite;

public partial class Library
{
    public static bool GetMigrationRequired(string libraryDir)
    {
        if (libraryDir.IsNullOrWhiteSpace())
        {
            throw new ArgumentNullException(nameof(libraryDir));
        }

        var fullPath = GetFullDbPath(libraryDir);
        var settingsPath = Path.Combine(fullPath, settingsFileName);
        if (!File.Exists(settingsPath))
        {
            return false;
        }

        var st = Serialization.FromJson<LibrarySettings>(FileSystem.ReadFileAsStringSafe(settingsPath));
        if (st == null)
        {
            return false;
        }
        else
        {
            return st.Version < FormatVersion;
        }
    }

    private static void SaveSettingsToDbPath(LibrarySettings settings, string dbDir)
    {
        var settingsPath = Path.Combine(dbDir, settingsFileName);
        FileSystem.WriteStringToFileSafe(settingsPath, Serialization.ToJson(settings));
    }

    internal static LibrarySettings? GetSettingsFromDbPath(string dbDir)
    {
        var settingsPath = Path.Combine(dbDir, settingsFileName);
        return Serialization.FromJson<LibrarySettings>(FileSystem.ReadFileAsStringSafe(settingsPath));
    }
}
