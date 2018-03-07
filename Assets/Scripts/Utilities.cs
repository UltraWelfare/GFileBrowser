using System.Linq;
using System.Collections.Generic;

public static class Utilities
{
    public static string splitNamePath(string path)
    {
        int pos;
        if(path.Contains("\\")){
            pos = path.LastIndexOf("\\") + 1;
        } else {
            pos = path.LastIndexOf("/") + 1;
        }
        return path.Substring(pos, path.Length - pos); 
    }

    public static List<string> orderAlphabetically(this List<string> ls)
    {
        return ls.OrderBy(str => str).ToList();
    }
   
}

