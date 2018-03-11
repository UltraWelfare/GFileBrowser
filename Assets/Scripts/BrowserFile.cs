using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GFB {
    public class BrowserFile : Browser {
        public BrowserFile(Transform contentView, GameObject prefab, MainController controller) : base(contentView, prefab, controller) { }

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
        public void Reload(string path, bool addToStack) {
            try {
                List<GBase> files = SystemCalls.returnFiles(path);
                List<GBase> folders = SystemCalls.returnFolders(path);
                if (addToStack && !(stack.Exists((String str) => { return str.Equals(path); }))) {
                    stack.Add(path);
                }
                controller.getUI.UpdatePathField(path);
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
                controller.getUI.DisplayError(e);
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
            GComponent com = go.GetComponent<GComponent>();
            components.Add(com);
            com.Load(b);
            if (com.Type == typeof(GFile)) {
                go.GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, () => {
                    controller.getUI.onFileLeftClicked(com);
                });
            } else if (com.Type == typeof(GFolder)) {
                go.GetComponent<UIClickListener>().AddDownListener(UIClickListener.Type.LeftClick, () => {
                    controller.getUI.onFolderLeftClicked(com);
                });
            }
        }
    }
}