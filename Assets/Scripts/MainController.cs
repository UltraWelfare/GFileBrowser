using UnityEngine;
using System.Collections.Generic;

namespace GFB {
    public class MainController {
        BrowserFile brf;
        BrowserDrive brd;

        UINavigator ui;
        public GameObject fb;
        GameObject fileScrollView, driveScrollView;

        public BrowserFile BRF { get { return BRF; } }

        public BrowserDrive BRD { get { return BRD; } }

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
            brf = new BrowserFile(fileScrollView.transform, GFileBrowser.Resources.basePrefab, ui);
            brd = new BrowserDrive(driveScrollView.transform, GFileBrowser.Resources.basePrefab, ui);
            ui.PassBrowser(brf, brd); // We need to pass the browser afterwars because ui needs to call specific parts of the Browser.
        }

        public void Show(string rootToShow) {
            fb.SetActive(true);
            brf.Reload(rootToShow, true);
            brd.Reload();
        }

        public void Hide() {
            fb.SetActive(false);
        }
    }
}
