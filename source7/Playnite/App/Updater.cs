using System.IO;
using System.Threading;

namespace Playnite;

public class Updater
{
    public class UpdateManifest
    {
        public const string ServerManifestFileName = "update.json";

        public Version? Version { get; set; }
        public Version? SdkVersion { get; set; }
        public Version? FullscreenThemeVersion { get; set; }
        public Version? DesktopThemeVersion { get; set; }
        public string? Checksum { get; set; }
        public List<string>? PackageUrls { get; set; }
        public List<Version>? VersionHistory { get; set; }
    }

    public class ReleaseNoteData
    {
        public Version? Version { get; set; }
        public string? Note { get; set; }
    }

    private static readonly ILogger logger = LogManager.GetLogger();
    private static string updateBranch => AppConfig.Config.UpdateBranch;
    private static string updaterFile => Path.Combine(PlaynitePaths.TempDir, "update.exe");

    private UpdateManifest? updateManifest;

    public async Task<List<ReleaseNoteData>> GetReleaseNotes()
    {
        await DownloadManifest();
        var notes = new List<ReleaseNoteData>();

        foreach (var version in updateManifest!.VersionHistory ?? new List<Version>())
        {
            if (version > PlayniteApplication.CurrentVersion)
            {
                var noteUrls = new List<string>
                {
                    AppConfig.Config.UpdateUrl.UriCombine(updateBranch, $"{version.ToString(2)}.html"),
                    AppConfig.Config.UpdateUrl2.UriCombine(updateBranch, $"{version.ToString(2)}.html")
                };

                try
                {
                    var note = await Downloader.DownloadStringAsync(noteUrls);
                    notes.Add(new ReleaseNoteData()
                    {
                        Version = version,
                        Note = note
                    });
                }
                catch (Exception e)
                {
                    logger.Error(e, $"Failed to download release notes for version {version}");
                }
            }
        }

        return notes;
    }

    public Task DownloadUpdate(Action<DownloadProgress> progressHandler)
    {
        return Task.Run(async () =>
        {
            await DownloadManifest();
            if (File.Exists(updaterFile))
            {
                if (VerifyUpdateFile(updateManifest!.Checksum!, updaterFile))
                {
                    logger.Info("Update already downloaded skipping download.");
                    return;
                }
            }

            if (updateManifest!.PackageUrls == null)
            {
                throw new Exception("No packages available for update to download.");
            }

            try
            {
                await Downloader.DownloadFileAsync(updateManifest.PackageUrls, updaterFile, progressHandler, CancellationToken.None);
            }
            catch (Exception e)
            {
                logger.Error(e, "Failed to download update file.");
                throw new Exception("Failed to download update file.");
            }

            if (!VerifyUpdateFile(updateManifest.Checksum!, updaterFile))
            {
                throw new Exception($"Update file integrity check failed.");
            }
        });
    }

    public void InstallUpdate(IPlayniteApplication app)
    {
        var portable = PlaynitePaths.IsPortable ? "/PORTABLE" : "";
        var fullscreen = app.Mode == ApplicationMode.Fullscreen ? "/FULLSCREEN" : "";
        logger.Info("Installing new update to {0}, in {1} mode".Format(PlaynitePaths.ProgramDir, portable));
        app.QuitAndStart(
            updaterFile,
            @"/SILENT /NOCANCEL /DIR=""{0}"" /UPDATE {1} {2}".Format(PlaynitePaths.ProgramDir, portable, fullscreen));
    }

    public async Task<bool> CheckIsUpdateAvailable()
    {
        var latest = await GetLatestVersion();
        var current = PlayniteApplication.CurrentVersion;
        return latest > current;
    }

    private bool VerifyUpdateFile(string checksum, string path)
    {
        var newMD5 = FileSystem.GetMD5(path);
        if (newMD5 != checksum)
        {
            logger.Error($"Checksum of downloaded file doesn't match: {newMD5} vs {checksum}");
            return false;
        }

        return true;
    }

    private async Task DownloadManifest()
    {
        if (updateManifest != null)
        {
            return;
        }

        var dataString = string.Empty;

        try
        {
            dataString = await GetUpdateManifestData(AppConfig.Config.UpdateUrl);
        }
        catch (Exception e)
        {
            logger.Warn(e, "Failed to download update manifest from main URL");
        }

        try
        {
            if (string.IsNullOrEmpty(dataString))
            {
                dataString = await GetUpdateManifestData(AppConfig.Config.UpdateUrl2);
            }
        }
        catch (Exception e)
        {
            logger.Warn(e, "Failed to download update manifest from secondary URL");
        }

        if (string.IsNullOrEmpty(dataString))
        {
            throw new Exception("Failed to download update manifest.");
        }

        updateManifest = Serialization.FromJson<UpdateManifest>(dataString);
        if (updateManifest == null)
        {
            logger.Error(dataString);
            throw new Exception("Failed to deserialize update manifest data.");
        }
    }

    private async Task<Version> GetLatestVersion()
    {
        await DownloadManifest();
        return updateManifest!.Version!;
    }

    private async Task<string> GetUpdateManifestData(string root)
    {
        var url = root.UriCombine(updateBranch, PlayniteApplication.CurrentVersion.ToString(2), UpdateManifest.ServerManifestFileName);
        return await Downloader.DownloadStringAsync(url);
    }
}