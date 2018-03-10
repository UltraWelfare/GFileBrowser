using System.Linq;
using System.Collections.Generic;
using System;

public static class Utilities {
    public static readonly float panelHeight = 35.9f;
    public static readonly float spacingY = 2.03f;

    /// <summary>
    /// Used to calculate the height of the scrollview depending on the prefab measurements.
    /// </summary>
    public static float calculateHeight(int count) {
        return (panelHeight + spacingY) * count;
    }

    /// <summary>
    /// Given a filepath it will return the name of the file.
    /// </summary>
    public static string splitNamePath(string path) {
        int pos = path.LastIndexOf("/") + 1;
        return path.Substring(pos, path.Length - pos);
    }

    /// <summary>
    /// Orders alphabetically a list of strings
    /// </summary>
    public static List<string> orderAlphabetically(this List<string> ls) {
        return ls.OrderBy(str => str).ToList();
    }

    /// <summary>
    /// Replaces all backslashes with frontslashes.
    /// </summary>
    public static string fixSlashes(this string str) {
        return str.Replace("\\", "/");
    }
}

