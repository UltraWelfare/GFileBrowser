using UnityEngine;
using System.Collections.Generic;
public class MainController
{
    Browser br;
    UINavigator ui;
    public GameObject fb;
    public GameObject fileScrollView;

    public MainController(GameObject parent)
    {
        fb = GameObject.Instantiate(GFileBrowser.Resources.fileBrowserPrefab, parent.transform, false);
        var fileScrollView = fb.transform.Find("FileScrollView").Find("Viewport").Find("Content").gameObject;
        fb.SetActive(false);
        ui = new UINavigator(fb);
        br = new Browser(fileScrollView.transform, ui);
        ui.InitCalls(br);
    }

    public void Show()
    {
        fb.SetActive(true);
        br.ReloadBrowser("D:/");
    }
}
