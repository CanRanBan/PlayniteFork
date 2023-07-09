using System.IO;

namespace Playnite;

internal class Definitions
{
    private static string platformsFile { get; } = Path.Combine(PlaynitePaths.ProgramDir, "Definitions", "Platforms.yaml");
    private static string regionsFile { get; } = Path.Combine(PlaynitePaths.ProgramDir, "Definitions", "Regions.yaml");

    private static readonly ILogger logger = LogManager.GetLogger();

    private static HashSet<PlatformDefinition>? platforms;
    public static IReadOnlyCollection<PlatformDefinition> Platforms
    {
        get
        {
            if (platforms != null)
            {
                return platforms;
            }

            if (File.Exists(platformsFile))
            {
                try
                {
                    platforms = Serialization.FromYamlFile<HashSet<PlatformDefinition>>(platformsFile);
                }
                catch (Exception e) when (!AppConfig.ThrowAllErrors)
                {
                    platforms = new HashSet<PlatformDefinition>();
                    logger.Error(e, $"Failed to emulated platforms list.");
                }
            }
            else
            {
                logger.Error("Emulation platforms file not found!");
                platforms = new HashSet<PlatformDefinition>();
            }

            return platforms;
        }
    }

    private static List<RegionDefinition>? regions;
    public static IReadOnlyCollection<RegionDefinition> Regions
    {
        get
        {
            if (regions != null)
            {
                return regions;
            }

            if (File.Exists(regionsFile))
            {
                try
                {
                    regions = Serialization.FromYamlFile<List<RegionDefinition>>(regionsFile);
                }
                catch (Exception e) when (!AppConfig.ThrowAllErrors)
                {
                    regions = new List<RegionDefinition>();
                    logger.Error(e, $"Failed to emulated regions list.");
                }
            }
            else
            {
                logger.Error("Emulation regions file not found!");
                regions = new List<RegionDefinition>();
            }

            return regions;
        }
    }
}
