using UnityEngine;
using System.Collections.Generic;

public class MainController {
    Browser br;

    UINavigator ui;
    public GameObject fb;
    GameObject fileScrollView, driveScrollView;
    public Browser CBrowser { get { return br; } }

    /// <summary>
    /// The main controller holds the following classes :
    /// - UINavigator, responsible for the ui
    /// - Browser, responsible for filling the scroll-view contents
    ///
    /// and some GameObjects (FileBrowser, FileScrollView, DriveScrollView)
    /// ------------------------------------------------------------
    /// Constructor takes a GameObject parent, which is used to instantiate the file browser (Preferrably the Canvas).
    /// </summary>
    public MainController(GameObject parent) {
        fb = GameObject.Instantiate(GFileBrowser.Resources.fileBrowserPrefab, parent.transform, false);
        fileScrollView = fb.transform.Find("FileScrollView").Find("Viewport").Find("Content").gameObject;
        driveScrollView = fb.transform.Find("DriveScrollView").Find("Viewport").Find("Content").gameObject;
        fb.SetActive(false); // ShowDialog has not been called only init, so we need to hide the UI from the user.
        ui = new UINavigator(fb);
        br = new Browser(fileScrollView.transform, driveScrollView.transform, ui);
        ui.PassBrowser(br); // We need to pass the browser afterwars because ui needs to call specific parts of the Browser.
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
