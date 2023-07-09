﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Playnite;
using System.Windows;
using System.Windows.Markup;
using System.Text.RegularExpressions;
using Playnite.Settings;
using Playnite.Common;
using Playnite.SDK;
using YamlDotNet.Serialization;
using Playnite.API;
using Playnite.Extensions.Markup;
using System.Windows.Input;
using Playnite.Plugins;

namespace Playnite
{
    public class ThemeManager
    {
        public static void ApplyFullscreenButtonPrompts(Application app, FullscreenButtonPrompts prompts)
        {
            if (prompts == FullscreenSettings.DefaultButtonPrompts)
            {
                var defaultXaml = $"{FullscreenSettings.DefaultButtonPrompts.ToString()}.xaml";
                foreach (var dir in PlayniteApplication.CurrentNative.Resources.MergedDictionaries.ToList())
                {
                    if (dir.Source == null)
                    {
                        continue;
                    }

                    if (dir.Source.OriginalString.Contains("ButtonPrompts") &&
                        !dir.Source.OriginalString.EndsWith(defaultXaml))
                    {
                        PlayniteApplication.CurrentNative.Resources.MergedDictionaries.Remove(dir);
                    }
                }
            }
            else
            {
                var promptsPath = Path.Combine(ThemeManager.DefaultTheme.DirectoryPath, "Images", "ButtonPrompts");
                foreach (var dir in Directory.GetDirectories(promptsPath))
                {
                    var dirInfo = new DirectoryInfo(dir);
                    var promptXaml = Path.Combine(dir, $"{dirInfo.Name}.xaml");
                    if (File.Exists(promptXaml) && dirInfo.Name == prompts.ToString())
                    {
                        var xaml = Xaml.FromFile(promptXaml);
                        if (xaml is ResourceDictionary xamlDir)
                        {
                            xamlDir.Source = new Uri(promptXaml, UriKind.Absolute);
                            PlayniteApplication.CurrentNative.Resources.MergedDictionaries.Add(xamlDir);
                        }
                    }
                }
            }
        }

        public static AddonLoadError ApplyTheme(Application app, ThemeManifest theme, ApplicationMode mode)
        {
            if (theme.Id.IsNullOrEmpty())
            {
                logger.Error($"Theme {theme.Name}, doesn't have ID.");
                return AddonLoadError.Uknown;
            }

            var apiVesion = mode == ApplicationMode.Desktop ? DesktopApiVersion : FullscreenApiVersion;
            if (!theme.ThemeApiVersion.IsNullOrEmpty())
            {
                var themeVersion = new Version(theme.ThemeApiVersion);
                if (themeVersion.Major != apiVesion.Major || themeVersion > apiVesion)
                {
                    logger.Error($"Failed to apply {theme.Name} theme, unsupported API version {theme.ThemeApiVersion}.");
                    return AddonLoadError.SDKVersion;
                }
            }

            var acceptableXamls = new List<string>();
            var defaultRoot = $"Themes/{mode.GetDescription()}/{DefaultTheme.DirectoryName}/";
            foreach (var dict in app.Resources.MergedDictionaries)
            {
                if (dict.Source.OriginalString.StartsWith(defaultRoot))
                {
                    acceptableXamls.Add(dict.Source.OriginalString.Replace(defaultRoot, "").Replace('/', '\\'));
                }
            }

            var allLoaded = true;
            foreach (var accXaml in acceptableXamls)
            {
                var xamlPath = Path.Combine(theme.DirectoryPath, accXaml);
                if (!File.Exists(xamlPath))
                {
                    continue;
                }

                try
                {
                    var xaml = Xaml.FromFile(xamlPath);
                }
                catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                {
                    logger.Error(e, $"Failed to load xaml {xamlPath}");
                    allLoaded = false;
                    break;
                }
            }

            if (!allLoaded)
            {
                return AddonLoadError.Uknown;
            }

            try
            {
                var cursorFile = ThemeFile.GetFilePath("cursor.cur");
                if (cursorFile.IsNullOrEmpty())
                {
                    cursorFile = ThemeFile.GetFilePath("cursor.ani");
                }

                if (!cursorFile.IsNullOrEmpty())
                {
                    Mouse.OverrideCursor = new Cursor(cursorFile, true);
                }
            }
            catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
            {
                logger.Error(e, "Failed to set custom mouse cursor.");
            }

            var themeRoot = $"Themes\\{mode.GetDescription()}\\{theme.DirectoryName}\\";
            // This is sad that we have to do this, but it fixes issues like #2328
            // We need to remove all loaded theme resources and reload them in specific order:
            //      default/1.xaml -> theme/1.xaml -> default/2.xaml -> theme/2.xaml etc.
            //
            // We can't just load custom theme files at the end or insert them in already loaded pool of resources
            // because styling with static references won't reload data from custom theme files.
            // That's why we also have to create new instances of default styles.
            foreach (var defaultRes in app.Resources.MergedDictionaries.ToList())
            {
                if (defaultRes.Source.OriginalString.StartsWith(defaultRoot))
                {
                    app.Resources.MergedDictionaries.Remove(defaultRes);
                }
            }

            foreach (var themeXamlFile in acceptableXamls)
            {
                var defaultPath = Path.Combine(PlaynitePaths.ThemesProgramPath, mode.GetDescription(), DefaultThemeDirName, themeXamlFile);
                var defaultXaml = Xaml.FromFile(defaultPath);
                if (defaultXaml is ResourceDictionary xamlDir)
                {
                    xamlDir.Source = new Uri(defaultPath, UriKind.Absolute);
                    app.Resources.MergedDictionaries.Add(xamlDir);
                }

                var xamlPath = Path.Combine(theme.DirectoryPath, themeXamlFile);
                if (!File.Exists(xamlPath))
                {
                    continue;
                }

                var xaml = Xaml.FromFile(xamlPath);
                if (xaml is ResourceDictionary themeDir)
                {
                    themeDir.Source = new Uri(xamlPath, UriKind.Absolute);
                    app.Resources.MergedDictionaries.Add(themeDir);
                }
                else
                {
                    logger.Error($"Skipping theme file {xamlPath}, it's not resource dictionary.");
                }
            }

            try
            {
                Localization.LoadAddonLocalization(theme.DirectoryPath);
            }
            catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
            {
                logger.Error(e, "Failed to load theme's localization files.");
                return AddonLoadError.Uknown;
            }

            return AddonLoadError.None;
        }

        public static IEnumerable<ThemeManifest> GetAvailableThemes()
        {
            foreach (var theme in GetAvailableThemes(ApplicationMode.Desktop))
            {
                yield return theme;
            }

            foreach (var theme in GetAvailableThemes(ApplicationMode.Fullscreen))
            {
                yield return theme;
            }
        }
    }
}