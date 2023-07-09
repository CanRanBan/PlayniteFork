﻿using Playnite;
using System.ComponentModel;

namespace System;

public static class EnumExtensions
{
    public static int GetMax(this Enum source)
    {
        return Enum.GetValues(source.GetType()).Cast<int>().Max();
    }
    public static int GetMin(this Enum source)
    {
        return Enum.GetValues(source.GetType()).Cast<int>().Min();
    }

    public static string GetDescription(this Enum source)
    {
        var field = source.GetType().GetField(source.ToString());
        if (field is null)
        {
            return string.Empty;
        }

        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            var desc = attributes[0].Description;
            if (Loc.IsStringId(desc))
            {
                return Loc.GetString(desc);
            }
            else
            {
                return desc;
            }
        }
        else
        {
            return source.ToString();
        }
    }
}
