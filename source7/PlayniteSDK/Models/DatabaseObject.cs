using CommunityToolkit.Mvvm.ComponentModel;

namespace Playnite;

/// <summary>
/// Represents base database object item.
/// </summary>
public partial class DatabaseObject : ObservableObject
{
    /// <summary>
    /// Gets or sets identifier of database object.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets name.
    /// </summary>
    [ObservableProperty] private string? name;

    /// <summary>
    /// Creates new instance of <see cref="DatabaseObject"/>.
    /// </summary>
    public DatabaseObject()
    {
    }

    /// <summary>
    /// Creates new instance of <see cref="DatabaseObject"/>.
    /// </summary>
    /// <param name="name"></param>
    public DatabaseObject(string name) : base()
    {
        Name = name;
    }

    /// <inheritdoc/>
    public override string? ToString()
    {
        return Name ?? string.Empty;
    }
}
