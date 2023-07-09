using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Playnite.Tests;

public class DataGenerator
{
    public List<T> GenerateList<T>(int size, Random random, bool boolState, Func<T>? generator = null)
    {
        var items = new List<T>(size);
        Enumerable.Range(1, random.Next(1, size)).ForEach(a => items.Add(generator == null ? (T)GenerateValue(typeof(T), random, boolState)! : generator()));
        return items;
    }

    public HashSet<T> GenerateHashSet<T>(int size, Random random, bool boolState, Func<T>? generator = null)
    {
        var items = new HashSet<T>(size);
        Enumerable.Range(1, random.Next(1, size)).ForEach(a => items.Add(generator == null ? (T)GenerateValue(typeof(T), random, boolState)! : generator()));
        return items;
    }

    public object? GenerateValue(Type type, Random random, bool boolState)
    {
        if (type == typeof(string))
        {
            return GlobalRandom.GetRandomString(random.Next(10, 100));
        }
        else if (type == typeof(Guid))
        {
            return Guid.NewGuid();
        }
        else if (type == typeof(bool))
        {
            return boolState;
        }
        else if (type == typeof(DateTime?))
        {
            return new DateTime(random.Next(1980, 2020), random.Next(1, 12), random.Next(1, 28));
        }
        else if (type == typeof(PartialDate))
        {
            return new PartialDate(random.Next(1980, 2020), random.Next(1, 12), random.Next(1, 28));
        }
        else if (type == typeof(ulong?) || type == typeof(ulong))
        {
            return (ulong)random.Next(0, int.MaxValue);
        }
        else if (type == typeof(int?) || type == typeof(int))
        {
            return random.Next(0, 100);
        }
        else if (type == typeof(uint?) || type == typeof(uint))
        {
            return (uint)random.Next(0, 100);
        }
        else if (type.IsEnum)
        {
            var values = Enum.GetValues(type);
            return values.GetValue(random.Next(values.Length));
        }
        else if (Nullable.GetUnderlyingType(type)?.IsEnum == true)
        {
            var values = Enum.GetValues(Nullable.GetUnderlyingType(type)!);
            return values.GetValue(random.Next(values.Length));
        }
        else if (type.FullName?.StartsWith("Playnite.", StringComparison.Ordinal) == true)
        {
            var genMethod = typeof(DataGenerator).GetMethod(nameof(GenerateObject))!.MakeGenericMethod(type);
            return genMethod.Invoke(this, new object[] { random, boolState });
        }
        else if (type.Name?.StartsWith("List`1", StringComparison.Ordinal) == true)
        {
            var baseType = type.GetGenericArguments()[0];
            var genMethod = typeof(DataGenerator).GetMethod(nameof(GenerateList))!.MakeGenericMethod(baseType!);
            return genMethod.Invoke(this, new object[] { 5, random, boolState, null! });
        }
        else if (type.Name?.StartsWith("HashSet`1", StringComparison.Ordinal) == true)
        {
            var baseType = type.GetGenericArguments()[0];
            var genMethod = typeof(DataGenerator).GetMethod(nameof(GenerateHashSet))!.MakeGenericMethod(baseType!);
            return genMethod.Invoke(this, new object[] { 5, random, boolState, null! });
        }

        throw new Exception($"Uknown member type {type}");
    }

    public T GenerateObject<T>(Random random, bool boolState)
    {
        var obj = typeof(T).CrateInstance<T>();
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => prop.GetCustomAttribute(typeof(JsonIgnoreAttribute)) == null))
        {
            prop.SetValue(obj, GenerateValue(prop.PropertyType, random, boolState));
        }

        return obj;
    }
}
