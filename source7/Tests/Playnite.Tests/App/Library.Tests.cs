namespace Playnite.Tests;

[TestFixture]
public class LibraryTests
{
    [Test]
    public void ContainsTest()
    {
        using var tempLib = TempLibrary.Create();
        var lib = tempLib.Lib;
        var game = new Game { Name = "testGame" };
        lib.Games.Add(game);
        Assert.IsTrue(lib.Games.Contains(game));
        Assert.IsTrue(lib.Games.Contains(game.Id));
        Assert.IsFalse(lib.Games.Contains(Guid.NewGuid()));
    }

    [Test]
    public void ContainsNoCacheTest()
    {
        using var tempLib = TempLibrary.Create();
        var lib = tempLib.Lib;
        var dec = new GameDescription { Text = "testGame" };
        lib.GameDescriptions.Add(dec);
        Assert.IsTrue(lib.GameDescriptions.Contains(dec));
        Assert.IsTrue(lib.GameDescriptions.Contains(dec.Id));
        Assert.IsFalse(lib.Games.Contains(Guid.NewGuid()));
    }
}
