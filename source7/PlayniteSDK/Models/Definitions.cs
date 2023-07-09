namespace Playnite;

/// <summary>
/// Represents built-in region definition.
/// </summary>
public class RegionDefinition : IEquatable<RegionDefinition>
{
    /// <summary>
    /// Gets region id.
    /// </summary>
    public string? Id { get; set; }
    /// <summary>
    /// Gets region name.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Gets value indicating whether the region should be imported into new libraries.
    /// </summary>
    public bool DefaultImport { get; set; }
    /// <summary>
    /// Gets ID of the region on IGDB database.
    /// </summary>
    public ulong IgdbId { get; set; }
    /// <summary>
    /// Gets region codes.
    /// </summary>
    public List<string>? Codes { get; set; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Id?.GetHashCode(StringComparison.Ordinal) ?? 0;
    }

    /// <inheritdoc/>
    public bool Equals(RegionDefinition? other)
    {
        return other?.Id == Id;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is RegionDefinition region)
        {
            return Equals(region);
        }
        else
        {
            return false;
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? Id ?? "uknown";
    }
}

/// <summary>
/// Represents built-in platform definition.
/// </summary>
public class PlatformDefinition : IEquatable<PlatformDefinition>
{
    /// <summary>
    /// Gets ID of the platform on IGDB database.
    /// </summary>
    public ulong IgdbId { get; set; }
    /// <summary>
    /// Gets platform name.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Gets platform id.
    /// </summary>
    public string? Id { get; set; }
    /// <summary>
    /// Gets list of platform ROM database ids.
    /// </summary>
    public List<string>? Databases { get; set; }
    /// <summary>
    /// Gets list of emulator IDs supporting this platform.
    /// </summary>
    public List<string>? Emulators { get; set; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Id?.GetHashCode(StringComparison.Ordinal) ?? 0;
    }

    /// <inheritdoc/>
    public bool Equals(PlatformDefinition? other)
    {
        return other?.Id == Id;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is PlatformDefinition platform)
        {
            return Equals(platform);
        }
        else
        {
            return false;
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? Id ?? "uknown";
    }
}