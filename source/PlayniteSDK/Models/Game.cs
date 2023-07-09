using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Playnite.SDK.Data;

namespace Playnite.SDK.Models
{


    /// <summary>
    /// Represents Playnite game object.
    /// </summary>
    public class Game : DatabaseObject
    {
        /// <summary>
        /// Gets the most recent date between the last played and added dates.
        /// </summary>
        /// <returns></returns>
        public DateTime? GetGameRecentActivity()
        {
            if (lastActivity == null)
            {
                return added;
            }
            else if (added == null || lastActivity > added)
            {
                return lastActivity;
            }
            else
            {
                return added;
            }
        }

        /// <summary>
        /// Gets play time category.
        /// </summary>
        /// <param name="seconds">Play time in seconds.</param>
        /// <returns></returns>
        private PlaytimeCategory GetPlayTimeCategory(ulong seconds)
        {
            if (seconds == 0)
            {
                return PlaytimeCategory.NotPlayed;
            }

            var hours = seconds / 3600;
            if (hours < 1)
            {
                return PlaytimeCategory.LessThenHour;
            }
            else if (hours >= 1 && hours <= 10)
            {
                return PlaytimeCategory.O1_10;
            }
            else if (hours >= 10 && hours <= 100)
            {
                return PlaytimeCategory.O10_100;
            }
            else if (hours >= 100 && hours <= 500)
            {
                return PlaytimeCategory.O100_500;
            }
            else if (hours >= 500 && hours <= 1000)
            {
                return PlaytimeCategory.O500_1000;
            }
            else
            {
                return PlaytimeCategory.O1000plus;
            }
        }

        /// <summary>
        /// Gets time segment.
        /// </summary>
        /// <param name="dateTime">Date time to be measured.</param>
        /// <returns></returns>
        private PastTimeSegment GetPastTimeSegment(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return PastTimeSegment.Never;
            }

            if (dateTime.Value.Date == DateTime.Today)
            {
                return PastTimeSegment.Today;
            }

            if (dateTime.Value.Date.AddDays(1) == DateTime.Today)
            {
                return PastTimeSegment.Yesterday;
            }

            var diff = DateTime.Now - dateTime.Value;
            if (diff.TotalDays < 7)
            {
                return PastTimeSegment.PastWeek;
            }

            if (diff.TotalDays < 31)
            {
                return PastTimeSegment.PastMonth;
            }

            if (diff.TotalDays < 365)
            {
                return PastTimeSegment.PastYear;
            }

            return PastTimeSegment.MoreThenYear;
        }

        /// <summary>
        /// Gets score rating.
        /// </summary>
        /// <param name="score">Score.</param>
        /// <returns></returns>
        private ScoreRating GetScoreRating(int? score)
        {
            if (score == null)
            {
                return ScoreRating.None;
            }
            else if (score > 75)
            {
                return ScoreRating.Positive;
            }
            else if (score > 25)
            {
                return ScoreRating.Mixed;
            }
            else
            {
                return ScoreRating.Negative;
            }
        }

        /// <summary>
        /// Gets score group.
        /// </summary>
        /// <param name="score">Score.</param>
        /// <returns></returns>
        private ScoreGroup GetScoreGroup(int? score)
        {
            if (score >= 0 && score < 10)
            {
                return ScoreGroup.O0x;
            }

            if (score >= 10 && score < 20)
            {
                return ScoreGroup.O1x;
            }

            if (score >= 20 && score < 30)
            {
                return ScoreGroup.O2x;
            }

            if (score >= 30 && score < 40)
            {
                return ScoreGroup.O3x;
            }

            if (score >= 40 && score < 50)
            {
                return ScoreGroup.O4x;
            }

            if (score >= 50 && score < 60)
            {
                return ScoreGroup.O5x;
            }

            if (score >= 60 && score < 70)
            {
                return ScoreGroup.O6x;
            }

            if (score >= 70 && score < 80)
            {
                return ScoreGroup.O7x;
            }

            if (score >= 80 && score < 90)
            {
                return ScoreGroup.O8x;
            }

            if (score >= 90)
            {
                return ScoreGroup.O9x;
            }

            return ScoreGroup.None;
        }

        /// <summary>
        /// Gets or sets game database reference.
        /// </summary>
        internal static IGameDatabase DatabaseReference
        {
            get; set;
        }

        /// <summary>
        /// Creates new instance of a Game object.
        /// </summary>
        public Game() : base()
        {
            GameId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Creates new instance of a Game object with specific name.
        /// </summary>
        /// <param name="name">Game name.</param>
        public Game(string name) : this()
        {
            Name = name;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name;
        }

       

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public char GetNameGroup()
        {
            var nameMatch = string.IsNullOrEmpty(SortingName) ? Name : SortingName;
            if (string.IsNullOrEmpty(nameMatch))
            {
                return '#';
            }
            else
            {
                var firstChar = char.ToUpper(nameMatch[0]);
                return char.IsLetter(firstChar) ? firstChar : '#';
            }
        }

        /// <summary>
        /// Gets game Install Size group.
        /// </summary>
        public InstallSizeGroup GetInstallSizeGroup()
        {
            if (installSize == null || installSize == 0)
            {
                return InstallSizeGroup.None;
            }
            else if (installSize <= 0x6400000) //100MB
            {
                return InstallSizeGroup.S0_0MB_100MB;
            }
            else if (installSize <= 0x40000000) //1GB
            {
                return InstallSizeGroup.S1_100MB_1GB;
            }
            else if (installSize <= 0x140000000) //5GB
            {
                return InstallSizeGroup.S2_1GB_5GB;
            }
            else if (installSize <= 0x280000000) //10GB
            {
                return InstallSizeGroup.S3_5GB_10GB;
            }
            else if (installSize <= 0x500000000) //20GB
            {
                return InstallSizeGroup.S4_10GB_20GB;
            }
            else if (installSize <= 0xA00000000) //40GB
            {
                return InstallSizeGroup.S5_20GB_40GB;
            }
            else if (installSize <= 0x1900000000) //100GB
            {
                return InstallSizeGroup.S6_40GB_100GB;
            }

            return InstallSizeGroup.S7_100GBPlus;
        }

        /// <summary>
        /// Gets game Install Drive group.
        /// </summary>
        public string GetInstallDriveGroup()
        {
            var installDrive = GetInstallDrive();
            if (string.IsNullOrEmpty(installDrive))
            {
                return ResourceProvider.GetString("LOCNone");
            }
            else
            {
                return installDrive;
            }
        }

        /// <summary>
        /// Gets game Install Drive.
        /// </summary>
        public string GetInstallDrive()
        {
            if (!isInstalled)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(InstallDirectory))
            {
                return string.Empty;
            }

            try
            {
                return Path.GetPathRoot(InstallDirectory).ToUpperInvariant();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
