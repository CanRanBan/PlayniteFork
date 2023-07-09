namespace Playnite;

#pragma warning disable CS1591

public enum AutomaticPlayActionType
{
    File = 0,
    Url = 1
}

public sealed class AutomaticPlayController : PlayActionController
{
    public AutomaticPlayActionType Type { get; set; }
    public GameTrackingOptions? TrackingOptions { get; set; }
    public string? Arguments { get; set; }
    public string? Path { get; set; }
    public string? WorkingDir { get; set; }

    public override void Play(PlayActionArgs args)
    {
        throw new NotSupportedException();
    }
}

public class GameActionControllerBase : IDisposable
{
    public string? Name { get; set; }

    public virtual void Dispose()
    {
    }
}

public abstract class PlayActionController : GameActionControllerBase
{
    public class GameStartedEventArgs
    {
        public int StartedProcessId { get; set; } = 0;

        public GameStartedEventArgs()
        {
        }

        public GameStartedEventArgs(int startedProcessId)
        {
            StartedProcessId = startedProcessId;
        }
    }

    public class GameStoppedEventArgs
    {
        public ulong SessionLength { get; set; } = 0;

        public GameStoppedEventArgs()
        {
        }

        public GameStoppedEventArgs(ulong sessionLength)
        {
            SessionLength = sessionLength;
        }
    }

    public class PlayActionArgs
    {
    }

    internal event EventHandler<GameStartedEventArgs>? Started;
    internal event EventHandler<GameStoppedEventArgs>? Stopped;

    public abstract void Play(PlayActionArgs args);

    protected void InvokeOnStarted(GameStartedEventArgs args)
    {
        Started?.Invoke(this, args);
    }

    protected void InvokeOnStopped(GameStoppedEventArgs args)
    {
        Stopped?.Invoke(this, args);
    }

    public override string ToString()
    {
        return Name ?? nameof(PlayActionController);
    }
}

public class PluginFeatures
{
}

public abstract class Plugin
{
}
