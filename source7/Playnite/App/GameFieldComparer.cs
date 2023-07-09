using System.Text.RegularExpressions;

namespace Playnite;

public partial class GameFieldComparer : IEqualityComparer<string>
{
    [GeneratedRegex("[\\s-]", RegexOptions.Compiled)]
    private static partial Regex wordSeparatorRegex();

    public static readonly GameFieldComparer Instance = new();

    public bool Equals(string? x, string? y)
    {
        return StringEquals(x, y);
    }

    public static bool StringEquals(string? x, string? y)
    {
        if (x.IsNullOrEmpty() || y.IsNullOrEmpty())
        {
            return false;
        }

        return string.Equals(
            wordSeparatorRegex().Replace(x, ""),
            wordSeparatorRegex().Replace(y, ""),
            StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool FieldEquals<T>(T x, string y) where T : DatabaseObject
    {
        return StringEquals(x.Name, y);
    }

    public static bool FieldEquals<T>(T x, T y) where T : DatabaseObject
    {
        return StringEquals(x.Name, y.Name);
    }

    public int GetHashCode(string obj)
    {
        return wordSeparatorRegex().Replace(obj, "").ToLower().GetHashCode(StringComparison.Ordinal);
    }
}