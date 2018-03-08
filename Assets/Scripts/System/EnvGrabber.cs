using System.IO;
using System.Collections.Generic;
using System;

public static class EnvGrabber {

    /// <summary>
    /// Returns a List of GBase(type of File) in the parameter path
    /// </summary>
    public static List<GBase> returnFiles(string path) {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetFiles(path), (string str) => { res.Add(new GFile(str.fixSlashes())); });
        return filter(res);
    }

    /// <summary>
    /// Returns a List of GBase(type of Folder) in the parameter path
    /// </summary>
    public static List<GBase> returnFolders(string path) {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetDirectories(path), (string str) => { res.Add(new GFolder(str.fixSlashes())); });
        return filter(res);
    }

    /// <summary>
    /// Returns a List of GBase(type of Drive)
    /// </summary>
    public static List<GBase> returnDrives() {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetLogicalDrives(), (string str) => { res.Add(new GDrive(str)); });
        return filter(res);
    }

    /// <summary>
    /// Filters out from a GBase List, the ignored files-folders from the static class GFileBrowser 
    /// </summary>
    private static List<GBase> filter(List<GBase> list) {
        List<GBase> newList = new List<GBase>();

        list.ForEach(item => { newList.Add(item); });

        list.ForEach(item => {
            if (GFileBrowser.IgnoreList.Contains(item.Name)) {
                newList.Remove(item);
            }
        });

        return newList;
    }
}
