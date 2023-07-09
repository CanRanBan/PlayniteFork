using System.Diagnostics;
using System.IO;

namespace Playnite.Tests;

public class TempDirectory : IDisposable
{
    private readonly bool autoDelete;

    public string TempDir { get; }

    public static TempDirectory Create(bool autoDelete = true, string? dirName = null)
    {
        if (dirName.IsNullOrEmpty())
        {
            var stack = new StackTrace(1);
            var method = stack.GetFrame(0)!.GetMethod();
            dirName = Paths.GetSafePathName($"{method!.DeclaringType!.Name}_{method.Name}");
        }

        return new TempDirectory(dirName, autoDelete);
    }

    public TempDirectory(string dirName, bool autoDelete = true)
    {
        TempDir = Path.Combine(Path.GetTempPath(), "Playnite", dirName);
        FileSystem.CreateDirectory(TempDir, true);
        this.autoDelete = autoDelete;
    }

    public void Dispose()
    {
        if (autoDelete)
        {
            FileSystem.DeleteDirectory(TempDir);
        }
    }

    public override string ToString()
    {
        return TempDir;
    }

    public static implicit operator string(TempDirectory dir) => dir.TempDir;
}

public class TempLibrary : IDisposable
{
    public Library Lib { get; }
    public TempDirectory Dir { get; }

    public TempLibrary(string dirName, bool autoDelete = true)
    {
        Dir = new TempDirectory(dirName, autoDelete);
        Lib = new Library(Dir);
    }

    public static TempLibrary Create(bool autoDelete = true, string? dirName = null)
    {
        if (dirName.IsNullOrEmpty())
        {
            var stack = new StackTrace(1);
            var method = stack.GetFrame(0)!.GetMethod();
            dirName = Paths.GetSafePathName($"{method!.DeclaringType!.Name}_{method.Name}");
        }

        return new TempLibrary(dirName, autoDelete);
    }

    public void Dispose()
    {
        Lib.Dispose();
        Dir.Dispose();
    }
}
