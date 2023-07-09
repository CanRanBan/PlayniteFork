using SqlNado;
using System.Collections;
using System.Collections.Concurrent;
using System.Security.RightsManagement;

namespace Playnite;

// This is to properly handle table names for generic types:
// https://github.com/smourier/SQLNado/issues/12
public class CustomSqliteDb : SQLiteDatabase
{
    public CustomSqliteDb(string filePath) :
        base(filePath, SQLiteOpenOptions.SQLITE_OPEN_READWRITE | SQLiteOpenOptions.SQLITE_OPEN_CREATE)
    {
    }

    protected override SQLiteObjectTableBuilder CreateObjectTableBuilder(Type type, SQLiteBuildTableOptions? options = null) =>
        new GenericsSQLiteObjectTableBuilder(this, type, options);

    public class GenericsSQLiteObjectTableBuilder : SQLiteObjectTableBuilder
    {
        private readonly string? genericName;

        public GenericsSQLiteObjectTableBuilder(CustomSqliteDb database, Type type, SQLiteBuildTableOptions? options = null)
            : base(database, type, options)
        {
            genericName = GetTableName(type);
        }

        public static string? GetTableName(Type type)
        {
            var genericArguments = type.GenericTypeArguments;
            if (genericArguments.Length > 0)
            {
                return string.Join("_", genericArguments.Select(a => a.Name));
            }

            return null;
        }

        protected override SQLiteObjectTable CreateObjectTable(string name)
        {
            if (!genericName.IsNullOrEmpty())
            {
                name = genericName;
            }

            return base.CreateObjectTable(name);
        }
    }
}

public class DbStoreItem<T> where T : DatabaseObject
{
    [SQLiteColumn(IsPrimaryKey = true)]
    public Guid Id { get; set; }

    public string? Data { get; set; }

    public DbStoreItem()
    {
    }

    public DbStoreItem(Guid id, string? data)
    {
        Id = id;
        Data = data;
    }
}

public class GenericStoreItem<T>
{
    [SQLiteColumn(IsPrimaryKey = true)]
    public Guid Id { get; set; }

    public string? Data { get; set; }

    public GenericStoreItem()
    {
    }

    public GenericStoreItem(Guid id, string? data)
    {
        Id = id;
        Data = data;
    }
}

public class CollectionItemUpdateData<T> where T : DatabaseObject
{
    public T OldData { get; }
    public T NewData { get; }

    public CollectionItemUpdateData(T oldData, T newData)
    {
        OldData = oldData;
        NewData = newData;
    }
}

public class ItemUpdatedEventArgs<T> : EventArgs where T : DatabaseObject
{
    public List<CollectionItemUpdateData<T>> Items { get; }

    public ItemUpdatedEventArgs(T oldData, T newData)
    {
        Items = new List<CollectionItemUpdateData<T>>() { new CollectionItemUpdateData<T>(oldData, newData) };
    }

    public ItemUpdatedEventArgs(IEnumerable<CollectionItemUpdateData<T>> updatedItems)
    {
        Items = updatedItems.ToList();
    }
}

public class ItemsAddedEventArgs<T> : EventArgs where T : DatabaseObject
{
    public List<T> Items { get; }

    public ItemsAddedEventArgs(List<T> items)
    {
        Items = items;
    }

    public ItemsAddedEventArgs(T item)
    {
        Items = new List<T>(1) { item };
    }
}

public class ItemsRemovedEventArgs<T> : EventArgs where T : DatabaseObject
{
    public List<T> Items { get; }

    public ItemsRemovedEventArgs(List<T> items)
    {
        Items = items;
    }

    public ItemsRemovedEventArgs(T item)
    {
        Items = new List<T>(1) { item };
    }
}

public class DatabaseCollection<T> : ICollection<T> where T : DatabaseObject
{
    private readonly ConcurrentDictionary<Guid, T> Items = new();
    private readonly string tableName;

    public readonly bool UseMemoryCache;
    public readonly Library Library;
    public readonly CustomSqliteDb Sql;

    public int Count => UseMemoryCache ? Items.Count : Sql.Count<DbStoreItem<T>>();
    public bool IsReadOnly => false;

    public event EventHandler<ItemUpdatedEventArgs<T>>? ItemsUpdated;
    public event EventHandler<ItemsAddedEventArgs<T>>? ItemsAdded;
    public event EventHandler<ItemsRemovedEventArgs<T>>? ItemsRemoved;

