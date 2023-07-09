namespace Playnite.Tests;

[TestFixture]
public class ReleaseDateTests
{
    [Test]
    public void CompareToTest()
    {
        var date = new PartialDate(2000);
        var dateMonth = new PartialDate(2001, 2);
        var dateDay = new PartialDate(2002, 5, 12);
        Assert.AreEqual(-1, date.CompareTo(dateMonth));
        Assert.AreEqual(0, date.CompareTo(new PartialDate(2000)));
        Assert.AreEqual(1, dateDay.CompareTo(date));
    }

    [Test]
    public void EqualsTest()
    {
        var date1 = new PartialDate(2000, 1, 1);
        var date2 = new PartialDate(2000, 1, 1);
        var date3 = new PartialDate(2000, 1, 2);
        Assert.AreEqual(date1, date2);
        Assert.AreNotEqual(date1, date3);
        Assert.IsTrue(date1 == date2);
        Assert.IsTrue(date1 != date3);
    }

    [Test]
    public void SerializationTest()
    {
        Assert.AreEqual("2001-2-3", new PartialDate(2001, 2, 3).Serialize());
        Assert.AreEqual("2001-2", new PartialDate(2001, 2).Serialize());
        Assert.AreEqual("2001", new PartialDate(2001).Serialize());
        Assert.AreEqual(new PartialDate(2001, 2, 3), PartialDate.Deserialize("2001-2-3"));
        Assert.AreEqual(new PartialDate(2001, 2), PartialDate.Deserialize("2001-2"));
        Assert.AreEqual(new PartialDate(2001), PartialDate.Deserialize("2001"));
    }

    [Test]
    public void JsonSerializationTest()
    {
        Assert.AreEqual(
            "\"2001-2-3\"",
            Serialization.ToJson(new PartialDate(2001, 2, 3)));

        Assert.AreEqual(
            new PartialDate(2001, 2, 3).GetCopy(),
            new PartialDate(2001, 2, 3));
    }
}
