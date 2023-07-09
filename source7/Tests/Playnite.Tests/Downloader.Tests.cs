using System.IO;
using System.Net;

namespace Playnite.Tests;

[TestFixture]
public class DownloaderTests
{
    [Test]
    public async Task GetResponseCodeTest()
    {
        var resp = await Downloader.GetResponseCode(@"https://playnite.link/favicon.ico");
        Assert.AreEqual(HttpStatusCode.OK, resp.statusCode);
        Assert.AreEqual("15086", resp.headers["Content-Length"]);

        resp = await Downloader.GetResponseCode(@"https://playnite.link/test.tst");
        Assert.AreEqual(HttpStatusCode.NotFound, resp.statusCode);
    }

    [Test]
    public async Task DownloadBytesTest()
    {
        Assert.That(await Downloader.DownloadBytesAsync(@"https://playnite.link/favicon.ico"), Is.Not.Empty);
    }

    [Test]
    public async Task DownloadStringTest()
    {
        StringAssert.Contains("<head>", await Downloader.DownloadStringAsync(@"https://playnite.link/index.html"));
    }

    [Test]
    public async Task DownloadFileAsyncProgressTest()
    {
        using var tempDir = TempDirectory.Create();
        var downFile = Path.Combine(tempDir, "test.jpg");
        var progressReports = 0;
        var progressTotal = 0L;
        await Downloader.DownloadFileAsync(
            @"https://playnite.link/screen1.jpg",
            downFile
            ,
            (a) =>
            {
                progressTotal = a.TotalBytes;
                progressReports++;
            },
            CancellationToken.None);

        Assert.AreEqual(452496, progressTotal);
        Assert.That(progressReports, Is.GreaterThan(0));
        var fileInfo = new FileInfo(downFile);
        Assert.AreEqual(452496, fileInfo.Length);
    }
}