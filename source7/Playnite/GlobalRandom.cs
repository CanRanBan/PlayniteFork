namespace Playnite;

public class GlobalRandom
{
    public static readonly Random Generator = new Random();
    private static readonly string randomStringChars = "ABCDEFGHIJKLMNOPQRSTYVWXZabcdefghijklmnopqrstyvwxz0123456789";

    public static int Next()
    {
        return Generator.Next();
    }

    public static int Next(int minValue, int maxValue)
    {
        return Generator.Next(minValue, maxValue);
    }

    public static int Next(int maxValue)
    {
        return Generator.Next(maxValue);
    }

    public static void NextBytes(byte[] buffer)
    {
        Generator.NextBytes(buffer);
    }

    public static double NextDouble()
    {
        return Generator.NextDouble();
    }

    public static DateTime GetRandomDateTime()
    {
        var startDate = new DateTime(1970, 1, 1);
        int range = (DateTime.Today - startDate).Days;
        return startDate.AddDays(Next(range));
    }

    public static string GetRandomString(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("0 is not a valid length");
        }

        var randomSetLeng = randomStringChars.Length - 1;
        var result = new StringBuilder(length);
        lock (Generator)
        {
            for (int i = 0; i < length; i++)
            {
                result.Append(randomStringChars[Generator.Next(0, randomSetLeng)]);
            }

            return result.ToString();
        }
    }
}
