using System.IO;
using System.Threading;

namespace Playnite;

public static class MetadataFileExtensions
{
    public static async Task<string?> AsLocalFile(this MetadataFile file, CancellationToken cancelToken)
    {
        if (!file.HasData)
        {
            return null;
        }

        if (file.Content != null)
        {
            var resultPath = Path.Combine(PlaynitePaths.TempDir, Guid.NewGuid() + Path.GetExtension(file.FileName));
            FileSystem.PrepareSaveFile(resultPath);
            File.WriteAllBytes(resultPath, file.Content!);
            return resultPath;
        }
        else
        {
            if (file.Path.IsHttpUrl())
            {
                var extension = Path.GetExtension(new Uri(file.Path).AbsolutePath);
                var resultPath = Path.Combine(PlaynitePaths.TempDir, Guid.NewGuid() + extension);
                FileSystem.PrepareSaveFile(resultPath);
                await Downloader.DownloadFileAsync(file.Path, resultPath, cancelToken);
                if (cancelToken.IsCancellationRequested)
                {
                    if (File.Exists(resultPath))
                    {
                        File.Delete(resultPath);
                    }

                    return null;
                }

                return resultPath;
            }
            else
            {
                return file.Path;
            }
        }
    }
}
