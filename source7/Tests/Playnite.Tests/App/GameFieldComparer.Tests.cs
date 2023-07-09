namespace Playnite.Tests;

[TestFixture]
public class GameFieldComparerTests
{
    [Test]
    public void ComparerTest()
    {
        Assert.IsTrue(GameFieldComparer.StringEquals("Single Player", "Single Player"));
        Assert.IsTrue(GameFieldComparer.StringEquals("Single-Player", "Single Player"));
        Assert.IsTrue(GameFieldComparer.StringEquals("SinglePlayer", "Single Player"));
        Assert.IsTrue(GameFieldComparer.StringEquals("single player", "Single Player"));

        Assert.IsFalse(GameFieldComparer.StringEquals("SingleaPlayer", "Single Player"));
        Assert.IsFalse(GameFieldComparer.StringEquals("Single:Player", "Single Player"));

        Assert.IsFalse(GameFieldComparer.StringEquals(null, null));
        Assert.IsFalse(GameFieldComparer.StringEquals(null, "Single Player"));
        Assert.IsFalse(GameFieldComparer.StringEquals("Single:Player", null));
    }
}
