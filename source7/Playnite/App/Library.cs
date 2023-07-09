using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Playnite;

public partial class Library : IDisposable
{
    public class LibrarySettings
    {
        public int Version { get; set; }
    }

    private static readonly ILogger logger = LogManager.GetLogger();

    private readonly Dictionary<string, CustomSqliteDb> sqliteDbs = new();
    private const string settingsFileName = "database.json";
    public const string FilesDirName = "files";
    public const string DbFilePathPrefix = "pfile://";
    public static readonly ushort FormatVersion = 1;

    private string filesDirectoryPath => Path.Combine(LibraryDir, FilesDirName);
    private string databaseFileSettingsPath => Path.Combine(LibraryDir, settingsFileName);
    public string LibraryDir { get; private set; }
    public static Library? Instance { get; private set; }

    public HashSet<Guid> UsedDevelopers { get; } = new();
    public event EventHandler? DevelopersInUseUpdated;
    public HashSet<Guid> UsedPublishers { get; } = new();
    public event EventHandler? PublishersInUseUpdated;

    private LibrarySettings? settings;
    public LibrarySettings Settings
    {
        get
        {
            if (settings == null)
            {
                if (File.Exists(databaseFileSettingsPath))
                {
                    settings = Serialization.FromJson<LibrarySettings>(FileSystem.ReadFileAsStringSafe(databaseFileSettingsPath));
                    settings ??= new() { Version = FormatVersion };
                }
                else
                {
                    settings = new() { Version = FormatVersion };
                }
            }

            return settings;
        }

        set
        {
            settings = value;
            FileSystem.WriteStringToFileSafe(databaseFileSettingsPath, Serialization.ToJson(settings));
        }
    }

