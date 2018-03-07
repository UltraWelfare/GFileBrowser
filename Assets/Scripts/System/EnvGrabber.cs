using System.IO;
using System.Collections.Generic;

public static class EnvGrabber
{
    public static List<GBase> returnFiles(string path)
    {
        List<GBase> res = new List<GBase>();
            
        foreach(string f in Directory.GetFiles(path))
        {
            res.Add(new GFile(f));
        }
        return res;
    }

    public static List<GBase> returnFolders(string path)
    {
        List<GBase> res = new List<GBase>();

        foreach (string f in Directory.GetDirectories(path))
        {
            res.Add(new GFolder(f));
        }
        return res;
    }
}