    public DatabaseCollection(Library lib, CustomSqliteDb db, bool useMemoryCache)
    {
        Sql = db;
        Library = lib;
        UseMemoryCache = useMemoryCache;
        tableName = CustomSqliteDb.GenericsSQLiteObjectTableBuilder.GetTableName(typeof(DbStoreItem<T>))!;

        if (UseMemoryCache && db.TableExists<DbStoreItem<T>>())
        {
            var initUpdateList = new List<DbStoreItem<T>>();
            foreach (var item in db.LoadAll<DbStoreItem<T>>())
            {
                if (item.Data.IsNullOrEmpty())
                {
                    continue;
                }

                var data = Serialization.FromJson<T>(item.Data);
                if (data is null)
                {
                    continue;
                }

                if (Init(data) == true)
                {
                    item.Data = Serialization.ToJson(data);
                    initUpdateList.Add(item);
                }

                Items[item.Id] = data;
            }

            if (initUpdateList.HasItems())
            {
                db.Save(initUpdateList);
            }
        }
    }

    public virtual bool Init(T item)
    {
        return false;
    }

    public virtual void Add(T item)
    {
        Sql.Save(new DbStoreItem<T>(item.Id, Serialization.ToJson(item)));
        if (UseMemoryCache)
        {
            Items[item.Id] = item;
        }

        ItemsAdded?.Invoke(this, new(item));
    }

    public virtual void Add(IEnumerable<T> items)
    {
        var update = items.Select(a => new DbStoreItem<T>(a.Id, Serialization.ToJson(a)));
        Sql.Save(update);
        if (UseMemoryCache)
        {
            items.ForEach(a => Items[a.Id] = a);
        }

        ItemsAdded?.Invoke(this, new(items.ToList()));
    }

    public virtual void Update(T item)
    {
        Sql.Save(new DbStoreItem<T>(item.Id, Serialization.ToJson(item)));
        if (UseMemoryCache)
        {
            Items[item.Id] = item;
        }

        var dbItem = GetFromDb(item.Id);
        if (dbItem == null)
        {
            ItemsAdded?.Invoke(this, new(item));
        }
        else
        {
            ItemsUpdated?.Invoke(this, new(dbItem, item));
        }
    }

    public virtual bool Remove(Guid id)
    {
        var dbItem = GetFromDb(id);
        if (dbItem != null)
        {
            Sql.Delete(new DbStoreItem<T>(id, null));
        }

        if (UseMemoryCache)
        {
            Items.TryRemove(id, out _);
        }

        if (dbItem != null)
        {
            ItemsRemoved?.Invoke(this, new(dbItem));
            return true;
        }

        return false;
    }

    public virtual bool Remove(T item)
    {
        return Remove(item.Id);
    }

    private T? GetFromDb(Guid id)
    {
        var item = Sql.LoadByPrimaryKey<DbStoreItem<T>>(id);
        if (item?.Data != null)
        {
            return Serialization.FromJson<T>(item.Data);
        }

        return null;
    }

    public T? Get(Guid id)
    {
        if (UseMemoryCache)
        {
            if (Items.TryGetValue(id, out var data))
            {
                return data;
            }

            return null;
        }

        return GetFromDb(id);
    }

    public List<T> Get(IEnumerable<Guid> ids)
    {
        var result = new List<T>();
        foreach (var id in ids)
        {
            var item = Get(id);
            if (item != null)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public void Clear()
    {
        throw new NotSupportedException();
    }

    public bool Contains(T item)
    {
        return Contains(item.Id);
    }

    public bool Contains(Guid id)
    {
        if (UseMemoryCache)
        {
            return Items.ContainsKey(id);
        }

        // TODO: optimize, have HashSet with IDs cached even for non cached collections
        return Sql.ExecuteScalar<int>($"SELECT EXISTS(SELECT 1 FROM {tableName} WHERE Id = '{id}');") == 1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotSupportedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (UseMemoryCache)
        {
            return Items.Values.GetEnumerator();
        }

        return Sql.LoadAll<DbStoreItem<T>>().
            Where(a => !a.Data.IsNullOrWhiteSpace()).
            Select(a => Serialization.FromJson<T>(a.Data!)).
            GetEnumerator()!;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        if (UseMemoryCache)
        {
            return Items.Values.GetEnumerator();
        }

        return Sql.LoadAll<DbStoreItem<T>>().
            Where(a => !a.Data.IsNullOrWhiteSpace()).
            Select(a => Serialization.FromJson<T>(a.Data!)).
            GetEnumerator()!;
    }
}

public partial class GameCollection
{
    public override bool Init(Game game)
    {
        var modified = false;

        foreach (var variant in game.Variants ?? Enumerable.Empty<GameVariant>())
        {
            if (variant.IsInstalling)
            {
                variant.IsInstalling = false;
                modified = true;
            }

            if (variant.IsLaunching)
            {
                variant.IsLaunching = false;
                modified = true;
            }

            if (variant.IsRunning)
            {
                variant.IsRunning = false;
                modified = true;
            }

            if (variant.IsUninstalling)
            {
                variant.IsUninstalling = false;
                modified = true;
            }
        }

        return modified;
    }

    public override void Add(Game item)
    {
        item.Added = DateTime.Now;
        base.Add(item);
    }

    public override void Add(IEnumerable<Game> items)
    {
        var date = DateTime.Now;
        items.ForEach(a => a.Added = date);
        base.Add(items);
    }

    public override void Update(Game item)
    {
        var dbItem = Get(item.Id);
        if (dbItem != null)
        {
            if (dbItem.Icon != item.Icon && dbItem.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Icon);
            }

            if (dbItem.Cover != item.Cover && dbItem.Cover?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Cover);
            }

            if (dbItem.Background != item.Background && dbItem.Background?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Background);
            }
        }

