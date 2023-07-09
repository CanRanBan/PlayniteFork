﻿using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Drawing.Imaging;

namespace Playnite;

public class ImageProperties
{
    public int Height { get; set; }
    public int Width { get; set; }

    public ImageProperties()
    {
    }

    public ImageProperties(int width, int height)
    {
        Width = width;
        Height = height;
    }
}

public class Images
{
    private static readonly ILogger logger = LogManager.GetLogger();

    public static Image GetImageFromResource(string path, string assemblyName, BitmapScalingMode scaling = BitmapScalingMode.HighQuality, double height = 16, double width = 16)
    {
        var image = new Image()
        {
            Source = new BitmapImage(new Uri($"pack://application:,,,/{assemblyName};component/" + path, UriKind.Absolute)),
            Height = height,
            Width = width
        };

        RenderOptions.SetBitmapScalingMode(image, scaling);
        return image;
    }

    public static Image GetImageFromFile(string path, BitmapScalingMode scaling = BitmapScalingMode.HighQuality, double height = 16, double width = 16)
    {
        var image = new Image()
        {
            Source = System.Drawing.Imaging.BitmapExtensions.BitmapFromFile(path),
            Height = height,
            Width = width
        };

        RenderOptions.SetBitmapScalingMode(image, scaling);
        return image;
    }

    public static Image GetEmptyImage(double height = 16, double width = 16)
    {
        return new Image()
        {
            Height = height,
            Width = width
        };
    }

    public static ImageProperties GetImageProperties(string imagePath)
    {
        try
        {
            using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return GetImageProperties(stream);
        }
        catch (Exception e)
        {
            logger.Error(e, $"Failed to load image properties from file {imagePath}");
            return new ImageProperties();
        }
    }

    public static ImageProperties GetImageProperties(Stream imageStream)
    {
        try
        {
            var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
            if (decoder.Frames.HasItems())
            {
                return new ImageProperties(
                    decoder.Frames.Max(a => a.PixelWidth),
                    decoder.Frames.Max(a => a.PixelHeight));
            }
            else
            {
                logger.Warn("Images stream has no frames.");
                return new ImageProperties();
            }
        }
        catch (Exception e)
        {
            logger.Error(e, "Failed to load image properties from stream.");
            return new ImageProperties();
        }
    }

    /// <summary>
    /// Converts file to an image file.
    /// </summary>
    /// <param name="imagePath"></param>
    /// <param name="outFileRoot">Resulting file name without extension.</param>
    /// <returns>File path to converted image if conversion was successful or original path if file is alreadny an image.</returns>
    public static string? ConvertToCompatibleFormat(string imagePath, string outFileRoot)
    {
        if (imagePath.IsNullOrEmpty() || !File.Exists(imagePath))
        {
            return null;
        }

        FileSystem.CreateDirectory(Path.GetDirectoryName(outFileRoot)!);
        if (imagePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
        {
            var icoPath = outFileRoot + ".ico";
            if (IconExtractor.ExtractMainIconFromFile(imagePath, icoPath))
            {
                return icoPath;
            }
            else
            {
                return null;
            }
        }
        else if (imagePath.EndsWith(".tga", StringComparison.OrdinalIgnoreCase))
        {
            var pngPath = outFileRoot + ".png";
            try
            {
                var bitmap = BitmapExtensions.TgaToBitmap(imagePath);
                if (bitmap != null)
                {
                    File.WriteAllBytes(pngPath, bitmap.ToPngArray());
                    return pngPath;
                }
                else
                {
                    logger.Error($"Failed to covert {imagePath} to bitmap.");
                    return null;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, $"Failed to covert {imagePath} to png.");
                return null;
            }
        }
        else
        {
            return imagePath;
        }
    }
}
