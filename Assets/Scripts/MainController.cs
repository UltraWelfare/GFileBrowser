using UnityEngine;
using System.Collections.Generic;
public class MainController {
    Browser br;

    UINavigator ui;
    public GameObject fb;
    GameObject fileScrollView, driveScrollView;
    public Browser CBrowser { get { return br; } }

    public MainController(GameObject parent) {
        fb = GameObject.Instantiate(GFileBrowser.Resources.fileBrowserPrefab, parent.transform, false);
        fileScrollView = fb.transform.Find("FileScrollView").Find("Viewport").Find("Content").gameObject;
        driveScrollView = fb.transform.Find("DriveScrollView").Find("Viewport").Find("Content").gameObject;
        fb.SetActive(false);
        ui = new UINavigator(fb);
        br = new Browser(fileScrollView.transform, driveScrollView.transform, ui);
        ui.InitCalls(br);
    }

    public void Show(string rootToShow) {
        fb.SetActive(true);
        br.ReloadFileBrowser(rootToShow);
        br.ReloadDriveBrowser();
    }

    public void Hide() {
        fb.SetActive(false);
    }
}
