using System.ComponentModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Playnite;

#pragma warning disable CS1591

public enum GameField : int
{
    ///
    BackgroundImage = 0,
    ///
    Description = 1,
    ///
    GenreIds = 2,
    ///
    Hidden = 3,
    ///
    Favorite = 4,
    ///
    Icon = 5,
    ///
    CoverImage = 6,
    ///
    InstallDirectory = 7,
    ///
    LastActivity = 9,
    ///
    SortingName = 10,
    ///
    Gameid = 11,
    ///
    PluginId = 12,
    ///
    PublisherIds = 16,
    ///
    DeveloperIds = 17,
    ///
    ReleaseDate = 18,
    ///
    CategoryIds = 19,
    ///
    TagIds = 20,
    ///
    Links = 21,
    ///
    IsInstalling = 22,
    ///
    IsUninstalling = 23,
    ///
    IsLaunching = 24,
    ///
    IsRunning = 25,
    ///
    IsInstalled = 26,
    ///
    IsCustomGame = 27,
    ///
    Playtime = 28,
    ///
    Added = 29,
    ///
    Modified = 30,
    ///
    PlayCount = 31,
    ///
    Version = 33,
    ///
    SourceId = 36,
    ///
    CompletionStatus = 37,
    ///
    UserScore = 38,
    ///
    CriticScore = 39,
    ///
    CommunityScore = 40,
    ///
    Genres = 41,
    ///
    Developers = 42,
    ///
    Publishers = 43,
    ///
    Tags = 44,
    ///
    Categories = 45,
    ///
    Source = 50,
    ///
    ReleaseYear = 51,
    ///
    PreScript = 53,
    ///
    PostScript = 54,
    ///
    Name = 55,
    ///
    Features = 56,
    ///
    FeatureIds = 57,
    ///
    UseGlobalPostScript = 58,
    ///
    UseGlobalPreScript = 59,
    ///
    UserScoreRating = 60,
    ///
    CommunityScoreRating = 61,
    ///
    CriticScoreRating = 62,
    ///
    UserScoreGroup = 63,
    ///
    CommunityScoreGroup = 64,
    ///
    CriticScoreGroup = 65,
    ///
    LastActivitySegment = 66,
    ///
    AddedSegment = 67,
    ///
    ModifiedSegment = 68,
    ///
    PlaytimeCategory = 69,
    ///
    InstallationStatus = 70,
    ///
    None = 71,
    ///
    GameStartedScript = 72,
    ///
    UseGlobalGameStartedScript = 73,
    ///
    Notes = 74,
    ///
    Manual = 75,
    ///
    GameActions = 76,
    ///
    IncludeLibraryPluginAction = 77,
    ///
    Roms = 78,
    ///
    AgeRatingIds = 79,
    ///
    AgeRatings = 80,
    ///
    SeriesIds = 81,
    ///
    Series = 82,
    ///
    RegionIds = 83,
    ///
    Regions = 84,
    ///
    PlatformIds = 85,
    ///
    Platforms = 86,
    ///
    CompletionStatusId = 87,
    ///
    OverrideInstallState = 88,
    ///
    InstallSize = 89,
    ///
    LastSizeScanDate = 90,
    ///
    RecentActivity = 91,
    ///
    EnableSystemHdr = 92
}

[AttributeUsage(AttributeTargets.Class)]
internal class LibraryCollectionAttribute : Attribute
{
    public bool UseMemoryCache { get; set; }
    public string? DbName { get; set; }
}

[AttributeUsage(AttributeTargets.Class)]
internal class AddCopyMethodAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class)]
internal class GenerateInUseAttribute : Attribute
{
}

public interface ICopyable<T>
{
    T GetCopy();
}

public abstract class MetadataProperty
{
}

public class MetadataIdProperty : MetadataProperty, IEquatable<MetadataIdProperty>
{
    public Guid Id { get; }

    public MetadataIdProperty(Guid dbId)
    {
        if (dbId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(dbId));
        }

