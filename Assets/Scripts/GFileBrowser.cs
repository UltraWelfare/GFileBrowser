using UnityEngine;
public static class GFileBrowser
{
    static MainController Controller;
    public delegate void fileSelected(GFile file);

    public static void Init(GameObject parent)
    {
        Resources.Load();
        Controller = new MainController();
        Controller.Wake(parent);
    }

    public static void ShowDialog()
    {
        Controller.Show();
    }

    public static void HideDialog()
    {
            
    }
}


static class Resources
{
    public static GameObject fileBrowserPrefab;
    public static GameObject folderPrefab, filePrefab;

    public static void Load()
    {
        filePrefab = UnityEngine.Resources.Load("FileBrowser/FilePanel") as GameObject;
        folderPrefab = UnityEngine.Resources.Load("FileBrowser/FolderPanel") as GameObject;
        fileBrowserPrefab = UnityEngine.Resources.Load("FileBrowser/FileBrowser") as GameObject;
    }

}