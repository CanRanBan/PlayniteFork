#nullable enable
namespace Playnite;

#pragma warning disable CS1591

public partial class Game : ICopyable<Game>
{
    public Game GetCopy()
    {
        var copy = new Game();
        copy.SortingName = SortingName;
        copy.ReleaseDate = ReleaseDate?.GetCopy();
        copy.LastActivity = LastActivity;
        copy.TotalPlayTime = TotalPlayTime;
        copy.TotalPlayCount = TotalPlayCount;
        copy.Added = Added;
        copy.Modified = Modified;
        copy.Manual = Manual;
        copy.Links = Links?.Select(a => a.GetCopy()).ToList();
        copy.Icon = Icon;
        copy.Cover = Cover;
        copy.Background = Background;
        copy.EnableSystemHdr = EnableSystemHdr;
        copy.Hidden = Hidden;
        copy.Favorite = Favorite;
        copy.UserScore = UserScore;
        copy.CriticScore = CriticScore;
        copy.CommunityScore = CommunityScore;
        copy.Variants = Variants?.Select(a => a.GetCopy()).ToList();
        copy.GenreIds = GenreIds is null ? null : new(GenreIds);
        copy.PlatformIds = PlatformIds is null ? null : new(PlatformIds);
        copy.PublisherIds = PublisherIds is null ? null : new(PublisherIds);
        copy.DeveloperIds = DeveloperIds is null ? null : new(DeveloperIds);
        copy.CategoryIds = CategoryIds is null ? null : new(CategoryIds);
        copy.TagIds = TagIds is null ? null : new(TagIds);
        copy.FeatureIds = FeatureIds is null ? null : new(FeatureIds);
        copy.SeriesIds = SeriesIds is null ? null : new(SeriesIds);
        copy.AgeRatingIds = AgeRatingIds is null ? null : new(AgeRatingIds);
        copy.RegionIds = RegionIds is null ? null : new(RegionIds);
        copy.SourceId = SourceId;
        copy.CompletionStatusId = CompletionStatusId;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameVariant : ICopyable<GameVariant>
{
    public GameVariant GetCopy()
    {
        var copy = new GameVariant();
        copy.Name = Name;
        copy.GameId = GameId;
        copy.PluginId = PluginId;
        copy.IsInstalling = IsInstalling;
        copy.IsUninstalling = IsUninstalling;
        copy.IsRunning = IsRunning;
        copy.IsLaunching = IsLaunching;
        copy.IsInstalled = IsInstalled;
        copy.OverrideInstallState = OverrideInstallState;
        copy.InstallSize = InstallSize;
        copy.InstallDirectory = InstallDirectory;
        copy.LastSizeScanDate = LastSizeScanDate;
        copy.Roms = Roms?.Select(a => a.GetCopy()).ToList();
        copy.IncludePluginActions = IncludePluginActions;
        copy.GameActions = GameActions is null ? null : new(GameActions);
        copy.SessionIds = SessionIds is null ? null : new(SessionIds);
        copy.AchievementsId = AchievementsId;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameSession : ICopyable<GameSession>
{
    public GameSession GetCopy()
    {
        var copy = new GameSession();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameAchievements : ICopyable<GameAchievements>
{
    public GameAchievements GetCopy()
    {
        var copy = new GameAchievements();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameDescription : ICopyable<GameDescription>
{
    public GameDescription GetCopy()
    {
        var copy = new GameDescription();
        copy.Text = Text;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameNote : ICopyable<GameNote>
{
    public GameNote GetCopy()
    {
        var copy = new GameNote();
        copy.Text = Text;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameScripts : ICopyable<GameScripts>
{
    public GameScripts GetCopy()
    {
        var copy = new GameScripts();
        copy.UseGlobalPostScript = UseGlobalPostScript;
        copy.UseGlobalPreScript = UseGlobalPreScript;
        copy.UseGlobalGameStartedScript = UseGlobalGameStartedScript;
        copy.PreScript = PreScript;
        copy.PostScript = PostScript;
        copy.GameStartedScript = GameStartedScript;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameRom : ICopyable<GameRom>
{
    public GameRom GetCopy()
    {
        var copy = new GameRom();
        copy.Name = Name;
        copy.Path = Path;
        return copy;
    }
}

public partial class Link : ICopyable<Link>
{
    public Link GetCopy()
    {
        var copy = new Link();
        copy.Name = Name;
        copy.Url = Url;
        return copy;
    }
}

public partial class GameTrackingOptions : ICopyable<GameTrackingOptions>
{
    public GameTrackingOptions GetCopy()
    {
        var copy = new GameTrackingOptions();
        copy.Mode = Mode;
        copy.TrackingPath = TrackingPath;
        return copy;
    }
}

public partial class FileGameAction : ICopyable<FileGameAction>
{
    public FileGameAction GetCopy()
    {
        var copy = new FileGameAction();
        copy.Path = Path;
        copy.Arguments = Arguments;
        copy.WorkingDir = WorkingDir;
        copy.TrackingOptions = TrackingOptions.GetCopy();
        copy.IsPlayAction = IsPlayAction;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class UrlGameAction : ICopyable<UrlGameAction>
{
    public UrlGameAction GetCopy()
    {
        var copy = new UrlGameAction();
        copy.Url = Url;
        copy.TrackingOptions = TrackingOptions.GetCopy();
        copy.IsPlayAction = IsPlayAction;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class EmulatorGameAction : ICopyable<EmulatorGameAction>
{
    public EmulatorGameAction GetCopy()
    {
        var copy = new EmulatorGameAction();
        copy.AdditionalArguments = AdditionalArguments;
        copy.OverrideDefaultArgs = OverrideDefaultArgs;
        copy.IsPlayAction = IsPlayAction;
        copy.EmulatorId = EmulatorId;
        copy.EmulatorProfileId = EmulatorProfileId;
        copy.IsPlayAction = IsPlayAction;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class ScriptGameAction : ICopyable<ScriptGameAction>
{
    public ScriptGameAction GetCopy()
    {
        var copy = new ScriptGameAction();
        copy.Script = Script;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class AgeRating : ICopyable<AgeRating>
{
    public AgeRating GetCopy()
    {
        var copy = new AgeRating();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class AppSoftware : ICopyable<AppSoftware>
{
    public AppSoftware GetCopy()
    {
        var copy = new AppSoftware();
        copy.Icon = Icon;
        copy.Arguments = Arguments;
        copy.Path = Path;
        copy.WorkingDir = WorkingDir;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Category : ICopyable<Category>
{
    public Category GetCopy()
    {
        var copy = new Category();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Company : ICopyable<Company>
{
    public Company GetCopy()
    {
        var copy = new Company();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class CompletionStatus : ICopyable<CompletionStatus>
{
    public CompletionStatus GetCopy()
    {
        var copy = new CompletionStatus();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameFeature : ICopyable<GameFeature>
{
    public GameFeature GetCopy()
    {
        var copy = new GameFeature();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class GameSource : ICopyable<GameSource>
{
    public GameSource GetCopy()
    {
        var copy = new GameSource();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Genre : ICopyable<Genre>
{
    public Genre GetCopy()
    {
        var copy = new Genre();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Platform : ICopyable<Platform>
{
    public Platform GetCopy()
    {
        var copy = new Platform();
        copy.SpecificationId = SpecificationId;
        copy.Icon = Icon;
        copy.Cover = Cover;
        copy.Background = Background;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Region : ICopyable<Region>
{
    public Region GetCopy()
    {
        var copy = new Region();
        copy.SpecificationId = SpecificationId;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Series : ICopyable<Series>
{
    public Series GetCopy()
    {
        var copy = new Series();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class Tag : ICopyable<Tag>
{
    public Tag GetCopy()
    {
        var copy = new Tag();
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}

public partial class ImportExclusionItem : ICopyable<ImportExclusionItem>
{
    public ImportExclusionItem GetCopy()
    {
        var copy = new ImportExclusionItem();
        copy.GameId = GameId;
        copy.LibraryId = LibraryId;
        copy.LibraryName = LibraryName;
        copy.Name = Name;
        copy.Id = Id;
        return copy;
    }
}