    public Library(string libraryDir)
    {
        if (libraryDir.IsNullOrWhiteSpace())
        {
            throw new Exception("Database path cannot be empty.");
        }

        LibraryDir = GetFullDbPath(libraryDir);
        var dbExists = File.Exists(databaseFileSettingsPath);
        logger.Info("Opening db " + LibraryDir);

        if (!FileSystem.CanWriteToFolder(LibraryDir))
        {
            throw new Exception($"Can't write to \"{LibraryDir}\" folder.");
        }

        FileSystem.CreateDirectory(LibraryDir);
        FileSystem.CreateDirectory(filesDirectoryPath);

        if (!dbExists)
        {
            Settings = new() { Version = FormatVersion };
        }
        else
        {
            if (Settings.Version > FormatVersion)
            {
                throw new Exception($"Database version {Settings.Version} is not supported.");
            }

            if (GetMigrationRequired(LibraryDir))
            {
                throw new Exception("Database must be migrated before opening.");
            }
        }

        LoadCollections();
        LoadUsedItems();

        // New DB setup
        if (!dbExists)
        {
            // Generate default platforms
            var platforms = Definitions.Platforms.
                Where(a => a.IgdbId != 0 && !a.Name.IsNullOrWhiteSpace()).
                Select(a => new Platform(a.Name!) { SpecificationId = a.Id });
            Platforms.Add(platforms);

            // Generate default regions
            var regions = Definitions.Regions.
                Where(a => a.DefaultImport && !a.Name.IsNullOrWhiteSpace()).
                Select(a => new Region(a.Name!) { SpecificationId = a.Id });
            Regions.Add(regions);

            // Generate default completion statuses
            var defStatuses = new CompletionStatus[]
            {
                new CompletionStatus(Loc.completion_not_played()),
                new CompletionStatus(Loc.completion_played()),
                new CompletionStatus(Loc.completion_beaten()),
                new CompletionStatus(Loc.completion_completed()),
                new CompletionStatus(Loc.completion_playing()),
                new CompletionStatus(Loc.completion_abandoned()),
                new CompletionStatus(Loc.completion_on_hold()),
                new CompletionStatus(Loc.completion_plan_to_play())
            };

            CompletionStatuses.Add(defStatuses);
            CompletionStatuses.SetSettings(new CompletionStatusSettings
            {
                DefaultStatus = defStatuses[0].Id,
                PlayedStatus = defStatuses[1].Id
            });

            // TODO
            // Generate default filter presets
            //var filters = FilterPresets as FilterPresetsCollection;
            //filters.IsEventsEnabled = false;
            //filters.Add(new FilterPreset
            //{
            //    Name = "All",
            //    ShowInFullscreeQuickSelection = true,
            //    GroupingOrder = GroupableField.None,
            //    SortingOrder = SortOrder.Name,
            //    SortingOrderDirection = SortOrderDirection.Ascending,
            //    Settings = new FilterPresetSettings()
            //});

            //filters.Add(new FilterPreset
            //{
            //    Name = "Recently Played",
            //    ShowInFullscreeQuickSelection = true,
            //    GroupingOrder = GroupableField.None,
            //    SortingOrder = SortOrder.LastActivity,
            //    SortingOrderDirection = SortOrderDirection.Descending,
            //    Settings = new FilterPresetSettings { IsInstalled = true }
            //});

            //filters.Add(new FilterPreset
            //{
            //    Name = "Favorites",
            //    ShowInFullscreeQuickSelection = true,
            //    GroupingOrder = GroupableField.None,
            //    SortingOrder = SortOrder.Name,
            //    SortingOrderDirection = SortOrderDirection.Ascending,
            //    Settings = new FilterPresetSettings { Favorite = true }
            //});

            //filters.Add(new FilterPreset
            //{
            //    Name = "Most Played",
            //    ShowInFullscreeQuickSelection = true,
            //    GroupingOrder = GroupableField.None,
            //    SortingOrder = SortOrder.Playtime,
            //    SortingOrderDirection = SortOrderDirection.Descending,
            //    Settings = new FilterPresetSettings()
            //});
        }

        Games.ItemsAdded += (_, e) => UpdateFieldsInUse(e.Items);
        Games.ItemsUpdated += (_, e) => UpdateFieldsInUse(e.Items.Select(a => a.NewData));
        Games.ItemsRemoved += (_, e) => UpdateFieldsInUse(e.Items);

        Platforms.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedPlatforms, PlatformsInUseUpdated);
        Genres.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedGenres, GenresInUseUpdated);
        Tags.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedTags, TagsInUseUpdated);
        Categories.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedCategories, CategoriesInUseUpdated);
        AgeRatings.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedAgeRatings, AgeRatingsInUseUpdated);
        Series.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedSeries, SeriesInUseUpdated);
        Regions.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedRegions, RegionsInUseUpdated);
        GameSources.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedGameSources, GameSourcesInUseUpdated);
        GameFeatures.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedGameFeatures, GameFeaturesInUseUpdated);
        CompletionStatuses.ItemsRemoved += (_, e) => UpdateRemovedFieldsInUse(e.Items, UsedCompletionStatuses, CompletionStatusesInUseUpdated);
        Companies.ItemsRemoved += (_, e) =>
        {
            UpdateRemovedFieldsInUse(e.Items, UsedCompanies, CompaniesInUseUpdated);
            UpdateRemovedFieldsInUse(e.Items, UsedDevelopers, DevelopersInUseUpdated);
            UpdateRemovedFieldsInUse(e.Items, UsedPublishers, PublishersInUseUpdated);
        };
    }

    private void Games_ItemsRemoved(object? sender, ItemsRemovedEventArgs<Game> e)
    {
    }

    private void UpdateFieldsInUse(IEnumerable<Game> games)
    {
        foreach (var game in games)
        {
            UpdateFieldsInUse(game.PlatformIds, UsedPlatforms, PlatformsInUseUpdated);
            UpdateFieldsInUse(game.GenreIds, UsedGenres, GenresInUseUpdated);
            UpdateFieldsInUse(game.TagIds, UsedTags, TagsInUseUpdated);
            UpdateFieldsInUse(game.CategoryIds, UsedCategories, CategoriesInUseUpdated);
            UpdateFieldsInUse(game.AgeRatingIds, UsedAgeRatings, AgeRatingsInUseUpdated);
            UpdateFieldsInUse(game.SeriesIds, UsedSeries, SeriesInUseUpdated);
            UpdateFieldsInUse(game.RegionIds, UsedRegions, RegionsInUseUpdated);
            UpdateFieldsInUse(game.SourceId, UsedGameSources, GameSourcesInUseUpdated);
            UpdateFieldsInUse(game.FeatureIds, UsedGameFeatures, GameFeaturesInUseUpdated);
            UpdateFieldsInUse(game.CompletionStatusId, UsedCompletionStatuses, CompletionStatusesInUseUpdated);
            UpdateFieldsInUse(game.DeveloperIds, UsedDevelopers, DevelopersInUseUpdated);
            UpdateFieldsInUse(game.PublisherIds, UsedPublishers, PublishersInUseUpdated);
            UpdateFieldsInUse(ListExtensions.Merge(game.PublisherIds, game.DeveloperIds), UsedCompanies, CompaniesInUseUpdated);
        }
    }

    private void UpdateFieldsInUse(Guid sourceData, HashSet<Guid> useCollection, EventHandler? handler)
    {
        if (sourceData != Guid.Empty && useCollection.Add(sourceData))
        {
            handler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void UpdateFieldsInUse(HashSet<Guid>? sourceData, HashSet<Guid> useCollection, EventHandler? handler)
    {
        if (useCollection.AddRange(sourceData))
        {
            handler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void UpdateRemovedFieldsInUse<T>(List<T> removedObjects, HashSet<Guid> useCollection, EventHandler? handler) where T : DatabaseObject
    {
        var anyRemoved = false;
        foreach (var item in removedObjects)
        {
            if (useCollection.Remove(item.Id))
            {
                anyRemoved = true;
            }
        }

        if (anyRemoved)
        {
            handler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void LoadUsedItems()
    {
        foreach (var game in Games)
        {
            UsedPlatforms.AddRange(game.PlatformIds);
            UsedGenres.AddRange(game.GenreIds);
            UsedTags.AddRange(game.TagIds);
            UsedCategories.AddRange(game.CategoryIds);
            UsedSeries.AddRange(game.SeriesIds);
            UsedCategories.AddRange(game.CategoryIds);
            UsedAgeRatings.AddRange(game.AgeRatingIds);
            UsedRegions.AddRange(game.RegionIds);
            UsedGameFeatures.AddRange(game.FeatureIds);

            game.DeveloperIds?.ForEach(a =>
            {
                UsedDevelopers.Add(a);
                UsedCompanies.Add(a);
            });

            game.PublisherIds?.ForEach(a =>
            {
                UsedPublishers.Add(a);
                UsedCompanies.Add(a);
            });

            if (game.SourceId != Guid.Empty)
            {
                UsedGameSources.Add(game.SourceId);
            }

            if (game.CompletionStatusId != Guid.Empty)
            {
                UsedCompletionStatuses.Add(game.CompletionStatusId);
            }
        }
    }

    public void Dispose()
    {
        sqliteDbs.Values.ForEach(a => a.Dispose());
    }

    public static string GetFullDbPath(string path)
    {
        if (path.IsNullOrWhiteSpace())
        {
            throw new Exception("Database path cannot be empty.");
        }

        if (path.Contains(ExpandableVariables.PlayniteDirectory, StringComparison.OrdinalIgnoreCase))
        {
            return path.Replace(ExpandableVariables.PlayniteDirectory, PlaynitePaths.ProgramDir, StringComparison.OrdinalIgnoreCase);
        }
        else if (path.Contains("%AppData%", StringComparison.OrdinalIgnoreCase))
        {
            return path.Replace("%AppData%", Environment.ExpandEnvironmentVariables("%AppData%"), StringComparison.OrdinalIgnoreCase);
        }
        else if (!Paths.IsFullPath(path))
        {
            return Path.GetFullPath(path);
        }

        return path;
    }

    public static string GetDefaultPath(bool portable)
    {
        if (portable)
        {
            return ExpandableVariables.PlayniteDirectory + @"\library";
        }
        else
        {
            return @"%AppData%\Playnite\library";
        }
    }

    public void RemoveFile(string dbPath)
    {
        if (dbPath.IsNullOrWhiteSpace())
        {
            return;
        }

        var filePath = GetFullFilePath(dbPath);
        if (!File.Exists(filePath))
        {
            return;
        }

        try
        {
            FileSystem.DeleteFileSafe(filePath);
        }
        catch (Exception e) when (!AppConfig.ThrowAllErrors)
        {
            logger.Error(e, $"Failed to remove old database file {dbPath}.");
        }

        try
        {
            var dir = Path.GetDirectoryName(filePath)!;
            if (FileSystem.IsDirectoryEmpty(dir))
            {
                FileSystem.DeleteDirectory(dir);
            }
        }
        catch (Exception e) when (!AppConfig.ThrowAllErrors)
        {
            logger.Error(e, "Failed to clean up directory after removing file");
        }
    }

    public string GetFullFilePath(string dbPath)
    {
        if (!dbPath.StartsWith(DbFilePathPrefix, StringComparison.Ordinal))
        {
            return dbPath;
        }

        return Path.Combine(filesDirectoryPath, dbPath.Replace(DbFilePathPrefix, string.Empty, StringComparison.Ordinal));
    }

    public void SetAsSingletonInstance()
    {
        if (Instance != null)
        {
            throw new Exception("Database singleton intance already exists.");
        }

        Instance = this;
    }

    public string GetFileStorageDir(Guid parentId)
    {
        var path = Path.Combine(filesDirectoryPath, parentId.ToString());
        FileSystem.CreateDirectory(path, false);
        return path;
    }

    public async Task<string?> AddFile(MetadataFile file, Guid parentId, bool isImage, CancellationToken token)
    {
        string? localPath = null;
        try
        {
            localPath = await file.AsLocalFile(token);
        }
        catch (Exception e)
        {
            logger.Error(e, "Failed to get local file from metadata file");
        }

        if (localPath.IsNullOrEmpty())
        {
            return null;
        }

        var finalFile = await AddFile(localPath, parentId, isImage);
        if (localPath.StartsWith(PlaynitePaths.TempDir, StringComparison.OrdinalIgnoreCase))
        {
            FileSystem.DeleteFile(localPath);
        }

        return finalFile;
    }

    public async Task<string?> AddFile(string path, Guid parentId, bool isImage, string? subFolder = null)
    {
        var targetSubDir = subFolder == null ?
            Path.Combine(filesDirectoryPath, parentId.ToString()) :
            Path.Combine(filesDirectoryPath, parentId.ToString(), subFolder);
        var targetDir = Path.Combine(filesDirectoryPath, targetSubDir);
        string? dbPath;

        if (path.IsHttpUrl())
        {
            try
            {
                var extension = Path.GetExtension(new Uri(path).AbsolutePath);
                var fileName = Guid.NewGuid().ToString() + extension;
                var downPath = Path.Combine(targetDir, fileName);
                await Downloader.DownloadFileAsync(path, downPath);
                if (isImage)
                {
                    var converted = Images.ConvertToCompatibleFormat(
                        downPath, Path.Combine(targetDir, Path.GetFileNameWithoutExtension(fileName)));
                    if (converted.IsNullOrEmpty())
                    {
                        FileSystem.DeleteFile(downPath);
                        return null;
                    }
                    else if (converted == downPath)
                    {
                        dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, fileName);
                    }
                    else
                    {
                        dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, Path.GetFileName(converted));
                        FileSystem.DeleteFile(downPath);
                    }
                }
                else
                {
                    dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, fileName);
                }
            }
            catch (System.Net.WebException e)
            {
                logger.Error(e, $"Failed to add http {path} file to database.");
                return null;
            }
        }
        else
        {
            try
            {
                var fileName = Path.GetFileName(path);
                // Re-use file if already part of db folder, don't copy.
                if (Paths.AreEqual(targetDir, Path.GetDirectoryName(path)))
                {
                    dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, fileName);
                }
                else
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                    if (isImage)
                    {
                        var converted = Images.ConvertToCompatibleFormat(
                            path, Path.Combine(targetDir, Path.GetFileNameWithoutExtension(fileName)));
                        if (converted.IsNullOrEmpty())
                        {
                            return null;
                        }
                        else if (converted == path)
                        {
                            FileSystem.CopyFile(path, Path.Combine(targetDir, fileName));
                            dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, fileName);
                        }
                        else
                        {
                            dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, Path.GetFileName(converted));
                        }
                    }
                    else
                    {
                        FileSystem.CopyFile(path, Path.Combine(targetDir, fileName));
                        dbPath = DbFilePathPrefix + Path.Combine(targetSubDir, fileName);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e, $"Failed to add {path} file to database.");
                return null;
            }
        }

        return dbPath;
    }

    public HashSet<string> GetImportedRomFiles(string emulatorDir)
    {
        var imported = new HashSet<string>();
        foreach (var game in Games)
        {
            foreach (var variant in game.Variants?.Where(a => a.Roms.HasItems()) ?? Enumerable.Empty<GameVariant>())
            {
                try
                {
                    var expVar = variant.ExpandVariables(game, emulatorDir);
                    foreach (var rom in expVar.Roms!)
                    {
                        if (rom.Path.IsNullOrWhiteSpace() || rom.Name.IsNullOrWhiteSpace())
                        {
                            continue;
                        }

                        string? absPath = null;
                        try
                        {
                            absPath = Path.GetFullPath(rom.Path);
                        }
                        catch (Exception e) when (!AppConfig.ThrowAllErrors)
                        {
                            logger.Error(e, $"Failed to get absolute ROM path:\n{rom.Path}");
                            continue;
                        }

                        if (!absPath.IsNullOrEmpty())
                        {
                            imported.Add(absPath);
                        }
                    }
                }
                catch (Exception e) when (!AppConfig.ThrowAllErrors)
                {
                    logger.Error(e, $"Failed to get roms from a game {game.Name} {game.Id}.");
                }
            }
        }

        return imported;
    }

    public HashSet<string> GetImportedExeFiles()
    {
        var imported = new HashSet<string>();
        foreach (var game in Games)
        {
            foreach (var variant in game.Variants?.Where(a => a.IsInstalled && a.GameActions.HasItems()) ?? Enumerable.Empty<GameVariant>())
            {
                // Since path can be defined in various partial forms between cation field,
                // we are going to support only format that's automtically generated by scan folder process.
                var actionIds = variant.GameActions!;
                var actions = FileGameActions.Get(actionIds);
                foreach (var action in actions.Where(a => !a.Path.IsNullOrWhiteSpace()))
                {
                    var expAction = action.ExpandVariables(game, variant);
                    imported.Add(expAction.Path + expAction.Arguments ?? string.Empty);
                }
            }
        }

        return imported;
    }
}