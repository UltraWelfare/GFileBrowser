using System;
using System.Collections.Generic;
using UnityEngine;
public static class GFileBrowser {

    static MainController Controller;

    /// <summary>
    /// is called when a file is selected and the user hits 'Done'. Returns the file selected
    /// </summary>
    public static Action<GBase> onFileSelected;

    static Order order = Order.FirstFolders;

    /// <summary>
    /// Specifies the order in which the folders-files should appear in the browser.
    /// </summary>
    public static Order FileOrder { get { return order; } set { order = value; } }

    static List<string> ignoreList = new List<string>()
    { "hiberfil.sys", "System Volume Information", "Recovery", "ProgramData", "bootmgr", "BOOTNXT",
      "BOOTSECT.BAK", "Boot", "pagefile.sys", "setup.log", "swapfile.sys", "$RECYCLE.BIN", "Documents and Settings" };
    public static List<string> IgnoreList { get { return ignoreList; } }
    
    /// <summary>
    /// First function to call in order to init the GFileBrowser.
    /// </summary>
    public static void Init(GameObject parent) {
        Resources.Load();
        Controller = new MainController(parent);
    }

    /// <summary>
    /// Adds to ignore list, so these folders-files don't display in the browser
    /// </summary>
    public static void AddToIgnore(string Name) {
        ignoreList.Add(Name);
    }

    /// <summary>
    /// Navigates the browser to a path
    /// </summary>
    public static void Navigate(string Path) {
        Controller.BRF.Reload(Path);
    }

    /// <summary>
    /// Shows the dialog to the user
    /// </summary>
    public static void ShowDialog(string Path) {
        Controller.Show(Path);
    }

    /// <summary>
    /// Hides the dialog from the user
    /// </summary>
    public static void HideDialog() {
        Controller.Hide();
    }

    public enum Order {
        FirstFolders,
        FirstFiles
    }

    /// <summary>
    /// Class responsible for holding the resources(textures, prefabs) of the file browser.
    /// </summary>
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


