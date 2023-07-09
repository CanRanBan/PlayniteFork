namespace Playnite.Tests;

[TestFixture]
public class DefinitionsTests
{
    [Test]
    public void PlatformsExistTest()
    {
        Assert.That(Definitions.Platforms, Is.Not.Empty);
    }

    [Test]
    public void RegionsExistTest()
    {
        Assert.That(Definitions.Regions, Is.Not.Empty);
    }
}