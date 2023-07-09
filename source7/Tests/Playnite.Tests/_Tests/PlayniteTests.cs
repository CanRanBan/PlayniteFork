﻿using System.IO;
using System.Reflection;
using System.Text;

namespace Playnite.Tests;

public static class TestVars
{
    public const string ProcessRunTesterProcessName = "ProcessRunTester";
    public const string ProcessRunTesterKeepRunningArg = "--keeprunning";

    public static string ProcessRunTesterExe { get; }
    public static string ProcessRunTesterReportFile { get; }

    public static string ResourcesDir { get; }
    public static string TempDir { get; }

    static TestVars()
    {
        ResourcesDir = Path.Combine(PlaynitePaths.ProgramDir, "Resources");
        ProcessRunTesterExe = Path.Combine(PlaynitePaths.ProgramDir, "ProcessRunTester.exe");
        ProcessRunTesterReportFile = Path.Combine(PlaynitePaths.ProgramDir, "processargs.json");

        TempDir = Path.Combine(Path.GetTempPath(), "playnite_unittests");
        if (!Directory.Exists(TempDir))
        {
            Directory.CreateDirectory(TempDir);
        }
    }
}

public class TestDateTimes : DateTimes.IDateTimes
{
    public DateTime Now { get; set; }
    public DateTime Today { get; set; }

    public TestDateTimes()
    {
    }

    public TestDateTimes(DateTime now)
    {
        Now = now;
        Today = now;
    }

    public TestDateTimes(DateTime now, DateTime today)
    {
        Now = now;
        Today = today;
    }
}

public static class PlayniteTests
{
    //public static MetadataFile GenerateFakeFile(string directory)
    //{
    //    var file = new byte[20];
    //    random.NextBytes(file);
    //    var fileName = Guid.NewGuid().ToString() + ".file";
    //    var filePath = Path.Combine(directory, fileName);
    //    File.WriteAllBytes(filePath, file);
    //    return new MetadataFile(fileName, file);
    //}

    //public static MetadataFile GenerateFakeFile()
    //{
    //    var file = new byte[20];
    //    random.NextBytes(file);
    //    var fileName = Guid.NewGuid().ToString() + ".file";
    //    return new MetadataFile(fileName, file);
    //}

    //public static void SetEntryAssembly(Assembly assembly)
    //{
    //    AppDomainManager manager = new AppDomainManager();
    //    FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
    //    entryAssemblyfield.SetValue(manager, assembly);

    //    AppDomain domain = AppDomain.CurrentDomain;
    //    FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
    //    domainManagerField.SetValue(domain, manager);
    //}

    //public static Mock<IPlayniteAPI> GetTestingApi()
    //{
    //    var api = new Mock<IPlayniteAPI>();
    //    var notification = new Mock<INotificationsAPI>();
    //    api.Setup(a => a.Paths).Returns(new PlaynitePathsAPI());
    //    api.Setup(a => a.ApplicationInfo).Returns(new PlayniteInfoAPI());
    //    api.Setup(a => a.Resources).Returns(new ResourceProvider());
    //    api.Setup(a => a.Notifications).Returns(notification.Object);
    //    return api;
    //}
}
