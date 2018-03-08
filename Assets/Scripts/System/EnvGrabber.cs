using System.IO;
using System.Collections.Generic;
using System;

public static class EnvGrabber {


    public static List<GBase> returnFiles(string path) {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetFiles(path), (string str) => { res.Add(new GFile(str.fixSlashes())); });
        return filter(res);
    }

    public static List<GBase> returnFolders(string path) {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetDirectories(path), (string str) => { res.Add(new GFolder(str.fixSlashes())); });
        return filter(res);
    }

    public static List<GBase> returnDrives() {
        List<GBase> res = new List<GBase>();
        Array.ForEach(Directory.GetLogicalDrives(), (string str) => { res.Add(new GDrive(str)); });
        return filter(res);
    }

    private static List<GBase> filter(List<GBase> list) {
        List<GBase> newList = new List<GBase>();
        
        list.ForEach(item => { newList.Add(item); });

        list.ForEach(item => {
            if(GFileBrowser.IgnoreList.Contains(item.Name)){
                newList.Remove(item);
            }
        });
        
        return newList;
    }
}
