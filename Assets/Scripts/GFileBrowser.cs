using UnityEngine;
public static class GFileBrowser
{
    

    static MainController Controller;

    public delegate void fileSelected(GFile file);

    static Order order = Order.FirstFolders;
    public static Order FileOrder { get { return order; } set { order = value; } }

    public static void Init(GameObject parent)
    {
        Resources.Load();
        Controller = new MainController(parent);
    }

    public static void ShowDialog()
    {
        Controller.Show();
    }

    public static void HideDialog()
    {
            
    }

    public enum Order {
        FirstFolders,
        FirstFiles
    }

    public static class Resources
    {
        public static GameObject fileBrowserPrefab;
        public static GameObject basePrefab;
        public static Texture2D fileSprite, folderSprite;
        public static void Load() {
            basePrefab = UnityEngine.Resources.Load("FileBrowser/BasePanel") as GameObject;
            fileBrowserPrefab = UnityEngine.Resources.Load("FileBrowser/FileBrowser") as GameObject;
            fileSprite = UnityEngine.Resources.Load("FileBrowser/file") as Texture2D;
            folderSprite = UnityEngine.Resources.Load("FileBrowser/folder") as Texture2D;
        }

    }
}


