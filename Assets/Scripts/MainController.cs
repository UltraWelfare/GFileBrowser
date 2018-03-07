using UnityEngine;
using System.Collections.Generic;
public class MainController
{
    Browser br;
    public GameObject fb;
    public GameObject fileScrollView;

    public MainController(GameObject parent)
    {
        fb = GameObject.Instantiate(GFileBrowser.Resources.fileBrowserPrefab, parent.transform, false);
        var fileScrollView = fb.transform.Find("FileScrollView").Find("Viewport").Find("Content").gameObject;
        fb.SetActive(false);

        br = new Browser(fileScrollView.transform);
    }

    public void Show()
    {
        fb.SetActive(true);
        br.reloadBrowser("D:/");
    }
}
