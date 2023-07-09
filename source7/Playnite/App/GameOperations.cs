using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Playnite;

public static class GameOperations
{
    private static readonly StringComparison OrdinalIgnoreCase = StringComparison.OrdinalIgnoreCase;
    private static readonly StringComparison Ordinal = StringComparison.Ordinal;
    private static readonly GameVariant EmptyVariant = new();

    public static ImportableGame? GetGameFromExecutable(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Cannot create game from executable, {path} not found.");
        }

        var game = new ImportableGame();
        if (path.EndsWith(".lnk", OrdinalIgnoreCase))
        {
            var prog = Programs.GetLnkShortcutData(path);
            if (prog.Path.IsNullOrEmpty())
            {
                return null;
            }

            var fileInfo = new FileInfo(prog.Path);
            game.GameId = path.MD5();
            game.Name = Path.GetFileNameWithoutExtension(path);
            game.InstallDirectory = prog.WorkDir.IsNullOrEmpty() ? fileInfo.Directory!.FullName : prog.WorkDir;
            game.Actions = new List<GameAction>
            {
                new FileGameAction
                {
                    WorkingDir = ExpandableVariables.InstallationDirectory,
                    Path = fileInfo.FullName.Replace(
                        game.InstallDirectory.EndWithDirSeparator(),
                        ExpandableVariables.InstallationDirectory.EndWithDirSeparator(),
                        OrdinalIgnoreCase),
                    Arguments = prog.Arguments,
                    IsPlayAction = true,
                    Name = game.Name
                }
            };

            if (!prog.Icon.IsNullOrEmpty())
            {
                var iconPath = Regex.Replace(prog.Icon, @",\d+$", "");
                if (File.Exists(iconPath))
                {
                    game.Icon = new MetadataFile(iconPath);
                }
            }
        }
        else if (path.EndsWith(".url", OrdinalIgnoreCase))
        {
            var urlData = IniFile.Parse(File.ReadAllLines(path));
            var shortcut = urlData["InternetShortcut"];
            if (shortcut == null)
            {
                throw new Exception("URL file doesn't have shortcut definition section.");
            }

            game.Name = Path.GetFileNameWithoutExtension(path);
            var icon = shortcut["IconFile"];
            if (icon != null)
            {
                game.Icon = new MetadataFile(icon);
            }

            game.Actions = new List<GameAction>
            {
                new UrlGameAction()
                {
                    Url = shortcut["URL"],
                    IsPlayAction = true,
                    Name = game.Name
                }
            };
        }
        else
        {
            var file = new FileInfo(path);
            var versionInfo = FileVersionInfo.GetVersionInfo(path);
            var programName = !string.IsNullOrEmpty(versionInfo.ProductName?.Trim()) ? versionInfo.ProductName : new DirectoryInfo(file.DirectoryName!).Name;
            game.Name = programName;
            game.InstallDirectory = file.DirectoryName!;
            game.Actions = new List<GameAction>
            {
                new FileGameAction()
                {
                    WorkingDir = ExpandableVariables.InstallationDirectory,
                    Path = file.FullName.Replace(
                        game.InstallDirectory.EndWithDirSeparator(),
                        ExpandableVariables.InstallationDirectory.EndWithDirSeparator(),
                        OrdinalIgnoreCase),
                    IsPlayAction = true,
                    Name = game.Name
                }
            };
        };