        item.Modified = DateTime.Now;
        base.Update(item);
    }

    public override bool Remove(Guid id)
    {
        var item = Get(id);
        if (item == null)
        {
            return false;
        }

        if (item.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Icon);
        }

        if (item.Cover?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Cover);
        }

        if (item.Background?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Background);
        }

        return base.Remove(id);
    }
}

public class CompletionStatusSettings
{
    public Guid DefaultStatus { get; set; }
    public Guid PlayedStatus { get; set; }
}

public partial class CompletionStatusCollection
{
    public CompletionStatusSettings GetSettings()
    {
        var item = Sql.LoadByPrimaryKey<GenericStoreItem<CompletionStatusSettings>>(Guid.Empty);
        if (item?.Data is not null)
        {
            var set = Serialization.FromJson<CompletionStatusSettings>(item.Data);
            if (set != null)
            {
                return set;
            }
        }

        return new CompletionStatusSettings();
    }

    public void SetSettings(CompletionStatusSettings settings)
    {
        Sql.Save(new GenericStoreItem<CompletionStatusSettings>(Guid.Empty, Serialization.ToJson(settings)));
    }

    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.CompletionStatusId == itemId))
        {
            game.CompletionStatusId = Guid.Empty;
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class AgeRatingCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.AgeRatingIds?.Contains(itemId) == true))
        {
            game.AgeRatingIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class CategoryCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.CategoryIds?.Contains(itemId) == true))
        {
            game.CategoryIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class CompanyCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games)
        {
            var modified = false;
            if (game.PublisherIds?.Contains(itemId) == true)
            {
                game.PublisherIds.Remove(itemId);
                modified = true;
            }

            if (game.DeveloperIds?.Contains(itemId) == true)
            {
                game.DeveloperIds.Remove(itemId);
                modified = true;
            }

            if (modified)
            {
                Library.Games.Update(game);
            }
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class GameFeatureCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.FeatureIds?.Contains(itemId) == true))
        {
            game.FeatureIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class GameSourceCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.SourceId == itemId))
        {
            game.SourceId = Guid.Empty;
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class GenreCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.GenreIds?.Contains(itemId) == true))
        {
            game.GenreIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class RegionCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.RegionIds?.Contains(itemId) == true))
        {
            game.RegionIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class SeriesCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.SeriesIds?.Contains(itemId) == true))
        {
            game.SeriesIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class TagCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.TagIds?.Contains(itemId) == true))
        {
            game.TagIds!.Remove(itemId);
            Library.Games.Update(game);
        }
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        return base.Remove(id);
    }
}

public partial class PlatformCollection
{
    private void RemoveUsage(Guid itemId)
    {
        foreach (var game in Library.Games.Where(a => a.PlatformIds?.Contains(itemId) == true))
        {
            game.PlatformIds!.Remove(itemId);
            Library.Games.Update(game);
        }

        // TODO remove usage from emulators as well
    }

    public override bool Remove(Guid id)
    {
        RemoveUsage(id);
        var item = Get(id);
        if (item == null)
        {
            return false;
        }

        if (item.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Icon);
        }

        if (item.Cover?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Cover);
        }

        if (item.Background?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Background);
        }

        return base.Remove(id);
    }

    public override void Update(Platform item)
    {
        var dbItem = Get(item.Id);
        if (dbItem != null)
        {
            if (dbItem.Icon != item.Icon && dbItem.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Icon);
            }

            if (dbItem.Cover != item.Cover && dbItem.Cover?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Cover);
            }

            if (dbItem.Background != item.Background && dbItem.Background?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Background);
            }
        }

        base.Update(item);
    }
}

public partial class AppSoftwareCollection
{
    public override bool Remove(Guid id)
    {
        var item = Get(id);
        if (item == null)
        {
            return false;
        }

        if (item.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
        {
            Library.RemoveFile(item.Icon);
        }

        return base.Remove(id);
    }

    public override void Update(AppSoftware item)
    {
        var dbItem = Get(item.Id);
        if (dbItem != null)
        {
            if (dbItem.Icon != item.Icon && dbItem.Icon?.StartsWith(Library.DbFilePathPrefix, StringComparison.Ordinal) == true)
            {
                Library.RemoveFile(dbItem.Icon);
            }
        }

        base.Update(item);
    }
}