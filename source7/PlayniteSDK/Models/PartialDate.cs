using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Playnite;

/// <summary>
///
/// </summary>
public class ReleaseDateConverter : JsonConverter<PartialDate>
{
    /// <inheritdoc/>
    public override PartialDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var strDate = reader.GetString();
            if (string.IsNullOrWhiteSpace(strDate))
            {
                throw new Exception("Can't deserialize ReleaseDate object from empty string.");
            }
            else
            {
                return PartialDate.Deserialize(strDate);
            }
        }
        // This is to support "wrong" ReleaseDate serialization that current IGDB plugin uses
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            reader.Read();
            var propName = reader.GetString();
            if (propName != "ReleaseDate")
            {
                throw new NotSupportedException("Can't deserialize release date, uknown format.");
            }

            reader.Read();
            var strDate = reader.GetString();
            if (string.IsNullOrWhiteSpace(strDate))
            {
                throw new Exception("Can't deserialize ReleaseDate object from empty string.");
            }
            else
            {
                while (reader.TokenType != JsonTokenType.EndObject)
                {
                    reader.Read();
                }

                return PartialDate.Deserialize(strDate);
            }
        }

        throw new NotSupportedException("Can't deserialize release date, uknown format.");
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, PartialDate value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Serialize());
    }
}

/// <summary>
/// Represents game release date.
/// </summary>
[JsonConverter(typeof(ReleaseDateConverter))]
public class PartialDate : IComparable, IComparable<PartialDate>, IEquatable<PartialDate>
{
    private static readonly char[] serSplitter = new char[] { '-' };
    /// <summary>
    /// Gets DateTime representation of release date.
    /// </summary>
    public readonly DateTime Date;

    /// <summary>
    /// Gets release day.
    /// </summary>
    public int? Day { get; private set; }
    /// <summary>
    /// Gets release month.
    /// </summary>
    public int? Month { get; private set; }
    /// <summary>
    /// Gets release year.
    /// </summary>
    public int Year { get; private set; }

    /// <summary>
    /// Creates new instance of <see cref="PartialDate"/>.
    /// </summary>
    /// <param name="year"></param>
    public PartialDate(int year)
    {
        if (year == default)
        {
            Year = default;
            Month = default;
            Day = default;
            Date = default;
        }
        else
        {
            Year = year;
            Day = null;
            Month = null;
            Date = new DateTime(year, 1, 1);
        }
    }

    /// <summary>
    /// Creates new instance of <see cref="PartialDate"/>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    public PartialDate(int year, int month)
    {
        Year = year;
        Month = month;
        Day = null;
        Date = new DateTime(year, month, 1);
    }

    /// <summary>
    /// Creates new instance of <see cref="PartialDate"/>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    public PartialDate(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
        Date = new DateTime(year, month, day);
    }

    /// <summary>
    /// Creates new instance of <see cref="PartialDate"/>.
    /// </summary>
    /// <param name="dateTime"></param>
    public PartialDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
    {
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is PartialDate date)
        {
            return CompareTo(date);
        }
        else
        {
            return 1;
        }
    }

    /// <inheritdoc/>
    public int CompareTo(PartialDate? other)
    {
        if (other is null)
        {
            return -1;
        }

        return Date.CompareTo(other.Date);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is PartialDate date)
        {
            return Equals(date);
        }
        else
        {
            return false;
        }
    }

    /// <inheritdoc/>
    public bool Equals(PartialDate? other)
    {
        if (other is null)
        {
            return false;
        }

        return Day == other.Day &&
            Month == other.Month &&
            Year == other.Year;
    }

    /// <inheritdoc/>
    public static bool operator ==(PartialDate obj1, PartialDate obj2)
    {
        return obj1.Equals(obj2);
    }

    /// <inheritdoc/>
    public static bool operator !=(PartialDate obj1, PartialDate obj2)
    {
        return !obj1.Equals(obj2);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Year, Month, Day);
    }

    /// <summary>
    /// Gets release date serialized to a string.
    /// </summary>
    /// <returns></returns>
    public string Serialize()
    {
        if (Day != null)
        {
            return $"{Year}-{Month}-{Day}";
        }
        else if (Month != null)
        {
            return $"{Year}-{Month}";
        }
        else
        {
            return Year.ToString();
        }
    }

    /// <summary>
    /// Try to deserialize string to a release date.
    /// </summary>
    /// <param name="stringDate"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool TryDeserialize(string stringDate, out PartialDate? date)
    {
        date = null;
        if (string.IsNullOrEmpty(stringDate))
        {
            return false;
        }

        var split = stringDate.Split(serSplitter);
        if (split.Length == 3)
        {
            if (DateTime.TryParseExact(stringDate, "yyyy-M-d", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                date = new PartialDate(parsedDate.Year, parsedDate.Month, parsedDate.Day);
                return true;
            }
        }
        else if (split.Length == 2)
        {
            if (DateTime.TryParseExact(stringDate, "yyyy-M", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                date = new PartialDate(parsedDate.Year, parsedDate.Month);
                return true;
            }
        }
        else if (split.Length == 1)
        {
            if (DateTime.TryParseExact(stringDate, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                date = new PartialDate(parsedDate.Year);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Deserialize string to release date.
    /// </summary>
    /// <param name="stringDate"></param>
    /// <returns></returns>
    public static PartialDate Deserialize(string stringDate)
    {
        if (string.IsNullOrEmpty(stringDate))
        {
            throw new ArgumentNullException(nameof(stringDate));
        }

        var split = stringDate.Split(serSplitter);
        if (split.Length == 3)
        {
            return new PartialDate(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }
        else if (split.Length == 2)
        {
            return new PartialDate(int.Parse(split[0]), int.Parse(split[1]));
        }
        else if (split.Length == 1)
        {
            return new PartialDate(int.Parse(split[0]));
        }
        else
        {
            throw new NotSupportedException("Uknown ReleaseDate string format.");
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        if (Day != null)
        {
            return Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
        }
        else if (Month != null)
        {
            return Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern);
        }
        else
        {
            return Year.ToString();
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public PartialDate GetCopy()
    {
        if (Day != null)
        {
            return new PartialDate(Year, Month!.Value, Day!.Value);
        }

        if (Month != null)
        {
            return new PartialDate(Year, Month.Value);
        }

        return new PartialDate(Year);
    }
}
