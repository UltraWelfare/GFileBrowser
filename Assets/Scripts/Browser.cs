using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Browser
{

    Transform fileScrollView;
    public Browser(Transform fileScrollView) {
        this.fileScrollView = fileScrollView;
    }

    public void reloadBrowser(string path) {
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

    void inst(List<GBase> ls) {
        var newls = ls.OrderBy(item => item.Name).ToList();
        newls.ForEach(item =>
        {
            GameObject f = GameObject.Instantiate(GFileBrowser.Resources.basePrefab, fileScrollView.transform, false);
            GComponent.Type t;
            if(item.GetType() == typeof(GFile)) {t = GComponent.Type.File; } else { t = GComponent.Type.Folder; } 
            f.GetComponent<GComponent>().Load(item, t);
            
        });

    }
}
