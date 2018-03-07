using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public static class EnvGrabber
{

    public static List<string> returnFiles(string path)
    {
        List<string> res = new List<string>();
            
        foreach(string f in Directory.GetFiles(path))
        {
            res.Add(f);
        }
        return res;
    }

    public static List<string> returnFolders(string path)
    {
        List<string> res = new List<string>();

        foreach (string f in Directory.GetDirectories(path))
        {
            res.Add(f);
        }
        return res;
    }
}
