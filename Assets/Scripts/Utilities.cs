﻿using System.Linq;
using System.Collections.Generic;

public static class Utilities
{
    public static readonly float panelHeight = 35.9f;
    public static readonly float spacingY = 2.03f;

    public static float calculateHeight(int count) {
        return (panelHeight + spacingY) * count +  2 * spacingY;
    }
    public static string splitNamePath(string path) {
        int pos;
        if(path.Contains("\\")){
            pos = path.LastIndexOf("\\") + 1;
        } else {
            pos = path.LastIndexOf("/") + 1;
        }
        return path.Substring(pos, path.Length - pos); 
    }

    public static List<string> orderAlphabetically(this List<string> ls) {
        return ls.OrderBy(str => str).ToList();
    }
   
}

