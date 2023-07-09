using Playnite.Common;
using Playnite.Controllers;
using Playnite.Database;
using Playnite.Emulators;
using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using Playnite.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Playnite
{
    public static class EmulatorProfileExtensions
    {
        public static CustomEmulatorProfile ExpandVariables(this CustomEmulatorProfile profile, Game game, string emulatorDir, string romPath)
        {
            var g = game.GetCopy();
            g.Roms = new System.Collections.ObjectModel.ObservableCollection<GameRom> { new GameRom("", romPath) };
            var expaded = profile.GetCopy();
            expaded.Arguments = g.ExpandVariables(expaded.Arguments, false, emulatorDir);
            expaded.WorkingDirectory = g.ExpandVariables(expaded.WorkingDirectory, true, emulatorDir);
            expaded.Executable = g.ExpandVariables(expaded.Executable, true, emulatorDir);
            expaded.TrackingPath = g.ExpandVariables(expaded.TrackingPath, true, emulatorDir);
            return expaded;
        }
    }



    public static class GameExtensions
    {
        private static ILogger logger = LogManager.GetLogger();

        

       

        public static Dictionary<Emulator, List<EmulatorProfile>> GetCompatibleEmulators(this Game game, GameDatabase database)
        {
            var emulators = new Dictionary<Emulator, List<EmulatorProfile>>();
            if (!game.Platforms.HasItems())
            {
                return emulators;
            }

            foreach (var emulator in database.Emulators)
            {
                var profiles = game.GetCompatibleProfiles(emulator);
                if (profiles.HasItems())
                {
                    emulators.Add(emulator, new List<EmulatorProfile>(profiles));
                }
            }

            return emulators;
        }

        public static List<EmulatorProfile> GetCompatibleProfiles(this Game game, Emulator emulator)
        {
            var profiles = new List<EmulatorProfile>();
            if (!game.Platforms.HasItems())
            {
                return profiles;
            }

            foreach (var profile in emulator.CustomProfiles ?? new ObservableCollection<CustomEmulatorProfile>())
            {
                if (profile.Platforms?.Intersect(game.PlatformIds).HasItems() == true)
                {
                    profiles.Add(profile);
                }
            }

            foreach (var profile in emulator.BuiltinProfiles ?? new ObservableCollection<BuiltInEmulatorProfile>())
            {
                var profDef = Emulation.GetProfile(emulator.BuiltInConfigId, profile.BuiltInProfileName);
                if (profDef == null)
                {
                    continue;
                }

                if (game.Platforms.Where(a => !a.SpecificationId.IsNullOrEmpty()).Any(a => profDef.Platforms.Contains(a.SpecificationId)))
                {
                    profiles.Add(profile);
                }
            }

            return profiles;
        }
    }
}
