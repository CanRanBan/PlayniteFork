using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Playnite;

public class GenericFilePlayController : PlayActionController
{
    private Stopwatch? stopWatch;
    private ProcessMonitor? procMon;

    private readonly Game game;
    private readonly GameVariant variant;
    private readonly FileGameAction action;

    public GenericFilePlayController(FileGameAction action, Game game, GameVariant variant)
    {
        this.game = game.GetCopy();
        this.variant = variant.ExpandVariables(game);
        this.action = action.ExpandVariables(game, variant);
    }

    public override void Play(PlayActionArgs args)
    {
        if (action.Path.IsNullOrWhiteSpace())
        {
            throw new Exception("Can't start game, no path to start specified.");
        }

        var proc = ProcessStarter.StartProcess(
            action.Path,
            action.Arguments ?? string.Empty,
            action.WorkingDir ?? string.Empty);

        procMon?.Dispose();
        procMon = new ProcessMonitor();
        procMon.TreeStarted += (_, treeArgs) =>
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs { StartedProcessId = treeArgs.StartedId });
        };

        procMon.TreeDestroyed += (_, __) =>
        {
            stopWatch!.Stop();
            InvokeOnStopped(new GameStoppedEventArgs { SessionLength = Convert.ToUInt64(stopWatch!.Elapsed.TotalSeconds) });
        };

        if (action.TrackingOptions.Mode == TrackingMode.Default)
        {
            // Handle Windows store apps
            var uwpMatch = Regex.Match(action.Arguments ?? string.Empty, @"shell:AppsFolder\\(.+)!.+");
            if (action.Path == "explorer.exe" && uwpMatch.Success)
            {
                var scanDirectory = variant.InstallDirectory;
                if (!variant.GameId.IsNullOrEmpty())
                {
                    var prg = Programs.GetUWPApps().FirstOrDefault(a => a.AppId == variant.GameId);
                    if (prg != null)
                    {
                        scanDirectory = prg.WorkDir;
                    }
                }

                procMon.WatchUwpApp(uwpMatch.Groups[1].Value, false);
            }
            else
            {
                stopWatch = Stopwatch.StartNew();
                InvokeOnStarted(new GameStartedEventArgs() { StartedProcessId = proc.Id });
                procMon.WatchProcessTree(proc);
            }
        }
        else if (action.TrackingOptions.Mode == TrackingMode.Process)
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs() { StartedProcessId = proc.Id });
            procMon.WatchProcessTree(proc);
        }
        else if (action.TrackingOptions.Mode == TrackingMode.OriginalProcess)
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs() { StartedProcessId = proc.Id });
            procMon.WatchSingleProcess(proc);
        }
        else if (action.TrackingOptions.Mode == TrackingMode.Directory)
        {
            var watchDir = action.TrackingOptions.TrackingPath.IsNullOrEmpty() ? variant.InstallDirectory : action.TrackingOptions.TrackingPath;
            if (!watchDir.IsNullOrEmpty() && FileSystem.DirectoryExists(watchDir))
            {
                procMon.WatchDirectoryProcesses(watchDir, false);
            }
            else
            {
                InvokeOnStopped(new GameStoppedEventArgs());
            }
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    public override void Dispose()
    {
        procMon?.Dispose();
        stopWatch?.Stop();
    }
}

public class GenericUrlPayController : PlayActionController
{
    private Stopwatch? stopWatch;
    private ProcessMonitor? procMon;

    private readonly Game game;
    private readonly GameVariant variant;
    private readonly UrlGameAction action;

    public GenericUrlPayController(UrlGameAction action, Game game, GameVariant variant)
    {
        this.game = game.GetCopy();
        this.variant = variant.ExpandVariables(game);
        this.action = action.ExpandVariables(game, variant);
    }

    public override void Play(PlayActionArgs args)
    {
        if (action.Url.IsNullOrWhiteSpace())
        {
            throw new Exception("Can't start game, no path to start specified.");
        }

        var proc = ProcessStarter.StartUrl(action.Url);
        procMon?.Dispose();
        procMon = new ProcessMonitor();
        procMon.TreeStarted += (_, treeArgs) =>
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs { StartedProcessId = treeArgs.StartedId });
        };

        procMon.TreeDestroyed += (_, __) =>
        {
            stopWatch!.Stop();
            InvokeOnStopped(new GameStoppedEventArgs { SessionLength = Convert.ToUInt64(stopWatch!.Elapsed.TotalSeconds) });
        };

        if (action.TrackingOptions.Mode == TrackingMode.Default || action.TrackingOptions.Mode == TrackingMode.Process)
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs() { StartedProcessId = proc.Id });
            procMon.WatchProcessTree(proc);
        }
        else if (action.TrackingOptions.Mode == TrackingMode.OriginalProcess)
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs() { StartedProcessId = proc.Id });
            procMon.WatchSingleProcess(proc);
        }
        else if (action.TrackingOptions.Mode == TrackingMode.Directory)
        {
            var watchDir = action.TrackingOptions.TrackingPath.IsNullOrEmpty() ? variant.InstallDirectory : action.TrackingOptions.TrackingPath;
            if (!watchDir.IsNullOrEmpty() && FileSystem.DirectoryExists(watchDir))
            {
                procMon.WatchDirectoryProcesses(watchDir, false);
            }
            else
            {
                InvokeOnStopped(new GameStoppedEventArgs());
            }
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    public override void Dispose()
    {
        procMon?.Dispose();
        stopWatch?.Stop();
    }
}

//    public override void Play(PlayActionArgs args)
//    {
//        StartingArgs = startingArgs;
//        var gameClone = Game.GetClone();
//        var action = playAction.GetClone();
//        action = action.ExpandVariables(gameClone);
//        action.Path = CheckPath(action.Path, nameof(action.Path), FileSystemItem.File);
//        action.WorkingDir = CheckPath(action.WorkingDir, nameof(action.WorkingDir), FileSystemItem.Directory);

//        if (playAction.Type == GameActionType.Script)
//        {
//            if (action.Script.IsNullOrWhiteSpace())
//            {
//                throw new ArgumentNullException("Game script is not defined.");
//            }

//            RunStartScript(
//                $"{Game.Name} play script",
//                action.Script,
//                gameClone.ExpandVariables(gameClone.InstallDirectory, true),
//                new Dictionary<string, object>(),
//                asyncExec);
//        }//
//    }

//    public override void Dispose()
//    {
//        isDisposed = true;
//        watcherToken?.Cancel();
//        playTask?.Wait(5000); // Give startup script time to gracefully shutdown.
//        procMon?.Dispose();
//        stopWatch?.Stop();
//        if (playRuntime?.IsDisposed == false)
//        {
//            playRuntime?.Dispose();
//        }

//        watcherToken?.Dispose();
//    }
//}
