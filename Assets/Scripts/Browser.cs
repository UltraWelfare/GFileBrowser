using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Browser {
    Transform fileScrollView, driveScrollView;
    UINavigator ui;
    List<string> stack = new List<string>();
    public List<GComponent> components = new List<GComponent>();
    public GBase CurrentSelectedFile;

    public Browser(Transform fileScrollView, Transform driveScrollView, UINavigator ui) {
        this.fileScrollView = fileScrollView;
        this.driveScrollView = driveScrollView;
        this.ui = ui;
    }

    public void ReloadDriveBrowser() {
        try {
            List<GBase> drives = EnvGrabber.returnDrives();
            ClearBrowser(driveScrollView);
            inst(drives, driveScrollView);
            var rt = driveScrollView.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, Utilities.calculateHeight(drives.Count));
        } catch (Exception e) {
            ui.DisplayError(e);
        }
    }

    public void ReloadFileBrowser(string path, bool addToStack = true) {
        try {
            List<GBase> files = EnvGrabber.returnFiles(path);
            List<GBase> folders = EnvGrabber.returnFolders(path);
            if (addToStack) { stack.Add(path); }
            ui.UpdatePathField(path);
            CurrentSelectedFile = null;
            ClearBrowser(fileScrollView);
            switch (GFileBrowser.FileOrder) {
                case GFileBrowser.Order.FirstFiles:
                    inst(files, fileScrollView);
                    inst(folders, fileScrollView);
                    break;
                case GFileBrowser.Order.FirstFolders:
                    inst(folders, fileScrollView);
                    inst(files, fileScrollView);
                    break;
            }
            var rt = fileScrollView.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, Utilities.calculateHeight(files.Count + folders.Count));
        } catch (Exception e) {
            ui.DisplayError(e);
        }

    }

    public void GoBack() {
        if (stack.Count < 2) {
            return;
        }
        ReloadFileBrowser(stack[stack.Count - 2], false);
        stack.RemoveAt(stack.Count - 1);
    }

    public void ClearBrowser(Transform root) {
        for (int i = 0; i < root.childCount; i++) {
            Transform item = root.GetChild(i);
            components.Remove(item.GetComponent<GComponent>());
            UnityEngine.GameObject.Destroy(item.gameObject);
        }
    }

    void inst(List<GBase> ls, Transform root) {
        var newls = ls.OrderBy(item => item.Name).ToList();
        newls.ForEach(item => {
            GameObject f = GameObject.Instantiate(GFileBrowser.Resources.basePrefab, root, false);
            f.GetComponent<GComponent>().Load(item, ui);
            components.Add(f.GetComponent<GComponent>());

        });
    }
}
