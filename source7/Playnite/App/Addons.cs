namespace Playnite;

public enum AddonLoadError
{
    None,
    Uknown,
    SDKVersion
}

public class Addons
{
    public static readonly string[] BuiltinExtensionIds = new string[]
    {
        "AmazonLibrary_Builtin",
        "BattlenetLibrary_Builtin",
        "EpicGamesLibrary_Builtin",
        "GogLibrary_Builtin",
        "HumbleLibrary_Builtin",
        "IGDBMetadata_Builtin",
        "ItchioLibrary_Builtin",
        "OriginLibrary_Builtin",
        "SteamLibrary_Builtin",
        "UplayLibrary_Builtin",
        "XboxLibrary_Builtin"
    };

    public static readonly string[] BuiltinThemeIds = new string[]
    {
        "Playnite_builtin_DefaultFullscreen",
        "Playnite_builtin_DefaultDesktop",
    };
}

public abstract class LocalAddonManifestBase
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Version { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }

    public override string? ToString()
    {
        return Name ?? base.ToString();
    }
}

public class LocalThemeManifest : LocalAddonManifestBase
{
    public string? ThemeApiVersion { get; set; }
    public ApplicationMode Mode { get; set; }
}

public enum ExtensionType
{
    General,
    Library,
    Script,
    Metadata
}
public class LocalExtensionManifest : LocalAddonManifestBase
{
    public string? Module { get; set; }
    public ExtensionType Type { get; set; }
}