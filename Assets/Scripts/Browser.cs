using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Browser
{
    Transform fileScrollView;
    UINavigator ui;
    List<string> stack = new List<string>();
    public List<GComponent> components = new List<GComponent>();
    public GBase CurrentSelectedFile;
    public Browser(Transform fileScrollView, UINavigator ui) {
        this.fileScrollView = fileScrollView;
        this.ui = ui;
    }

    public void GoBack(){
        if(stack.Count < 2){
            return;
        }
        ReloadBrowser(stack[stack.Count - 2], false);
        stack.RemoveAt(stack.Count - 1);
    }
    public void ReloadBrowser(string path, bool addToStack = true) {
        
        try {
            List<GBase> files = EnvGrabber.returnFiles(path);
			List<GBase> folders = EnvGrabber.returnFolders(path);
			if(addToStack) { stack.Add(path); }
        	ui.UpdatePathField(path);
        	CurrentSelectedFile = null;
        	ClearBrowser();
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
			var rt = fileScrollView.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, Utilities.calculateHeight(files.Count + folders.Count));
        } catch (Exception e){
			ui.displayError(e.ToString());
		}
        
    }

    public void ClearBrowser()
    {
        for(int i = 0; i < fileScrollView.childCount; i++){
            Transform item = fileScrollView.GetChild(i);
            components.Remove(item.GetComponent<GComponent>());
            UnityEngine.GameObject.Destroy(item.gameObject);
        }
    }

    void inst(List<GBase> ls) {
        var newls = ls.OrderBy(item => item.Name).ToList();
        newls.ForEach(item =>
        {
            GameObject f = GameObject.Instantiate(GFileBrowser.Resources.basePrefab, fileScrollView.transform, false);
            GComponent.Type t;
            if(item.GetType() == typeof(GFile)) {t = GComponent.Type.File; } else { t = GComponent.Type.Folder; } 
            f.GetComponent<GComponent>().Load(item, t, ui);
            components.Add(f.GetComponent<GComponent>());
            
        });

    }
}
