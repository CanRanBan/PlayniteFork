using Playnite.Common;
using Playnite.SDK;
using Playnite.SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Playnite.Emulators
{
    public class Emulation : IEmulationAPI
    {
        private static readonly ILogger logger = LogManager.GetLogger();
 
        private static string emulatorDefDir => Path.Combine(PlaynitePaths.ProgramPath, "Emulation", "Emulators");

        public const string StartupScriptFileName = "startGame.ps1";
        public const string GameImportScriptFileName = "importGames.ps1";

        #region IEmulationAPI

        IList<EmulatedPlatform> IEmulationAPI.Platforms => Platforms.GetClone();
        IList<EmulatedRegion> IEmulationAPI.Regions => Regions.GetClone();
        IList<EmulatorDefinition> IEmulationAPI.Emulators => Definitions.GetClone();

        EmulatedPlatform IEmulationAPI.GetPlatform(string platformsId)
        {
            return GetPlatform(platformsId).GetClone();
        }

        EmulatedRegion IEmulationAPI.GetRegion(string regionId)
        {
            return GetRegion(regionId).GetClone();
        }

        EmulatorDefinition IEmulationAPI.GetEmulator(string emulatorDefinitionId)
        {
            return GetDefition(emulatorDefinitionId).GetClone();
        }

        #endregion IEmulationAPI


        public static EmulatedPlatform GetPlatform(string platformsId)
        {
            return Platforms.FirstOrDefault(a => a.Id == platformsId);
        }

        public static EmulatedPlatform GetPlatformByDatabase(string databaseName)
        {
            return Platforms.FirstOrDefault(a => a.Databases?.ContainsString(databaseName, StringComparison.OrdinalIgnoreCase) == true);
        }

        public static EmulatedRegion GetRegion(string regionsId)
        {
            return Regions.FirstOrDefault(a => a.Id == regionsId);
        }

        public static EmulatedRegion GetRegionByCode(string code)
        {
            return Regions.FirstOrDefault(a => a.Codes.ContainsString(code, StringComparison.OrdinalIgnoreCase));
        }

        private static List<EmulatorDefinition> definitions;
        public static IList<EmulatorDefinition> Definitions
        {
            get
            {
                if (definitions != null)
                {
                    return definitions;
                }

                definitions = new List<EmulatorDefinition>();
                if (!Directory.Exists(emulatorDefDir))
                {
                    return definitions;
                }

                try
                {
                    foreach (var dir in Directory.GetDirectories(emulatorDefDir))
                    {
                        var manifest = Path.Combine(dir, "emulator.yaml");
                        try
                        {
                            var data = Serialization.FromYamlFile<EmulatorDefinition>(manifest);
                            data.DirectoryName = Path.GetFileName(dir);
                            definitions.Add(data);
                        }
                        catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                        {
                            logger.Error(e, $"Failed to load emulator definition file {manifest}");
                        }
                    }
                }
                catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                {
                    definitions = new List<EmulatorDefinition>();
                    logger.Error(e, "Failed to load emulator definitions.");
                }

                return definitions.AsReadOnly();
            }
        }

        public static EmulatorDefinition GetDefition(string emulatorId)
        {
            if (emulatorId.IsNullOrEmpty())
            {
                return null;
            }

            return Definitions.FirstOrDefault(a => a.Id == emulatorId);
        }

        public static EmulatorDefinitionProfile GetProfile(string emulatorId, string profileName)
        {
            if (emulatorId.IsNullOrEmpty())
            {
                return null;
            }

            return Definitions.FirstOrDefault(a => a.Id == emulatorId)?.Profiles?.FirstOrDefault(a => a.Name == profileName);
        }

        public static bool IsEmuProfileValid(SDK.Models.Emulator emulator, string profileId)
        {
            if (profileId.StartsWith(SDK.Models.CustomEmulatorProfile.ProfilePrefix))
            {
                return emulator.CustomProfiles?.Any(a => a.Id == profileId) == true;
            }
            else
            {
                return GetProfile(emulator.BuiltInConfigId, profileId) != null;
            }
        }

        public static string GetExecutable(string directory, EmulatorDefinitionProfile profile, bool relative)
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception($"{directory} not found.");
            }

            var fileEnumerator = new SafeFileEnumerator(directory, "*.*", SearchOption.AllDirectories);
            foreach (var file in fileEnumerator)
            {
                if (file.Attributes.HasFlag(FileAttributes.Directory))
                {
                    continue;
                }

                var relativePath = file.FullName.Replace(Path.GetDirectoryName(file.FullName), "").Trim(Path.DirectorySeparatorChar);
                var regex = new Regex(profile.StartupExecutable, RegexOptions.IgnoreCase);
                if (regex.IsMatch(relativePath))
                {
                    if (relative)
                    {
                        return relativePath;
                    }
                    else
                    {
                        return file.FullName;
                    }
                }
            }

            return null;
        }

        public static string GetStartupScriptPath(EmulatorDefinition emulator)
        {
            return Path.Combine(emulatorDefDir, emulator.DirectoryName, "startGame.ps1");
        }

        public static string GetGameImportScriptPath(EmulatorDefinition emulator)
        {
            return Path.Combine(emulatorDefDir, emulator.DirectoryName, "importGames.ps1");
        }
    }
}
