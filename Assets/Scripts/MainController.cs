using UnityEngine;
using System.Collections.Generic;
public class MainController
{
    Instantiator inst;
        
    public void Wake(GameObject g)
    {
        inst = new Instantiator(g);
    }

    public void Show()
    {
        inst.fb.SetActive(true);
        reloadBrowser("F:/");
    }

    public void reloadBrowser(string path)
    {
        List<string> files = EnvGrabber.returnFiles(path);
        List<string> folders = EnvGrabber.returnFolders(path);

        foreach(string f in files)
        {
            inst.File(new GFile(f));
        }

        foreach (string f in folders)
        {
            inst.Folder(new GFolder(f));
        }
    }
}
