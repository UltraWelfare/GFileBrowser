using System;
using System.Collections.Generic;
using UnityEngine;

public class BrowserFile : Browser {
    public BrowserFile(Transform contentView, GameObject prefab, UINavigator ui) : base(contentView, prefab, ui) { }

    public GBase CurrentSelectedFile;

    List<string> stack = new List<string>();

    /// <summary>
    /// Keeps a list of the components that are currently alive.
    /// </summary>
    public List<GComponent> components = new List<GComponent>();

    public override void Reload() {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Reloads the file content view.
    /// You can optionally pass if you want to add the current navigated path to the stack.
    /// </summary>
    public override void Reload(string path, bool addToStack) {
        try {
            List<GBase> files = EnvGrabber.returnFiles(path);
            List<GBase> folders = EnvGrabber.returnFolders(path);
            if(addToStack) { stack.Add(path); }
            ui.UpdatePathField(path);
            CurrentSelectedFile = null;
            Clear((item) => { components.Remove(item.GetComponent<GComponent>()); });
            switch (GFileBrowser.FileOrder) {
                case GFileBrowser.Order.FirstFiles:
                    inst(files, addToComponents);
                    inst(folders, addToComponents);
                    break;
                case GFileBrowser.Order.FirstFolders:
                    inst(folders, addToComponents);
                    inst(files, addToComponents);
                    break;
            }
            recalculateContentSize(files.Count + folders.Count);
        } catch (Exception e) {
            ui.DisplayError(e);
        }
    }

    /// <summary>
    /// Goes back in the stack (redirects to the previous folder).
    /// </summary>
    public void GoBack() {
        if (stack.Count < 2) {
            return;
        }
        Reload(stack[stack.Count - 2], false);
        stack.RemoveAt(stack.Count - 1);
    }


    void addToComponents(GBase b, GameObject go) {
        components.Add(go.GetComponent<GComponent>());
        go.GetComponent<GComponent>().Load(b, ui);
    }
}