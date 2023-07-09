﻿using System.Drawing.Imaging;
using System.Windows;

namespace Playnite.Tests;

[TestFixture]
public class BitmapExtensionsTests
{
    [Test]
    public void BitmapLoadPropertiesEquabilityTest()
    {
        var np1 = new BitmapLoadProperties(1, 1, new DpiScale(1, 1));
        var np2 = new BitmapLoadProperties(1, 1, new DpiScale(1, 1));
        var np3 = new BitmapLoadProperties(2, 2, new DpiScale(2, 2));
        BitmapLoadProperties? np4 = null;
        var np5 = new BitmapLoadProperties(2, 2, new DpiScale(2, 2), ImageLoadScaling.BitmapDotNet);
        var np6 = new BitmapLoadProperties(2, 2, new DpiScale(2, 2), ImageLoadScaling.None);

        Assert.AreEqual(np1, np2);
        Assert.IsTrue(np1 == np2);
        Assert.IsTrue(np4! == null!);
        Assert.IsTrue(np3 != null!);
        Assert.IsTrue(np3! == np5);
        Assert.IsTrue(np5 != np6);

        Assert.AreNotEqual(np1, np3);
        Assert.IsTrue(np1 != np3!);
    }
}
