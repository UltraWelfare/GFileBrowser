using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Browser
{

    GameObject filep = GFileBrowser.Resources.filePrefab;
    GameObject folderp = GFileBrowser.Resources.folderPrefab;
    Transform fileScrollView;
    public Browser(Transform fileScrollView)
    {
        this.fileScrollView = fileScrollView;
    }

    public void reloadBrowser(string path)
    {
        List<GBase> files = EnvGrabber.returnFiles(path);
        List<GBase> folders = EnvGrabber.returnFolders(path);

        switch (GFileBrowser.FileOrder)
        {
            case GFileBrowser.Order.FirstFiles:
                inst(files);
                inst(folders);
                break;
            case GFileBrowser.Order.FirstFolders:
                inst(folders);
                inst(files);
                break;
        }
    }

    void inst(List<GBase> ls)
    {
        var newls = ls.OrderBy(item => item.Name).ToList();
        newls.ForEach(item =>
        {
            GameObject fp;
            if(item.GetType() == typeof(GFile)) { fp = filep; } else { fp = folderp; }

            GameObject f = GameObject.Instantiate(fp, fileScrollView.transform, false);
            if (!f.GetComponent<GComponent>()) { f.AddComponent<GComponent>(); }

            f.GetComponent<GComponent>().Load(item);
        });

    }
    void file(GFile file)
    {
        GameObject f = GameObject.Instantiate(filep, fileScrollView.transform, false);
        if (!f.GetComponent<GFileComponent>())
        {
            f.AddComponent<GFileComponent>();
        }
        f.GetComponent<GFileComponent>().Load(file);
    }

    void folder(GFolder folder)
    {
        GameObject f = GameObject.Instantiate(folderp, fileScrollView.transform, false);
        if (!f.GetComponent<GFolderComponent>())
        {
            f.AddComponent<GFolderComponent>();
        }
        f.GetComponent<GFolderComponent>().Load(folder);
    }
}
