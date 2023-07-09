using System.ComponentModel;

namespace Playnite;

public enum InstallSizeGroup
{
    [Description(LocId.none)]                   None = 0,
    [Description(LocId.size_zero_to100_mb)]     S0_0MB_100MB = 1,
    [Description(LocId.size100_mb_to1_gb)]      S1_100MB_1GB = 2,
    [Description(LocId.size1_gb_to5_gb)]        S2_1GB_5GB = 3,
    [Description(LocId.size5_gb_to10_gb)]       S3_5GB_10GB = 4,
    [Description(LocId.size10_gb_to20_gb)]      S4_10GB_20GB = 5,
    [Description(LocId.size20_gb_to40_gb)]      S5_20GB_40GB = 6,
    [Description(LocId.size40_gb_to100_gb)]     S6_40GB_100GB = 7,
    [Description(LocId.size_more_than100_gb)]   S7_100GBPlus = 8
}

public enum PastTimeSegment
{
    [Description(LocId.today)]                  Today = 0,
    [Description(LocId.yesterday)]              Yesterday = 1,
    [Description(LocId.in_past7_days)]          PastWeek = 2,
    [Description(LocId.in_past31_days)]         PastMonth = 3,
    [Description(LocId.in_past365_days)]        PastYear = 4,
    [Description(LocId.more_than365_days_ago)]  MoreThenYear = 5,
    [Description(LocId.never)]                  Never = 6
}

public enum ScoreRating
{
    None = 0,
    Negative = 1,
    Positive = 2,
    Mixed = 3
}

public enum ScoreGroup
{
    [Description("0x")]         O0x = 0,
    [Description("1x")]         O1x = 1,
    [Description("2x")]         O2x = 2,
    [Description("3x")]         O3x = 3,
    [Description("4x")]         O4x = 4,
    [Description("5x")]         O5x = 5,
    [Description("6x")]         O6x = 6,
    [Description("7x")]         O7x = 7,
    [Description("8x")]         O8x = 8,
    [Description("9x")]         O9x = 9,
    [Description(LocId.none)]   None = 10
}

public enum PlaytimeCategory
{
    [Description(LocId.played_none)]                NotPlayed = 0,
    [Description(LocId.playtime_less_then_an_hour)] LessThenHour = 1,
    [Description(LocId.playtime1to10)]              O1_10 = 2,
    [Description(LocId.playtime10to100)]            O10_100 = 3,
    [Description(LocId.playtime100to500)]           O100_500 = 4,
    [Description(LocId.playtime500to1000)]          O500_1000 = 5,
    [Description(LocId.playtime1000plus)]           O1000plus = 6
}