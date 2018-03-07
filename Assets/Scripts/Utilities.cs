using UnityEngine;
using System.Collections;

public static class Utilities
{
    public static string splitNamePath(string path)
    {
        int pos = path.LastIndexOf("/") + 1;

        return path.Substring(pos, path.Length - pos); 
    }
}