        game.IsInstalled = true;
        return game;
    }

    public static GameVariant ExpandVariables(
        this GameVariant variant,
        Game game,
        string? emulatorDir = null)
    {
        var v = variant.GetCopy();
        if (!v.InstallDirectory.IsNullOrWhiteSpace())
        {
            v.InstallDirectory = game.StringExpand(EmptyVariant, v.InstallDirectory, true, emulatorDir);
        }

        foreach (var rom in v.Roms ?? Enumerable.Empty<GameRom>())
        {
            if (rom.Path.IsNullOrWhiteSpace())
            {
                continue;
            }

            rom.Path = game.StringExpand(EmptyVariant, rom.Path, true, emulatorDir);
        }

        return v;
    }

    //public static string ExpandVariables(
    //    this Game game,
    //    GameVariant variant,
    //    string inputString,
    //    bool fixSeparators = false,
    //    string? emulatorDir = null,
    //    string? romPath = null)
    //{
    //    var g = game.ExpandGame(fixSeparators, emulatorDir, romPath);
    //    return StringExpand(g, variant, inputString, fixSeparators, emulatorDir, romPath);
    //}

    private static string StringExpand(
        this Game game,
        GameVariant variant,
        string inputString,
        bool fixSeparators = false,
        string? emulatorDir = null,
        string? romPath = null)
    {
        if (inputString.IsNullOrWhiteSpace() || !inputString.Contains('{', Ordinal))
        {
            return inputString;
        }

        var result = inputString;
        if (!variant.InstallDirectory.IsNullOrWhiteSpace())
        {
            result = result.Replace(ExpandableVariables.InstallationDirectory, variant.InstallDirectory, OrdinalIgnoreCase);
            var dirSplit = variant.InstallDirectory.Split(Paths.DirectorySeparators, StringSplitOptions.RemoveEmptyEntries);
            if (dirSplit.Length > 1)
            {
                result = result.Replace(ExpandableVariables.InstallationDirName, dirSplit[^1], OrdinalIgnoreCase);
            }
        }

        if (romPath.IsNullOrWhiteSpace() && variant.Roms.HasItems())
        {
            romPath = variant.Roms[0].Path;
        }

        if (!romPath.IsNullOrWhiteSpace())
        {
            result = result.Replace(ExpandableVariables.ImagePath, romPath, OrdinalIgnoreCase);
            result = result.Replace(ExpandableVariables.ImageNameNoExtension, Path.GetFileNameWithoutExtension(romPath), OrdinalIgnoreCase);
            result = result.Replace(ExpandableVariables.ImageName, Path.GetFileName(romPath), OrdinalIgnoreCase);
        }

        result = result.Replace(ExpandableVariables.PlayniteDirectory, PlaynitePaths.ProgramDir, OrdinalIgnoreCase);
        result = result.Replace(ExpandableVariables.Name, game.Name, OrdinalIgnoreCase);
        result = result.Replace(ExpandableVariables.PluginId, variant.PluginId.ToString(), OrdinalIgnoreCase);
        result = result.Replace(ExpandableVariables.GameId, variant.GameId, OrdinalIgnoreCase);
        result = result.Replace(ExpandableVariables.DatabaseId, game.Id.ToString(), OrdinalIgnoreCase);
        result = result.Replace(ExpandableVariables.EmulatorDirectory, emulatorDir ?? string.Empty, OrdinalIgnoreCase);

        // TODO: should support all fields maybe?
        //var plats = game.Platforms;
        //if (plats.HasItems())
        //{
        //    result = result.Replace(ExpandableVariables.Platform, plats?[0].Name);
        //}

        return fixSeparators ? Paths.FixSeparators(result) : result;
    }

    public static FileGameAction ExpandVariables(this FileGameAction action, Game game, GameVariant variant)
    {
        action = action.GetCopy();
        variant = variant.ExpandVariables(game);

        if (!action.Path.IsNullOrWhiteSpace())
        {
            action.Path = game.StringExpand(variant, action.Path);
        }

        if (!action.Arguments.IsNullOrWhiteSpace())
        {
            action.Arguments = game.StringExpand(variant, action.Arguments);
        }

        if (!action.WorkingDir.IsNullOrWhiteSpace())
        {
            action.WorkingDir = game.StringExpand(variant, action.WorkingDir, true);
        }

        if (!action.TrackingOptions.TrackingPath.IsNullOrWhiteSpace())
        {
            action.TrackingOptions.TrackingPath = game.StringExpand(variant, action.TrackingOptions.TrackingPath, true);
        }

        return action;
    }

    public static UrlGameAction ExpandVariables(this UrlGameAction action, Game game, GameVariant variant)
    {
        action = action.GetCopy();
        variant = variant.ExpandVariables(game);

        if (!action.Url.IsNullOrWhiteSpace())
        {
            action.Url = game.StringExpand(variant, action.Url);
        }

        if (!action.TrackingOptions.TrackingPath.IsNullOrWhiteSpace())
        {
            action.TrackingOptions.TrackingPath = game.StringExpand(variant, action.TrackingOptions.TrackingPath, true);
        }

        return action;
    }
}