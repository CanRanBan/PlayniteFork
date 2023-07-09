#nullable enable
namespace Playnite.Tests;

public partial class PlayniteModelsTests
{
    [Test] public void GetCopyTests()
    {
        GetCopyTest<Game>();
        GetCopyTest<GameVariant>();
        GetCopyTest<GameSession>();
        GetCopyTest<GameAchievements>();
        GetCopyTest<GameDescription>();
        GetCopyTest<GameNote>();
        GetCopyTest<GameScripts>();
        GetCopyTest<GameRom>();
        GetCopyTest<Link>();
        GetCopyTest<GameTrackingOptions>();
        GetCopyTest<FileGameAction>();
        GetCopyTest<UrlGameAction>();
        GetCopyTest<EmulatorGameAction>();
        GetCopyTest<ScriptGameAction>();
        GetCopyTest<AgeRating>();
        GetCopyTest<AppSoftware>();
        GetCopyTest<Category>();
        GetCopyTest<Company>();
        GetCopyTest<CompletionStatus>();
        GetCopyTest<GameFeature>();
        GetCopyTest<GameSource>();
        GetCopyTest<Genre>();
        GetCopyTest<Platform>();
        GetCopyTest<Region>();
        GetCopyTest<Series>();
        GetCopyTest<Tag>();
        GetCopyTest<ImportExclusionItem>();
    }
}