        Id = dbId;
    }

    public override string ToString()
    {
        return Id.ToString();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MetadataIdProperty);
    }

    public bool Equals(MetadataIdProperty? other)
    {
        return Id == other?.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class MetadataNameProperty : MetadataProperty, IEquatable<MetadataNameProperty>
{
    public string Name { get; }

    public MetadataNameProperty(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MetadataNameProperty);
    }

    public bool Equals(MetadataNameProperty? other)
    {
        return string.Equals(Name, other?.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}

public class MetadataSpecProperty : MetadataProperty, IEquatable<MetadataSpecProperty>
{
    public string Id { get; }

    public MetadataSpecProperty(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        Id = id;
    }

    public override string ToString()
    {
        return Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MetadataSpecProperty);
    }

    public bool Equals(MetadataSpecProperty? other)
    {
        return string.Equals(Id, other?.Id, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}

public class MetadataFile
{
    public bool HasData => (!string.IsNullOrWhiteSpace(FileName) && Content != null) || !string.IsNullOrWhiteSpace(Path);
    public string? FileName { get; set; }
    public byte[]? Content { get; set; }
    public string? Path { get; set; }

    public MetadataFile()
    {
    }

    public MetadataFile(string path)
    {
        FileName = System.IO.Path.GetFileName(path);
        Path = path;
    }

    public MetadataFile(string name, byte[] data)
    {
        FileName = name;
        Content = data;
    }

    public MetadataFile(string name, byte[] data, string originalUrl)
    {
        FileName = name;
        Content = data;
        Path = originalUrl;
    }
}

public partial class ImportableGame
{
    public class GameSession
    {
        public uint Length { get; set; }
        public DateTime? Date { get; set; }
    }

    public string? Name { get; set; }
    public string? GameId { get; set; }
    public string? SortingName { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public PartialDate? ReleaseDate { get; set; }
    public DateTime? LastPlayed { get; set; }
    public ulong TotalPlayCount { get; set; }
    public string? Manual { get; set; }
    public List<Link>? Links { get; set; }
    public MetadataFile? Icon { get; set; }
    public MetadataFile? Cover { get; set; }
    public MetadataFile? Background { get; set; }
    public bool EnableSystemHdr { get; set; }
    public bool Hidden { get; set; }
    public bool Favorite { get; set; }
    public uint? UserScore { get; set; }
    public uint? CriticScore { get; set; }
    public uint? CommunityScore { get; set; }
    public HashSet<MetadataProperty>? Genres { get; set; }
    public HashSet<MetadataProperty>? Platforms { get; set; }
    public HashSet<MetadataProperty>? Publishers { get; set; }
    public HashSet<MetadataProperty>? Developers { get; set; }
    public HashSet<MetadataProperty>? Categories { get; set; }
    public HashSet<MetadataProperty>? Tags { get; set; }
    public HashSet<MetadataProperty>? Features { get; set; }
    public HashSet<MetadataProperty>? Series { get; set; }
    public HashSet<MetadataProperty>? AgeRatings { get; set; }
    public HashSet<MetadataProperty>? Regions { get; set; }
    public MetadataProperty? Source { get; set; }
    public MetadataProperty? CompletionStatus { get; set; }
    public List<GameSession>? Sessions { get; set; }
    public bool IsInstalled { get; set; }
    public string? InstallDirectory { get; set; }
    public List<GameRom>? Roms { get; set; }
    public List<GameAction>? Actions { get; set; }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Game))]
public partial class Game : DatabaseObject
{
    [ObservableProperty] private string? sortingName;
    [ObservableProperty] private PartialDate? releaseDate;
    [ObservableProperty] private DateTime? lastActivity;
    [ObservableProperty] private ulong totalPlayTime;
    [ObservableProperty] private ulong totalPlayCount;
    [ObservableProperty] private DateTime? added;
    [ObservableProperty] private DateTime? modified;
    [ObservableProperty] private string? manual;
    [ObservableProperty] private List<Link>? links;
    [ObservableProperty] private string? icon;
    [ObservableProperty] private string? cover;
    [ObservableProperty] private string? background;
    [ObservableProperty] private bool enableSystemHdr;
    [ObservableProperty] private bool hidden;
    [ObservableProperty] private bool favorite;
    [ObservableProperty] private uint? userScore;
    [ObservableProperty] private uint? criticScore;
    [ObservableProperty] private uint? communityScore;
    [ObservableProperty] private List<GameVariant>? variants;

    [ObservableProperty] private HashSet<Guid>? genreIds;
    [ObservableProperty] private HashSet<Guid>? platformIds;
    [ObservableProperty] private HashSet<Guid>? publisherIds;
    [ObservableProperty] private HashSet<Guid>? developerIds;
    [ObservableProperty] private HashSet<Guid>? categoryIds;
    [ObservableProperty] private HashSet<Guid>? tagIds;
    [ObservableProperty] private HashSet<Guid>? featureIds;
    [ObservableProperty] private HashSet<Guid>? seriesIds;
    [ObservableProperty] private HashSet<Guid>? ageRatingIds;
    [ObservableProperty] private HashSet<Guid>? regionIds;
    [ObservableProperty] private Guid sourceId;
    [ObservableProperty] private Guid completionStatusId;
}

[AddCopyMethod]
public partial class GameVariant : DatabaseObject
{
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? gameId;
    [ObservableProperty] private Guid pluginId;
    [ObservableProperty] private bool isInstalling;
    [ObservableProperty] private bool isUninstalling;
    [ObservableProperty] private bool isRunning;
    [ObservableProperty] private bool isLaunching;
    [ObservableProperty] private bool isInstalled;
    [ObservableProperty] private bool overrideInstallState;
    [ObservableProperty] private ulong? installSize;
    [ObservableProperty] private string? installDirectory;
    [ObservableProperty] private DateTime? lastSizeScanDate;
    [ObservableProperty] private List<GameRom>? roms;
    [ObservableProperty] private bool includePluginActions;
    [ObservableProperty] private List<Guid>? gameActions;
    [ObservableProperty] private HashSet<Guid>? sessionIds;

    [ObservableProperty] private Guid achievementsId;
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class GameSession : DatabaseObject
{
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class GameAchievements : DatabaseObject
{
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class GameDescription : DatabaseObject
{
    [ObservableProperty] private string? text;
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class GameNote : DatabaseObject
{
    [ObservableProperty] private string? text;
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class GameScripts : DatabaseObject
{
    [ObservableProperty] private bool useGlobalPostScript;
    [ObservableProperty] private bool useGlobalPreScript;
    [ObservableProperty] private bool useGlobalGameStartedScript;
    [ObservableProperty] private string? preScript;
    [ObservableProperty] private string? postScript;
    [ObservableProperty] private string? gameStartedScript;
}

[AddCopyMethod]
public partial class GameRom : ObservableObject
{
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? path;

    public GameRom()
    {
    }

    public GameRom(string name, string path)
    {
        this.Name = name;
        this.Path = path;
    }

    public override string ToString()
    {
        return $"{Name}: {Path}";
    }
}

[AddCopyMethod]
public partial class Link : ObservableObject
{
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? url;

    public Link()
    {
    }

    public Link(string name, string url)
    {
        Name = name;
        Url = url;
    }
}

public enum TrackingMode
{
    [Description(LocId.action_tracking_mode_default)]      Default = 0,
    [Description(LocId.action_tracking_mode_process)]      Process = 1,
    [Description(LocId.action_tracking_mode_directory)]    Directory = 2,
    [Description(LocId.action_tracking_original_process)]  OriginalProcess = 3,
}

[AddCopyMethod]
public partial class GameTrackingOptions : ObservableObject
{
    [ObservableProperty] private TrackingMode mode = TrackingMode.Default;
    [ObservableProperty] private string? trackingPath;

    public override string ToString()
    {
        return $"{Mode}: {TrackingPath}";
    }
}

public abstract partial class GameAction : DatabaseObject
{
    [ObservableProperty] private bool isPlayAction;
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class FileGameAction : GameAction
{
    [ObservableProperty] private string? path;
    [ObservableProperty] private string? arguments;
    [ObservableProperty] private string? workingDir;
    [ObservableProperty] private GameTrackingOptions trackingOptions = new();

    public override string ToString()
    {
        return $"{this.Path}, {Arguments}, {WorkingDir}";
    }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class UrlGameAction : GameAction
{
    [ObservableProperty] private string? url;
    [ObservableProperty] private GameTrackingOptions trackingOptions = new();

    public override string ToString()
    {
        return Url ?? "no url";
    }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class EmulatorGameAction : GameAction
{
    [ObservableProperty] private string? additionalArguments;
    [ObservableProperty] private bool overrideDefaultArgs;
    [ObservableProperty] private bool isPlayAction;
    [ObservableProperty] private Guid emulatorId;
    [ObservableProperty] private string? emulatorProfileId;

    public override string ToString()
    {
        return $"{EmulatorId}, {EmulatorProfileId}, {OverrideDefaultArgs}, {AdditionalArguments}";
    }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(Game))]
public partial class ScriptGameAction : DatabaseObject
{
    [ObservableProperty] private string? script;

    public override string ToString()
    {
        return "script action";
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(AgeRating))]
public partial class AgeRating : DatabaseObject
{
    public AgeRating() : base()
    {
    }

    public AgeRating(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(AppSoftware))]
public partial class AppSoftware : DatabaseObject
{
    [ObservableProperty] private string? icon;
    [ObservableProperty] private string? arguments;
    [ObservableProperty] private string? path;
    [ObservableProperty] private string? workingDir;

    public AppSoftware() : base()
    {
    }

    public AppSoftware(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Category))]
public partial class Category : DatabaseObject
{
    public Category() : base()
    {
    }

    public Category(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Company))]
public partial class Company : DatabaseObject
{
    public Company() : base()
    {
    }

    public Company(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(CompletionStatus))]
public partial class CompletionStatus : DatabaseObject
{
    public CompletionStatus() : base()
    {
    }

    public CompletionStatus(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(GameFeature))]
public partial class GameFeature : DatabaseObject
{
    public GameFeature() : base()
    {
    }

    public GameFeature(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(GameSource))]
public partial class GameSource : DatabaseObject
{
    public GameSource() : base()
    {
    }

    public GameSource(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Genre))]
public partial class Genre : DatabaseObject
{
    public Genre() : base()
    {
    }

    public Genre(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Platform))]
public partial class Platform : DatabaseObject
{
    [ObservableProperty] private string? specificationId;
    [ObservableProperty] private string? icon;
    [ObservableProperty] private string? cover;
    [ObservableProperty] private string? background;

    public Platform() : base()
    {
    }

    public Platform(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Region))]
public partial class Region : DatabaseObject
{
    [ObservableProperty] private string? specificationId;

    public Region() : base()
    {
    }

    public Region(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Series))]
public partial class Series : DatabaseObject
{
    public Series() : base()
    {
    }

    public Series(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[GenerateInUse]
[LibraryCollection(UseMemoryCache = true, DbName = nameof(Tag))]
public partial class Tag : DatabaseObject
{
    public Tag() : base()
    {
    }

    public Tag(string name) : base(name)
    {
    }
}

[AddCopyMethod]
[LibraryCollection(UseMemoryCache = false, DbName = nameof(ImportExclusionItem))]
public partial class ImportExclusionItem : DatabaseObject
{
    public string? GameId { get; set; }
    public Guid LibraryId { get; set; }
    public string? LibraryName { get; set; }

    public ImportExclusionItem()
    {
    }

    public ImportExclusionItem(string gameId, string gameName, Guid libraryId, string libraryName)
    {
        GameId = gameId;
        Name = gameName;
        LibraryId = libraryId;
        LibraryName = libraryName;
        Id = GetId();
    }

    public Guid GetId()
    {
        return GetId(GameId, LibraryId);
    }

    public static Guid GetId(string? gameId, Guid libraryId)
    {
        var id = $"{gameId}_{libraryId}";
        return new Guid(System.Security.Cryptography.MD5.HashData(Encoding.UTF8.GetBytes(id)));
    }
}