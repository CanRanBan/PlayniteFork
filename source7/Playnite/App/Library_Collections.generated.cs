#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.IO;
namespace Playnite;

public partial class GameCollection : DatabaseCollection<Game>
{
    public GameCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class GameSessionCollection : DatabaseCollection<GameSession>
{
    public GameSessionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class GameAchievementsCollection : DatabaseCollection<GameAchievements>
{
    public GameAchievementsCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class GameDescriptionCollection : DatabaseCollection<GameDescription>
{
    public GameDescriptionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class GameNoteCollection : DatabaseCollection<GameNote>
{
    public GameNoteCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class GameScriptsCollection : DatabaseCollection<GameScripts>
{
    public GameScriptsCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class FileGameActionCollection : DatabaseCollection<FileGameAction>
{
    public FileGameActionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class UrlGameActionCollection : DatabaseCollection<UrlGameAction>
{
    public UrlGameActionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class EmulatorGameActionCollection : DatabaseCollection<EmulatorGameAction>
{
    public EmulatorGameActionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class ScriptGameActionCollection : DatabaseCollection<ScriptGameAction>
{
    public ScriptGameActionCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class AgeRatingCollection : DatabaseCollection<AgeRating>
{
    public AgeRatingCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class AppSoftwareCollection : DatabaseCollection<AppSoftware>
{
    public AppSoftwareCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class CategoryCollection : DatabaseCollection<Category>
{
    public CategoryCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class CompanyCollection : DatabaseCollection<Company>
{
    public CompanyCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class CompletionStatusCollection : DatabaseCollection<CompletionStatus>
{
    public CompletionStatusCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class GameFeatureCollection : DatabaseCollection<GameFeature>
{
    public GameFeatureCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class GameSourceCollection : DatabaseCollection<GameSource>
{
    public GameSourceCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class GenreCollection : DatabaseCollection<Genre>
{
    public GenreCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class PlatformCollection : DatabaseCollection<Platform>
{
    public PlatformCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class RegionCollection : DatabaseCollection<Region>
{
    public RegionCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class SeriesCollection : DatabaseCollection<Series>
{
    public SeriesCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class TagCollection : DatabaseCollection<Tag>
{
    public TagCollection(Library lib, CustomSqliteDb db) : base(lib, db, true)
    {
    }
}

public partial class ImportExclusionItemCollection : DatabaseCollection<ImportExclusionItem>
{
    public ImportExclusionItemCollection(Library lib, CustomSqliteDb db) : base(lib, db, false)
    {
    }
}

public partial class Library
{
    [AllowNull] public GameCollection Games { get; private set; }
    [AllowNull] public GameSessionCollection GameSessions { get; private set; }
    [AllowNull] public GameAchievementsCollection GameAchievements { get; private set; }
    [AllowNull] public GameDescriptionCollection GameDescriptions { get; private set; }
    [AllowNull] public GameNoteCollection GameNotes { get; private set; }
    [AllowNull] public GameScriptsCollection GameScripts { get; private set; }
    [AllowNull] public FileGameActionCollection FileGameActions { get; private set; }
    [AllowNull] public UrlGameActionCollection UrlGameActions { get; private set; }
    [AllowNull] public EmulatorGameActionCollection EmulatorGameActions { get; private set; }
    [AllowNull] public ScriptGameActionCollection ScriptGameActions { get; private set; }
    [AllowNull] public AgeRatingCollection AgeRatings { get; private set; }
    [AllowNull] public AppSoftwareCollection AppSoftwares { get; private set; }
    [AllowNull] public CategoryCollection Categories { get; private set; }
    [AllowNull] public CompanyCollection Companies { get; private set; }
    [AllowNull] public CompletionStatusCollection CompletionStatuses { get; private set; }
    [AllowNull] public GameFeatureCollection GameFeatures { get; private set; }
    [AllowNull] public GameSourceCollection GameSources { get; private set; }
    [AllowNull] public GenreCollection Genres { get; private set; }
    [AllowNull] public PlatformCollection Platforms { get; private set; }
    [AllowNull] public RegionCollection Regions { get; private set; }
    [AllowNull] public SeriesCollection Series { get; private set; }
    [AllowNull] public TagCollection Tags { get; private set; }
    [AllowNull] public ImportExclusionItemCollection ImportExclusionItems { get; private set; }
    public HashSet<Guid> UsedAgeRatings { get; } = new();
    public event EventHandler? AgeRatingsInUseUpdated;
    public HashSet<Guid> UsedCategories { get; } = new();
    public event EventHandler? CategoriesInUseUpdated;
    public HashSet<Guid> UsedCompanies { get; } = new();
    public event EventHandler? CompaniesInUseUpdated;
    public HashSet<Guid> UsedCompletionStatuses { get; } = new();
    public event EventHandler? CompletionStatusesInUseUpdated;
    public HashSet<Guid> UsedGameFeatures { get; } = new();
    public event EventHandler? GameFeaturesInUseUpdated;
    public HashSet<Guid> UsedGameSources { get; } = new();
    public event EventHandler? GameSourcesInUseUpdated;
    public HashSet<Guid> UsedGenres { get; } = new();
    public event EventHandler? GenresInUseUpdated;
    public HashSet<Guid> UsedPlatforms { get; } = new();
    public event EventHandler? PlatformsInUseUpdated;
    public HashSet<Guid> UsedRegions { get; } = new();
    public event EventHandler? RegionsInUseUpdated;
    public HashSet<Guid> UsedSeries { get; } = new();
    public event EventHandler? SeriesInUseUpdated;
    public HashSet<Guid> UsedTags { get; } = new();
    public event EventHandler? TagsInUseUpdated;
    private void LoadCollections()
    {
        sqliteDbs.Add("Game", new CustomSqliteDb(Path.Combine(LibraryDir, "Game.db")));
        sqliteDbs.Add("AgeRating", new CustomSqliteDb(Path.Combine(LibraryDir, "AgeRating.db")));
        sqliteDbs.Add("AppSoftware", new CustomSqliteDb(Path.Combine(LibraryDir, "AppSoftware.db")));
        sqliteDbs.Add("Category", new CustomSqliteDb(Path.Combine(LibraryDir, "Category.db")));
        sqliteDbs.Add("Company", new CustomSqliteDb(Path.Combine(LibraryDir, "Company.db")));
        sqliteDbs.Add("CompletionStatus", new CustomSqliteDb(Path.Combine(LibraryDir, "CompletionStatus.db")));
        sqliteDbs.Add("GameFeature", new CustomSqliteDb(Path.Combine(LibraryDir, "GameFeature.db")));
        sqliteDbs.Add("GameSource", new CustomSqliteDb(Path.Combine(LibraryDir, "GameSource.db")));
        sqliteDbs.Add("Genre", new CustomSqliteDb(Path.Combine(LibraryDir, "Genre.db")));
        sqliteDbs.Add("Platform", new CustomSqliteDb(Path.Combine(LibraryDir, "Platform.db")));
        sqliteDbs.Add("Region", new CustomSqliteDb(Path.Combine(LibraryDir, "Region.db")));
        sqliteDbs.Add("Series", new CustomSqliteDb(Path.Combine(LibraryDir, "Series.db")));
        sqliteDbs.Add("Tag", new CustomSqliteDb(Path.Combine(LibraryDir, "Tag.db")));
        sqliteDbs.Add("ImportExclusionItem", new CustomSqliteDb(Path.Combine(LibraryDir, "ImportExclusionItem.db")));
        Games = new(this, sqliteDbs["Game"]);
        GameSessions = new(this, sqliteDbs["Game"]);
        GameAchievements = new(this, sqliteDbs["Game"]);
        GameDescriptions = new(this, sqliteDbs["Game"]);
        GameNotes = new(this, sqliteDbs["Game"]);
        GameScripts = new(this, sqliteDbs["Game"]);
        FileGameActions = new(this, sqliteDbs["Game"]);
        UrlGameActions = new(this, sqliteDbs["Game"]);
        EmulatorGameActions = new(this, sqliteDbs["Game"]);
        ScriptGameActions = new(this, sqliteDbs["Game"]);
        AgeRatings = new(this, sqliteDbs["AgeRating"]);
        AppSoftwares = new(this, sqliteDbs["AppSoftware"]);
        Categories = new(this, sqliteDbs["Category"]);
        Companies = new(this, sqliteDbs["Company"]);
        CompletionStatuses = new(this, sqliteDbs["CompletionStatus"]);
        GameFeatures = new(this, sqliteDbs["GameFeature"]);
        GameSources = new(this, sqliteDbs["GameSource"]);
        Genres = new(this, sqliteDbs["Genre"]);
        Platforms = new(this, sqliteDbs["Platform"]);
        Regions = new(this, sqliteDbs["Region"]);
        Series = new(this, sqliteDbs["Series"]);
        Tags = new(this, sqliteDbs["Tag"]);
        ImportExclusionItems = new(this, sqliteDbs["ImportExclusionItem"]);
    }
}
