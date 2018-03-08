using System;
using System.Collections.Generic;
using UnityEngine;
public static class GFileBrowser {

    static MainController Controller;

    public static Action<GBase> onFileSelected;

    static Order order = Order.FirstFolders;
    public static Order FileOrder { get { return order; } set { order = value; } }

    static List<string> ignoreList = new List<string>()
    { "hiberfil.sys", "System Volume Information", "Recovery", "ProgramData", "bootmgr", "BOOTNXT",
      "BOOTSECT.BAK", "Boot", "pagefile.sys", "setup.log", "swapfile.sys", "$RECYCLE.BIN" };
    public static List<string> IgnoreList { get { return ignoreList; } }

    public static void Init(GameObject parent) {
        Resources.Load();
        Controller = new MainController(parent);
    }

    public static void AddToIgnore(string Name) {
        ignoreList.Add(Name);
    }
    
    public static void Navigate(string Path) {
        Controller.CBrowser.ReloadFileBrowser(Path);
    }

    public static void ShowDialog(string Path) {
        Controller.Show(Path);
    }

    public static void HideDialog() {
        Controller.Hide();
    }

    public enum Order {
        FirstFolders,
        FirstFiles
    }

    public static class Resources {
        public static GameObject fileBrowserPrefab;
        public static GameObject basePrefab;
        public static Texture2D fileTexture, folderTexture, driveTexture;
        public static void Load() {
            basePrefab = UnityEngine.Resources.Load("FileBrowser/BasePanel") as GameObject;
            fileBrowserPrefab = UnityEngine.Resources.Load("FileBrowser/FileBrowser") as GameObject;
            fileTexture = UnityEngine.Resources.Load("FileBrowser/file") as Texture2D;
            folderTexture = UnityEngine.Resources.Load("FileBrowser/folder") as Texture2D;
            driveTexture = UnityEngine.Resources.Load("FileBrowser/drive") as Texture2D;
        }

    }
}


