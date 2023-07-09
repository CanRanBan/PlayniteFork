namespace Playnite.Tests;

[TestFixture]
public partial class PlayniteModelsTests
{
    public static void GetCopyTest<T>() where T : ICopyable<T>
    {
        var generator = new DataGenerator();
        var obj = generator.GenerateObject<T>(GlobalRandom.Generator, false);
        var obj2 = generator.GenerateObject<T>(GlobalRandom.Generator, true);

        Assert.AreEqual(
            Serialization.ToJson(obj),
            Serialization.ToJson(obj.GetCopy()));
        Assert.AreEqual(
            Serialization.ToJson(obj2),
            Serialization.ToJson(obj2.GetCopy()));
    }
}
