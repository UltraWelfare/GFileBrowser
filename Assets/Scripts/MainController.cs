using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace GFB {
    public class MainController {
        BrowserFile brf;
        BrowserDrive brd;
        UINavigator ui;

        public GameObject fb;
        GameObject fileScrollView, driveScrollView;

        public BrowserFile BRF { get { return BRF; } }

        public BrowserDrive BRD { get { return BRD; } }

        public UINavigator getUI { get { return ui; } }

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

            brf = new BrowserFile(fileScrollView.transform, GFileBrowser.Resources.basePrefab, this);
            brd = new BrowserDrive(driveScrollView.transform, GFileBrowser.Resources.basePrefab, this);
            ui = new UINavigator(fb, brf, brd);

            fb.transform.Find("DoneButton").GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, ui.onDone);
            fb.transform.Find("BackButton").GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, ui.onBack);
            fb.transform.Find("RedirectButton").GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, ui.onRedirect);
            if (GFileBrowser.IsMoveable) {
                fb.AddComponent<UIWindowMoveable>().setCanvas(parent);
                fb.GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, fb.GetComponent<UIWindowMoveable>().StartDragging);
                fb.GetComponent<UIClickListener>().AddUpListener(UIClickListener.Type.LeftClick, fb.GetComponent<UIWindowMoveable>().StopDragging);
            }
            fb.SetActive(false); // ShowDialog has not been called only init, so we need to hide the UI from the user.
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
